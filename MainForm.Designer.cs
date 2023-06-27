
namespace FullMin
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.glControl_main = new OpenTK.GLControl();
            this.SuspendLayout();
            // 
            // glControl_main
            // 
            this.glControl_main.BackColor = System.Drawing.Color.Black;
            this.glControl_main.Location = new System.Drawing.Point(31, 25);
            this.glControl_main.Name = "glControl_main";
            this.glControl_main.Size = new System.Drawing.Size(1396, 723);
            this.glControl_main.TabIndex = 0;
            this.glControl_main.VSync = false;
            this.glControl_main.Load += new System.EventHandler(this.glControl_main_Load);
            this.glControl_main.Resize += new System.EventHandler(this.glControl_main_Resize);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1465, 773);
            this.Controls.Add(this.glControl_main);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl glControl_main;
    }
}