namespace SlowerMouse
{
    internal class MouseSlowener
    {
        KeyboardHook hook;
        MouseManager manager;

        public bool isRunning { get; private set; }

        public void Start(int percentage)
        {
            hook = new KeyboardHook();
            manager = new MouseManager();

            manager.SetMouseSpeeds(percentage);

            hook.KeyDown += Hook_KeyDown;
            hook.KeyUp += Hook_KeyUp;

            hook.Install();

            isRunning = true;
        }

        public void Stop()
        {
            hook.UnInstall();

            hook.KeyDown -= Hook_KeyDown;
            hook.KeyUp -= Hook_KeyUp;

            isRunning = false;
        }

        public void Update(int percentage)
        {
            hook.UnInstall();

            manager.SetMouseSpeeds(percentage);

            hook.Install();
        }

        private void Hook_KeyDown()
        {
            manager.SlowDown();
        }

        private void Hook_KeyUp()
        {
            manager.SpeedUp();
        }
    }
}
