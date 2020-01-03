namespace Updater
{
    partial class MainFrm
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
            this.UserControl = new MetroFramework.Controls.MetroUserControl();
            this.ProgBar = new MetroFramework.Controls.MetroProgressBar();
            this.Upd8Txt = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // UserControl
            // 
            this.UserControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.UserControl.BackgroundImage = global::Updater.Properties.Resources.BgImage;
            this.UserControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserControl.Location = new System.Drawing.Point(0, 0);
            this.UserControl.Name = "UserControl";
            this.UserControl.Size = new System.Drawing.Size(400, 225);
            this.UserControl.TabIndex = 0;
            this.UserControl.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.UserControl.UseCustomBackColor = true;
            this.UserControl.UseSelectable = true;
            this.UserControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserControl_MouseDown);
            // 
            // ProgBar
            // 
            this.ProgBar.Location = new System.Drawing.Point(12, 190);
            this.ProgBar.MarqueeAnimationSpeed = 300;
            this.ProgBar.Name = "ProgBar";
            this.ProgBar.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgBar.Size = new System.Drawing.Size(376, 23);
            this.ProgBar.TabIndex = 1;
            this.ProgBar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ProgBar.Value = 35;
            // 
            // Upd8Txt
            // 
            this.Upd8Txt.AutoSize = true;
            this.Upd8Txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Upd8Txt.Location = new System.Drawing.Point(168, 167);
            this.Upd8Txt.Name = "Upd8Txt";
            this.Upd8Txt.Size = new System.Drawing.Size(63, 19);
            this.Upd8Txt.TabIndex = 2;
            this.Upd8Txt.Text = "Updating";
            this.Upd8Txt.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Upd8Txt.UseCustomBackColor = true;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 225);
            this.Controls.Add(this.Upd8Txt);
            this.Controls.Add(this.ProgBar);
            this.Controls.Add(this.UserControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZeroTsu Updater";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroUserControl UserControl;
        private MetroFramework.Controls.MetroProgressBar ProgBar;
        private MetroFramework.Controls.MetroLabel Upd8Txt;
    }
}

