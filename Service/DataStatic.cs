using FullMin.Model;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMin.Service
{
    public static class DataStatic
    {
        public static List<Shape> listShape { get; set; } = new List<Shape>();
        public static List<GraphicsPath> listPointResize { get; set; } = new List<GraphicsPath>();
        public static List<LineModel> listLine { get; set; } = new List<LineModel>();

    }
}
