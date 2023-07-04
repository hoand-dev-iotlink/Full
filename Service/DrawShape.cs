using System;
using System.Collections.Generic;
using System.Drawing;
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
    }
}
