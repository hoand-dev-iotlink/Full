using OpenTK.Graphics.OpenGL;
using System;
using OpenTK;
using OpenTK.Graphics;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using FullMin.Service;
using FullMin.Model;
using FullMin.Service.objectAnimation;
using Newtonsoft.Json;

namespace FullMin
{
    public partial class MainFormNew : Form
    {
        private float zoomFactor = 1.0f, offsetX, offsetY; // Tỷ lệ phóng ban đầu
        private PointF lastMousePos;
        private Bitmap bitmap;
        private List<PointColorModel> pointColorModels;
        private int currentFrame = 0;
        private Timer timer1;

        private readonly LedService ledService;
        private readonly ColorPointService colorPointService;
        private readonly ObjectAnimationService objectAnimationService;
        public MainFormNew()
        {
            InitializeComponent();
            ledService = new LedService();
            colorPointService = new ColorPointService();
            objectAnimationService = new ObjectAnimationService();
            glControl1.MouseWheel += glControl1_MouseWheel;
            glControl1.MouseMove += glControl1_MouseMove;
            glControl1.MouseDown += glControl1_MouseDown;
            bitmap = colorPointService.GetBitmap("path_to_image.bmp");

            //timer1 = new Timer();
            //timer1.Interval = 5; // Thời gian thay đổi màu (ms)
            //timer1.Tick += timer1_Tick;
            //timer1.Start();

            AddListAnimation();
        }
        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();
            GL.Scale(zoomFactor, zoomFactor, 1.0f); // Áp dụng tỷ lệ phóng
                                                    // Vẽ đối tượng OpenGL của bạn
            GL.Translate(offsetX, offsetY, 0);
            
            pointColorModels = ledService.TestLead(100);
            

            pointColorModels = colorPointService.GetColor(bitmap, pointColorModels, currentFrame);
            DrawLedByList(pointColorModels);
            glControl1.SwapBuffers();
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, glControl1.Width, glControl1.Height, 0, -1, 1);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
        }

        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            // Kéo chuột để di chuyển khung nhìn
            if (e.Button == MouseButtons.Left)
            {
                PointF delta = new PointF(e.Location.X - lastMousePos.X, e.Location.Y - lastMousePos.Y);
                PointF delta1 = new PointF(e.Location.X - lastMousePos.X, e.Location.Y - lastMousePos.Y);
                offsetX += delta.X / zoomFactor; // Áp dụng di chuyển theo tỷ lệ phóng
                offsetY += delta.Y / zoomFactor; // Áp dụng di chuyển theo tỷ lệ phóng
                lastMousePos = e.Location;
                //log.Log(string.Format("offsetX={0},offsetY={1},offsetX={2}, offsetY={3}", offsetX, offsetY, delta1.X, delta1.Y));
                glControl1.Invalidate(); // Vẽ lại OpenGL
            }
        }
        private void glControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            // Phóng to hoặc thu nhỏ khi cuộn chuột
            if (e.Delta > 0)
                zoomFactor *= 1.1f; // Tăng tỷ lệ phóng thêm 10%
            else
                zoomFactor *= 0.9f; // Giảm tỷ lệ phóng đi 10%
            glControl1.Invalidate(); // Vẽ lại OpenGL
        }
        private void glControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lastMousePos = e.Location;
            }
        }
        

        private void glControl1_Resize(object sender, EventArgs e)
        {
            // Cập nhật kích thước viewport khi khung hình thay đổi
            //viewportSize = new SizeF(glControl1.Width, glControl1.Height);
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
        }

        private void MainFormNew_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormHoa formHoa = new FormHoa();
            formHoa.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //isLightOn = true; // Chuyển đổi trạng thái đèn LED
            //currentColorIndex = (currentColorIndex + 1) % colors.Length; // Thay đổi chỉ số màu sắc
            //glControl1.Invalidate(); // Vẽ lại OpenGL

            // Tăng currentFrameIndex lên mỗi lần tick
            currentFrame += 10;
            // Cập nhật màu cho các đèn LED
            //UpdateLEDColors();
            pointColorModels = colorPointService.GetColor(bitmap, pointColorModels, currentFrame);
            DrawLedByList(pointColorModels);

           

            // Nếu đã vượt quá số frame của hình bitmap, đặt currentFrameIndex về 0
            if (currentFrame >= bitmap.Width)
            {
                currentFrame = 0;
            }

            // Render lại
            glControl1.Invalidate();

        }

        private void cb_animation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            var selectedEmployee = ((SelectItem)cb_animation.SelectedItem);
            //Lvw_HieUng.Items.Clear();
            Lvw_HieUng.Clear();
            imageList1.Images.Clear();
            objectAnimationService.AddAnimation(selectedEmployee.value, imageList1, Lvw_HieUng);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            FormHoa formHoa = new FormHoa();
            formHoa.ShowDialog();
        }

        private void DrawLedByList(List<PointColorModel> pointColorModels,bool check =false)
        {
            foreach (var item in pointColorModels)
            {
                ledService.DrawLead(item,check);
            }
        }
        private void AddListAnimation()
        {
            objectAnimationService.AddAnimation("AnimationBackground", imageList1, Lvw_HieUng);
            cb_animation.DisplayMember = "Text";
            cb_animation.ValueMember = "Value";
            cb_animation.Items.Add(new SelectItem() { text= "Hiệu ứng nền", value = "AnimationBackground" });
            cb_animation.Items.Add(new SelectItem() { text = "Hiệu ứng viền", value = "AnimationBorder" });
            cb_animation.Items.Add(new SelectItem() { text = "Hiệu ứng hình ảnh", value = "AnimationImage" });
            cb_animation.Items.Add(new SelectItem() { text = "Hiệu ứng chữ", value = "AnimationText" });
            cb_animation.Items.Add(new SelectItem() { text = "Hiệu ứng động", value = "AnimationActive" });
        }
    }
}
