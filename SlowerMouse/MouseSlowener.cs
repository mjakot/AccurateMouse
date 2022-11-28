using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlowerMouse
{
    internal class MouseSlowener
    {
        KeyboardHook hook;
        MouseManager manager;

        public MouseSlowener(int percentage)
        {
            hook = new KeyboardHook();
            manager = new MouseManager(percentage);
        }

        private void SetUp()
        {
            hook.KeyDown += OnKeyDown;
            hook.KeyUp += OnKeyUp;

            hook.Install();
        }

        private void OnKeyUp(Keys key)
        {
            manager.SpeedUp(key);
        }

        private void OnKeyDown(Keys key)
        {
            manager.SlowDown(key);
        }
    }
}
