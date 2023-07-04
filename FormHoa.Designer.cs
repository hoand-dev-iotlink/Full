
namespace FullMin
{
    partial class FormHoa
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
            this.ptb_DrawLead = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_DrawLead)).BeginInit();
            this.SuspendLayout();
            // 
            // ptb_DrawLead
            // 
            this.ptb_DrawLead.BackColor = System.Drawing.Color.Black;
            this.ptb_DrawLead.Location = new System.Drawing.Point(1, 84);
            this.ptb_DrawLead.Name = "ptb_DrawLead";
            this.ptb_DrawLead.Size = new System.Drawing.Size(1353, 647);
            this.ptb_DrawLead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptb_DrawLead.TabIndex = 0;
            this.ptb_DrawLead.TabStop = false;
            this.ptb_DrawLead.Paint += new System.Windows.Forms.PaintEventHandler(this.ptb_DrawLead_Paint);
            this.ptb_DrawLead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ptb_DrawLead_MouseDown);
            this.ptb_DrawLead.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptb_DrawLead_MouseMove);
            // 
            // FormHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 733);
            this.Controls.Add(this.ptb_DrawLead);
            this.Name = "FormHoa";
            this.Text = "FormHoa";
            ((System.ComponentModel.ISupportInitialize)(this.ptb_DrawLead)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptb_DrawLead;
    }
}