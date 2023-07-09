using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMin.Service
{
    public class DrawShape : IDrawShape
    {
        public void AddShape(Shape shape)
        {
            DataStatic.listShape.Add(shape);
        }

        public void DrawingListShape(Graphics graphics)
        {
            foreach (var shape in DataStatic.listShape)
            {
                //log.Log(shape.pointStart.X+","+ shape.pointStart.Y + ","+shape.color.Name);
                shape.DrawingShape(graphics);
            }
        }

        public void RemoveShape(Shape shape)
        {
            throw new NotImplementedException();
        }

        public void DrawingShape(Shape shape, Graphics graphics)
        {
            shape.DrawingShape(graphics);
        }
        public void CheckPointInPolygon(System.Drawing.Drawing2D.GraphicsPath polygonPath)
        {
            foreach (var shape in DataStatic.listShape)
            {
                if (polygonPath.IsVisible(shape.pointStart))
                {
                    shape.isSelect = true;
                }else
                    shape.isSelect = false;
            }
        }

        public void DrawingCurveSelected(List<PointF> points, Graphics graphics)
        {
            GraphicsPath path = new GraphicsPath();
            DataStatic.listPointResize = new List<GraphicsPath>();
            float maxX = points.Max(x=>x.X);//? points[0]: points[2];
            float maxY = points.Max(x => x.Y);
            float width = Math.Abs(points[0].X - points[1].X) / 2;
            float heigth = Math.Abs(points[0].Y - points[3].Y) / 2;
            PointF PointMax = points[0].X > points[2].X && points[0].Y > points[2].Y ? points[0]: points[2];
            Rectangle rectangle = new Rectangle(Convert.ToInt32(maxX - 4), Convert.ToInt32(maxY - 4), 8, 8);
            addPointResize(rectangle, 0, 0, graphics,maxX,maxY, path);
            addPointResize(rectangle, width, 0, graphics, maxX, maxY, path);
            addPointResize(rectangle, 0, heigth, graphics, maxX, maxY, path);
            addPointResize(rectangle, 0, (heigth *2) , graphics, maxX, maxY, path, true);

        }
        private void addPointResize(Rectangle rectangle, float width, float height, Graphics graphics,
            float maxX, float maxY,GraphicsPath path, bool isCheck =false)
        {
            rectangle.X = width == 0 ? Convert.ToInt32(maxX - 4) : Convert.ToInt32(maxX - width - 4);
            rectangle.Y = height == 0 ? Convert.ToInt32(maxY - 4) : Convert.ToInt32(maxY - height - 4);
            if (!isCheck) { 
                graphics.FillRectangle(new SolidBrush(Color.Blue), rectangle);
                path.AddRectangle(rectangle);
                DataStatic.listPointResize.Add(path);
            }
            else { 
                graphics.FillEllipse(new SolidBrush(Color.Blue), rectangle);
                path.AddEllipse(rectangle);
                DataStatic.listPointResize.Add(path);
            }


        }
    }
}
