namespace TsuSploit
{
    partial class TsuMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.UserControl = new MetroFramework.Controls.MetroUserControl();
            this.ClearBtn = new MetroFramework.Controls.MetroButton();
            this.ExecuteLuaC = new MetroFramework.Controls.MetroButton();
            this.ExecuteLua = new MetroFramework.Controls.MetroButton();
            this.BestTextBox = new ScintillaNET.Scintilla();
            this.SelectedAPI = new MetroFramework.Controls.MetroLabel();
            this.InjectBtn = new MetroFramework.Controls.MetroButton();
            this.APIType = new MetroFramework.Controls.MetroComboBox();
            this.TabControl = new MetroFramework.Controls.MetroTabControl();
            this.ApiLoader = new System.Windows.Forms.TabPage();
            this.OpenScript = new MetroFramework.Controls.MetroButton();
            this.SaveScript = new MetroFramework.Controls.MetroButton();
            this.ReLoad = new MetroFramework.Controls.MetroButton();
            this.ListBox = new System.Windows.Forms.ListBox();
            this.StatusTxt = new MetroFramework.Controls.MetroLabel();
            this.SettingsPage = new System.Windows.Forms.TabPage();
            this.LatestV = new MetroFramework.Controls.MetroLabel();
            this.CurrentV = new MetroFramework.Controls.MetroLabel();
            this.DlLatestVer = new MetroFramework.Controls.MetroButton();
            this.ResetDir = new MetroFramework.Controls.MetroButton();
            this.ScPathTxt = new MetroFramework.Controls.MetroLabel();
            this.ScriptPath = new MetroFramework.Controls.MetroTextBox();
            this.ChangePath = new MetroFramework.Controls.MetroButton();
            this.TimeBfITxt = new MetroFramework.Controls.MetroLabel();
            this.WaitInjectTime = new MetroFramework.Controls.MetroTextBox();
            this.AutoHook = new MetroFramework.Controls.MetroCheckBox();
            this.MultiRBX = new MetroFramework.Controls.MetroCheckBox();
            this.TopMostCheck = new MetroFramework.Controls.MetroCheckBox();
            this.HoverOpacity = new MetroFramework.Controls.MetroCheckBox();
            this.Title = new MetroFramework.Controls.MetroLabel();
            this.CloseBtn = new MetroFramework.Controls.MetroLabel();
            this.MinimizeBtn = new MetroFramework.Controls.MetroLabel();
            this.MinimizeTimer = new System.Windows.Forms.Timer(this.components);
            this.StartTimer = new System.Windows.Forms.Timer(this.components);
            this.ExitTimer = new System.Windows.Forms.Timer(this.components);
            this.HoverOp = new System.Windows.Forms.Timer(this.components);
            this.FocusCheck = new System.Windows.Forms.Timer(this.components);
            this.MultiRBXTrack = new System.Windows.Forms.Timer(this.components);
            this.StatusChecker = new System.Windows.Forms.Timer(this.components);
            this.Hooker = new System.Windows.Forms.Timer(this.components);
            this.FolderSetter = new System.Windows.Forms.FolderBrowserDialog();
            this.ScriptOpener = new System.Windows.Forms.OpenFileDialog();
            this.SaveScripts = new System.Windows.Forms.SaveFileDialog();
            this.TabControl.SuspendLayout();
            this.ApiLoader.SuspendLayout();
            this.SettingsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserControl
            // 
            this.UserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserControl.Location = new System.Drawing.Point(0, 0);
            this.UserControl.Name = "UserControl";
            this.UserControl.Size = new System.Drawing.Size(800, 450);
            this.UserControl.TabIndex = 0;
            this.UserControl.UseSelectable = true;
            // 
            // ClearBtn
            // 
            this.ClearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClearBtn.Location = new System.Drawing.Point(677, 353);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(110, 23);
            this.ClearBtn.TabIndex = 6;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ClearBtn.UseSelectable = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // ExecuteLuaC
            // 
            this.ExecuteLuaC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ExecuteLuaC.Location = new System.Drawing.Point(121, 354);
            this.ExecuteLuaC.Name = "ExecuteLuaC";
            this.ExecuteLuaC.Size = new System.Drawing.Size(110, 23);
            this.ExecuteLuaC.TabIndex = 5;
            this.ExecuteLuaC.Text = "Execute [Lua C]";
            this.ExecuteLuaC.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ExecuteLuaC.UseSelectable = true;
            this.ExecuteLuaC.Click += new System.EventHandler(this.ExecuteLuaC_Click);
            // 
            // ExecuteLua
            // 
            this.ExecuteLua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ExecuteLua.Location = new System.Drawing.Point(4, 354);
            this.ExecuteLua.Name = "ExecuteLua";
            this.ExecuteLua.Size = new System.Drawing.Size(110, 23);
            this.ExecuteLua.TabIndex = 4;
            this.ExecuteLua.Text = "Execute";
            this.ExecuteLua.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ExecuteLua.UseSelectable = true;
            this.ExecuteLua.Click += new System.EventHandler(this.ExecuteLua_Click);
            // 
            // BestTextBox
            // 
            this.BestTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BestTextBox.Lexer = ScintillaNET.Lexer.Lua;
            this.BestTextBox.Location = new System.Drawing.Point(0, 38);
            this.BestTextBox.Name = "BestTextBox";
            this.BestTextBox.Size = new System.Drawing.Size(607, 310);
            this.BestTextBox.TabIndex = 3;
            this.BestTextBox.Text = "--[[\r\nTsuSploit is crappy\r\nI <3 Zero Two\r\n]]";
            this.BestTextBox.MarginClick += new System.EventHandler<ScintillaNET.MarginClickEventArgs>(this.BestTextBox_MarginClick);
            // 
            // SelectedAPI
            // 
            this.SelectedAPI.AutoSize = true;
            this.SelectedAPI.Location = new System.Drawing.Point(525, 10);
            this.SelectedAPI.Name = "SelectedAPI";
            this.SelectedAPI.Size = new System.Drawing.Size(82, 19);
            this.SelectedAPI.TabIndex = 2;
            this.SelectedAPI.Text = "Selected API";
            this.SelectedAPI.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SelectedAPI.UseCustomBackColor = true;
            // 
            // InjectBtn
            // 
            this.InjectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.InjectBtn.Location = new System.Drawing.Point(5, 7);
            this.InjectBtn.Name = "InjectBtn";
            this.InjectBtn.Size = new System.Drawing.Size(73, 24);
            this.InjectBtn.TabIndex = 1;
            this.InjectBtn.Text = "Inject";
            this.InjectBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.InjectBtn.UseCustomBackColor = true;
            this.InjectBtn.UseSelectable = true;
            this.InjectBtn.Click += new System.EventHandler(this.InjectBtn_Click);
            // 
            // APIType
            // 
            this.APIType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.APIType.FormattingEnabled = true;
            this.APIType.ItemHeight = 23;
            this.APIType.Items.AddRange(new object[] {
            "EasyExploits API",
            "WeAreDevs API",
            "ApiModule",
            "SirHurtAPI",
            "Krnl"});
            this.APIType.Location = new System.Drawing.Point(611, 5);
            this.APIType.Name = "APIType";
            this.APIType.Size = new System.Drawing.Size(178, 29);
            this.APIType.TabIndex = 0;
            this.APIType.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.APIType.UseCustomBackColor = true;
            this.APIType.UseSelectable = true;
            this.APIType.SelectedIndexChanged += new System.EventHandler(this.APIType_SelectedIndexChanged);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.ApiLoader);
            this.TabControl.Controls.Add(this.SettingsPage);
            this.TabControl.Location = new System.Drawing.Point(0, 25);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 1;
            this.TabControl.Size = new System.Drawing.Size(800, 425);
            this.TabControl.TabIndex = 3;
            this.TabControl.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TabControl.UseSelectable = true;
            // 
            // ApiLoader
            // 
            this.ApiLoader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ApiLoader.Controls.Add(this.OpenScript);
            this.ApiLoader.Controls.Add(this.SaveScript);
            this.ApiLoader.Controls.Add(this.ReLoad);
            this.ApiLoader.Controls.Add(this.ListBox);
            this.ApiLoader.Controls.Add(this.StatusTxt);
            this.ApiLoader.Controls.Add(this.ClearBtn);
            this.ApiLoader.Controls.Add(this.ExecuteLuaC);
            this.ApiLoader.Controls.Add(this.ExecuteLua);
            this.ApiLoader.Controls.Add(this.BestTextBox);
            this.ApiLoader.Controls.Add(this.SelectedAPI);
            this.ApiLoader.Controls.Add(this.InjectBtn);
            this.ApiLoader.Controls.Add(this.APIType);
            this.ApiLoader.ForeColor = System.Drawing.Color.White;
            this.ApiLoader.Location = new System.Drawing.Point(4, 38);
            this.ApiLoader.Name = "ApiLoader";
            this.ApiLoader.Size = new System.Drawing.Size(792, 383);
            this.ApiLoader.TabIndex = 0;
            this.ApiLoader.Text = "API Loader";
            // 
            // OpenScript
            // 
            this.OpenScript.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.OpenScript.Location = new System.Drawing.Point(445, 353);
            this.OpenScript.Name = "OpenScript";
            this.OpenScript.Size = new System.Drawing.Size(110, 23);
            this.OpenScript.TabIndex = 11;
            this.OpenScript.Text = "Open Script";
            this.OpenScript.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.OpenScript.UseSelectable = true;
            this.OpenScript.Click += new System.EventHandler(this.OpenScript_Click);
            // 
            // SaveScript
            // 
            this.SaveScript.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.SaveScript.Location = new System.Drawing.Point(561, 353);
            this.SaveScript.Name = "SaveScript";
            this.SaveScript.Size = new System.Drawing.Size(110, 23);
            this.SaveScript.TabIndex = 10;
            this.SaveScript.Text = "Save Script";
            this.SaveScript.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SaveScript.UseSelectable = true;
            this.SaveScript.Click += new System.EventHandler(this.SaveScript_Click);
            // 
            // ReLoad
            // 
            this.ReLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ReLoad.Location = new System.Drawing.Point(611, 325);
            this.ReLoad.Name = "ReLoad";
            this.ReLoad.Size = new System.Drawing.Size(178, 23);
            this.ReLoad.TabIndex = 9;
            this.ReLoad.Text = "Refresh List";
            this.ReLoad.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ReLoad.UseSelectable = true;
            this.ReLoad.Click += new System.EventHandler(this.ReLoad_Click);
            // 
            // ListBox
            // 
            this.ListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListBox.ForeColor = System.Drawing.Color.White;
            this.ListBox.FormattingEnabled = true;
            this.ListBox.HorizontalScrollbar = true;
            this.ListBox.IntegralHeight = false;
            this.ListBox.Location = new System.Drawing.Point(611, 38);
            this.ListBox.Name = "ListBox";
            this.ListBox.Size = new System.Drawing.Size(178, 281);
            this.ListBox.TabIndex = 8;
            this.ListBox.DoubleClick += new System.EventHandler(this.ListBox_DoubleClick);
            // 
            // StatusTxt
            // 
            this.StatusTxt.AutoSize = true;
            this.StatusTxt.Location = new System.Drawing.Point(81, 10);
            this.StatusTxt.Name = "StatusTxt";
            this.StatusTxt.Size = new System.Drawing.Size(184, 19);
            this.StatusTxt.TabIndex = 7;
            this.StatusTxt.Text = "Status: ZeroTsuBestGirlForever";
            this.StatusTxt.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.StatusTxt.UseCustomBackColor = true;
            // 
            // SettingsPage
            // 
            this.SettingsPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.SettingsPage.Controls.Add(this.LatestV);
            this.SettingsPage.Controls.Add(this.CurrentV);
            this.SettingsPage.Controls.Add(this.DlLatestVer);
            this.SettingsPage.Controls.Add(this.ResetDir);
            this.SettingsPage.Controls.Add(this.ScPathTxt);
            this.SettingsPage.Controls.Add(this.ScriptPath);
            this.SettingsPage.Controls.Add(this.ChangePath);
            this.SettingsPage.Controls.Add(this.TimeBfITxt);
            this.SettingsPage.Controls.Add(this.WaitInjectTime);
            this.SettingsPage.Controls.Add(this.AutoHook);
            this.SettingsPage.Controls.Add(this.MultiRBX);
            this.SettingsPage.Controls.Add(this.TopMostCheck);
            this.SettingsPage.Controls.Add(this.HoverOpacity);
            this.SettingsPage.Location = new System.Drawing.Point(4, 38);
            this.SettingsPage.Name = "SettingsPage";
            this.SettingsPage.Size = new System.Drawing.Size(792, 383);
            this.SettingsPage.TabIndex = 1;
            this.SettingsPage.Text = "Settings";
            // 
            // LatestV
            // 
            this.LatestV.Location = new System.Drawing.Point(1, 309);
            this.LatestV.Name = "LatestV";
            this.LatestV.Size = new System.Drawing.Size(181, 22);
            this.LatestV.TabIndex = 12;
            this.LatestV.Text = "Latest Version: 02160216";
            this.LatestV.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.LatestV.UseCustomBackColor = true;
            this.LatestV.Visible = false;
            // 
            // CurrentV
            // 
            this.CurrentV.Location = new System.Drawing.Point(1, 331);
            this.CurrentV.Name = "CurrentV";
            this.CurrentV.Size = new System.Drawing.Size(181, 22);
            this.CurrentV.TabIndex = 11;
            this.CurrentV.Text = "Current Version: 02020202";
            this.CurrentV.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CurrentV.UseCustomBackColor = true;
            this.CurrentV.Visible = false;
            // 
            // DlLatestVer
            // 
            this.DlLatestVer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.DlLatestVer.Location = new System.Drawing.Point(5, 355);
            this.DlLatestVer.Name = "DlLatestVer";
            this.DlLatestVer.Size = new System.Drawing.Size(171, 23);
            this.DlLatestVer.TabIndex = 10;
            this.DlLatestVer.Text = "Update";
            this.DlLatestVer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.DlLatestVer.UseSelectable = true;
            this.DlLatestVer.Click += new System.EventHandler(this.DlLatestVer_Click);
            // 
            // ResetDir
            // 
            this.ResetDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ResetDir.Location = new System.Drawing.Point(723, 34);
            this.ResetDir.Name = "ResetDir";
            this.ResetDir.Size = new System.Drawing.Size(63, 23);
            this.ResetDir.TabIndex = 9;
            this.ResetDir.Text = "Reset";
            this.ResetDir.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResetDir.UseSelectable = true;
            this.ResetDir.Click += new System.EventHandler(this.ResetDir_Click);
            // 
            // ScPathTxt
            // 
            this.ScPathTxt.Location = new System.Drawing.Point(494, 7);
            this.ScPathTxt.Name = "ScPathTxt";
            this.ScPathTxt.Size = new System.Drawing.Size(164, 22);
            this.ScPathTxt.TabIndex = 8;
            this.ScPathTxt.Text = "Current Script Folder Path";
            this.ScPathTxt.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ScPathTxt.UseCustomBackColor = true;
            // 
            // ScriptPath
            // 
            // 
            // 
            // 
            this.ScriptPath.CustomButton.Image = null;
            this.ScriptPath.CustomButton.Location = new System.Drawing.Point(100, 1);
            this.ScriptPath.CustomButton.Name = "";
            this.ScriptPath.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ScriptPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ScriptPath.CustomButton.TabIndex = 1;
            this.ScriptPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ScriptPath.CustomButton.UseSelectable = true;
            this.ScriptPath.CustomButton.Visible = false;
            this.ScriptPath.Lines = new string[] {
        "ZEROTWOBESTGIRLFOREVER"};
            this.ScriptPath.Location = new System.Drawing.Point(665, 6);
            this.ScriptPath.MaxLength = 32767;
            this.ScriptPath.Name = "ScriptPath";
            this.ScriptPath.PasswordChar = '\0';
            this.ScriptPath.ReadOnly = true;
            this.ScriptPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ScriptPath.SelectedText = "";
            this.ScriptPath.SelectionLength = 0;
            this.ScriptPath.SelectionStart = 0;
            this.ScriptPath.ShortcutsEnabled = true;
            this.ScriptPath.Size = new System.Drawing.Size(122, 23);
            this.ScriptPath.TabIndex = 7;
            this.ScriptPath.Text = "ZEROTWOBESTGIRLFOREVER";
            this.ScriptPath.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ScriptPath.UseCustomBackColor = true;
            this.ScriptPath.UseSelectable = true;
            this.ScriptPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ScriptPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ChangePath
            // 
            this.ChangePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ChangePath.Location = new System.Drawing.Point(564, 34);
            this.ChangePath.Name = "ChangePath";
            this.ChangePath.Size = new System.Drawing.Size(154, 23);
            this.ChangePath.TabIndex = 6;
            this.ChangePath.Text = "Change Script Folder Path ";
            this.ChangePath.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ChangePath.UseSelectable = true;
            this.ChangePath.Click += new System.EventHandler(this.ChangePath_Click);
            // 
            // TimeBfITxt
            // 
            this.TimeBfITxt.Location = new System.Drawing.Point(480, 353);
            this.TimeBfITxt.Name = "TimeBfITxt";
            this.TimeBfITxt.Size = new System.Drawing.Size(181, 22);
            this.TimeBfITxt.TabIndex = 5;
            this.TimeBfITxt.Text = "Delay before Inject (seconds)\r\n";
            this.TimeBfITxt.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TimeBfITxt.UseCustomBackColor = true;
            this.TimeBfITxt.Visible = false;
            // 
            // WaitInjectTime
            // 
            // 
            // 
            // 
            this.WaitInjectTime.CustomButton.Image = null;
            this.WaitInjectTime.CustomButton.Location = new System.Drawing.Point(100, 1);
            this.WaitInjectTime.CustomButton.Name = "";
            this.WaitInjectTime.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.WaitInjectTime.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.WaitInjectTime.CustomButton.TabIndex = 1;
            this.WaitInjectTime.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.WaitInjectTime.CustomButton.UseSelectable = true;
            this.WaitInjectTime.CustomButton.Visible = false;
            this.WaitInjectTime.Lines = new string[] {
        "10"};
            this.WaitInjectTime.Location = new System.Drawing.Point(665, 353);
            this.WaitInjectTime.MaxLength = 32767;
            this.WaitInjectTime.Name = "WaitInjectTime";
            this.WaitInjectTime.PasswordChar = '\0';
            this.WaitInjectTime.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.WaitInjectTime.SelectedText = "";
            this.WaitInjectTime.SelectionLength = 0;
            this.WaitInjectTime.SelectionStart = 0;
            this.WaitInjectTime.ShortcutsEnabled = true;
            this.WaitInjectTime.Size = new System.Drawing.Size(122, 23);
            this.WaitInjectTime.TabIndex = 4;
            this.WaitInjectTime.Text = "10";
            this.WaitInjectTime.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.WaitInjectTime.UseCustomBackColor = true;
            this.WaitInjectTime.UseSelectable = true;
            this.WaitInjectTime.Visible = false;
            this.WaitInjectTime.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.WaitInjectTime.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.WaitInjectTime.TextChanged += new System.EventHandler(this.WaitInjectTime_TextChanged);
            // 
            // AutoHook
            // 
            this.AutoHook.AutoSize = true;
            this.AutoHook.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.AutoHook.Location = new System.Drawing.Point(5, 66);
            this.AutoHook.Name = "AutoHook";
            this.AutoHook.Size = new System.Drawing.Size(77, 15);
            this.AutoHook.TabIndex = 3;
            this.AutoHook.Text = "Auto Inject";
            this.AutoHook.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.AutoHook.UseCustomBackColor = true;
            this.AutoHook.UseSelectable = true;
            this.AutoHook.CheckedChanged += new System.EventHandler(this.AutoHook_CheckedChanged);
            // 
            // MultiRBX
            // 
            this.MultiRBX.AutoSize = true;
            this.MultiRBX.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.MultiRBX.Location = new System.Drawing.Point(5, 46);
            this.MultiRBX.Name = "MultiRBX";
            this.MultiRBX.Size = new System.Drawing.Size(106, 15);
            this.MultiRBX.TabIndex = 2;
            this.MultiRBX.Text = "Mutiple ROBLOX";
            this.MultiRBX.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.MultiRBX.UseCustomBackColor = true;
            this.MultiRBX.UseSelectable = true;
            this.MultiRBX.CheckedChanged += new System.EventHandler(this.MultiRBX_CheckedChanged);
            // 
            // TopMostCheck
            // 
            this.TopMostCheck.AutoSize = true;
            this.TopMostCheck.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.TopMostCheck.Location = new System.Drawing.Point(5, 25);
            this.TopMostCheck.Name = "TopMostCheck";
            this.TopMostCheck.Size = new System.Drawing.Size(70, 15);
            this.TopMostCheck.TabIndex = 1;
            this.TopMostCheck.Text = "Top Most";
            this.TopMostCheck.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TopMostCheck.UseCustomBackColor = true;
            this.TopMostCheck.UseSelectable = true;
            this.TopMostCheck.CheckedChanged += new System.EventHandler(this.TopMostCheck_CheckedChanged);
            // 
            // HoverOpacity
            // 
            this.HoverOpacity.AutoSize = true;
            this.HoverOpacity.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.HoverOpacity.Location = new System.Drawing.Point(5, 5);
            this.HoverOpacity.Name = "HoverOpacity";
            this.HoverOpacity.Size = new System.Drawing.Size(94, 15);
            this.HoverOpacity.TabIndex = 0;
            this.HoverOpacity.Text = "Hover Opacity";
            this.HoverOpacity.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.HoverOpacity.UseCustomBackColor = true;
            this.HoverOpacity.UseSelectable = true;
            this.HoverOpacity.CheckedChanged += new System.EventHandler(this.HoverOpacity_CheckedChanged);
            // 
            // Title
            // 
            this.Title.Location = new System.Drawing.Point(0, 2);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(800, 20);
            this.Title.TabIndex = 2;
            this.Title.Text = "TsuSploit";
            this.Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Title.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Title_MouseDown);
            // 
            // CloseBtn
            // 
            this.CloseBtn.AutoSize = true;
            this.CloseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseBtn.Location = new System.Drawing.Point(779, 3);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(17, 19);
            this.CloseBtn.TabIndex = 4;
            this.CloseBtn.Text = "X";
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // MinimizeBtn
            // 
            this.MinimizeBtn.AutoSize = true;
            this.MinimizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimizeBtn.Location = new System.Drawing.Point(758, 2);
            this.MinimizeBtn.Name = "MinimizeBtn";
            this.MinimizeBtn.Size = new System.Drawing.Size(15, 19);
            this.MinimizeBtn.TabIndex = 5;
            this.MinimizeBtn.Text = "_";
            this.MinimizeBtn.Click += new System.EventHandler(this.MinimizeBtn_Click);
            // 
            // MinimizeTimer
            // 
            this.MinimizeTimer.Interval = 25;
            this.MinimizeTimer.Tick += new System.EventHandler(this.MinimizeTimer_Tick);
            // 
            // StartTimer
            // 
            this.StartTimer.Interval = 25;
            this.StartTimer.Tick += new System.EventHandler(this.StartTimer_Tick);
            // 
            // ExitTimer
            // 
            this.ExitTimer.Interval = 25;
            this.ExitTimer.Tick += new System.EventHandler(this.ExitTimer_Tick);
            // 
            // HoverOp
            // 
            this.HoverOp.Interval = 25;
            this.HoverOp.Tick += new System.EventHandler(this.HoverOp_Tick);
            // 
            // FocusCheck
            // 
            this.FocusCheck.Interval = 25;
            this.FocusCheck.Tick += new System.EventHandler(this.FocusCheck_Tick);
            // 
            // MultiRBXTrack
            // 
            this.MultiRBXTrack.Tick += new System.EventHandler(this.MultiRBXTrack_Tick);
            // 
            // StatusChecker
            // 
            this.StatusChecker.Tick += new System.EventHandler(this.StatusChecker_Tick);
            // 
            // Hooker
            // 
            this.Hooker.Tick += new System.EventHandler(this.Hooker_Tick);
            // 
            // FolderSetter
            // 
            this.FolderSetter.Description = "Select a folder to use as Script Folder.";
            this.FolderSetter.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // ScriptOpener
            // 
            this.ScriptOpener.Filter = "Lua files|*.lua|Text file|*.txt|All files|*.*";
            this.ScriptOpener.ShowReadOnly = true;
            this.ScriptOpener.Title = "TsuSploit Script Opener";
            // 
            // SaveScripts
            // 
            this.SaveScripts.Filter = "Lua files|*.lua|Text file|*.txt|All files|*.*";
            this.SaveScripts.Title = "TsuSploit Script Saver";
            // 
            // TsuMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MinimizeBtn);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.UserControl);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TsuMain";
            this.Opacity = 0D;
            this.Text = "ZeroTwoSploit";
            this.TopMost = true;
            this.TabControl.ResumeLayout(false);
            this.ApiLoader.ResumeLayout(false);
            this.ApiLoader.PerformLayout();
            this.SettingsPage.ResumeLayout(false);
            this.SettingsPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroUserControl UserControl;
        private MetroFramework.Controls.MetroButton ClearBtn;
        private MetroFramework.Controls.MetroButton ExecuteLuaC;
        private MetroFramework.Controls.MetroButton ExecuteLua;
        private ScintillaNET.Scintilla BestTextBox;
        private MetroFramework.Controls.MetroLabel SelectedAPI;
        private MetroFramework.Controls.MetroButton InjectBtn;
        private MetroFramework.Controls.MetroComboBox APIType;
        private MetroFramework.Controls.MetroTabControl TabControl;
        private System.Windows.Forms.TabPage ApiLoader;
        private MetroFramework.Controls.MetroLabel Title;
        private MetroFramework.Controls.MetroLabel CloseBtn;
        private MetroFramework.Controls.MetroLabel MinimizeBtn;
        private System.Windows.Forms.Timer MinimizeTimer;
        private System.Windows.Forms.Timer StartTimer;
        private System.Windows.Forms.Timer ExitTimer;
        private System.Windows.Forms.TabPage SettingsPage;
        private MetroFramework.Controls.MetroCheckBox HoverOpacity;
        private System.Windows.Forms.Timer HoverOp;
        private MetroFramework.Controls.MetroCheckBox TopMostCheck;
        private System.Windows.Forms.Timer FocusCheck;
        private MetroFramework.Controls.MetroCheckBox MultiRBX;
        private System.Windows.Forms.Timer MultiRBXTrack;
        private MetroFramework.Controls.MetroLabel StatusTxt;
        private System.Windows.Forms.Timer StatusChecker;
        private MetroFramework.Controls.MetroCheckBox AutoHook;
        private System.Windows.Forms.Timer Hooker;
        private MetroFramework.Controls.MetroTextBox WaitInjectTime;
        private MetroFramework.Controls.MetroLabel TimeBfITxt;
        private System.Windows.Forms.ListBox ListBox;
        private MetroFramework.Controls.MetroButton ReLoad;
        private MetroFramework.Controls.MetroLabel ScPathTxt;
        private MetroFramework.Controls.MetroTextBox ScriptPath;
        private MetroFramework.Controls.MetroButton ChangePath;
        private System.Windows.Forms.FolderBrowserDialog FolderSetter;
        private MetroFramework.Controls.MetroButton ResetDir;
        private MetroFramework.Controls.MetroButton OpenScript;
        private MetroFramework.Controls.MetroButton SaveScript;
        private System.Windows.Forms.OpenFileDialog ScriptOpener;
        private System.Windows.Forms.SaveFileDialog SaveScripts;
        private MetroFramework.Controls.MetroButton DlLatestVer;
        private MetroFramework.Controls.MetroLabel LatestV;
        private MetroFramework.Controls.MetroLabel CurrentV;
    }
}

