using FullMin.Model;
using FullMin.Service;
using FullMin.TravellingSalesman;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace FullMin
{
    public partial class FormHoa : Form
    {
        private Graphics graphics;
        private readonly DrawShape drawShape;
        private readonly RetangleSelectService retangleSelectService;
        private LedModel led, pointMouse;
        private MenuModel menuDraw = new MenuModel();
        private List<PointF> point = new List<PointF>();
        private Location[] _bestSolutionSoFar;
        public FormHoa()
        {
            InitializeComponent();
            drawShape = new DrawShape();
            retangleSelectService = new RetangleSelectService();
            graphics = ptb_DrawLead.CreateGraphics();
            CreateMatrixPoints(5, 5, 25);

        }

        #region -------event------
        private void ptb_DrawLead_Paint(object sender, PaintEventArgs e)
        {
            //graphics.Clear(Color.Black);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (menuDraw.Home)
            {
                //draw border mouse move
                retangleSelectService.PaintSelect(e.Graphics, drawShape);
            }
            //if (menuDraw.Home && point.Count > 3 && !SelectMouse)
            //{
            //    polygonPath = new GraphicsPath();
            //    using (Pen pen = new Pen(Color.Blue, 2)
            //    {
            //        DashStyle = DashStyle.Custom
            //    })
            //    {

            //        e.Graphics.DrawPolygon(pen, point.ToArray());
            //        polygonPath.AddPolygon(point.ToArray());

            //    }
            //    //find point inside polygon
            //    drawShape.CheckPointInPolygon(polygonPath);
            //}
            //if (SelectMouse && rectangleSelect.Width == 0 && point.Count > 2)
            //{
            //    using (Pen pen = new Pen(Color.Blue, 2)
            //    {
            //        DashStyle = DashStyle.Custom
            //    })
            //    {
            //        int width = Convert.ToInt32(Math.Abs(point[0].X - point[1].X));
            //        int heigth = Convert.ToInt32(Math.Abs(point[0].Y - point[3].Y));
            //        rectangleSelect = new Rectangle(Convert.ToInt32(point[0].X), Convert.ToInt32(point[0].Y), width, heigth);
            //        // viền hình
            //        e.Graphics.DrawRectangle(pen, rectangleSelect);
            //        // Tạo đối tượng SolidBrush với màu xanh và độ mờ
            //        Color greenColor = Color.FromArgb(100, Color.Blue);
            //        SolidBrush brush = new SolidBrush(greenColor);
            //        // Vẽ hình chữ nhật với màu fill
            //        e.Graphics.FillRectangle(brush, rectangleSelect);

            //        //drawShape.DrawingCurveSelected(point, e.Graphics);
            //        brush.Dispose();
            //    }

            //}
            //if(menuDraw.Home && point.Count > 3 && rectangleSelect.Width > 0)
            //{
            //    using (Pen pen = new Pen(Color.Blue, 2)
            //    {
            //        DashStyle = DashStyle.Custom
            //    })
            //    {
            //        e.Graphics.DrawRectangle(pen, rectangleSelect);

            //        Color greenColor = Color.FromArgb(100, Color.Blue);

            //        // Tạo đối tượng SolidBrush với màu xanh và độ mờ
            //        SolidBrush brush = new SolidBrush(greenColor);

            //        // Vẽ hình chữ nhật với màu fill
            //        e.Graphics.FillRectangle(brush, rectangleSelect);
            //        brush.Dispose();
            //    }
            //}

            drawShape.DrawingListShape(e.Graphics);
            if (pointMouse != null && menuDraw.Pen) drawShape.DrawingShape(pointMouse, e.Graphics);



        }
        private void ptb_DrawLead_MouseDown(object sender, MouseEventArgs e)
        {
            if (menuDraw.Pen)
            {
                led = new LedModel() { color = Color.White, pointStart = new PointF() { X = e.X, Y = e.Y } };
                drawShape.AddShape(led);
                ResetPaint();
            }
            if (menuDraw.Home)
            {
                retangleSelectService.StartSelect(e.Location);
                retangleSelectService.StartDistanceSelect(e.Location);
            }
            //if (menuDraw.Home && rectangleSelect.Width == 0 && e.Button == MouseButtons.Left)
            //{
            //    point = new List<PointF>();
            //    point.Add(new PointF(e.Location.X, e.Location.Y));

            //}
            //if (menuDraw.Home && rectangleSelect.Width > 0)
            //{
            //    polygonPath = new GraphicsPath();
            //    polygonPath.AddRectangle(rectangleSelect);
            //    if (polygonPath.IsVisible(e.Location))
            //    {
            //        MouserectangleSelect = e.Location;
            //    }
            //    else if (SelectMouse)
            //    {
            //        point = new List<PointF>();
            //        point.Add(new PointF(e.Location.X, e.Location.Y));
            //        rectangleSelect = new Rectangle();
            //        SelectMouse = false;
            //    }
            //}
        }
        private void ptb_DrawLead_MouseMove(object sender, MouseEventArgs e)
        {
            //vẽ
            if (menuDraw.Pen)
            {
                pointMouse = new LedModel() { color = Color.Red, pointStart = new PointF() { X = e.X, Y = e.Y } };
                ResetPaint();
            }
            if (menuDraw.Home)
            {
                //vẽ polygon select
                retangleSelectService.DrawingSelect(e.Location, e.Button, ptb_DrawLead);
                //hover retangle select
                retangleSelectService.MouseMoveSelect(e.Location, ptb_DrawLead);
            }
            //if (e.Button == MouseButtons.Left && menuDraw.Home && rectangleSelect.Width == 0 && e.Location.X > 1)
            //{
            //    if (point.Count > 2) point.RemoveRange(1, 3);
            //    point.Add(new PointF(e.Location.X, point[0].Y));
            //    point.Add(new PointF(e.Location.X, e.Location.Y));
            //    point.Add(new PointF(point[0].X, e.Location.Y));
            //    ResetPaint();
            //}
            //hover Rectangle select
            //if (rectangleSelect != null && rectangleSelect.Width > 0 && menuDraw.Home)
            //{
            //    polygonPath = new GraphicsPath();
            //    polygonPath.AddRectangle(rectangleSelect);
            //    if (polygonPath.IsVisible(e.Location))
            //    {
            //        ptb_DrawLead.Cursor = Cursors.SizeAll;
            //        if (MouserectangleSelect.X > 0 && e.Button == MouseButtons.Left)
            //        {
            //            distance = new Point((e.Location.X - MouserectangleSelect.X), (e.Location.Y - MouserectangleSelect.Y));
            //            rectangleSelect.X = rectangleSelect.X + distance.X;
            //            rectangleSelect.Y = rectangleSelect.Y + distance.Y;
            //            ChangeDistanceByShape(distance);
            //            MouserectangleSelect = e.Location;

            //            ResetPaint();
            //        }
            //    }else
            //        ptb_DrawLead.Cursor = Cursors.Default;
            //}

        }
        private void ptb_DrawLead_MouseUp(object sender, MouseEventArgs e)
        {
            if (menuDraw.Home)
            {
                retangleSelectService.EndSelect(ptb_DrawLead, e.Location);
                retangleSelectService.EndSDistanceSelect(e.Location);
                //SelectMouse = true;
                //UpdateCurveSelected();
                //ResetPaint();
            }
            //if (rectangleSelect != null && rectangleSelect.Width > 0 && menuDraw.Home && (distance.X != 0 || distance.Y != 0))
            //{
            //    distance = new Point(0, 0);
            //    ChangeDistanceByShape(distance);
            //}

        }


        private void rjButton1_MouseClick(object sender, MouseEventArgs e)
        {
            menuDraw.ClearAll();
            menuDraw.Pen = true;
            //textBox1.Visible = true;

        }

        private void rjButton2_Click(object sender, System.EventArgs e)
        {
            menuDraw.ClearAll();
            menuDraw.Home = true;
            //textBox1.Visible = true;
            //menuDraw.currentShape = true;
            ptb_DrawLead.Cursor = Cursors.Default;
        }

        private void rjButton3_Click(object sender, System.EventArgs e)
        {
            menuDraw.ClearAll();
            menuDraw.PenCharacter = true;
            //textBox1.Visible = true;
        }

        #endregion

        private void ChangeDistanceByShape(Point distance)
        {
            foreach (var item in DataStatic.listShape)
            {
                if (item.isSelect)
                {
                    item.distance = distance;
                }
            }
        }
        private void ResetPaint()
        {
            ptb_DrawLead.Invalidate();
        }



        public List<List<Point>> CreateMatrixPoints(int rows, int columns, int pointSpacing)
        {
            List<List<Point>> matrixPoints = new List<List<Point>>();

            for (int row = 0; row < rows; row++)
            {
                List<Point> rowPoints = new List<Point>();

                for (int column = 0; column < columns; column++)
                {
                    Point point = new Point(column * pointSpacing, row * pointSpacing);
                    rowPoints.Add(point);
                    led = new LedModel() { color = Color.White, pointStart = new PointF() { X = point.X, Y = point.Y } };
                    drawShape.AddShape(led);
                }

                matrixPoints.Add(rowPoints);
            }

            return matrixPoints;
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormHoa_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(rjBt_home, "Hello");
        }

        private void ptb_DrawLead_Click(object sender, EventArgs e)
        {

        }

        private void rBt_delete_Click(object sender, EventArgs e)
        {
            if (retangleSelectService.CheckExitsAreaSelected())
            {
                drawShape.RemoveShapExistSelect();
                retangleSelectService.EndSelect(ptb_DrawLead, new Point() { X = 0, Y = 0 });
            }
        }

        private void rjBt_CreateLine_Click(object sender, EventArgs e)
        {
            
            int count = DataStatic.listShape.Count;
            List<Point> lspoint = new List<Point>();
            for (int i = 0; i < count; i++)
            {
                lspoint.Add(new Point((int)DataStatic.listShape[i].pointStart.X, (int)DataStatic.listShape[i].pointStart.Y));
                //locations[i - 1] = new Location((int)DataStatic.listShape[i].pointStart.X, (int)DataStatic.listShape[i].pointStart.Y);
            }
            //TSPNew tSPNew = new TSPNew();
            //var lstpoint = tSPNew.SolveTSP(lspoint);
            MST mSTtoTSP = new MST();
            var lstpoint = mSTtoTSP.MSTtoTSP(lspoint);
            // Optimize the tour using the 2-Opt algorithm
            List<Point> optimizedTour = mSTtoTSP.TwoOpt(lstpoint);

            List<LineModel> lines = new List<LineModel>();
            //lines.Add(new LineModel() { pointStart = DataStatic.listShape[0].pointStart, pointEnd = new PointF(bestSolutionSoFar[0].X, bestSolutionSoFar[0].Y) });
            for (int i = 0; i < optimizedTour.Count -1; i++)
            {
                lines.Add(new LineModel() { pointStart = new PointF(optimizedTour[i].X, optimizedTour[i].Y), pointEnd = new PointF(optimizedTour[i + 1].X, optimizedTour[i + 1].Y) });
            }
            DataStatic.listLine = lines;
            ResetPaint();

            //OrTool orTool = new OrTool();
            //orTool.init();
            //TravellingSalesmanAlgorithm algorithm = new TravellingSalesmanAlgorithm(startLocation, locations, (count - 1) * 2);
            //while (true)
            //{
            //    algorithm.MustMutateFailedCrossovers = false;
            //    algorithm.MustDoCrossovers = true;
            //    algorithm.Reproduce();

            //    //if (_mutateDuplicates)
            //    //    algorithm.MutateDuplicates();

            //    var newSolution = algorithm.GetBestSolutionSoFar().ToArray();
            //    if (_bestSolutionSoFar != null && !newSolution.SequenceEqual(_bestSolutionSoFar))
            //    {
            //        _bestSolutionSoFar = newSolution;
            //        paint(algorithm);
            //        break;
            //    }
            //    _bestSolutionSoFar = newSolution;
            //}



        }
        private void paint(TravellingSalesmanAlgorithm algorithm)
        {
            var bestSolutionSoFar = algorithm.GetBestSolutionSoFar().ToArray();
            List<LineModel> lines = new List<LineModel>();
            lines.Add(new LineModel() { pointStart = DataStatic.listShape[0].pointStart, pointEnd = new PointF(bestSolutionSoFar[0].X, bestSolutionSoFar[0].Y) });
            for (int i = 0; i < bestSolutionSoFar.Length - 1; i++)
            {
                lines.Add(new LineModel() { pointStart = new PointF(bestSolutionSoFar[i].X, bestSolutionSoFar[i].Y), pointEnd = new PointF(bestSolutionSoFar[i + 1].X, bestSolutionSoFar[i + 1].Y) });
            }
            DataStatic.listLine = lines;
            ResetPaint();
        }

        //private void FormHoa_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if(e.Control && e.KeyCode == Keys.V && retangleSelectService.CheckExitsAreaSelected())
        //    {
        //        drawShape.CloneShape();
        //        retangleSelectService.UpdateCurveSelected();
        //        ResetPaint();
        //    }
        //}

        private void rBt_clone_Click(object sender, EventArgs e)
        {
            if (retangleSelectService.CheckExitsAreaSelected())
            {
                drawShape.CloneShape();
                retangleSelectService.UpdateCurveSelected();
                ResetPaint();
            }
        }

    }
}
