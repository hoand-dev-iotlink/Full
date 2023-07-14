using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging;
using AForge.Imaging.Filters;
using FullMin.Service;
using OpenTK.Graphics.OpenGL;

namespace FullMin
{
    public partial class Test : Form
    {
        private Bitmap bitmap; // Bitmap tạm thời để vẽ các điểm
        private Graphics graphics; // Graphics object để vẽ lên bitmap
        public Test()
        {
            
            InitializeComponent();
            bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
            graphics = Graphics.FromImage(bitmap);
            // Thiết lập các thuộc tính OpenGLControl

        }

        private void Test_Load(object sender, EventArgs e)
        {



        }

        //private void glControl_test_Paint(object sender, PaintEventArgs e)
        //{
        //    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        //    Font font = new Font("Arial", 24, FontStyle.Regular, GraphicsUnit.Pixel);

        //    // Thiết lập màu và vị trí của chữ
        //    Brush brush = Brushes.Black;
        //    PointF location = new PointF(50, 50);

        //    // Vẽ chữ lên bitmap
        //    string text = "LED!";
        //    graphics.DrawString(text, font, brush, location);

        //    e.Graphics.DrawImage(bitmap, Point.Empty);
        //}

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //Font font = new Font("Arial", 200, FontStyle.Regular, GraphicsUnit.Pixel);

            //// Thiết lập màu và vị trí của chữ
            //Brush brush = Brushes.Black;
            //PointF location = new PointF(50, 50);

            //// Vẽ chữ lên bitmap
            //string text = "LED!";
            //graphics.DrawString(text, font, brush, location);

            //e.Graphics.DrawImage(bitmap, Point.Empty);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                // Thiết lập font chữ và kích thước
                Font font = new Font("Arial", 24, FontStyle.Regular, GraphicsUnit.Pixel);

                // Thiết lập màu và vị trí của chữ
                Brush brush = Brushes.Red;
                PointF location = new PointF(50, 50);

                // Vẽ chữ lên bitmap
                string text = "Hello, World!";
                graphics.DrawString(text, font, brush, location);
            }
            bitmap.Save("output.png");
            Bitmap bitmap1 = new Bitmap("output.png");

            Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayImage = grayscaleFilter.Apply(bitmap1);

            // Lấy tất cả các điểm trong hình ảnh chữ
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.ProcessImage(grayImage);
            Blob[] blobs = blobCounter.GetObjectsInformation();
            // In ra tọa độ của từng điểm
            foreach (Blob blob in blobs)
            {
                var a = blobCounter.GetBlobsEdgePoints(blob);
                Console.WriteLine("Điểm: X = {0}, Y = {1}", blob.CenterOfGravity.X, blob.CenterOfGravity.Y);
            }
        }
    }
}
