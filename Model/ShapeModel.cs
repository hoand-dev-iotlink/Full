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
    public abstract class ShapeModel
    {
        private Color c = Color.White;
        private bool isselect = false;
        public PointF pointStart { get; set; }
        public PointF pointEnd { get; set; } = new PointF();
        public Point distance { get; set; } = new Point(0, 0);
        public Color color { 
            get { return c; }
            set { c = value; }
        }
        public bool isFill { get; set; } = true;
        public bool isSelect {
            get { return isselect; }
            set
            {
                isselect = value;
                color = value ? Color.Red : Color.White;
            }
        }
       

    }
}
