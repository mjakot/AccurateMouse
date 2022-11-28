using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SlowerMouse
{
    internal class MouseManager
    {
        [DllImport("User32.dll")]
        static extern Boolean SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, UInt32 pvParam, UInt32 fWinIni);
        [DllImport("User32.dll")]
        static extern Boolean SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, IntPtr pvParam, UInt32 fWinIni);

        private const UInt32 SPI_SETMOUSESPEED = 0x0071;
        private const UInt32 SPI_GETMOUSESPEED = 0x0070;

        private UInt32 normalSpeed;
        private UInt32 slowerSpeed;

        public float percentage { private get; set; }

        public MouseManager(int percentage)
        {
            this.percentage = percentage / 100f;

            GetMouseSpeeds();
        }

        private unsafe void GetMouseSpeeds()
        {
            int speed;

            SystemParametersInfo(SPI_GETMOUSESPEED, 0, new IntPtr(&speed), 0);

            normalSpeed = (UInt32)speed;
            slowerSpeed = (UInt32)(speed * percentage);
        }

        private bool IsKeyValid(Keys key)
        {
            if (key == Keys.LShiftKey)
            {
                return true;
            }

            return false;
        }

        public bool SlowDown(Keys key)
        {
            if (IsKeyValid(key))
            {
                SystemParametersInfo(SPI_SETMOUSESPEED, 0, slowerSpeed, 0);

                return true;
            }
            return false;
        }

        public bool SpeedUp(Keys key)
        {
            if (IsKeyValid(key))
            {
                SystemParametersInfo(SPI_SETMOUSESPEED, 0, normalSpeed, 0);

                return true;
            }
            return false;
        }
    }
}
