using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullMin.Service
{
    public class RetangleSelectService: IRetangleSelectService
    {
        private List<PointF> points = new List<PointF>();
        private Rectangle rectangleSelect = new Rectangle();
        private bool isDrawSelect = true;
        private GraphicsPath polygonPath = new GraphicsPath();
        private Point distancePoint= new Point();

        public void DrawingSelect(Point point, MouseButtons buttons, PictureBox ptb_DrawLead)
        {
            if (isDrawSelect && buttons == MouseButtons.Left)
            {
                if (points.Count > 2) points.RemoveRange(1, 3);
                points.Add(new PointF(point.X, points[0].Y));
                points.Add(new PointF(point.X, point.Y));
                points.Add(new PointF(points[0].X, point.Y));
                ptb_DrawLead.Invalidate();
            }
        }

        public void EndSelect(PictureBox ptb_DrawLead)
        {
            if (isDrawSelect)
            {
                isDrawSelect = false;
                points = new List<PointF>();
                UpdateCurveSelected();
                ptb_DrawLead.Invalidate();
            }
            else
            {
                isDrawSelect = true;
                ptb_DrawLead.Invalidate();
            }
        }

        public void MouseMoveSelect(Point point, PictureBox ptb_DrawLead)
        {
            if (CheckInsideRectangle(point))
            {
                ptb_DrawLead.Cursor = Cursors.SizeAll;
                if (distancePoint.X > 0) {
                    MoveDistanceSelect(point);
                    ptb_DrawLead.Invalidate();
                //{
                //    distance = new Point((e.Location.X - MouserectangleSelect.X), (e.Location.Y - MouserectangleSelect.Y));
                //    rectangleSelect.X = rectangleSelect.X + distance.X;
                //    rectangleSelect.Y = rectangleSelect.Y + distance.Y;
                //    ChangeDistanceByShape(distance);
                //    MouserectangleSelect = e.Location;

                    //    ResetPaint();
                }
            }
            else
                ptb_DrawLead.Cursor = Cursors.Default;
        }

        public void PaintSelect(Graphics graphics, DrawShape drawShape)
        {
            if (isDrawSelect && points.Count > 2) //drawing select
            {
                polygonPath = new GraphicsPath();
                using (Pen pen = new Pen(Color.Blue, 2)
                {
                    DashStyle = DashStyle.Custom
                })
                {
                    graphics.DrawPolygon(pen, points.ToArray());
                    polygonPath.AddPolygon(points.ToArray());
                }
                //find point inside polygon
                drawShape.CheckPointInPolygon(polygonPath);
            }
            DrawRetangle(graphics);
            
        }

        public void StartSelect(Point pointStart)
        {
            if (isDrawSelect)
            {
                ResetAllSelect();
                points = new List<PointF>();
                points.Add(new PointF(pointStart.X, pointStart.Y));
                
            }
        }

        public void StartDistanceSelect(Point pointStart)
        {
            if (CheckInsideRectangle(pointStart))
            {
                if (distancePoint.X == 0) distancePoint = pointStart;
            }
        }
        public void EndSDistanceSelect(Point pointEnd)
        {
            if (CheckInsideRectangle(pointEnd))
            {
                distancePoint = new Point(0, 0);
                ChangeDistanceByShape(distancePoint);
            }
            
        }


        #region-----private----

        private void DrawRetangle(Graphics graphics)
        {
            using (Pen pen = new Pen(Color.Blue, 2)
            {
                DashStyle = DashStyle.Custom
            })
            {
                // viền hình
                graphics.DrawRectangle(pen, rectangleSelect);
                // Tạo đối tượng SolidBrush với màu xanh và độ mờ
                Color greenColor = Color.FromArgb(100, Color.Blue);
                SolidBrush brush = new SolidBrush(greenColor);
                // Vẽ hình chữ nhật với màu fill
                graphics.FillRectangle(brush, rectangleSelect);
                brush.Dispose();
            }
        }

        private void UpdateCurveSelected()
        {
            var listShape = DataStatic.listShape.FindAll(x => x.isSelect);
            List<PointF> points = new List<PointF>();
            points.Add(new PointF(0, 0));
            points.Add(new PointF(0, 0));
            points.Add(new PointF(0, 0));
            float X, Y;
            foreach (var item in listShape)
            {
                //min
                X = points[0].X == 0 ? item.pointStart.X : (points[0].X > item.pointStart.X ? item.pointStart.X : points[0].X);
                Y = points[0].Y == 0 ? item.pointStart.Y : (points[0].Y > item.pointStart.Y ? item.pointStart.Y : points[0].Y);
                points[0] = new PointF(X, Y);
                //max
                X = points[2].X == 0 ? item.pointStart.X : (points[2].X < item.pointStart.X ? item.pointStart.X : points[2].X);
                Y = points[2].Y == 0 ? item.pointStart.Y : (points[2].Y < item.pointStart.Y ? item.pointStart.Y : points[2].Y);
                points[2] = new PointF(X, Y);
            }
            points[0] = new PointF(points[0].X - 3, points[0].Y - 3);
            points[2] = new PointF(points[2].X + 9, points[2].Y + 9);
            points[1] = new PointF(points[2].X, points[0].Y);
            points.Add(new PointF(points[0].X, points[2].Y));

            int width = Convert.ToInt32(Math.Abs(points[0].X - points[1].X));
            int heigth = Convert.ToInt32(Math.Abs(points[0].Y - points[3].Y));
            rectangleSelect = new Rectangle(Convert.ToInt32(points[0].X), Convert.ToInt32(points[0].Y), width, heigth);

        }

        private void MoveDistanceSelect(Point pointEnd)
        {
            Point distance = new Point((pointEnd.X - distancePoint.X), (pointEnd.Y - distancePoint.Y));
            rectangleSelect.X = rectangleSelect.X + distance.X;
            rectangleSelect.Y = rectangleSelect.Y + distance.Y;
            ChangeDistanceByShape(distance);
            distancePoint = pointEnd;
        }
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
        private void ChangeSelectDistanceByShape(Point distance)
        {
            foreach (var item in DataStatic.listShape)
            {
                if (item.isSelect)
                {
                    item.distance = distance;
                    item.isSelect = false;
                }
            }
        }
        private bool CheckInsideRectangle(Point pointStart)
        {
            polygonPath = new GraphicsPath();
            polygonPath.AddRectangle(rectangleSelect);
            if (polygonPath.IsVisible(pointStart))
            {
                return true;
            }
            return false;
        }
        private void ResetAllSelect()
        {
            rectangleSelect = new Rectangle();
            points = new List<PointF>();
            distancePoint = new Point(0, 0);
            ChangeSelectDistanceByShape(distancePoint);
        }
        #endregion
    }
}
