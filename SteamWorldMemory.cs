using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using LiveSplit.Memory;
namespace LiveSplit.SteamWorldDig {
	public partial class SteamWorldMemory {
		public Process Program { get; set; }
		public bool IsHooked { get; set; } = false;
		private DateTime lastHooked;

		public SteamWorldMemory() {
			lastHooked = DateTime.MinValue;
		}

		public int GameState() {
			return Program.Read<int>(Program.MainModule.BaseAddress, 0x2BE5C8);
		}
		public int EndState() {
			return Program.Read<byte>(Program.MainModule.BaseAddress, 0x2BE5BC, 0x60, 0x20, 0x5c0);
		}
		public uint BackgroundColor() {
			int flag = GameState();
			if (flag > 2) {
				return (uint)Program.Read<int>(Program.MainModule.BaseAddress, 0x2BE5BC, 0x60, 0x20, 0x5ac);
			}
			return 0;
		}
		public uint ForegroundColor() {
			int flag = GameState();
			if (flag > 2) {
				return (uint)Program.Read<int>(Program.MainModule.BaseAddress, 0x2BE5BC, 0x60, 0x20, 0x5a4);
			}
			return 0;
		}
		public int GoldCurrent() {
			int flag = GameState();
			if (flag > 2) {
				return Program.Read<int>(Program.MainModule.BaseAddress, 0x2BE5BC, 0x60, 0x20, 0x4E0);
			}
			return 0;
		}
		public int GoldTotal() {
			int flag = GameState();
			if (flag > 2) {
				return Program.Read<int>(Program.MainModule.BaseAddress, 0x2BE5BC, 0x60, 0x20, 0x340);
			}
			return 0;
		}
		public int OrbsCurrent() {
			int flag = GameState();
			if (flag > 2) {
				return Program.Read<int>(Program.MainModule.BaseAddress, 0x2BE5BC, 0x60, 0x20, 0x4E4);
			}
			return 0;
		}
		public int OrbsTotal() {
			int flag = GameState();
			if (flag > 2) {
				int saveIndex = Program.Read<int>(Program.MainModule.BaseAddress, 0x2BE5BC, 0x60, 0x0, 0x54, 0x60);
				return Program.Read<int>(Program.MainModule.BaseAddress, 0x2BE5BC, 0x60, 0x0, 0x54, 0x18 + 0x20 * saveIndex);
			}
			return 0;
		}
		public int Deaths() {
			int flag = GameState();
			if (flag > 2) {
				int saveIndex = Program.Read<int>(Program.MainModule.BaseAddress, 0x2BE5BC, 0x60, 0x0, 0x54, 0x60);
				return Program.Read<int>(Program.MainModule.BaseAddress, 0x2BE5BC, 0x60, 0x0, 0x54, 0x1c + 0x20 * saveIndex);
			}
			return 0;
		}
		public double GameTime() {
			int flag = GameState();
			if (flag > 2) {
				int saveIndex = Program.Read<int>(Program.MainModule.BaseAddress, 0x2BE5BC, 0x60, 0x0, 0x54, 0x60);
				return Program.Read<double>(Program.MainModule.BaseAddress, 0x2BE5BC, 0x60, 0x0, 0x54, 0x8 + 0x20 * saveIndex);
			}
			return 0;
		}
		public PointF Position() {
			int flag = GameState();
			if (flag > 2) {
				float px = Program.Read<float>(Program.MainModule.BaseAddress, 0x2BE5BC, 0x60, 0x20, 0x4BC);
				float py = Program.Read<float>(Program.MainModule.BaseAddress, 0x2BE5BC, 0x60, 0x20, 0x4C0);
				return new PointF(px, py);
			}
			return PointF.Empty;
		}
		public string AquiredFlags() {
			int flag = GameState();
			if (flag > 2) {
				StringBuilder sb = new StringBuilder();
				List<string> flags = new List<string>();
				int capacity = Program.Read<int>(Program.MainModule.BaseAddress, 0x2BE5BC, 0x60, 0x20, 0x4EC);
				IntPtr start = (IntPtr)Program.Read<int>(Program.MainModule.BaseAddress, 0x2BE5BC, 0x60, 0x20, 0x4E8, 0x4 * capacity);
				do {
					int length = Program.Read<int>(start - 0x10);
					string currentFlag = string.Empty;
					if (length >= 16) {
						currentFlag = Program.ReadAscii((IntPtr)Program.Read<int>(start - 0x20));
					} else {
						currentFlag = Program.ReadAscii(start - 0x20);
					}
					if (!string.IsNullOrEmpty(currentFlag)) {
						flags.Add(currentFlag);
					}
					start = (IntPtr)Program.Read<int>(start);
				} while (start != IntPtr.Zero);

				flags.Sort(delegate (string s1, string s2) {
					return s1.CompareTo(s2);
				});
				for (int i = 0; i < flags.Count; i++) {
					sb.Append(flags[i]).Append(',');
				}
				if (sb.Length > 0) {
					sb.Length--;
				}
				return sb.ToString();
			}
			return string.Empty;
		}
		public HashSet<string> AquiredFlagsHash() {
			int flag = GameState();
			HashSet<string> flags = new HashSet<string>();
			if (flag > 2) {
				int capacity = Program.Read<int>(Program.MainModule.BaseAddress, 0x2BE5BC, 0x60, 0x20, 0x4EC);
				IntPtr start = (IntPtr)Program.Read<int>(Program.MainModule.BaseAddress, 0x2BE5BC, 0x60, 0x20, 0x4E8, 0x4 * capacity);
				do {
					int length = Program.Read<int>(start - 0x10);
					string currentFlag = string.Empty;
					if (length >= 16) {
						currentFlag = Program.ReadAscii((IntPtr)Program.Read<int>(start - 0x20));
					} else {
						currentFlag = Program.ReadAscii(start - 0x20);
					}
					if (!string.IsNullOrEmpty(currentFlag)) {
						flags.Add(currentFlag);
					}
					start = (IntPtr)Program.Read<int>(start);
				} while (start != IntPtr.Zero);
			}
			return flags;
		}
		public bool HookProcess() {
			if ((Program == null || Program.HasExited) && DateTime.Now > lastHooked.AddSeconds(1)) {
				lastHooked = DateTime.Now;
				Process[] processes = Process.GetProcessesByName("SteamWorldDig");
				Program = processes.Length == 0 ? null : processes[0];
				IsHooked = true;
			}

			if (Program == null || Program.HasExited) {
				IsHooked = false;
			}

			return IsHooked;
		}
		public void Dispose() {
			if (Program != null) {
				Program.Dispose();
			}
		}
	}
}