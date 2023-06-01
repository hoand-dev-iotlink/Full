
namespace FullMin
{
    partial class Test
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
            this.glControl_test = new OpenTK.GLControl();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // glControl_test
            // 
            this.glControl_test.BackColor = System.Drawing.Color.Black;
            this.glControl_test.Location = new System.Drawing.Point(194, 53);
            this.glControl_test.Name = "glControl_test";
            this.glControl_test.Size = new System.Drawing.Size(856, 504);
            this.glControl_test.TabIndex = 0;
            this.glControl_test.VSync = false;
            this.glControl_test.Load += new System.EventHandler(this.glControl_test_Load);
            this.glControl_test.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_test_Paint);
            this.glControl_test.Resize += new System.EventHandler(this.glControl_test_Resize);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 589);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.glControl_test);
            this.Name = "Test";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Test_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl glControl_test;
        private System.Windows.Forms.Button button1;
    }
}