using System.Runtime.InteropServices;

namespace SlowerMouse
{
    public partial class Form1 : Form
    {
        MouseSlowener slowener;

        int percentage;

        public Form1()
        {
            InitializeComponent();

            slowener = new MouseSlowener();

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
    }
}