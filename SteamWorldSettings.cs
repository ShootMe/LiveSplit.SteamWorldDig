using System;
using System.Windows.Forms;
using System.Xml;
namespace LiveSplit.SteamWorldDig {
	public partial class SteamWorldSettings : UserControl {
		public bool AutoReset { get; set; }
		public bool Pickaxe { get; set; }
		public bool SpeedBoots { get; set; }
		public bool SteamJump { get; set; }
		public bool Drill { get; set; }
		public bool OldWorld { get; set; }
		public bool Generator1 { get; set; }
		public bool Biff { get; set; }
		public bool SteamPunch { get; set; }
		public bool Generator2 { get; set; }
		public bool Vectron { get; set; }
		public bool StaticDash { get; set; }
		public bool MineralDetector { get; set; }
		public bool Generator3 { get; set; }
		public bool FallDampeners { get; set; }
		public bool Dandy { get; set; }
		public bool Gold20K { get; set; }
		public bool Orbs150 { get; set; }
		private bool isLoading;

		public SteamWorldSettings() {
			isLoading = true;
			InitializeComponent();

			//Defaults
			AutoReset = true;
			Pickaxe = false;
			SpeedBoots = true;
			SteamJump = true;
			Drill = true;
			OldWorld = false;
			Generator1 = false;
			Biff = true;
			SteamPunch = true;
			Generator2 = false;
			Vectron = false;
			StaticDash = true;
			MineralDetector = false;
			Generator3 = false;
			FallDampeners = false;
			Dandy = false;
			Gold20K = false;
			Orbs150 = false;

			isLoading = false;
		}

		private void Settings_Load(object sender, EventArgs e) {
			isLoading = true;
			LoadSettings();
			isLoading = false;
		}
		public void LoadSettings() {
			chkAutoReset.Checked = AutoReset;
			chkPickaxe.Checked = Pickaxe;
			chkSpeedBoots.Checked = SpeedBoots;
			chkSteamJump.Checked = SteamJump;
			chkDrill.Checked = Drill;
			chkOldWorld.Checked = OldWorld;
			chkGenerator1.Checked = Generator1;
			chkBiff.Checked = Biff;
			chkSteamPunch.Checked = SteamPunch;
			chkGenerator2.Checked = Generator2;
			chkVectron.Checked = Vectron;
			chkStaticDash.Checked = StaticDash;
			chkMineralDector.Checked = MineralDetector;
			chkGenerator3.Checked = Generator3;
			chkFallDampeners.Checked = FallDampeners;
			chkDandy.Checked = Dandy;
			chkGold20K.Checked = Gold20K;
			chkOrbs150.Checked = Orbs150;
		}
		private void chkBox_CheckedChanged(object sender, EventArgs e) {
			UpdateSplits();
		}
		public void UpdateSplits() {
			if (isLoading) return;

			AutoReset = chkAutoReset.Checked;
			Pickaxe = chkPickaxe.Checked;
			SpeedBoots = chkSpeedBoots.Checked;
			SteamJump = chkSteamJump.Checked;
			Drill = chkDrill.Checked;
			OldWorld = chkOldWorld.Checked;
			Generator1 = chkGenerator1.Checked;
			Biff = chkBiff.Checked;
			SteamPunch = chkSteamPunch.Checked;
			Generator2 = chkGenerator2.Checked;
			Vectron = chkVectron.Checked;
			StaticDash = chkStaticDash.Checked;
			MineralDetector = chkMineralDector.Checked;
			Generator3 = chkGenerator3.Checked;
			FallDampeners = chkFallDampeners.Checked;
			Dandy = chkDandy.Checked;
			Gold20K = chkGold20K.Checked;
			Orbs150 = chkOrbs150.Checked;
		}
		public XmlNode UpdateSettings(XmlDocument document) {
			XmlElement xmlSettings = document.CreateElement("Settings");

			SetSetting(document, xmlSettings, chkAutoReset, "AutoReset");
			SetSetting(document, xmlSettings, chkPickaxe, "Pickaxe");
			SetSetting(document, xmlSettings, chkSpeedBoots, "SpeedBoots");
			SetSetting(document, xmlSettings, chkSteamJump, "SteamJump");
			SetSetting(document, xmlSettings, chkDrill, "Drill");
			SetSetting(document, xmlSettings, chkOldWorld, "OldWorld");
			SetSetting(document, xmlSettings, chkGenerator1, "Generator1");
			SetSetting(document, xmlSettings, chkBiff, "Biff");
			SetSetting(document, xmlSettings, chkSteamPunch, "SteamPunch");
			SetSetting(document, xmlSettings, chkGenerator2, "Generator2");
			SetSetting(document, xmlSettings, chkVectron, "Vectron");
			SetSetting(document, xmlSettings, chkStaticDash, "StaticDash");
			SetSetting(document, xmlSettings, chkMineralDector, "MineralMarker");
			SetSetting(document, xmlSettings, chkGenerator3, "Generator3");
			SetSetting(document, xmlSettings, chkFallDampeners, "FallDampeners");
			SetSetting(document, xmlSettings, chkDandy, "Dandy");
			SetSetting(document, xmlSettings, chkGold20K, "Gold20K");
			SetSetting(document, xmlSettings, chkOrbs150, "Orbs150");

			return xmlSettings;
		}
		private void SetSetting(XmlDocument document, XmlElement settings, CheckBox chk, string name) {
			XmlElement xmlOption = document.CreateElement(name);
			xmlOption.InnerText = chk.Checked.ToString();
			settings.AppendChild(xmlOption);
		}
		public void SetSettings(XmlNode settings) {
			AutoReset = GetSetting(settings, "//AutoReset", true);
			Pickaxe = GetSetting(settings, "//Pickaxe");
			SpeedBoots = GetSetting(settings, "//SpeedBoots", true);
			SteamJump = GetSetting(settings, "//SteamJump", true);
			Drill = GetSetting(settings, "//Drill", true);
			OldWorld = GetSetting(settings, "//OldWorld");
			Generator1 = GetSetting(settings, "//Generator1");
			Biff = GetSetting(settings, "//Biff", true);
			SteamPunch = GetSetting(settings, "//SteamPunch", true);
			Generator2 = GetSetting(settings, "//Generator2");
			Vectron = GetSetting(settings, "//Vectron");
			StaticDash = GetSetting(settings, "//StaticDash", true);
			MineralDetector = GetSetting(settings, "//MineralMarker");
			Generator3 = GetSetting(settings, "//Generator3");
			FallDampeners = GetSetting(settings, "//FallDampeners");
			Dandy = GetSetting(settings, "//Dandy");
			Gold20K = GetSetting(settings, "//Gold20K");
			Orbs150 = GetSetting(settings, "//Orbs150");
		}
		private bool GetSetting(XmlNode settings, string name, bool defaultVal = false) {
			XmlNode option = settings.SelectSingleNode(name);
			if (option != null && option.InnerText != "") {
				return bool.Parse(option.InnerText);
			}
			return defaultVal;
		}
	}
}