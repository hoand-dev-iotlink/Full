using FullMin.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMin.Model
{
    public class LineModel : Shape
    {
        public override void DrawingShape(Graphics graphics)
        {
            using (GraphicsPath path = graphicsPath())
            {
                using (Brush pen = new SolidBrush(color))
                {
                    graphics.FillPath(pen, path);
                }
            }
        }

        protected override GraphicsPath graphicsPath()
        {
            GraphicsPath path = new GraphicsPath();
            if (distance.X != 0 || distance.Y != 0)
            {
                pointStart = new PointF(pointStart.X + distance.X, pointStart.Y + distance.Y);
                pointEnd = new PointF(pointEnd.X + distance.X, pointEnd.Y + distance.Y);
            }
            path.AddLine(pointStart, pointEnd);
            //RectangleF circleRectPr = new RectangleF(pointStart.X, pointStart.Y, 3 * 2, 3 * 2);
            //path.AddEllipse(circleRectPr);
            return path;
        }
    }
}
