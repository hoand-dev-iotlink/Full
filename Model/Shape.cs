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
    public abstract class Shape:ShapeModel
    {
        public virtual void DrawingShape(Graphics graphics)
        {
            if (isFill)
            {
                using (GraphicsPath path = graphicsPath())
                {
                    using (Brush pen = new SolidBrush(color))
                    {
                        graphics.FillPath(pen, path);
                    }
                }
            }
        }

        protected virtual GraphicsPath graphicsPath()
        {
            GraphicsPath path = new GraphicsPath();
            if (distance.X != 0 || distance.Y != 0) pointStart = new PointF(pointStart.X + distance.X, pointStart.Y + distance.Y);
            RectangleF circleRectPr = new RectangleF(pointStart.X, pointStart.Y, 3 * 2, 3 * 2);
            path.AddEllipse(circleRectPr);
            return path;
        }

    }
}
