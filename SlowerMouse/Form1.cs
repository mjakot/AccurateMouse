using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SlowerMouse
{
    public partial class Form1 : Form
    {
        MouseSlowener slowener;
        TrayManager manager;

        int percentage;

        public Form1()
        {
            InitializeComponent();

            slowener = new MouseSlowener();
            manager = new TrayManager();

            percentage = (int)PercentageUpDown.Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            slowener.Start(percentage);
        }

        private void PercentageUpDown_ValueChanged(object sender, EventArgs e)
        {
            percentage = (int)PercentageUpDown.Value;

            slowener.Update(percentage);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            slowener.Stop();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                manager.GoToTray();
            }
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            manager.Maximize();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manager.Maximize();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GoTrayButton_Click(object sender, EventArgs e)
        {
            manager.GoToTray();
        }

        private void GoToTrayButton_Click(object sender, EventArgs e)
        {
            manager.GoToTray();
        }
    }
}