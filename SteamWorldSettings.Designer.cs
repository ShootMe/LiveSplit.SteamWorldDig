namespace LiveSplit.SteamWorldDig {
	partial class SteamWorldSettings {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.flowMain = new System.Windows.Forms.FlowLayoutPanel();
			this.flowOptions = new System.Windows.Forms.FlowLayoutPanel();
			this.chkPickaxe = new System.Windows.Forms.CheckBox();
			this.chkSpeedBoots = new System.Windows.Forms.CheckBox();
			this.chkSteamJump = new System.Windows.Forms.CheckBox();
			this.chkDrill = new System.Windows.Forms.CheckBox();
			this.chkOldWorld = new System.Windows.Forms.CheckBox();
			this.chkGenerator1 = new System.Windows.Forms.CheckBox();
			this.chkBiff = new System.Windows.Forms.CheckBox();
			this.chkSteamPunch = new System.Windows.Forms.CheckBox();
			this.chkGenerator2 = new System.Windows.Forms.CheckBox();
			this.chkVectron = new System.Windows.Forms.CheckBox();
			this.chkStaticDash = new System.Windows.Forms.CheckBox();
			this.chkMineralDector = new System.Windows.Forms.CheckBox();
			this.chkGenerator3 = new System.Windows.Forms.CheckBox();
			this.chkFallDampeners = new System.Windows.Forms.CheckBox();
			this.chkDandy = new System.Windows.Forms.CheckBox();
			this.chkGold20K = new System.Windows.Forms.CheckBox();
			this.chkOrbs150 = new System.Windows.Forms.CheckBox();
			this.toolTips = new System.Windows.Forms.ToolTip(this.components);
			this.flowMain.SuspendLayout();
			this.flowOptions.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowMain
			// 
			this.flowMain.AutoSize = true;
			this.flowMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowMain.Controls.Add(this.flowOptions);
			this.flowMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowMain.Location = new System.Drawing.Point(0, 0);
			this.flowMain.Margin = new System.Windows.Forms.Padding(0);
			this.flowMain.Name = "flowMain";
			this.flowMain.Size = new System.Drawing.Size(279, 410);
			this.flowMain.TabIndex = 0;
			this.flowMain.WrapContents = false;
			// 
			// flowOptions
			// 
			this.flowOptions.Controls.Add(this.chkPickaxe);
			this.flowOptions.Controls.Add(this.chkSpeedBoots);
			this.flowOptions.Controls.Add(this.chkSteamJump);
			this.flowOptions.Controls.Add(this.chkDrill);
			this.flowOptions.Controls.Add(this.chkOldWorld);
			this.flowOptions.Controls.Add(this.chkGenerator1);
			this.flowOptions.Controls.Add(this.chkBiff);
			this.flowOptions.Controls.Add(this.chkSteamPunch);
			this.flowOptions.Controls.Add(this.chkFallDampeners);
			this.flowOptions.Controls.Add(this.chkGenerator2);
			this.flowOptions.Controls.Add(this.chkVectron);
			this.flowOptions.Controls.Add(this.chkMineralDector);
			this.flowOptions.Controls.Add(this.chkStaticDash);
			this.flowOptions.Controls.Add(this.chkGenerator3);
			this.flowOptions.Controls.Add(this.chkDandy);
			this.flowOptions.Controls.Add(this.chkGold20K);
			this.flowOptions.Controls.Add(this.chkOrbs150);
			this.flowOptions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowOptions.Location = new System.Drawing.Point(0, 0);
			this.flowOptions.Margin = new System.Windows.Forms.Padding(0);
			this.flowOptions.Name = "flowOptions";
			this.flowOptions.Size = new System.Drawing.Size(279, 410);
			this.flowOptions.TabIndex = 0;
			// 
			// chkPickaxe
			// 
			this.chkPickaxe.AutoSize = true;
			this.chkPickaxe.Location = new System.Drawing.Point(3, 3);
			this.chkPickaxe.Name = "chkPickaxe";
			this.chkPickaxe.Size = new System.Drawing.Size(64, 17);
			this.chkPickaxe.TabIndex = 0;
			this.chkPickaxe.Text = "Pickaxe";
			this.toolTips.SetToolTip(this.chkPickaxe, "Splits upon gaining the Sharp Pickaxe upgrade");
			this.chkPickaxe.UseVisualStyleBackColor = true;
			this.chkPickaxe.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
			// 
			// chkSpeedBoots
			// 
			this.chkSpeedBoots.AutoSize = true;
			this.chkSpeedBoots.Location = new System.Drawing.Point(3, 26);
			this.chkSpeedBoots.Name = "chkSpeedBoots";
			this.chkSpeedBoots.Size = new System.Drawing.Size(87, 17);
			this.chkSpeedBoots.TabIndex = 1;
			this.chkSpeedBoots.Text = "Speed Boots";
			this.toolTips.SetToolTip(this.chkSpeedBoots, "Splits upon gaining Speed Boots");
			this.chkSpeedBoots.UseVisualStyleBackColor = true;
			this.chkSpeedBoots.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
			// 
			// chkSteamJump
			// 
			this.chkSteamJump.AutoSize = true;
			this.chkSteamJump.Location = new System.Drawing.Point(3, 49);
			this.chkSteamJump.Name = "chkSteamJump";
			this.chkSteamJump.Size = new System.Drawing.Size(84, 17);
			this.chkSteamJump.TabIndex = 2;
			this.chkSteamJump.Text = "Steam Jump";
			this.toolTips.SetToolTip(this.chkSteamJump, "Splits upon gaining Steam Jump");
			this.chkSteamJump.UseVisualStyleBackColor = true;
			this.chkSteamJump.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
			// 
			// chkDrill
			// 
			this.chkDrill.AutoSize = true;
			this.chkDrill.Location = new System.Drawing.Point(3, 72);
			this.chkDrill.Name = "chkDrill";
			this.chkDrill.Size = new System.Drawing.Size(43, 17);
			this.chkDrill.TabIndex = 3;
			this.chkDrill.Text = "Drill";
			this.toolTips.SetToolTip(this.chkDrill, "Splits upon gaining the Drill");
			this.chkDrill.UseVisualStyleBackColor = true;
			this.chkDrill.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
			// 
			// chkOldWorld
			// 
			this.chkOldWorld.AutoSize = true;
			this.chkOldWorld.Location = new System.Drawing.Point(3, 95);
			this.chkOldWorld.Name = "chkOldWorld";
			this.chkOldWorld.Size = new System.Drawing.Size(73, 17);
			this.chkOldWorld.TabIndex = 4;
			this.chkOldWorld.Text = "Old World";
			this.toolTips.SetToolTip(this.chkOldWorld, "Splits upon entering Old World");
			this.chkOldWorld.UseVisualStyleBackColor = true;
			this.chkOldWorld.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
			// 
			// chkGenerator1
			// 
			this.chkGenerator1.AutoSize = true;
			this.chkGenerator1.Location = new System.Drawing.Point(3, 118);
			this.chkGenerator1.Name = "chkGenerator1";
			this.chkGenerator1.Size = new System.Drawing.Size(82, 17);
			this.chkGenerator1.TabIndex = 5;
			this.chkGenerator1.Text = "Generator 1";
			this.toolTips.SetToolTip(this.chkGenerator1, "Splits upon destroying the Generator in Archea");
			this.chkGenerator1.UseVisualStyleBackColor = true;
			this.chkGenerator1.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
			// 
			// chkBiff
			// 
			this.chkBiff.AutoSize = true;
			this.chkBiff.Location = new System.Drawing.Point(3, 141);
			this.chkBiff.Name = "chkBiff";
			this.chkBiff.Size = new System.Drawing.Size(41, 17);
			this.chkBiff.TabIndex = 6;
			this.chkBiff.Text = "Biff";
			this.toolTips.SetToolTip(this.chkBiff, "Splits upon gaining access to vendor Biff");
			this.chkBiff.UseVisualStyleBackColor = true;
			this.chkBiff.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
			// 
			// chkSteamPunch
			// 
			this.chkSteamPunch.AutoSize = true;
			this.chkSteamPunch.Location = new System.Drawing.Point(3, 164);
			this.chkSteamPunch.Name = "chkSteamPunch";
			this.chkSteamPunch.Size = new System.Drawing.Size(90, 17);
			this.chkSteamPunch.TabIndex = 7;
			this.chkSteamPunch.Text = "Steam Punch";
			this.toolTips.SetToolTip(this.chkSteamPunch, "Splits upon gaining Steam Punch");
			this.chkSteamPunch.UseVisualStyleBackColor = true;
			this.chkSteamPunch.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
			// 
			// chkGenerator2
			// 
			this.chkGenerator2.AutoSize = true;
			this.chkGenerator2.Location = new System.Drawing.Point(3, 210);
			this.chkGenerator2.Name = "chkGenerator2";
			this.chkGenerator2.Size = new System.Drawing.Size(82, 17);
			this.chkGenerator2.TabIndex = 9;
			this.chkGenerator2.Text = "Generator 2";
			this.toolTips.SetToolTip(this.chkGenerator2, "Splits upon destroying the Generator in Old World");
			this.chkGenerator2.UseVisualStyleBackColor = true;
			this.chkGenerator2.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
			// 
			// chkVectron
			// 
			this.chkVectron.AutoSize = true;
			this.chkVectron.Location = new System.Drawing.Point(3, 233);
			this.chkVectron.Name = "chkVectron";
			this.chkVectron.Size = new System.Drawing.Size(63, 17);
			this.chkVectron.TabIndex = 10;
			this.chkVectron.Text = "Vectron";
			this.toolTips.SetToolTip(this.chkVectron, "Splits upon entering Vectron");
			this.chkVectron.UseVisualStyleBackColor = true;
			this.chkVectron.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
			// 
			// chkStaticDash
			// 
			this.chkStaticDash.AutoSize = true;
			this.chkStaticDash.Location = new System.Drawing.Point(3, 279);
			this.chkStaticDash.Name = "chkStaticDash";
			this.chkStaticDash.Size = new System.Drawing.Size(81, 17);
			this.chkStaticDash.TabIndex = 12;
			this.chkStaticDash.Text = "Static Dash";
			this.toolTips.SetToolTip(this.chkStaticDash, "Splits upon gaining Static Dash");
			this.chkStaticDash.UseVisualStyleBackColor = true;
			this.chkStaticDash.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
			// 
			// chkMineralDector
			// 
			this.chkMineralDector.AutoSize = true;
			this.chkMineralDector.Location = new System.Drawing.Point(3, 256);
			this.chkMineralDector.Name = "chkMineralDector";
			this.chkMineralDector.Size = new System.Drawing.Size(104, 17);
			this.chkMineralDector.TabIndex = 11;
			this.chkMineralDector.Text = "Mineral Detector";
			this.toolTips.SetToolTip(this.chkMineralDector, "Splits upon gaining Static Dash");
			this.chkMineralDector.UseVisualStyleBackColor = true;
			this.chkMineralDector.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
			// 
			// chkGenerator3
			// 
			this.chkGenerator3.AutoSize = true;
			this.chkGenerator3.Location = new System.Drawing.Point(3, 302);
			this.chkGenerator3.Name = "chkGenerator3";
			this.chkGenerator3.Size = new System.Drawing.Size(82, 17);
			this.chkGenerator3.TabIndex = 13;
			this.chkGenerator3.Text = "Generator 3";
			this.toolTips.SetToolTip(this.chkGenerator3, "Splits upon destroying the final Generator in Vectron");
			this.chkGenerator3.UseVisualStyleBackColor = true;
			this.chkGenerator3.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
			// 
			// chkFallDampeners
			// 
			this.chkFallDampeners.AutoSize = true;
			this.chkFallDampeners.Location = new System.Drawing.Point(3, 187);
			this.chkFallDampeners.Name = "chkFallDampeners";
			this.chkFallDampeners.Size = new System.Drawing.Size(99, 17);
			this.chkFallDampeners.TabIndex = 8;
			this.chkFallDampeners.Text = "Fall Dampeners";
			this.toolTips.SetToolTip(this.chkFallDampeners, "Splits upon gaining Fall Dampeners");
			this.chkFallDampeners.UseVisualStyleBackColor = true;
			this.chkFallDampeners.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
			// 
			// chkDandy
			// 
			this.chkDandy.AutoSize = true;
			this.chkDandy.Location = new System.Drawing.Point(3, 325);
			this.chkDandy.Name = "chkDandy";
			this.chkDandy.Size = new System.Drawing.Size(57, 17);
			this.chkDandy.TabIndex = 14;
			this.chkDandy.Text = "Dandy";
			this.toolTips.SetToolTip(this.chkDandy, "Splits upon gaining access to vendor Dandy");
			this.chkDandy.UseVisualStyleBackColor = true;
			this.chkDandy.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
			// 
			// chkGold20K
			// 
			this.chkGold20K.AutoSize = true;
			this.chkGold20K.Location = new System.Drawing.Point(3, 348);
			this.chkGold20K.Name = "chkGold20K";
			this.chkGold20K.Size = new System.Drawing.Size(70, 17);
			this.chkGold20K.TabIndex = 15;
			this.chkGold20K.Text = "20K Gold";
			this.toolTips.SetToolTip(this.chkGold20K, "Splits upon gathering a total of 20K gold");
			this.chkGold20K.UseVisualStyleBackColor = true;
			this.chkGold20K.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
			// 
			// chkOrbs150
			// 
			this.chkOrbs150.AutoSize = true;
			this.chkOrbs150.Location = new System.Drawing.Point(3, 371);
			this.chkOrbs150.Name = "chkOrbs150";
			this.chkOrbs150.Size = new System.Drawing.Size(69, 17);
			this.chkOrbs150.TabIndex = 16;
			this.chkOrbs150.Text = "150 Orbs";
			this.toolTips.SetToolTip(this.chkOrbs150, "Splits upon gathering a total of 150 orbs");
			this.chkOrbs150.UseVisualStyleBackColor = true;
			this.chkOrbs150.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
			// 
			// SteamWorldSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.flowMain);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "SteamWorldSettings";
			this.Size = new System.Drawing.Size(279, 410);
			this.Load += new System.EventHandler(this.Settings_Load);
			this.flowMain.ResumeLayout(false);
			this.flowOptions.ResumeLayout(false);
			this.flowOptions.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.FlowLayoutPanel flowMain;
		private System.Windows.Forms.FlowLayoutPanel flowOptions;
		private System.Windows.Forms.CheckBox chkSteamJump;
		private System.Windows.Forms.CheckBox chkBiff;
		private System.Windows.Forms.ToolTip toolTips;
		private System.Windows.Forms.CheckBox chkSpeedBoots;
		private System.Windows.Forms.CheckBox chkDrill;
		private System.Windows.Forms.CheckBox chkPickaxe;
		private System.Windows.Forms.CheckBox chkSteamPunch;
		private System.Windows.Forms.CheckBox chkStaticDash;
		private System.Windows.Forms.CheckBox chkVectron;
		private System.Windows.Forms.CheckBox chkOldWorld;
		private System.Windows.Forms.CheckBox chkGenerator1;
		private System.Windows.Forms.CheckBox chkGenerator2;
		private System.Windows.Forms.CheckBox chkGenerator3;
		private System.Windows.Forms.CheckBox chkMineralDector;
		private System.Windows.Forms.CheckBox chkGold20K;
		private System.Windows.Forms.CheckBox chkOrbs150;
		private System.Windows.Forms.CheckBox chkDandy;
		private System.Windows.Forms.CheckBox chkFallDampeners;
	}
}
