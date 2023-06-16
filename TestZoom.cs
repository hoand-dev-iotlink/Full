using OpenTK.Graphics.OpenGL;
using System;
using OpenTK;
using OpenTK.Graphics;
using System.Windows.Forms;
using System.Drawing;

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
        public TestZoom()
        {
            InitializeComponent();
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

            drawCircle(5, 5, 5);
            drawCircle(5, 5, 20);
            drawCircle(5, 5, 35);
            
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
            // Chọn hình ảnh hiện tại để vẽ
            //Bitmap currentFrame = frames[currentFrameIndex];

            //// Chuyển đổi hình ảnh BMP thành dữ liệu pixel dùng cho OpenGL texture
            //BitmapData bitmapData = currentFrame.LockBits(new Rectangle(0, 0, currentFrame.Width, currentFrame.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
            //currentFrame.UnlockBits(bitmapData);

            //GL.Color3(Color.White);
            GL.Begin(BeginMode.TriangleFan);
            //GL.Color3(Color.Red); // Sử dụng màu từ giá trị HSV
            GL.Color3(isLightOn ? colors[currentColorIndex] : Color.Red);

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
    }
}
