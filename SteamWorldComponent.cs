using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
namespace LiveSplit.SteamWorldDig {
	public class SteamWorldComponent : IComponent {
		public string ComponentName { get { return "SteamWorld Dig Autosplitter"; } }
		public TimerModel Model { get; set; }
		public IDictionary<string, Action> ContextMenuControls { get { return null; } }
		internal static string[] keys = { "CurrentSplit", "State", "GameState", "Aquirements", "OrbsTotal", "GoldTotal", "Deaths", "GameTime", "BGColor", "FGColor" };
		private SteamWorldMemory mem;
		private int currentSplit = -1, state = 0, lastLogCheck = 0, lastGameState = 0;
		private uint lastColor = 0;
		private bool hasLog = false;
		private Dictionary<string, string> currentValues = new Dictionary<string, string>();
		private SteamWorldSettings settings;
		private HashSet<string> currentAquirements = new HashSet<string>();
		private static string LOGFILE = "_SteamWorld.log";

		public SteamWorldComponent() {
			mem = new SteamWorldMemory();
			settings = new SteamWorldSettings();
			foreach (string key in keys) {
				currentValues[key] = "";
			}
		}

		public void GetValues() {
			if (!mem.HookProcess()) { return; }

			if (Model != null) {
				HandleSplits();
			}

			LogValues();
		}
		private void HandleSplits() {
			bool shouldSplit = false;

			int gameState = mem.GameState();
			if (currentSplit == -1 && (int)mem.GameTime() == 0) {
				shouldSplit = lastGameState == 1 && (gameState == 2 || gameState == 3);
			} else if (Model.CurrentState.CurrentPhase == TimerPhase.Running) {
				if (currentSplit + 1 < Model.CurrentState.Run.Count) {
					HashSet<string> aquirements = mem.AquiredFlagsHash();
					if (settings.Pickaxe && !currentAquirements.Contains("pickaxe_pre") && aquirements.Contains("pickaxe_pre")) {
						shouldSplit = true;
						currentAquirements.Add("pickaxe_pre");
					} else if (settings.SpeedBoots && !currentAquirements.Contains("enable_run") && aquirements.Contains("enable_run")) {
						shouldSplit = true;
						currentAquirements.Add("enable_run");
					} else if (settings.SteamJump && !currentAquirements.Contains("enable_charge_jump") && aquirements.Contains("enable_charge_jump")) {
						shouldSplit = true;
						currentAquirements.Add("enable_charge_jump");
					} else if (settings.Drill && !currentAquirements.Contains("drill") && aquirements.Contains("drill")) {
						shouldSplit = true;
						currentAquirements.Add("drill");
					} else if (settings.OldWorld && !currentAquirements.Contains("reached_old_world") && aquirements.Contains("reached_old_world")) {
						shouldSplit = true;
						currentAquirements.Add("reached_old_world");
					} else if (settings.Generator1 && !currentAquirements.Contains("disable_barrier_boss3") && aquirements.Contains("disable_barrier_boss3")) {
						shouldSplit = true;
						currentAquirements.Add("disable_barrier_boss3");
					} else if (settings.Biff && !currentAquirements.Contains("experience_shop_1") && aquirements.Contains("experience_shop_1")) {
						shouldSplit = true;
						currentAquirements.Add("experience_shop_1");
					} else if (settings.SteamPunch && !currentAquirements.Contains("punch") && aquirements.Contains("punch")) {
						shouldSplit = true;
						currentAquirements.Add("punch");
					} else if (settings.Generator2 && !currentAquirements.Contains("disable_barrier_boss2") && aquirements.Contains("disable_barrier_boss2")) {
						shouldSplit = true;
						currentAquirements.Add("disable_barrier_boss2");
					} else if (settings.Vectron && !currentAquirements.Contains("reached_vectron") && aquirements.Contains("reached_vectron")) {
						shouldSplit = true;
						currentAquirements.Add("reached_vectron");
					} else if (settings.StaticDash && !currentAquirements.Contains("enable_jump_double") && aquirements.Contains("enable_jump_double")) {
						shouldSplit = true;
						currentAquirements.Add("enable_jump_double");
					} else if (settings.MineralDetector && !currentAquirements.Contains("minimap_resources") && aquirements.Contains("minimap_resources")) {
						shouldSplit = true;
						currentAquirements.Add("minimap_resources");
					} else if (settings.Generator3 && !currentAquirements.Contains("disable_barrier_boss1") && aquirements.Contains("disable_barrier_boss1")) {
						shouldSplit = true;
						currentAquirements.Add("disable_barrier_boss1");
					} else if (settings.FallDampeners && !currentAquirements.Contains("fall_dampeners") && aquirements.Contains("fall_dampeners")) {
						shouldSplit = true;
						currentAquirements.Add("fall_dampeners");
					} else if (settings.Dandy && !currentAquirements.Contains("experience_shop_2") && aquirements.Contains("experience_shop_2")) {
						shouldSplit = true;
						currentAquirements.Add("experience_shop_2");
					} else if (settings.Gold20K && !currentAquirements.Contains("Gold20K") && mem.GoldTotal() >= 20000) {
						shouldSplit = true;
						currentAquirements.Add("Gold20K");
					} else if (settings.Orbs150 && !currentAquirements.Contains("Orbs150") && mem.OrbsTotal() >= 150) {
						shouldSplit = true;
						currentAquirements.Add("Orbs150");
					}
				} else if (state == 0) {
					uint color = mem.BackgroundColor();

					if (lastColor == 0xFF2D2DFF && color == 0xFF282828) {
						state++;
					}

					lastColor = color;
				} else {
					shouldSplit = mem.EndState() == 0;
				}
			}

			lastGameState = gameState;
			HandleSplit(shouldSplit, gameState == 1 && settings.AutoReset);
		}
		private void HandleGameTimes() {
			if (currentSplit >= 0 && currentSplit <= Model.CurrentState.Run.Count) {
				TimeSpan gameTime = TimeSpan.FromSeconds(mem.GameTime());
				if (currentSplit == Model.CurrentState.Run.Count) {
					Time t = Model.CurrentState.Run[currentSplit - 1].SplitTime;
					Model.CurrentState.Run[currentSplit - 1].SplitTime = new Time(t.RealTime, gameTime);
				} else {
					Model.CurrentState.SetGameTime(gameTime);
				}
			}
		}
		private void HandleSplit(bool shouldSplit, bool shouldReset = false) {
			if (shouldReset) {
				if (currentSplit >= 0) {
					Model.Reset();
				}
			} else if (shouldSplit) {
				if (currentSplit < 0) {
					Model.Start();
				} else {
					Model.Split();
				}
			}
		}
		private void LogValues() {
			if (lastLogCheck == 0) {
				hasLog = File.Exists(LOGFILE);
				lastLogCheck = 300;
			}
			lastLogCheck--;

			if (hasLog || !Console.IsOutputRedirected) {
				string prev = "", curr = "";
				foreach (string key in keys) {
					prev = currentValues[key];

					switch (key) {
						case "CurrentSplit": curr = currentSplit.ToString(); break;
						case "State": curr = state.ToString(); break;
						case "GameState": curr = mem.GameState().ToString("X"); break;
						case "GameTime": curr = TimeSpan.FromSeconds(mem.GameTime()).TotalMinutes.ToString("0.0"); break;
						case "Aquirements": curr = mem.AquiredFlags(); break;
						case "GoldTotal": curr = mem.GoldTotal().ToString(); break;
						case "OrbsTotal": curr = mem.OrbsTotal().ToString(); break;
						case "Deaths": curr = mem.Deaths().ToString(); break;
						case "BGColor": curr = mem.BackgroundColor().ToString(); break;
						case "FGColor": curr = mem.ForegroundColor().ToString(); break;
						case "Pos":
							PointF pos = mem.Position();
							curr = (pos.X / 10f).ToString("0") + "," + (pos.Y / 10f).ToString("0"); break;
						default: curr = ""; break;
					}

					if (!prev.Equals(curr)) {
						WriteLogWithTime(key + ": ".PadRight(16 - key.Length, ' ') + prev.PadLeft(25, ' ') + " -> " + curr);

						currentValues[key] = curr;
					}
				}
			}
		}

