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
        public Point pointStart { get; set; }
        public Point pointEnd { get; set; } = new Point();
        public Color color { get; set; } = Color.White;
        public bool isFill { get; set; } = true;
       

    }
}
