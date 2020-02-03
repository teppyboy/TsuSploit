namespace TsuSploit
{
    partial class CustomMsgBox
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
            this.Title = new MetroFramework.Controls.MetroLabel();
            this.UserControl = new MetroFramework.Controls.MetroUserControl();
            this.Btn1 = new MetroFramework.Controls.MetroButton();
            this.Btn2 = new MetroFramework.Controls.MetroButton();
            this.Btn3 = new MetroFramework.Controls.MetroButton();
            this.IconMode = new System.Windows.Forms.PictureBox();
            this.CloseBtn = new MetroFramework.Controls.MetroLabel();
            this.Msg = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.IconMode)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Location = new System.Drawing.Point(-1, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(452, 20);
            this.Title.TabIndex = 3;
            this.Title.Text = "CustomMsgBox";
            this.Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Title.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Title_MouseDown);
            // 
            // UserControl
            // 
            this.UserControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.UserControl.Location = new System.Drawing.Point(-1, 0);
            this.UserControl.Name = "UserControl";
            this.UserControl.Size = new System.Drawing.Size(452, 150);
            this.UserControl.TabIndex = 4;
            this.UserControl.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.UserControl.UseCustomBackColor = true;
            this.UserControl.UseSelectable = true;
            // 
            // Btn1
            // 
            this.Btn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Btn1.Location = new System.Drawing.Point(368, 125);
            this.Btn1.Name = "Btn1";
            this.Btn1.Size = new System.Drawing.Size(70, 20);
            this.Btn1.TabIndex = 11;
            this.Btn1.Text = "Btn1";
            this.Btn1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Btn1.UseSelectable = true;
            this.Btn1.Click += new System.EventHandler(this.Btn1_Click);
            // 
            // Btn2
            // 
            this.Btn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Btn2.Location = new System.Drawing.Point(292, 125);
            this.Btn2.Name = "Btn2";
            this.Btn2.Size = new System.Drawing.Size(70, 20);
            this.Btn2.TabIndex = 12;
            this.Btn2.Text = "Btn2";
            this.Btn2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Btn2.UseSelectable = true;
            this.Btn2.Click += new System.EventHandler(this.Btn2_Click);
            // 
            // Btn3
            // 
            this.Btn3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Btn3.Location = new System.Drawing.Point(216, 125);
            this.Btn3.Name = "Btn3";
            this.Btn3.Size = new System.Drawing.Size(70, 20);
            this.Btn3.TabIndex = 13;
            this.Btn3.Text = "Btn3";
            this.Btn3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Btn3.UseSelectable = true;
            this.Btn3.Click += new System.EventHandler(this.Btn3_Click);
            // 
            // IconMode
            // 
            this.IconMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.IconMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.IconMode.Location = new System.Drawing.Point(12, 50);
            this.IconMode.Name = "IconMode";
            this.IconMode.Size = new System.Drawing.Size(48, 48);
            this.IconMode.TabIndex = 14;
            this.IconMode.TabStop = false;
            // 
            // CloseBtn
            // 
            this.CloseBtn.AutoSize = true;
            this.CloseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseBtn.Location = new System.Drawing.Point(434, 0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(17, 19);
            this.CloseBtn.TabIndex = 15;
            this.CloseBtn.Text = "X";
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // Msg
            // 
            this.Msg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Msg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Msg.Font = new System.Drawing.Font("Segoe UI Light", 10F);
            this.Msg.ForeColor = System.Drawing.Color.White;
            this.Msg.Location = new System.Drawing.Point(66, 28);
            this.Msg.Name = "Msg";
            this.Msg.ReadOnly = true;
            this.Msg.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.Msg.Size = new System.Drawing.Size(372, 91);
            this.Msg.TabIndex = 16;
            this.Msg.Text = "{TXT}";
            // 
            // CustomMsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 150);
            this.Controls.Add(this.Msg);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.IconMode);
            this.Controls.Add(this.Btn3);
            this.Controls.Add(this.Btn2);
            this.Controls.Add(this.Btn1);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.UserControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomMsgBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZeroTsu Notice";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.IconMode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel Title;
        private MetroFramework.Controls.MetroUserControl UserControl;
        private MetroFramework.Controls.MetroButton Btn1;
        private MetroFramework.Controls.MetroButton Btn2;
        private MetroFramework.Controls.MetroButton Btn3;
        private System.Windows.Forms.PictureBox IconMode;
        private MetroFramework.Controls.MetroLabel CloseBtn;
        private System.Windows.Forms.RichTextBox Msg;
    }
}