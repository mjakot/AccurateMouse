namespace SlowerMouse
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PercentageUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.PercentageUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // PercentageUpDown
            // 
            this.PercentageUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PercentageUpDown.Location = new System.Drawing.Point(26, 21);
            this.PercentageUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PercentageUpDown.Name = "PercentageUpDown";
            this.PercentageUpDown.Size = new System.Drawing.Size(43, 23);
            this.PercentageUpDown.TabIndex = 1;
            this.PercentageUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.PercentageUpDown.ValueChanged += new System.EventHandler(this.PercentageUpDown_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PercentageUpDown);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PercentageUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NumericUpDown PercentageUpDown;
    }
}