using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using TsuSploit.Properties;

namespace TsuSploit
{
    public partial class CustomMsgBox : Form
    {
        private string currReturnType = null;
        public DialogResult MsgBox(string MsgTxt, string MTitle, MessageBoxButtons btnType, MessageBoxIcon Icon)
        {
            InitializeComponent();
            Title.Text = MTitle;
            Msg.Text = MsgTxt;
            // Begin of button check
            if (btnType == MessageBoxButtons.OK)
            {
                Btn2.Visible = false;
                Btn3.Visible = false;
                Btn1.Text = "OK";
            }
            else if (btnType == MessageBoxButtons.OKCancel)
            {
                Btn3.Visible = false;
                Btn3.Text = "OK";
                Btn1.Text = "Cancel";
            }
            else if (btnType == MessageBoxButtons.YesNo)
            {
                Btn3.Visible = false;
                Btn2.Text = "Yes";
                Btn1.Text = "No";
            }
            else if (btnType == MessageBoxButtons.YesNoCancel)
            {
                Btn3.Text = "Yes";
                Btn2.Text = "No";
                Btn1.Text = "Cancel";
            }
            else if (btnType == MessageBoxButtons.RetryCancel)
            {
                Btn3.Visible = false;
                Btn2.Text = "Retry";
                Btn1.Text = "Cancel";
            }
            else if (btnType == MessageBoxButtons.AbortRetryIgnore)
            {
                Btn3.Text = "Abort";
                Btn2.Text = "Retry";
                Btn1.Text = "Ignore";
            }
            // End of button check
            // Begin of icon check
            if (Icon == MessageBoxIcon.Error)
            {
                IconMode.BackgroundImage = new Bitmap(Resources.Error);
            }
            else if (Icon == MessageBoxIcon.Information)
            {
                IconMode.BackgroundImage = new Bitmap(Resources.Info);
            }
            else if (Icon == MessageBoxIcon.None)
            {
                Msg.Size = new Size(426, 91);
            }
            // End of icon check
            this.ShowDialog();
            while (currReturnType == null)
            {
                Task.Delay(10);
            }
            if (currReturnType == "OK")
            {
                this.Close();
                return DialogResult.OK;
            }
            else if (currReturnType == "Yes")
            {
                this.Close();
                return DialogResult.Yes;
            }
            else if (currReturnType == "No")
            {
                this.Close();
                return DialogResult.No;
            }
            else if (currReturnType == "Cancel")
            {
                this.Close();
                return DialogResult.Cancel;
            }
            else if (currReturnType == "Abort")
            {
                this.Close();
                return DialogResult.Abort;
            }
            else if (currReturnType == "Retry")
            {
                this.Close();
                return DialogResult.Retry;
            }
            else if (currReturnType == "Ignore")
            {
                this.Close();
                return DialogResult.Ignore;
            }
            this.Close();
            return DialogResult.None;
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            currReturnType = Btn1.Text;
            this.Close();
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            currReturnType = Btn2.Text;
            this.Close();
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            currReturnType = Btn3.Text;
            this.Close();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        private void Title_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            currReturnType = Btn1.Text;
            this.Close();
        }
    }
}
