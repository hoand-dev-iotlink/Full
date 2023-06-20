using OpenTK.Graphics.OpenGL;
using System;
using OpenTK;
using OpenTK.Graphics;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using FullMin.Service;

namespace FullMin
{
    public partial class TestZoom : Form
    {
        private float hue; // Biến thay đổi màu
        private float zoomFactor = 1.0f; // Tỷ lệ phóng ban đầu
        private float offsetX, offsetY;
        private Color[] colors = { Color.Green, Color.Green, Color.Blue,Color.White,Color.Brown };
        private int currentColorIndex = 0; // Chỉ số màu sắc hiện tại
        private bool isLightOn = false; // Trạng thái đèn LED
        private bool isDragging;
        private PointF lastMousePos;
        private Bitmap bitmap;
        private List<Light> lights;

        private double transitionDuration = 2.0; // Thời gian chuyển đổi màu (tính bằng giây)
        private double elapsedTime = 0.0; // Thời gian đã trôi qua
        public TestZoom()
        {
            InitializeComponent();
            GetBitmap();
            glControl1.MouseWheel += glControl1_MouseWheel;
            glControl1.MouseMove += glControl1_MouseMove;
            timer1 = new Timer();
            timer1.Interval = 1000; // Thời gian thay đổi màu (ms)
            timer1.Tick += timer1_Tick;
        }

        private void TestZoom_Load(object sender, EventArgs e)
        {

        }
        private void TestZoom_Paint(object sender, PaintEventArgs e)
        {

        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();
            GL.Scale(zoomFactor, zoomFactor, 1.0f); // Áp dụng tỷ lệ phóng
                                                    // Vẽ đối tượng OpenGL của bạn
            GL.Translate(offsetX, offsetY, 0);
            //vẽ lead test
            int x = 5, y = 5;
            for (int i = 0; i < 100; i++)
            {

                y = 5;
                for (int j = 0; j < 10; j++)
                {
                    drawCircle(5, x, y);
                    //lights.Add(new Light(x, y,));
                    y = ((j + 1) * 15) + 5;
                }
                x = ((i + 1) * 15) + 5;
            }
            //vẽ lead with image
            //for(int i=0;i<1000;i++)
            //{
            //    Color currentColor = lights[i].GetColor(elapsedTime, transitionDuration);
            //    lights[i].Draw(currentColor);
            //}

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
                offsetX += delta.X / zoomFactor; // Áp dụng di chuyển theo tỷ lệ phóng
                offsetY += delta.Y / zoomFactor; // Áp dụng di chuyển theo tỷ lệ phóng
                lastMousePos = e.Location;

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
                isDragging = true;
                lastMousePos = e.Location;
            }
        }
        private void glControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void glControl1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            // Cập nhật kích thước viewport khi khung hình thay đổi
            //viewportSize = new SizeF(glControl1.Width, glControl1.Height);
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
        }
        private void drawCircle(float radius, float x, float y)
        {
            GL.Begin(BeginMode.TriangleFan);
            GL.Color3(isLightOn ? colors[currentColorIndex] : Color.Red);
            float x1 = x >= bitmap.Width ? (x - bitmap.Width) : x;
            var pixelColor = bitmap.GetPixel((int)x1, (int)y);
            //var color = new Color(pixelColor.R, pixelColor.G, pixelColor.B, 255);
            GL.Color3(pixelColor.R, pixelColor.G, pixelColor.B);
            for (int i = 0; i < 360; i++)
            {
                double degInRad = i * 3.1416 / 180;
                GL.Vertex2(Math.Cos(degInRad) * radius + x, Math.Sin(degInRad) * radius + y);
            }
            GL.End();
            GL.PopMatrix();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            isLightOn = true; // Chuyển đổi trạng thái đèn LED
            currentColorIndex = (currentColorIndex + 1) % colors.Length; // Thay đổi chỉ số màu sắc
            glControl1.Invalidate(); // Vẽ lại OpenGL
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            isLightOn = false;
            glControl1.Invalidate();
        }

        private Color ColorFromHSV(float hue, float saturation, float value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            float f = hue / 60 - (float)Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }

        private void GetBitmap()
        {
            bitmap = new Bitmap(@"..\..\image\path_to_image.bmp");
            lights = new List<Light>();

            // Tạo danh sách đèn và đặt màu ban đầu cho mỗi đèn
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    lights.Add(new Light(x, y, pixelColor));
                }
            }
        }
    }
}
