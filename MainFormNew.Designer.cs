
namespace FullMin
{
    partial class MainFormNew
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormNew));
            this.glControl1 = new OpenTK.GLControl();
            this.cb_animation = new System.Windows.Forms.ComboBox();
            this.Lvw_HieUng = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rjButton4 = new FullMin.Service.RJButton();
            this.rjButton3 = new FullMin.Service.RJButton();
            this.rjButton1 = new FullMin.Service.RJButton();
            this.rjButton2 = new FullMin.Service.RJButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(170, 100);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(1177, 619);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            this.glControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseMove);
            this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
            // 
            // cb_animation
            // 
            this.cb_animation.BackColor = System.Drawing.Color.White;
            this.cb_animation.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_animation.FormattingEnabled = true;
            this.cb_animation.Location = new System.Drawing.Point(2, 100);
            this.cb_animation.Name = "cb_animation";
            this.cb_animation.Size = new System.Drawing.Size(167, 27);
            this.cb_animation.Sorted = true;
            this.cb_animation.TabIndex = 1;
            this.cb_animation.Text = "Hiệu ứng nền";
            this.cb_animation.SelectedIndexChanged += new System.EventHandler(this.cb_animation_SelectedIndexChanged);
            // 
            // Lvw_HieUng
            // 
            this.Lvw_HieUng.BackColor = System.Drawing.Color.Black;
            this.Lvw_HieUng.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lvw_HieUng.ForeColor = System.Drawing.Color.Blue;
            this.Lvw_HieUng.HideSelection = false;
            this.Lvw_HieUng.Location = new System.Drawing.Point(2, 130);
            this.Lvw_HieUng.Margin = new System.Windows.Forms.Padding(0);
            this.Lvw_HieUng.Name = "Lvw_HieUng";
            this.Lvw_HieUng.Size = new System.Drawing.Size(167, 589);
            this.Lvw_HieUng.TabIndex = 3;
            this.Lvw_HieUng.UseCompatibleStateImageBehavior = false;
            this.Lvw_HieUng.View = System.Windows.Forms.View.List;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rjButton4);
            this.panel1.Controls.Add(this.rjButton3);
            this.panel1.Controls.Add(this.rjButton1);
            this.panel1.Controls.Add(this.rjButton2);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(167, 97);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Loại đèn";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "6803",
            "9803",
            "1903",
            "988",
            "2801",
            "2812",
            "16703",
            "1914"});
            this.comboBox1.Location = new System.Drawing.Point(4, 62);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(55, 25);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.Text = "6803";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "-RGB",
            "-RBG",
            "-GRB",
            "-GBR",
            "-BRG",
            "-BGR"});
            this.comboBox2.Location = new System.Drawing.Point(72, 62);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(62, 25);
            this.comboBox2.TabIndex = 11;
            this.comboBox2.Text = "-RGB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(69, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Mã màu";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(171, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1176, 97);
            this.panel2.TabIndex = 6;
            // 
            // rjButton4
            // 
            this.rjButton4.ActiveColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton4.BackColor = System.Drawing.Color.Black;
            this.rjButton4.BackgroundColor = System.Drawing.Color.Black;
            this.rjButton4.BorderColor = System.Drawing.Color.White;
            this.rjButton4.BorderRadius = 20;
            this.rjButton4.BorderSize = 2;
            this.rjButton4.FlatAppearance.BorderSize = 0;
            this.rjButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton4.ForeColor = System.Drawing.Color.White;
            this.rjButton4.HoverColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton4.Image = ((System.Drawing.Image)(resources.GetObject("rjButton4.Image")));
            this.rjButton4.Location = new System.Drawing.Point(121, 0);
            this.rjButton4.Name = "rjButton4";
            this.rjButton4.Size = new System.Drawing.Size(40, 40);
            this.rjButton4.TabIndex = 7;
            this.rjButton4.TextColor = System.Drawing.Color.White;
            this.rjButton4.UseVisualStyleBackColor = false;
            // 
            // rjButton3
            // 
            this.rjButton3.ActiveColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton3.BackColor = System.Drawing.Color.Black;
            this.rjButton3.BackgroundColor = System.Drawing.Color.Black;
            this.rjButton3.BorderColor = System.Drawing.Color.White;
            this.rjButton3.BorderRadius = 20;
            this.rjButton3.BorderSize = 2;
            this.rjButton3.FlatAppearance.BorderSize = 0;
            this.rjButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton3.ForeColor = System.Drawing.Color.White;
            this.rjButton3.HoverColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton3.Image = ((System.Drawing.Image)(resources.GetObject("rjButton3.Image")));
            this.rjButton3.Location = new System.Drawing.Point(80, 0);
            this.rjButton3.Name = "rjButton3";
            this.rjButton3.Size = new System.Drawing.Size(40, 40);
            this.rjButton3.TabIndex = 6;
            this.rjButton3.TextColor = System.Drawing.Color.White;
            this.rjButton3.UseVisualStyleBackColor = false;
            // 
            // rjButton1
            // 
            this.rjButton1.ActiveColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BackColor = System.Drawing.Color.Black;
            this.rjButton1.BackgroundColor = System.Drawing.Color.Black;
            this.rjButton1.BorderColor = System.Drawing.Color.White;
            this.rjButton1.BorderRadius = 20;
            this.rjButton1.BorderSize = 2;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.HoverColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.Image = ((System.Drawing.Image)(resources.GetObject("rjButton1.Image")));
            this.rjButton1.Location = new System.Drawing.Point(40, 0);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(40, 40);
            this.rjButton1.TabIndex = 5;
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            // 
            // rjButton2
            // 
            this.rjButton2.ActiveColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton2.BackColor = System.Drawing.Color.Black;
            this.rjButton2.BackgroundColor = System.Drawing.Color.Black;
            this.rjButton2.BorderColor = System.Drawing.Color.White;
            this.rjButton2.BorderRadius = 20;
            this.rjButton2.BorderSize = 2;
            this.rjButton2.FlatAppearance.BorderSize = 0;
            this.rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton2.ForeColor = System.Drawing.Color.White;
            this.rjButton2.HoverColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton2.Image = ((System.Drawing.Image)(resources.GetObject("rjButton2.Image")));
            this.rjButton2.Location = new System.Drawing.Point(0, 0);
            this.rjButton2.Name = "rjButton2";
            this.rjButton2.Size = new System.Drawing.Size(40, 40);
            this.rjButton2.TabIndex = 4;
            this.rjButton2.TextColor = System.Drawing.Color.White;
            this.rjButton2.UseVisualStyleBackColor = false;
            this.rjButton2.Click += new System.EventHandler(this.rjButton2_Click);
            // 
            // MainFormNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Lvw_HieUng);
            this.Controls.Add(this.cb_animation);
            this.Controls.Add(this.glControl1);
            this.Name = "MainFormNew";
            this.Text = "TestZoom";
            this.Load += new System.EventHandler(this.MainFormNew_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.ComboBox cb_animation;
        private System.Windows.Forms.ListView Lvw_HieUng;
        private System.Windows.Forms.ImageList imageList1;
        private Service.RJButton rjButton2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private Service.RJButton rjButton4;
        private Service.RJButton rjButton3;
        private Service.RJButton rjButton1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
    }
}