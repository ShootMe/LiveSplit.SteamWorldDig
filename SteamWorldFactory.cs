using LiveSplit.Model;
using LiveSplit.UI.Components;
using System;
using System.Reflection;
namespace LiveSplit.SteamWorldDig {
	public class SteamWorldFactory : IComponentFactory {
		public string ComponentName { get { return "SteamWorld Dig Autosplitter v" + this.Version.ToString(); } }
		public string Description { get { return "Autosplitter for SteamWorld Dig"; } }
		public ComponentCategory Category { get { return ComponentCategory.Control; } }
		public IComponent Create(LiveSplitState state) { return new SteamWorldComponent(); }
		public string UpdateName { get { return this.ComponentName; } }
		public string UpdateURL { get { return "https://raw.githubusercontent.com/ShootMe/LiveSplit.SteamWorldDig/master/"; } }
		public string XMLURL { get { return this.UpdateURL + "Components/LiveSplit.SteamWorldDig.Updates.xml"; } }
		public Version Version { get { return Assembly.GetExecutingAssembly().GetName().Version; } }
	}
}