using FullMin.Model;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMin.Service
{
    public class LedService
    {
        public int radius = 5;
        public void DrawLead(PointColorModel pointColor,bool check =false)
        {
            GL.Begin(BeginMode.TriangleFan);
            GL.Color3(pointColor.color);
            //float x1 = x >= bitmap.Width ? (x - bitmap.Width) : x;
            //var pixelColor = bitmap.GetPixel((int)x1, (int)y);
            //var color = new Color(pixelColor.R, pixelColor.G, pixelColor.B, 255);
            //GL.Color3(pixelColor.R, pixelColor.G, pixelColor.B);
            if (!check)
            {
                for (int i = 0; i < 360; i++)
                {
                    double degInRad = i * 3.1416 / 180;
                    GL.Vertex2(Math.Cos(degInRad) * radius + pointColor.point.X, Math.Sin(degInRad) * radius + pointColor.point.Y);
                }
            }
            
            GL.End();
            GL.PopMatrix();
        }

        public List<PointColorModel> TestLead(int countLed)
        {
            List<PointColorModel> listPointColorModels = new List<PointColorModel>();
            //vẽ lead test
            int x = 5, y = 5;
            for (int i = 0; i < countLed; i++)
            {

                y = 5;
                for (int j = 0; j < 5; j++)
                {
                    //drawCircle(5, x, y);
                    PointColorModel pointColorModel = new PointColorModel() { point = new Point() { X = x, Y = y }, color = Color.Red };
                    //ledService.DrawLead(pointColorModel);
                    listPointColorModels.Add(pointColorModel);
                    y = ((j + 1) * 15) + 5;
                }
                x = ((i + 1) * 15) + 5;
            }
            return listPointColorModels;
        }
    }
}
