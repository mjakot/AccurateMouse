using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SlowerMouse
{
    internal class MouseSlowDown
    {
        [DllImport("User32.dll")]
        static extern Boolean SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, UInt32 pvParam, UInt32 fWinIni);
        [DllImport("User32.dll")]
        static extern Boolean SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, IntPtr pvParam, UInt32 fWinIni);

        private const UInt32 SPI_SETMOUSESPEED = 0x0071;
        private const UInt32 SPI_GETMOUSESPEED = 0x0070;

        private UInt32 normalSpeed;
        private UInt32 slowerSpeed;

        public float precentage { private get; set; }

        public MouseSlowDown(float precentage)
        {
            this.precentage = precentage / 100f;

            GetMouseSpeeds();
        }

        private unsafe void GetMouseSpeeds()
        {
            int speed;

            SystemParametersInfo(SPI_GETMOUSESPEED, 0, new IntPtr(&speed), 0);

            normalSpeed = (UInt32)speed;
            slowerSpeed = (UInt32)(speed * precentage);
        }

        public void SlowDown()
        {
            SystemParametersInfo(SPI_SETMOUSESPEED, 0, slowerSpeed, 0);
        }

        public void SpeedUp()
        {
            SystemParametersInfo(SPI_SETMOUSESPEED, 0, normalSpeed, 0);
        }
    }
}
