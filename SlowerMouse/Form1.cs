using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SlowerMouse
{
    public partial class Form1 : Form
    {
        MouseSlowener slowener;

        public Form1()
        {
            InitializeComponent();

            slowener = new MouseSlowener();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            slowener.Start(GetPercentage());
        }

        private void PercentageUpDown_ValueChanged(object sender, EventArgs e)
        {
            slowener.Update(GetPercentage());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            slowener.Stop();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                GoToTray();
            }
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Maximize();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Maximize();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GoToTrayButton_Click(object sender, EventArgs e)
        {
            GoToTray();
        }

        private void GoToTray()
        {
            Hide();
            WindowState = FormWindowState.Minimized;
            NotifyIcon.Visible = true;
        }

        private void Maximize()
        {
            Show();
            WindowState = FormWindowState.Normal;
            NotifyIcon.Visible = false;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            switch(slowener.isRunning)
            {
                case true:
                    slowener.Stop();
                    StopButton.Text = "Start";
                    break;

                case false:
                    slowener.Start(GetPercentage());
                    StopButton.Text = "Stop";
                    break;
            }
        }

        private int GetPercentage()
        {
            return (int)PercentageUpDown.Value;
        }
    }
}