namespace OutlookAmplifier
{
	partial class OutlookAmplifierForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.gbOptions = new System.Windows.Forms.GroupBox();
			this.soundFilePanel = new System.Windows.Forms.FlowLayoutPanel();
			this.paSoundPath = new System.Windows.Forms.Panel();
			this.lbSoundPath = new System.Windows.Forms.Label();
			this.soundButtonsLayout = new System.Windows.Forms.FlowLayoutPanel();
			this.cmdPlayStop = new System.Windows.Forms.Button();
			this.cmdLoadSound = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.volumeBar = new System.Windows.Forms.TrackBar();
			this.cbPlaySound = new System.Windows.Forms.CheckBox();
			this.cbShowOutlook = new System.Windows.Forms.CheckBox();
			this.testLabel1 = new System.Windows.Forms.Label();
			this.mainLayout = new System.Windows.Forms.FlowLayoutPanel();
			this.flProgramOptions = new System.Windows.Forms.FlowLayoutPanel();
			this.gbProgramOptions = new System.Windows.Forms.GroupBox();
			this.cbConfirmClose = new System.Windows.Forms.CheckBox();
			this.cbCloseOutlook = new System.Windows.Forms.CheckBox();
			this.cbShowOnStart = new System.Windows.Forms.CheckBox();
			this.cbAutoStart = new System.Windows.Forms.CheckBox();
			this.testLabel2 = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.cmdShowOutlook = new System.Windows.Forms.Button();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.gbOptions.SuspendLayout();
			this.soundFilePanel.SuspendLayout();
			this.paSoundPath.SuspendLayout();
			this.soundButtonsLayout.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
			this.mainLayout.SuspendLayout();
			this.flProgramOptions.SuspendLayout();
			this.gbProgramOptions.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbOptions
			// 
			this.gbOptions.AutoSize = true;
			this.gbOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.gbOptions.Controls.Add(this.soundFilePanel);
			this.gbOptions.Controls.Add(this.cbPlaySound);
			this.gbOptions.Controls.Add(this.cbShowOutlook);
			this.gbOptions.Controls.Add(this.testLabel1);
			this.gbOptions.Location = new System.Drawing.Point(50, 50);
			this.gbOptions.Margin = new System.Windows.Forms.Padding(20);
			this.gbOptions.Name = "gbOptions";
			this.gbOptions.Padding = new System.Windows.Forms.Padding(10);
			this.gbOptions.Size = new System.Drawing.Size(206, 205);
			this.gbOptions.TabIndex = 0;
			this.gbOptions.TabStop = false;
			this.gbOptions.Text = " When new mail arrives: ";
			this.gbOptions.Layout += new System.Windows.Forms.LayoutEventHandler(this.gbOptions_Layout);
			// 
			// soundFilePanel
			// 
			this.soundFilePanel.AutoSize = true;
			this.soundFilePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.soundFilePanel.Controls.Add(this.paSoundPath);
			this.soundFilePanel.Controls.Add(this.soundButtonsLayout);
			this.soundFilePanel.Controls.Add(this.groupBox1);
			this.soundFilePanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.soundFilePanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.soundFilePanel.Location = new System.Drawing.Point(10, 84);
			this.soundFilePanel.Name = "soundFilePanel";
			this.soundFilePanel.Size = new System.Drawing.Size(186, 111);
			this.soundFilePanel.TabIndex = 4;
			this.soundFilePanel.WrapContents = false;
			// 
			// paSoundPath
			// 
			this.paSoundPath.Controls.Add(this.lbSoundPath);
			this.paSoundPath.Location = new System.Drawing.Point(3, 3);
			this.paSoundPath.Name = "paSoundPath";
			this.paSoundPath.Size = new System.Drawing.Size(138, 15);
			this.paSoundPath.TabIndex = 6;
			// 
			// lbSoundPath
			// 
			this.lbSoundPath.AutoSize = true;
			this.lbSoundPath.Location = new System.Drawing.Point(0, 0);
			this.lbSoundPath.Margin = new System.Windows.Forms.Padding(0);
			this.lbSoundPath.Name = "lbSoundPath";
			this.lbSoundPath.Padding = new System.Windows.Forms.Padding(5, 0, 3, 0);
			this.lbSoundPath.Size = new System.Drawing.Size(89, 15);
			this.lbSoundPath.TabIndex = 4;
			this.lbSoundPath.Text = "NewMail.mp3";
			this.lbSoundPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbSoundPath.Resize += new System.EventHandler(this.lbSoundPath_Resize);
			// 
			// soundButtonsLayout
			// 
			this.soundButtonsLayout.AutoSize = true;
			this.soundButtonsLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.soundButtonsLayout.Controls.Add(this.cmdPlayStop);
			this.soundButtonsLayout.Controls.Add(this.cmdLoadSound);
			this.soundButtonsLayout.Location = new System.Drawing.Point(0, 21);
			this.soundButtonsLayout.Margin = new System.Windows.Forms.Padding(0);
			this.soundButtonsLayout.Name = "soundButtonsLayout";
			this.soundButtonsLayout.Size = new System.Drawing.Size(144, 35);
			this.soundButtonsLayout.TabIndex = 5;
			// 
			// cmdPlayStop
			// 
			this.cmdPlayStop.AutoSize = true;
			this.cmdPlayStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cmdPlayStop.Location = new System.Drawing.Point(3, 3);
			this.cmdPlayStop.Name = "cmdPlayStop";
			this.cmdPlayStop.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
			this.cmdPlayStop.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.cmdPlayStop.Size = new System.Drawing.Size(61, 29);
			this.cmdPlayStop.TabIndex = 2;
			this.cmdPlayStop.Text = " Play ";
			this.cmdPlayStop.UseVisualStyleBackColor = true;
			this.cmdPlayStop.Click += new System.EventHandler(this.cmdPlayStop_Click);
			// 
			// cmdLoadSound
			// 
			this.cmdLoadSound.AutoSize = true;
			this.cmdLoadSound.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cmdLoadSound.Location = new System.Drawing.Point(70, 3);
			this.cmdLoadSound.Name = "cmdLoadSound";
			this.cmdLoadSound.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
			this.cmdLoadSound.Size = new System.Drawing.Size(71, 29);
			this.cmdLoadSound.TabIndex = 3;
			this.cmdLoadSound.Text = "Browse";
			this.cmdLoadSound.UseVisualStyleBackColor = true;
			this.cmdLoadSound.Click += new System.EventHandler(this.cmdLoadSound_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.volumeBar);
			this.groupBox1.Location = new System.Drawing.Point(3, 59);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(180, 49);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = " Volume: ";
			// 
			// volumeBar
			// 
			this.volumeBar.AutoSize = false;
			this.volumeBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.volumeBar.LargeChange = 20;
			this.volumeBar.Location = new System.Drawing.Point(3, 19);
			this.volumeBar.Margin = new System.Windows.Forms.Padding(0);
			this.volumeBar.Maximum = 100;
			this.volumeBar.Name = "volumeBar";
			this.volumeBar.Size = new System.Drawing.Size(174, 24);
			this.volumeBar.TabIndex = 4;
			this.volumeBar.TickFrequency = 5;
			this.volumeBar.ValueChanged += new System.EventHandler(this.volumeBar_ValueChanged);
			this.volumeBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.volumeBar_KeyUp);
			this.volumeBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.volumeBar_MouseUp);
			// 
			// cbPlaySound
			// 
			this.cbPlaySound.AutoSize = true;
			this.cbPlaySound.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbPlaySound.Location = new System.Drawing.Point(10, 55);
			this.cbPlaySound.Name = "cbPlaySound";
			this.cbPlaySound.Padding = new System.Windows.Forms.Padding(5);
			this.cbPlaySound.Size = new System.Drawing.Size(186, 29);
			this.cbPlaySound.TabIndex = 1;
			this.cbPlaySound.Text = "Play sound";
			this.cbPlaySound.UseVisualStyleBackColor = true;
			this.cbPlaySound.CheckedChanged += new System.EventHandler(this.cbPlaySound_CheckedChanged);
			// 
			// cbShowOutlook
			// 
			this.cbShowOutlook.AutoSize = true;
			this.cbShowOutlook.Checked = true;
			this.cbShowOutlook.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbShowOutlook.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbShowOutlook.Location = new System.Drawing.Point(10, 26);
			this.cbShowOutlook.Name = "cbShowOutlook";
			this.cbShowOutlook.Padding = new System.Windows.Forms.Padding(5);
			this.cbShowOutlook.Size = new System.Drawing.Size(186, 29);
			this.cbShowOutlook.TabIndex = 0;
			this.cbShowOutlook.Text = "Show outlook";
			this.cbShowOutlook.UseVisualStyleBackColor = true;
			this.cbShowOutlook.CheckedChanged += new System.EventHandler(this.cbShowOutlook_CheckedChanged);
			// 
			// testLabel1
			// 
			this.testLabel1.AutoSize = true;
			this.testLabel1.ForeColor = System.Drawing.SystemColors.Control;
			this.testLabel1.Location = new System.Drawing.Point(10, 26);
			this.testLabel1.Name = "testLabel1";
			this.testLabel1.Size = new System.Drawing.Size(183, 15);
			this.testLabel1.TabIndex = 2;
			this.testLabel1.Text = "Test Label Label Label Test Label 1";
			this.testLabel1.SizeChanged += new System.EventHandler(this.testLabel1_SizeChanged);
			// 
			// mainLayout
			// 
			this.mainLayout.AutoSize = true;
			this.mainLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mainLayout.Controls.Add(this.gbOptions);
			this.mainLayout.Controls.Add(this.flProgramOptions);
			this.mainLayout.Location = new System.Drawing.Point(3, 2);
			this.mainLayout.Name = "mainLayout";
			this.mainLayout.Padding = new System.Windows.Forms.Padding(30);
			this.mainLayout.Size = new System.Drawing.Size(615, 305);
			this.mainLayout.TabIndex = 1;
			// 
			// flProgramOptions
			// 
			this.flProgramOptions.AutoSize = true;
			this.flProgramOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flProgramOptions.Controls.Add(this.gbProgramOptions);
			this.flProgramOptions.Controls.Add(this.flowLayoutPanel1);
			this.flProgramOptions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flProgramOptions.Location = new System.Drawing.Point(296, 50);
			this.flProgramOptions.Margin = new System.Windows.Forms.Padding(20);
			this.flProgramOptions.Name = "flProgramOptions";
			this.flProgramOptions.Size = new System.Drawing.Size(269, 187);
			this.flProgramOptions.TabIndex = 2;
			this.flProgramOptions.WrapContents = false;
			// 
			// gbProgramOptions
			// 
			this.gbProgramOptions.AutoSize = true;
			this.gbProgramOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.gbProgramOptions.Controls.Add(this.cbConfirmClose);
			this.gbProgramOptions.Controls.Add(this.cbCloseOutlook);
			this.gbProgramOptions.Controls.Add(this.cbShowOnStart);
			this.gbProgramOptions.Controls.Add(this.cbAutoStart);
			this.gbProgramOptions.Controls.Add(this.testLabel2);
			this.gbProgramOptions.Location = new System.Drawing.Point(0, 0);
			this.gbProgramOptions.Margin = new System.Windows.Forms.Padding(0);
			this.gbProgramOptions.Name = "gbProgramOptions";
			this.gbProgramOptions.Padding = new System.Windows.Forms.Padding(10);
			this.gbProgramOptions.Size = new System.Drawing.Size(269, 152);
			this.gbProgramOptions.TabIndex = 1;
			this.gbProgramOptions.TabStop = false;
			this.gbProgramOptions.Text = " Program options: ";
			this.gbProgramOptions.Layout += new System.Windows.Forms.LayoutEventHandler(this.gbProgramOptions_Layout);
			// 
			// cbConfirmClose
			// 
			this.cbConfirmClose.AutoSize = true;
			this.cbConfirmClose.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbConfirmClose.Location = new System.Drawing.Point(10, 113);
			this.cbConfirmClose.Name = "cbConfirmClose";
			this.cbConfirmClose.Padding = new System.Windows.Forms.Padding(5);
			this.cbConfirmClose.Size = new System.Drawing.Size(249, 29);
			this.cbConfirmClose.TabIndex = 4;
			this.cbConfirmClose.Text = "Confirm on close";
			this.cbConfirmClose.UseVisualStyleBackColor = true;
			this.cbConfirmClose.CheckedChanged += new System.EventHandler(this.cbConfirmClose_CheckedChanged);
			// 
			// cbCloseOutlook
			// 
			this.cbCloseOutlook.AutoSize = true;
			this.cbCloseOutlook.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbCloseOutlook.Location = new System.Drawing.Point(10, 84);
			this.cbCloseOutlook.Name = "cbCloseOutlook";
			this.cbCloseOutlook.Padding = new System.Windows.Forms.Padding(5);
			this.cbCloseOutlook.Size = new System.Drawing.Size(249, 29);
			this.cbCloseOutlook.TabIndex = 2;
			this.cbCloseOutlook.Text = "Close outlook when close this program";
			this.cbCloseOutlook.UseVisualStyleBackColor = true;
			this.cbCloseOutlook.CheckedChanged += new System.EventHandler(this.cbCloseOutlook_CheckedChanged);
			// 
			// cbShowOnStart
			// 
			this.cbShowOnStart.AutoSize = true;
			this.cbShowOnStart.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbShowOnStart.Location = new System.Drawing.Point(10, 55);
			this.cbShowOnStart.Name = "cbShowOnStart";
			this.cbShowOnStart.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
			this.cbShowOnStart.Size = new System.Drawing.Size(249, 29);
			this.cbShowOnStart.TabIndex = 1;
			this.cbShowOnStart.Text = "Show this dialog on startup";
			this.cbShowOnStart.UseVisualStyleBackColor = true;
			this.cbShowOnStart.CheckedChanged += new System.EventHandler(this.cbShowOnStart_CheckedChanged);
			// 
			// cbAutoStart
			// 
			this.cbAutoStart.AutoSize = true;
			this.cbAutoStart.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbAutoStart.Location = new System.Drawing.Point(10, 26);
			this.cbAutoStart.Name = "cbAutoStart";
			this.cbAutoStart.Padding = new System.Windows.Forms.Padding(5);
			this.cbAutoStart.Size = new System.Drawing.Size(249, 29);
			this.cbAutoStart.TabIndex = 0;
			this.cbAutoStart.Text = "Auto start at login";
			this.cbAutoStart.UseVisualStyleBackColor = true;
			this.cbAutoStart.CheckedChanged += new System.EventHandler(this.cbAutoStart_CheckedChanged);
			// 
			// testLabel2
			// 
			this.testLabel2.AutoSize = true;
			this.testLabel2.ForeColor = System.Drawing.SystemColors.Control;
			this.testLabel2.Location = new System.Drawing.Point(13, 26);
			this.testLabel2.Name = "testLabel2";
			this.testLabel2.Size = new System.Drawing.Size(243, 15);
			this.testLabel2.TabIndex = 3;
			this.testLabel2.Text = "xx Close outlook when close this program xx";
			this.testLabel2.SizeChanged += new System.EventHandler(this.testLabel2_SizeChanged);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.cmdShowOutlook);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 152);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(269, 35);
			this.flowLayoutPanel1.TabIndex = 6;
			// 
			// cmdShowOutlook
			// 
			this.cmdShowOutlook.AutoSize = true;
			this.cmdShowOutlook.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cmdShowOutlook.Location = new System.Drawing.Point(132, 3);
			this.cmdShowOutlook.Name = "cmdShowOutlook";
			this.cmdShowOutlook.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
			this.cmdShowOutlook.Size = new System.Drawing.Size(134, 29);
			this.cmdShowOutlook.TabIndex = 3;
			this.cmdShowOutlook.Text = "Show Outlook now";
			this.cmdShowOutlook.UseVisualStyleBackColor = true;
			this.cmdShowOutlook.Click += new System.EventHandler(this.cmdShowOutlook_Click);
			// 
			// notifyIcon
			// 
			this.notifyIcon.Text = "Outlook amplifer";
			this.notifyIcon.Visible = true;
			this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog";
			this.openFileDialog.Filter = "Default(*.mp3,*.wav)|*.mp3;*.wav";
			this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
			// 
			// OutlookAmplifierForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(621, 256);
			this.Controls.Add(this.mainLayout);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "OutlookAmplifierForm";
			this.Opacity = 0D;
			this.ShowInTaskbar = false;
			this.Text = "Outlook amplifier";
			this.gbOptions.ResumeLayout(false);
			this.gbOptions.PerformLayout();
			this.soundFilePanel.ResumeLayout(false);
			this.soundFilePanel.PerformLayout();
			this.paSoundPath.ResumeLayout(false);
			this.paSoundPath.PerformLayout();
			this.soundButtonsLayout.ResumeLayout(false);
			this.soundButtonsLayout.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
			this.mainLayout.ResumeLayout(false);
			this.mainLayout.PerformLayout();
			this.flProgramOptions.ResumeLayout(false);
			this.flProgramOptions.PerformLayout();
			this.gbProgramOptions.ResumeLayout(false);
			this.gbProgramOptions.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.CheckBox cbShowOutlook;
        private System.Windows.Forms.CheckBox cbPlaySound;
        private System.Windows.Forms.FlowLayoutPanel mainLayout;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.GroupBox gbProgramOptions;
        private System.Windows.Forms.CheckBox cbCloseOutlook;
        private System.Windows.Forms.CheckBox cbShowOnStart;
        private System.Windows.Forms.CheckBox cbAutoStart;
        private System.Windows.Forms.Label testLabel2;
        private System.Windows.Forms.CheckBox cbConfirmClose;
		private System.Windows.Forms.Button cmdLoadSound;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.FlowLayoutPanel soundFilePanel;
		private System.Windows.Forms.Label lbSoundPath;
		private System.Windows.Forms.FlowLayoutPanel soundButtonsLayout;
		private System.Windows.Forms.Button cmdPlayStop;
		private System.Windows.Forms.Panel paSoundPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar volumeBar;
        private System.Windows.Forms.Label testLabel1;
        private System.Windows.Forms.FlowLayoutPanel flProgramOptions;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button cmdShowOutlook;
    }
}