		public void Update(IInvalidator invalidator, LiveSplitState lvstate, float width, float height, LayoutMode mode) {
			if (Model == null) {
				Model = new TimerModel() { CurrentState = lvstate };
				Model.InitializeGameTime();
				Model.CurrentState.IsGameTimePaused = true;
				lvstate.OnReset += OnReset;
				lvstate.OnPause += OnPause;
				lvstate.OnResume += OnResume;
				lvstate.OnStart += OnStart;
				lvstate.OnSplit += OnSplit;
				lvstate.OnUndoSplit += OnUndoSplit;
				lvstate.OnSkipSplit += OnSkipSplit;
			}

			GetValues();
		}

		public void OnReset(object sender, TimerPhase e) {
			currentSplit = -1;
			state = 0;
			lastColor = 0;
			currentAquirements.Clear();
			Model.CurrentState.IsGameTimePaused = true;
			WriteLog("---------Reset----------------------------------");
		}
		public void OnResume(object sender, EventArgs e) {
			WriteLog("---------Resumed--------------------------------");
		}
		public void OnPause(object sender, EventArgs e) {
			WriteLog("---------Paused---------------------------------");
		}
		public void OnStart(object sender, EventArgs e) {
			currentSplit = 0;
			state = 0;
			lastColor = 0;
			currentAquirements.Clear();
			Model.CurrentState.IsGameTimePaused = false;
			WriteLog("---------New Game-------------------------------");
		}
		public void OnUndoSplit(object sender, EventArgs e) {
			currentSplit--;
			state = 0;
		}
		public void OnSkipSplit(object sender, EventArgs e) {
			currentSplit++;
			state = 0;
		}
		public void OnSplit(object sender, EventArgs e) {
			currentSplit++;
			state = 0;
			HandleGameTimes();
		}
		private void WriteLog(string data) {
			if (hasLog || !Console.IsOutputRedirected) {
				if (Console.IsOutputRedirected) {
					using (StreamWriter wr = new StreamWriter(LOGFILE, true)) {
						wr.WriteLine(data);
					}
				} else {
					Console.WriteLine(data);
				}
			}
		}
		private void WriteLogWithTime(string data) {
			WriteLog(DateTime.Now.ToString(@"HH\:mm\:ss.fff") + (Model != null && Model.CurrentState.CurrentTime.RealTime.HasValue ? " | " + Model.CurrentState.CurrentTime.RealTime.Value.ToString("G").Substring(3, 11) : "") + ": " + data);
		}

		public Control GetSettingsControl(LayoutMode mode) { return settings; }
		public void SetSettings(XmlNode document) { settings.SetSettings(document); }
		public XmlNode GetSettings(XmlDocument document) { return settings.UpdateSettings(document); }
		public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion) { }
		public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion) { }
		public float HorizontalWidth { get { return 0; } }
		public float MinimumHeight { get { return 0; } }
		public float MinimumWidth { get { return 0; } }
		public float PaddingBottom { get { return 0; } }
		public float PaddingLeft { get { return 0; } }
		public float PaddingRight { get { return 0; } }
		public float PaddingTop { get { return 0; } }
		public float VerticalHeight { get { return 0; } }
		public void Dispose() { }
	}
}