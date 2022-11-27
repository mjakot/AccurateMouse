using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace SlowerMouseDemo
{
    public partial class Form1 : Form
    {
        //TODO: Clean up and make better(get good)
        //TODO: Add ability to change % of slowerspeed from topspeed
        //TODO: Add ability to go in tray
        //TODO: Maybe add ability to change activation key
        
        






        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public const UInt32 SPI_SETMOUSESPEED = 0x0071;
        public const UInt32 SPI_GETMOUSESPEED = 0x0070;

        [DllImport("User32.dll")]
        static extern Boolean SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, UInt32 pvParam, UInt32 fWinIni);
        [DllImport("User32.dll")]
        static extern Boolean SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, IntPtr pvParam, UInt32 fWinIni);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, KeyboardHookHandler lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private const int WM_KEYDOWN = 0x100;
        private const int WM_SYSKEYDOWN = 0x104;
        private const int WM_KEYUP = 0x101;
        private const int WM_SYSKEYUP = 0x105;

        static UInt32 mouseSpeed;
        static UInt32 slowerSpeed;

        private delegate IntPtr KeyboardHookHandler(int nCode, IntPtr wParam, IntPtr lParam);
        private KeyboardHookHandler hookHandler;

        public delegate void KeyboardHookCallback(Keys key);

        public event KeyboardHookCallback KeyDown;
        public event KeyboardHookCallback KeyUp;

        private IntPtr hookID = IntPtr.Zero;

        public void Install()
        {
            hookHandler = HookFunc;
            hookID = SetHook(hookHandler);
        }

        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        private IntPtr SetHook(KeyboardHookHandler proc)
        {
            using (ProcessModule module = Process.GetCurrentProcess().MainModule)
                return SetWindowsHookEx(13, proc, GetModuleHandle(module.ModuleName), 0);
        }

        private IntPtr HookFunc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int iwParam = wParam.ToInt32();

                if ((iwParam == WM_KEYDOWN || iwParam == WM_SYSKEYDOWN))
                {
                    KeyDown?.Invoke((Keys)Marshal.ReadInt32(lParam));
                }

                if ((iwParam == WM_KEYUP || iwParam == WM_SYSKEYUP))
                {
                    KeyUp?.Invoke((Keys)Marshal.ReadInt32(lParam));
                }
            }

            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }

        public void OnKeyPressed(Keys key)
        {
            if (key == Keys.LShiftKey)
            {
                label1.Text = "Received";
                SystemParametersInfo(SPI_SETMOUSESPEED, 0, slowerSpeed, 0);
            }
        }

        public void OnKeyReleased(Keys key)
        {
            if (key == Keys.LShiftKey)
            {
                label1.Text = "1";
                SystemParametersInfo(SPI_SETMOUSESPEED, 0, mouseSpeed, 0);
            }
        }

        public unsafe Form1()
        {
            InitializeComponent();

            int speed;

            int hotkeyID = 0;
            RegisterHotKey(this.Handle, hotkeyID, (int)KeyModifier.Shift, Keys.H.GetHashCode());

            KeyDown += OnKeyPressed;
            KeyUp += OnKeyReleased;

            Install();

            SystemParametersInfo(SPI_GETMOUSESPEED, 0, new IntPtr(&speed), 0);

            mouseSpeed = (UInt32)speed;

            slowerSpeed = (UInt32)(0.3 * mouseSpeed);

            label1.Text = slowerSpeed.ToString();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                label1.Text = "Recieved";
                SystemParametersInfo(SPI_SETMOUSESPEED, 0, slowerSpeed, 0);
                label1.Text = "Slowed";

                Thread.Sleep(100);

                SystemParametersInfo(SPI_SETMOUSESPEED, 0, mouseSpeed, 0);
                label1.Text = "Restored";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, 0);
            UnhookWindowsHookEx(hookID);
        }
    }
}
