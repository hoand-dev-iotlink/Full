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
using FullMin.Service;
using OpenTK.Graphics.OpenGL;

namespace FullMin
{
    public partial class DrawMain : Form
    {

        private Point[] points;
        private Rectangle bbox;
        private int dx = 10; // Giá trị dịch chuyển theo trục X
        private int dy = 10; // Giá trị dịch chuyển theo trục Y

        private float mouseX;
        private float mouseY;
        private float circleRadius = 5f;
        private List<RectangleF> listPoint = new List<RectangleF>();

        private float scaleFactor = 1.0f;
        private RectangleF circleRectPr;
        private RectangleF circleRect;
        private bool isCheckDraw=false;

        private Bitmap bitmap, zoomedBitmap; // Bitmap tạm thời để vẽ các điểm
        private Graphics graphics; // Graphics object để vẽ lên bitmap

        public DrawMain()
        {

            InitializeComponent();
            // Đăng ký sự kiện MouseWheel
            MouseWheel += DrawMain_MouseWheel;
            MouseMove += panel2_MouseMove;
            Invalidated += DrawMain_Invalidated;
            //bitmap = new Bitmap(ClientSize.Width * 5, ClientSize.Height * 5);
            //graphics = Graphics.FromImage(bitmap);
            graphics = panel2.CreateGraphics();
            MouseDown += panel2_MouseDown;


        }

        private void DrawMain_Invalidated(object sender, InvalidateEventArgs e)
        {
            isCheckDraw = false;
        }

        private void DrawMain_Load(object sender, EventArgs e)
        {


        }
        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    graphics = e.Graphics;

        //    graphics.SmoothingMode = SmoothingMode.AntiAlias;

        //    // Tạo ma trận biến đổi dựa trên tỉ lệ zoom
        //    Matrix transformMatrix = new Matrix();
        //    transformMatrix.Scale(scaleFactor, scaleFactor);

        //    // Áp dụng ma trận biến đổi vào đối tượng Graphics
        //    graphics.Transform = transformMatrix;
        //    //g.Tr


        //    // Chuyển đổi tọa độ của chuột từ màn hình sang tọa độ của Form
        //    PointF mousePoint = PointToClient(MousePosition);

        //    //// Vẽ hình tròn tại vị trí chuột
        //    float x = (mousePoint.X / scaleFactor) - circleRadius;
        //    float y = (mousePoint.Y / scaleFactor) - circleRadius;
        //    RectangleF circleRect = new RectangleF(x, y, circleRadius * 2, circleRadius * 2);
        //    graphics.FillEllipse(Brushes.Red, circleRect);

        //    //if (circleRectPr != null && circleRectPr.X > 0 && isCheckDraw)
        //    //{
        //    //    g.FillEllipse(Brushes.White, circleRectPr);
        //    //    isCheckDraw = false;
        //    //}

        //    //using (Pen point = new Pen(Color.White, 1f))
        //    //{
        //    //    foreach (var item in listPoint)
        //    //    {
        //    //        g.FillEllipse(Brushes.White, item);
        //    //    }
        //    //}
        //    //e.Graphics.ScaleTransform(scaleFactor, scaleFactor);
        //    //e.Graphics.DrawImage(bitmap, Point.Empty);


        //}
        
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // Kiểm tra xem chuột có nằm trong bbox không
            //if (bbox.Contains(e.Location))
            //{
            //    // Di chuyển tất cả các điểm trong bbox
            //    for (int i = 0; i < points.Length; i++)
            //    {
            //        points[i] = new Point(points[i].X + dx, points[i].Y + dy);
            //    }

            //    // Vẽ lại Form
            //    //Invalidate();
            //}

            //mouseX = e.X;
            //mouseY = e.Y;

            //PointF delta = new PointF(e.Location.X - lastMousePos.X, e.Location.Y - lastMousePos.Y);
            //PointF delta1 = new PointF(e.Location.X - lastMousePos.X, e.Location.Y - lastMousePos.Y);
            //offsetX += delta.X / zoomFactor; // Áp dụng di chuyển theo tỷ lệ phóng
            //offsetY += delta.Y / zoomFactor; // Áp dụng di chuyển theo tỷ lệ phóng
           
            // Vẽ lại Form khi chuột di chuyển
            float x = (e.X / scaleFactor) - circleRadius;
            float y = (e.Y / scaleFactor) - circleRadius;
            circleRectPr = new RectangleF(x, y, circleRadius * 2, circleRadius * 2);
            isCheckDraw = true;
            //listPoint.Add(circleRect);
            //g.FillEllipse(Brushes.White, circleRect);
            //UpdateBitMap((int)x, (int)y);
            graphics.FillEllipse(Brushes.White, circleRectPr);
            //ZoomIn(circleRectPr);
            //graphics.DrawEllipse(Pens.White, e.X - 5, e.Y - 5, 10, 10);

