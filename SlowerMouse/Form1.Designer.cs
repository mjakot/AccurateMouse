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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PercentageUpDown = new System.Windows.Forms.NumericUpDown();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GoToTrayButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PercentageUpDown)).BeginInit();
            this.TrayMenuStrip.SuspendLayout();
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
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.TrayMenuStrip;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "Slower Your Mouse";
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // TrayMenuStrip
            // 
            this.TrayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.TrayMenuStrip.Name = "contextMenuStrip1";
            this.TrayMenuStrip.Size = new System.Drawing.Size(104, 48);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // GoToTrayButton
            // 
            this.GoToTrayButton.Location = new System.Drawing.Point(95, 21);
            this.GoToTrayButton.Name = "GoToTrayButton";
            this.GoToTrayButton.Size = new System.Drawing.Size(75, 23);
            this.GoToTrayButton.TabIndex = 2;
            this.GoToTrayButton.Text = "Go to tray";
            this.GoToTrayButton.UseVisualStyleBackColor = true;
            this.GoToTrayButton.Click += new System.EventHandler(this.GoToTrayButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 68);
            this.Controls.Add(this.GoToTrayButton);
            this.Controls.Add(this.PercentageUpDown);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.PercentageUpDown)).EndInit();
            this.TrayMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NumericUpDown PercentageUpDown;
        private NotifyIcon NotifyIcon;
        private ContextMenuStrip TrayMenuStrip;
        private ToolStripMenuItem showToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Button GoToTrayButton;
    }
}