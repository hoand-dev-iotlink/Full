using FullMin.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMin.Service
{
    public class ColorPointService
    {
        public List<PointColorModel> GetColor(Bitmap bitmap, List<PointColorModel> points, int frameIndex)
        {
            // Tính toán vị trí tương ứng trên hình bitmap cho mỗi đèn LED
            //int ledCount = ledColors.Count;
            int bitmapWidth = bitmap.Width;
            int bitmapHeight = bitmap.Height;
            int x, y;
            for (int i = 0; i < points.Count; i++)
            {
                // Tính toán vị trí X và Y trên hình bitmap dựa trên chỉ số đèn LED
                x = (frameIndex + points[i].point.X) % bitmapWidth;// (int)((float)i / (ledCount - 1) * (bitmapWidth - 1));
                y = points[i].point.Y % bitmapHeight;
                
                // Lấy màu từ pixel tương ứng trên hình bitmap
                
                Color pixelColor = bitmap.GetPixel(x, y);
                //string hexValue = ColorTranslator.ToHtml(pixelColor);
                //log.Log(string.Format("x={0},y={1},color={2}", x, y, hexValue));

                // Cập nhật màu cho đèn LED
                points[i].color = pixelColor;
            }
            return points;
        }
        public Bitmap GetBitmap(string name)
        {
            string path = String.Format(@"..\..\image\{0}", name);
            Bitmap bitmap = new Bitmap(path);
            return bitmap;
        }
    }
}
