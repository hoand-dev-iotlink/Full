using FullMin.Model;
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
            foreach (var line in DataStatic.listLine)
            {
                line.DrawingShape(graphics);
            }
        }

        public void RemoveShape(Shape shape)
        {
            DataStatic.listShape.Remove(shape);
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
        public void CloneShape()
        {
            List<Shape> shapes = DataStatic.listShape.Where(x => x.isSelect).ToList();
            foreach (var item in shapes)
            {
                Point point = new Point() { X = (int)item.pointStart.X + 5, Y = (int)item.pointStart.Y + 5 };
                NewShapeDefault(point, Color.Red,true);
                item.isSelect = false;
            }
        }
        public void NewShapeDefault(Point point, Color colorp,bool isSelectp = false)
        {
            LedModel led = new LedModel() { color = colorp, pointStart = new PointF() { X = point.X, Y = point.Y },isSelect= isSelectp };
            AddShape(led);
        }

        public void RemoveShapExistSelect()
        {
            int shapes = DataStatic.listShape.RemoveAll(x => x.isSelect);
        }
    }
}