            // Vẽ bitmap lên màn hình
            //using (Graphics g = CreateGraphics())
            //{
            //    g.DrawImage(bitmap, Point.Empty);
            //}


            // GraphicsPath path = new GraphicsPath();
            // path.AddEllipse(x, y, 10, 10);

            // Vẽ đường viền hình tròn
            //Pen pen = new Pen(Color.White, 2);
            // graphics.DrawPath(pen, path);

            // Vẽ nền hình tròn
            // SolidBrush brush = new SolidBrush(Color.Red);
            // graphics.FillPath(brush, path);

            //if (scaleFactor != 1)
            //{
            //    int newWidth = (int)(ClientSize.Width / scaleFactor);
            //    int newHeight = (int)(ClientSize.Height / scaleFactor);
            //    //ChangeBitmapSize(newWidth, newHeight);
            //}
            //Invalidate();
        }


        private void DrawMain_MouseWheel(object sender, MouseEventArgs e)
        {
            // Kiểm tra hướng cuộn
            if (e.Delta > 0)
            {
                // Zoom in khi cuộn lên
                scaleFactor *= 1.1f;
            }
            else
            {
                // Zoom out khi cuộn xuống
                scaleFactor *= 0.9f;
            }

            // Giới hạn tỉ lệ zoom trong khoảng từ 0.1 đến 10
            scaleFactor = Math.Max(scaleFactor, 0.1f);
            scaleFactor = Math.Min(scaleFactor, 10f);
            
            // Vẽ lại Form khi thay đổi tỉ lệ zoom
            Invalidate();
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            // Vẽ hình tròn tại vị trí chuột
            mouseX = (e.X / scaleFactor) - circleRadius;
            mouseY = (e.Y / scaleFactor) - circleRadius;
            //if (circleRect != null && circleRect.X == 0)
            //{
            //    circleRect = new RectangleF(x, y, circleRadius * 2, circleRadius * 2);
            //    g.FillEllipse(Brushes.Red, circleRect);
            //}else
            //{
            //    circleRect.Y = y;
            //    circleRect.X = x;
            //    g.FillEllipse(Brushes.Red, circleRect);
            //}
            //g.Dispose();
            //panel2.Invalidate();
        }

        private void UpdateBitMap(int x, int y)
        {
            int newWidth = Math.Max(x, bitmap.Width);
            int newHeight = Math.Max(y, bitmap.Height);

            if (newWidth > bitmap.Width || newHeight > bitmap.Height)
            {
                Bitmap newBitmap = new Bitmap(newWidth, newHeight);
                //using (Graphics g = Graphics.FromImage(newBitmap))
                //{
                //    g.DrawImage(bitmap, 0, 0);
                //}
                graphics.DrawImage(bitmap, Point.Empty);
                bitmap.Dispose();
                bitmap = newBitmap;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //g.SmoothingMode = SmoothingMode.AntiAlias;

            //// Tạo ma trận biến đổi dựa trên tỉ lệ zoom
            //Matrix transformMatrix = new Matrix();
            //transformMatrix.Scale(scaleFactor, scaleFactor);

            //// Áp dụng ma trận biến đổi vào đối tượng Graphics
            //g.Transform = transformMatrix;
            PointF mousePoint = PointToClient(MousePosition);
            float x = (mousePoint.X / scaleFactor) - circleRadius;
            float y = (mousePoint.Y / scaleFactor) - circleRadius;
            circleRectPr = new RectangleF(mouseX, mouseY, circleRadius * 2, circleRadius * 2);
            isCheckDraw = true;
            //listPoint.Add(circleRect);
            g.FillEllipse(Brushes.Red, circleRectPr);
            //UpdateBitMap((int)x, (int)y);
            //g.FillEllipse(Brushes.White, circleRectPr);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            float x = (e.X / scaleFactor) - circleRadius;
            float y = (e.Y / scaleFactor) - circleRadius;
            circleRectPr = new RectangleF(x, y, circleRadius * 2, circleRadius * 2);
            graphics.FillEllipse(Brushes.White, circleRectPr);
        }

        private void ChangeBitmapSize(int newWidth, int newHeight)
        {
            // Tạo Bitmap mới với kích thước mới
            Bitmap newBitmap = new Bitmap(newWidth, newHeight);

            // Sử dụng Graphics để vẽ dữ liệu từ Bitmap ban đầu vào Bitmap mới
            using (Graphics newGraphics = Graphics.FromImage(newBitmap))
            {
                newGraphics.DrawImage(bitmap, 0, 0, newWidth, newHeight);
            }
            bitmap = newBitmap;
            // Trả về Bitmap mới đã thay đổi kích thước và sao chép dữ liệu
            //return newBitmap;
        }

    }
}
