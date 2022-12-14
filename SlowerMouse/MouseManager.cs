using System.Runtime.InteropServices;

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

        public unsafe void SetMouseSpeeds(int percentage)
        {
            int speed;

            SystemParametersInfo(SPI_GETMOUSESPEED, 0, new IntPtr(&speed), 0);

            normalSpeed = (UInt32)speed;
            slowerSpeed = (UInt32)(speed - (speed * percentage) / 100);
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
