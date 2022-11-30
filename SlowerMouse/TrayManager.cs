using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlowerMouse
{
    internal class TrayManager : Form1
    {
        public void GoToTray()
        {
            Hide();
            WindowState = FormWindowState.Minimized;
            NotifyIcon.Visible = true;
        }

        public void Maximize()
        {
            Show();
            WindowState = FormWindowState.Normal;
            NotifyIcon.Visible = false;
        }
    }
}
