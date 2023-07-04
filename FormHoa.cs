using FullMin.Model;
using FullMin.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullMin
{
    public partial class FormHoa : Form
    {
        private Graphics graphics;
        private List<PictureBox> list = new List<PictureBox>();
        private List<PointF> points = new List<PointF>();
        private PointF pointMove = new PointF();
        private Bitmap bitmap;
        private readonly DrawShape drawShape;
        private LedModel led,pointMouse;
        public FormHoa()
        {
            InitializeComponent();
            drawShape = new DrawShape();
            graphics = ptb_DrawLead.CreateGraphics();

        }

        #region -------test xóa them------
        //public FormHoa()
        //{
        //    InitializeComponent();
        //    //graphics = panel1.CreateGraphics();
        //    // Đăng ký các sự kiện chuột và phím
        //    this.MouseDown += FormHoa_MouseDown;
        //    this.MouseMove += FormHoa_MouseMove;
        //    this.MouseUp += FormHoa_MouseUp;
        //    this.KeyDown += FormHoa_KeyDown;
        //}
        //private List<Point> points = new List<Point>();
        //private Point selectedPoint = Point.Empty;
        //private bool isDragging = false;
        //private Point dragOffset = Point.Empty;


        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);

        //    Graphics g = e.Graphics;

        //    // Vẽ các điểm đã lưu
        //    foreach (Point point in points)
        //    {
        //        DrawPoint(g, point);
        //    }

        //    // Nếu có điểm được chọn, vẽ vùng chọn
        //    if (!selectedPoint.IsEmpty)
        //    {
        //        DrawSelection(g, selectedPoint);
        //    }
        //}

        //private void DrawPoint(Graphics g, Point point)
        //{
        //    // Vẽ một hình tròn tại vị trí của điểm
        //    int radius = 5;
        //    int diameter = radius * 2;
        //    Rectangle circleRect = new Rectangle(point.X - radius, point.Y - radius, diameter, diameter);
        //    g.FillEllipse(Brushes.Red, circleRect);
        //}

        //private void DrawSelection(Graphics g, Point point)
        //{
        //    // Vẽ một vùng chọn xung quanh điểm được chọn
        //    int radius = 7;
        //    int diameter = radius * 2;
        //    Rectangle selectionRect = new Rectangle(point.X - radius, point.Y - radius, diameter, diameter);
        //    g.DrawEllipse(Pens.Blue, selectionRect);
        //}

        //private void FormHoa_MouseDown(object sender, MouseEventArgs e)
        //{
        //    // Kiểm tra xem có điểm nào được chọn hay không
        //    foreach (Point point in points)
        //    {
        //        Rectangle selectionRect = new Rectangle(point.X - 7, point.Y - 7, 14, 14);
        //        if (selectionRect.Contains(e.Location))
        //        {
        //            // Nếu điểm được chọn, lưu vào biến selectedPoint
        //            selectedPoint = point;
        //            isDragging = true;
        //            dragOffset = new Point(e.Location.X - point.X, e.Location.Y - point.Y);
        //            this.Invalidate(); // Vẽ lại để hiển thị vùng chọn
        //            return;
        //        }
        //    }

        //    // Nếu không có điểm nào được chọn, tạo một điểm mới
        //    Point newPoint = new Point(e.Location.X, e.Location.Y);
        //    points.Add(newPoint);
        //    this.Invalidate(); // Vẽ lại để hiển thị điểm mới
        //}

        //private void FormHoa_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (isDragging)
        //    {
        //        // Di chuyển điểm được chọn
        //        selectedPoint = new Point(e.Location.X - dragOffset.X, e.Location.Y - dragOffset.Y);
        //        this.Invalidate(); // Vẽ lại để di chuyển điểm
        //    }
        //}

        //private void FormHoa_MouseUp(object sender, MouseEventArgs e)
        //{
        //    isDragging = false;
        //}

        //private void FormHoa_KeyDown(object sender, KeyEventArgs e)
        //{
        //    // Xóa điểm được chọn khi nhấn phím Delete
        //    if (e.KeyCode == Keys.Delete && !selectedPoint.IsEmpty)
        //    {
        //        points.Remove(selectedPoint);
        //        selectedPoint = Point.Empty;
        //        this.Invalidate(); // Vẽ lại để xóa điểm
        //    }
        //}
        #endregion

        private void ptb_DrawLead_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            drawShape.DrawingListShape(e.Graphics);
            if(pointMouse != null) drawShape.DrawingShape(pointMouse, e.Graphics);
        }

        private void ptb_DrawLead_MouseDown(object sender, MouseEventArgs e)
        {
            led = new LedModel() {color=Color.White,pointStart= new Point() {X=e.X,Y=e.Y } };
            drawShape.AddShape(led);
            ResetPaint();
        }
        private void ResetPaint()
        {
            ptb_DrawLead.Invalidate();
        }

        private void ptb_DrawLead_MouseMove(object sender, MouseEventArgs e)
        {
            pointMouse = new LedModel() { color = Color.Red, pointStart = new Point() { X = e.X, Y = e.Y } };
            ResetPaint();
        }
    }
}
