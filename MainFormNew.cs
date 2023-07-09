using OpenTK.Graphics.OpenGL;
using System;
using OpenTK;
using OpenTK.Graphics;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using FullMin.Service;
using FullMin.Model;

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
        //private double transitionDuration = 2.0; // Thời gian chuyển đổi màu (tính bằng giây)
        //private double elapsedTime = 0.0; // Thời gian đã trôi qua
        public MainFormNew()
        {
            InitializeComponent();
            ledService = new LedService();
            colorPointService = new ColorPointService();
            //GetBitmap();
            glControl1.MouseWheel += glControl1_MouseWheel;
            glControl1.MouseMove += glControl1_MouseMove;
            glControl1.MouseDown += glControl1_MouseDown;
            bitmap = colorPointService.GetBitmap("path_to_image.bmp");

            timer1 = new Timer();
            timer1.Interval = 5; // Thời gian thay đổi màu (ms)
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }
        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();
            GL.Scale(zoomFactor, zoomFactor, 1.0f); // Áp dụng tỷ lệ phóng
                                                    // Vẽ đối tượng OpenGL của bạn
            GL.Translate(offsetX, offsetY, 0);
            ////vẽ lead test
            //int x = 5, y = 5;
            //for (int i = 0; i < 100; i++)
            //{

            //    y = 5;
            //    for (int j = 0; j < 10; j++)
            //    {
            //        //drawCircle(5, x, y);
            //        PointColorModel pointColorModel = new PointColorModel() { point = new Point() { X = x, Y = y },color=Color.Red };
            //        ledService.DrawLead(pointColorModel);
            //        y = ((j + 1) * 15) + 5;
            //    }
            //    x = ((i + 1) * 15) + 5;
            //}
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
        //private void glControl1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        isDragging = false;
        //    }
        //}

        //private void glControl1_Scroll(object sender, ScrollEventArgs e)
        //{

        //}

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

        //private void drawCircle(float radius, float x, float y)
        //{
        //    GL.Begin(BeginMode.TriangleFan);
        //    GL.Color3(isLightOn ? colors[currentColorIndex] : Color.Red);
        //    float x1 = x >= bitmap.Width ? (x - bitmap.Width) : x;
        //    var pixelColor = bitmap.GetPixel((int)x1, (int)y);
        //    //var color = new Color(pixelColor.R, pixelColor.G, pixelColor.B, 255);
        //    GL.Color3(pixelColor.R, pixelColor.G, pixelColor.B);
        //    for (int i = 0; i < 360; i++)
        //    {
        //        double degInRad = i * 3.1416 / 180;
        //        GL.Vertex2(Math.Cos(degInRad) * radius + x, Math.Sin(degInRad) * radius + y);
        //    }
        //    GL.End();
        //    GL.PopMatrix();
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    timer1.Start();
        //}

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

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    timer1.Stop();
        //    isLightOn = false;
        //    glControl1.Invalidate();
        //}


        private void DrawLedByList(List<PointColorModel> pointColorModels,bool check =false)
        {
            foreach (var item in pointColorModels)
            {
                ledService.DrawLead(item,check);
            }
        }
    }
}
