using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;

namespace FullMin
{
    public partial class Test : Form
    {
        private float hue; // Biến thay đổi màu
        private Bitmap[] frames; // Mảng chứa các hình ảnh BMP
        private float rotationAngle; // Góc quay của hình tròn
        private float rotationSpeed; // Tốc độ quay của hình tròn
        private int currentFrameIndex = 0; // Chỉ số hình ảnh hiện tại
        public Test()
        {
            frames = LoadFrames();
            InitializeComponent();
            // Thiết lập các thuộc tính OpenGLControl
            
        }

        private void Test_Load(object sender, EventArgs e)
        {
            //GL.Clear(ClearBufferMask.ColorBufferBit);

            UpdateAnimation();

        }
        private void Draw()
        {
            // Xóa màn hình
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            // Vẽ hình tròn
            GL.Color3(Color.Red);  // Đặt màu cho hình tròn
            GL.Begin(BeginMode.Polygon);
            for (int i = 0; i < 360; i++)
            {
                double angle = i * Math.PI / 180.0;
                double x = Math.Cos(angle);
                double y = Math.Sin(angle);
                GL.Vertex2(x, y);
            }
            GL.End();

            // Hiển thị hình tròn lên OpenGLControl
            glControl_test.SwapBuffers();
        }
        private void glControl_test_Resize(object sender, EventArgs e)
        {
            int w = glControl_test.Width;
            int h = glControl_test.Height;
            glControl_test.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            //GL.ClearColor(Color.Red);
            GL.Ortho(-w / 2, w / 2, -h / 2, h / 2, -1, 1);
            GL.Viewport(0, 0, w, h);
            GL.End();
            glControl_test.SwapBuffers();
        }

        private void glControl_test_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Projection);
            //GL.LoadIdentity();
           // GL.Ortho(-1, 1, -1, 1, -1, 1);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            drawCircle(5,5,5);
            drawCircle(5, 5, 20);
            drawCircle(5, 5, 35);
            //point();
            glControl_test.SwapBuffers();
        }
        //private void Draw_clock()
        //{
        //    drawCircle(80);//80 is radius of the circle
        //    //Draw_digit();
        //}
        private void Application_Idle(object sender, EventArgs e)
        {
            // Cập nhật giá trị màu
            hue += 0.01f;
            if (hue > 1)
                hue = 0;

            glControl_test.Invalidate(); // Yêu cầu vẽ lại control
        }
        private void drawCircle(float radius,float x, float y)
        {
            // Chọn hình ảnh hiện tại để vẽ
            //Bitmap currentFrame = frames[currentFrameIndex];

            //// Chuyển đổi hình ảnh BMP thành dữ liệu pixel dùng cho OpenGL texture
            //BitmapData bitmapData = currentFrame.LockBits(new Rectangle(0, 0, currentFrame.Width, currentFrame.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
            //currentFrame.UnlockBits(bitmapData);

            //GL.Color3(Color.White);
            GL.Begin(BeginMode.TriangleFan);
            GL.Color3(ColorFromHSV(hue, 1, 0.5f)); // Sử dụng màu từ giá trị HSV

            for (int i = 0; i < 360; i++)
            {
                double degInRad = i * 3.1416 / 180;
                GL.Vertex2(Math.Cos(degInRad) * radius + x , Math.Sin(degInRad) * radius + y);
            }
            GL.End();
            GL.PopMatrix();
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
        private void point()
        {

            float pointSize = 10f; // Kích thước của điểm
            float borderRadius = 50f; // Bán kính của border radius

            // Chọn hình ảnh hiện tại để vẽ
            Bitmap currentFrame = frames[currentFrameIndex];

            // Chuyển đổi hình ảnh BMP thành dữ liệu pixel dùng cho OpenGL texture
            BitmapData bitmapData = currentFrame.LockBits(new Rectangle(0, 0, currentFrame.Width, currentFrame.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
            currentFrame.UnlockBits(bitmapData);


            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(-borderRadius, -borderRadius); // Góc dưới bên trái
            GL.Vertex2(-borderRadius, borderRadius); // Góc trên bên trái
            GL.Vertex2(borderRadius, borderRadius); // Góc trên bên phải
            GL.Vertex2(borderRadius, -borderRadius); // Góc dưới bên phải
            GL.End();

            GL.PointSize(pointSize); // Đặt kích thước của điểm
            GL.Color3(Color.Red);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(0, 0); // Tọa độ của điểm
            GL.End();

            //GL.PointSize(pointSize);
            //GL.Color3(Color.Red);  // Đặt màu cho điểm
            //GL.Begin(BeginMode.Points);
            //GL.Vertex2(0, 0);  // Tọa độ của điểm
            //GL.End();
        }
        private Bitmap[] LoadFrames()
        {
            // Đọc các hình ảnh BMP từ thư mục hoặc tệp tin
            // Và trả về mảng các hình ảnh đã đọc

            // Ví dụ:
            string[] filePaths = Directory.GetFiles("image", "2_.bmp");
            List<Bitmap> frames = new List<Bitmap>();

            foreach (string filePath in filePaths)
            {
                Bitmap frame = new Bitmap(filePath);
                frames.Add(frame);
            }

            return frames.ToArray();
        }
        private void UpdateAnimation()
        {
            // Cập nhật góc quay của hình tròn
            rotationAngle += 2;

            // Kiểm tra nếu đã đến hình ảnh cuối cùng trong mảng
            if (currentFrameIndex >= frames.Length - 1)
            {
                // Reset lại chỉ số hình ảnh để quay trở lại hình ảnh đầu tiên
                currentFrameIndex = 0;
            }
            else
            {
                // Tăng chỉ số hình ảnh hiện tại
                currentFrameIndex++;
            }
        }
    }
}
