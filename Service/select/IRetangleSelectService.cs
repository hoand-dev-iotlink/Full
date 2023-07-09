using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullMin.Service
{
    public interface IRetangleSelectService
    {
        void StartSelect(Point pointStart);
        void DrawingSelect(Point point, MouseButtons buttons, PictureBox ptb_DrawLead);
        void EndSelect(PictureBox ptb_DrawLead);
        void PaintSelect(Graphics graphics, DrawShape drawShape);
        void MouseMoveSelect(Point point, PictureBox ptb_DrawLead);
        void StartDistanceSelect(Point pointStart);

        void EndSDistanceSelect(Point pointEnd);
    }
}
