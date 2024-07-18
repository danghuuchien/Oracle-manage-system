using System;
using System.Windows.Forms;
using System.Drawing;

namespace AdminApp.CustomControls
{
    public class WindowDragger
    {
        private Control control;
        private bool isDragging = false;
        private Point lastPoint;

        public WindowDragger(Control control)
        {
            this.control = control;
            control.MouseDown += Control_MouseDown;
            control.MouseMove += Control_MouseMove;
            control.MouseUp += Control_MouseUp;
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastPoint = new Point(e.X, e.Y);
            }
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                control.Left += e.X - lastPoint.X;
                control.Top += e.Y - lastPoint.Y;
            }
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
    }
}
