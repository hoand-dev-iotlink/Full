using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMin.Service
{
    public interface IDrawShape
    {
        void DrawingListShape(Graphics graphics);
        void DrawingShape(Shape shape, Graphics graphics);
        void AddShape(Shape shape);
        void RemoveShape(Shape shape);
    }
}
