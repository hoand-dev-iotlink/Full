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
            RectangleF circleRectPr = new RectangleF(pointStart.X, pointStart.Y, 5 * 2, 5 * 2);
            path.AddEllipse(circleRectPr);
            return path;
        }

    }
}
