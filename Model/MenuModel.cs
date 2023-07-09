using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMin.Model
{
    public class MenuModel
    {
        public bool Home { get; set; } = true;
        public bool Pen { get; set; } = false;
        public bool PenCharacter { get; set; } = false;
        public bool currentShape { get; set; }
        
        public Rectangle rectangleRegion;

        public void ClearAll()
        {
            Home = false;
            Pen = false;
            PenCharacter = false;
        }

        /// <summary>
        /// Phương thức cập nhật lại một vùng là hình chữ nhật bao quanh hình vẽ
        /// ở chế độ chọn hình
        /// </summary>
        /// <param name="p"></param>
        public void updateRectangleRegion(Point p)
        {
            rectangleRegion.Width = p.X - rectangleRegion.X;
            rectangleRegion.Height = p.Y - rectangleRegion.Y;
        }
    }
}
