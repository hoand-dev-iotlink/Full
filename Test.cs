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
using FullMin.Service;
using OpenTK.Graphics.OpenGL;

namespace FullMin
{
    public partial class Test : Form
    {
        private Bitmap bitmap;
        private List<Color> ledColors;
        private Timer animationTimer;
        private int currentFrameIndex;
        private List<Point>  points ;
        public Test()
        {
            bitmap = new Bitmap(@"..\..\image\path_to_image.bmp");

            // Khởi tạo danh sách màu cho các đèn LED
            ledColors = new List<Color>();
            points = new List<Point>();
            // Thiết lập timer để cập nhật hiệu ứng màu
            animationTimer = new Timer();
            animationTimer.Interval = 5; // Thời gian cập nhật hiệu ứng (milliseconds)
            animationTimer.Tick += AnimationTimer_Tick;

            currentFrameIndex = 0;
            InitializeComponent();
            // Thiết lập các thuộc tính OpenGLControl
            
        }

        private void Test_Load(object sender, EventArgs e)
        {


            //// Initialize the points
            //points = new List<Point>();
            //points.Add(new Point(100, 100));
            //points.Add(new Point(200, 100));
            //points.Add(new Point(300, 100));
            //points.Add(new Point(400, 100));
            //points.Add(new Point(500, 100));
            //points.Add(new Point(600, 100));
            //points.Add(new Point(700, 100));
            //points.Add(new Point(800, 100));
            //points.Add(new Point(900, 100));
            //points.Add(new Point(1000, 100));
            //points.Add(new Point(1100, 100));
            //points.Add(new Point(1200, 100));
            //points.Add(new Point(1300, 100));
            //points.Add(new Point(1400, 100));
            //points.Add(new Point(1500, 100));
            //points.Add(new Point(1600, 100));
            //// drawCircle(5,5,5);
            //// drawCircle(5, 5, 20);
            //// drawCircle(5, 5, 35);

            //// Load the bitmap
            //bitmap = new Bitmap(@"..\..\image\path_to_image.bmp");

            //// Start the animation timer
            //timer.Start();

            glControl_test.MakeCurrent();
            GL.Viewport(0, 0, glControl_test.Width, glControl_test.Height);

            // Thiết lập các thiết bị OpenGL
            SetupOpenGL();

            // Bắt đầu timer
            animationTimer.Start();


        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // Cập nhật màu cho các đèn LED
            UpdateLEDColors();

            // Tăng currentFrameIndex lên mỗi lần tick
            currentFrameIndex +=10;

            // Nếu đã vượt quá số frame của hình bitmap, đặt currentFrameIndex về 0
            if (currentFrameIndex >= bitmap.Width)
            {
                currentFrameIndex = 0;
            }

            // Render lại
            glControl_test.Invalidate();
        }
        private void Draw()
        {
            //// Xóa màn hình
            //GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //// Vẽ hình tròn
            //GL.Color3(Color.Red);  // Đặt màu cho hình tròn
            //GL.Begin(BeginMode.Polygon);
            //for (int i = 0; i < 360; i++)
            //{
            //    double angle = i * Math.PI / 180.0;
            //    double x = Math.Cos(angle);
            //    double y = Math.Sin(angle);
            //    GL.Vertex2(x, y);
            //}
            //GL.End();

            //// Hiển thị hình tròn lên OpenGLControl
            //glControl_test.SwapBuffers();
        }
        private void glControl_test_Resize(object sender, EventArgs e)
        {
            //int w = glControl_test.Width;
            //int h = glControl_test.Height;
            //glControl_test.MakeCurrent();
            //GL.MatrixMode(MatrixMode.Projection);
            //GL.LoadIdentity();
            ////GL.ClearColor(Color.Red);
            //GL.Ortho(-w / 2, w / 2, -h / 2, h / 2, -1, 1);
            //GL.Viewport(0, 0, w, h);
            //GL.End();
            //glControl_test.SwapBuffers();
        }

        private void glControl_test_Paint(object sender, PaintEventArgs e)
        {
            // GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            // GL.MatrixMode(MatrixMode.Projection);
            // //GL.LoadIdentity();
            //// GL.Ortho(-1, 1, -1, 1, -1, 1);

            // GL.MatrixMode(MatrixMode.Modelview);
            // GL.LoadIdentity();

            // drawCircle(5,5,5);
            // drawCircle(5, 5, 20);
            // drawCircle(5, 5, 35);
            // //point();
            // glControl_test.SwapBuffers();

            //GL.Clear(ClearBufferMask.ColorBufferBit);

            //// Draw the current frame
            //Point currentPoint = points[currentFrameIndex];
            //DrawFrame(currentPoint);

            //glControl_test.SwapBuffers();

            // Xóa màn hình
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Lấy kích thước và vị trí đèn LED
            int ledCount = ledColors.Count;
            int ledWidth = 20; // Độ rộng của đèn LED (tùy chỉnh theo yêu cầu)
            int ledHeight = 20; // Chiều cao của đèn LED (tùy chỉnh theo yêu cầu)
            int spacing = 10; // Khoảng cách giữa các đèn LED (tùy chỉnh theo yêu cầu)

            // Vẽ đèn LED
            for (int i = 0; i < ledCount; i++)
            {
                // Tọa độ X của đèn LED
                int x = i * (ledWidth + spacing);

                // Vẽ đèn LED với màu tương ứng
                GL.Begin(PrimitiveType.Quads);
                GL.Color3(ledColors[i]);

                GL.Vertex2(x, 0);
                GL.Vertex2(x + ledWidth, 0);
                GL.Vertex2(x + ledWidth, ledHeight);
                GL.Vertex2(x, ledHeight);
                //points.Add(new Point(x, (ledWidth+ ledHeight) /2));
                GL.End();
            }
            // Swap buffers để hiển thị lên màn hình
            glControl_test.SwapBuffers();
        }
        //private void DrawFrame(Point point)
        //{
        //    // Clear the screen
        //    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        //    // Set up the orthographic projection
        //    GL.MatrixMode(MatrixMode.Projection);
        //    GL.LoadIdentity();
        //    GL.Ortho(0, Width, Height, 0, -1, 1);

