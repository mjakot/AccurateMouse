using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SlowerMouse
{
    internal class KeyboardHook
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, KeyboardHookHandler lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private delegate IntPtr KeyboardHookHandler(int nCode, IntPtr wParam, IntPtr lParam);
        public delegate void KeyboardHookCallback();

        private KeyboardHookHandler hookHandler;

        public event KeyboardHookCallback KeyDown;
        public event KeyboardHookCallback KeyUp;

        private IntPtr hookID = IntPtr.Zero;

        private const int WM_KEYDOWN = 0x100;
        private const int WM_SYSKEYDOWN = 0x104;
        private const int WM_KEYUP = 0x101;
        private const int WM_SYSKEYUP = 0x105;

        public void Install()
        {
            hookHandler = HookFunc;
            hookID = SetHook(hookHandler);
        }

        public void UnInstall()
        {
            UnhookWindowsHookEx(hookID);
        }

        private IntPtr SetHook(KeyboardHookHandler proc)
        {
            using (ProcessModule module = Process.GetCurrentProcess().MainModule)
            {
                return SetWindowsHookEx(13, proc, GetModuleHandle(module.ModuleName), 0);
            }
        }

        private IntPtr HookFunc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int iwParam = wParam.ToInt32();

                if ((iwParam == WM_KEYDOWN || iwParam == WM_SYSKEYDOWN))
                {
                    Keys key = ((Keys)Marshal.ReadInt32(lParam));

                    if (key == Keys.LShiftKey)
                    {
                        KeyDown?.Invoke();
                    }
                }

                if ((iwParam == WM_KEYUP || iwParam == WM_SYSKEYUP))
                {
                    Keys key = (Keys)Marshal.ReadInt32(lParam);

                    if (key == Keys.LShiftKey)
                    {

                        KeyUp?.Invoke();
                    }
                }
            }

            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }
    }
}
