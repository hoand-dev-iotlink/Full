using FullMin.Model;
using FullMin.Service;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Windows.Forms;

namespace FullMin
{
    public partial class MainForm : Form
    {
        //zoom
        private PointF lastMousePos;
        private float zoomFactor = 1.0f, offsetX, offsetY; // Tỷ lệ phóng ban đầu
        private readonly LedService ledService;


        public MainForm()
        {         
            InitializeComponent();
            ledService = new LedService();
            glControl_main.MouseWheel += glControl_main_MouseLeave;
            glControl_main.MouseMove += glControl_main_MouseMove;
        }

        #region ---------Event zoom---------
        private void glControl_main_MouseLeave(object sender, MouseEventArgs e)
        {
            // Phóng to hoặc thu nhỏ khi cuộn chuột
            if (e.Delta > 0)
                zoomFactor *= 1.1f; // Tăng tỷ lệ phóng thêm 10%
            else
                zoomFactor *= 0.9f; // Giảm tỷ lệ phóng đi 10%
            glControl_main.Invalidate(); // Vẽ lại OpenGL
        }

        private void glControl_main_Load(object sender, System.EventArgs e)
        {
            GL.Viewport(0, 0, glControl_main.Width, glControl_main.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, glControl_main.Width, glControl_main.Height, 0, -1, 1);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            glControl_main.SwapBuffers();
        }

        private void glControl_main_Resize(object sender, System.EventArgs e)
        {
            GL.Viewport(0, 0, glControl_main.Width, glControl_main.Height);
        }

        private void glControl_main_MouseMove(object sender, MouseEventArgs e)
        {
            // Kéo chuột để di chuyển khung nhìn
            if (e.Button == MouseButtons.Left)
            {
                PointF delta = new PointF(e.Location.X - lastMousePos.X, e.Location.Y - lastMousePos.Y);
                offsetX += delta.X / zoomFactor; // Áp dụng di chuyển theo tỷ lệ phóng
                offsetY += delta.Y / zoomFactor; // Áp dụng di chuyển theo tỷ lệ phóng
                lastMousePos = e.Location;

                glControl_main.Invalidate(); // Vẽ lại OpenGL
            }
        }
        #endregion

        private void glControl_main_Paint(object sender, PaintEventArgs e)
        {

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();
            GL.Scale(zoomFactor, zoomFactor, 1.0f); // Áp dụng tỷ lệ phóng
                                                    // Vẽ đối tượng OpenGL của bạn
            GL.Translate(offsetX, offsetY, 0);

            int x = 5, y = 5;
            for (int i = 0; i < 100; i++)
            {

                y = 5;
                for (int j = 0; j < 10; j++)
                {
                    PointColorModel point = new PointColorModel() { point = new Point() { X = x, Y = y } };
                    ledService.DrawLead(point);
                    //lights.Add(new Light(x, y,));
                    y = ((j + 1) * 15) + 5;
                }
                x = ((i + 1) * 15) + 5;
            }

            glControl_main.SwapBuffers();
        }
    }
}
