using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMin.Service
{
    public class Light
    {
        private const float PointSize = 5.0f;
        private const float MaxBrightness = 1.0f;

        private int x;
        private int y;
        private Color initialColor;

        public Light(int x, int y, Color initialColor)
        {
            this.x = x;
            this.y = y;
            this.initialColor = initialColor;
        }

        public Color GetColor(double elapsedTime, double transitionDuration)
        {
            double t = elapsedTime / transitionDuration; // Tính toán thời gian đã trôi qua so với thời gian chuyển đổi

            // Tính toán độ sáng hiện tại dựa trên thời gian chuyển đổi
            float currentBrightness = (float)(MaxBrightness * (1 - t));

            // Tạo màu hiện tại dựa trên màu ban đầu và độ sáng hiện tại
            int currentR = (int)(initialColor.R * currentBrightness);
            int currentG = (int)(initialColor.G * currentBrightness);
            int currentB = (int)(initialColor.B * currentBrightness);

            return Color.FromArgb(currentR, currentG, currentB);
        }

        public void Draw(Color color)
        {
            //GL.PointSize(PointSize);
            //GL.Begin(PrimitiveType.Points);
            //GL.Color3(color);
            //GL.Vertex2(x, y);
            //GL.End();

            GL.Begin(BeginMode.TriangleFan);
            //GL.Color3(Color.Red); // Sử dụng màu từ giá trị HSV
            GL.Color3(color);

            for (int i = 0; i < 360; i++)
            {
                double degInRad = i * 3.1416 / 180;
                GL.Vertex2(Math.Cos(degInRad) * 5 + x, Math.Sin(degInRad) * 5 + y);
            }
            GL.End();
            GL.PopMatrix();
        }
    }
}