        //    // Set up the model view matrix
        //    GL.MatrixMode(MatrixMode.Modelview);
        //    GL.LoadIdentity();

        //    // Translate to the point position
        //    GL.Translate(point.X, point.Y, 0);

        //    // Draw the bitmap
        //    DrawBitmap(bitmap, frameWidth, frameHeight);

        //    // Reset the translation
        //    GL.Translate(-point.X, -point.Y, 0);
        //}

        //private void DrawBitmap(Bitmap bitmap, int width, int height)
        //{
        //    GL.Enable(EnableCap.Texture2D);
        //    GL.TexEnv(TextureEnvTarget.TextureEnv, TextureEnvParameter.TextureEnvMode, (float)TextureEnvMode.Modulate);

        //    // Create a texture from the bitmap
        //    int textureId;
        //    GL.GenTextures(1, out textureId);
        //    GL.BindTexture(TextureTarget.Texture2D, textureId);
        //    BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        //    GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, width, height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
        //    bitmap.UnlockBits(bitmapData);

        //    // Set texture parameters
        //    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (float)TextureMinFilter.Linear);
        //    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (float)TextureMagFilter.Linear);

        //    // Draw a textured quad
        //    GL.Begin(PrimitiveType.Quads);
        //    GL.TexCoord2(0, 0);
        //    GL.Vertex2(0, 0);
        //    GL.TexCoord2(1, 0);
        //    GL.Vertex2(width, 0);
        //    GL.TexCoord2(1, 1);
        //    GL.Vertex2(width, height);
        //    GL.TexCoord2(0, 1);
        //    GL.Vertex2(0, height);
        //    GL.End();

        //    // Clean up the texture
        //    GL.DeleteTextures(1, ref textureId);

        //    GL.Disable(EnableCap.Texture2D);
        //}
        private void Application_Idle(object sender, EventArgs e)
        {
            // Cập nhật giá trị màu
            //hue += 0.01f;
            //if (hue > 1)
            //    hue = 0;

            //glControl_test.Invalidate(); // Yêu cầu vẽ lại control
        }
        private void drawCircle(float radius,float x, float y)
        {
            
        }

        private void SetupOpenGL()
        {
            // Cấu hình OpenGL
            GL.Enable(EnableCap.ColorMaterial);
            GL.Enable(EnableCap.DepthTest);
            GL.ShadeModel(ShadingModel.Smooth);

            // Đặt màu clear cho màn hình
            GL.ClearColor(Color.Black);

            // Đặt phép chiếu
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, glControl_test.Width, glControl_test.Height, 0, -1, 1);

            // Đặt ma trận ModelView
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            // Khởi tạo danh sách màu cho các đèn LED
            int ledCount = 10; // Số lượng đèn LED--------------
            int ledWidth = 20; // Độ rộng của đèn LED (tùy chỉnh theo yêu cầu)
            int ledHeight = 20; // Chiều cao của đèn LED (tùy chỉnh theo yêu cầu)
            int spacing = 10; // Khoảng cách giữa các đèn LED (tùy chỉnh theo yêu cầu)
          
            for (int i = 0; i < ledCount; i++)
            {
                int x = i * (ledWidth + spacing);
                ledColors.Add(Color.Black); // Màu ban đầu của đèn LED
                points.Add(new Point(x, (ledWidth + ledHeight) / 2));
            }
        }

        private void UpdateLEDColors()
        {
            // Tính toán vị trí tương ứng trên hình bitmap cho mỗi đèn LED
            int ledCount = ledColors.Count;
            int bitmapWidth = bitmap.Width;
            int bitmapHeight = bitmap.Height;

            for (int i = 0; i < points.Count; i++)
            {
                // Tính toán vị trí X và Y trên hình bitmap dựa trên chỉ số đèn LED
                int x = currentFrameIndex + points[i].X;// (int)((float)i / (ledCount - 1) * (bitmapWidth - 1));
                int y = points[i].Y;
                x = x >= bitmapWidth ? 0 : x;
                y = y >= bitmapHeight ? 0 : y;
                //log.Log(string.Format("x={0},y={1}", x, y));
                // Lấy màu từ pixel tương ứng trên hình bitmap
                Color pixelColor = bitmap.GetPixel(x, y);
                string hexValue = ColorTranslator.ToHtml(pixelColor);
                //log.Log(string.Format("x={0},y={1},color={2}", x, y, hexValue));

                // Cập nhật màu cho đèn LED
                ledColors[i] = pixelColor;
            }
        }


    }
}
