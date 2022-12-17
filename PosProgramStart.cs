using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visual_project
{
    public partial class PosProgramStart : Form
    {
        public static PosProgramStart start;
        public PosProgramStart()
        {
            InitializeComponent();
            start=this;
            StartPosition = FormStartPosition.CenterScreen; // 폼의 시작위치를 디스플레이의 가운데로 맞춤
        }

        private bool onClick;
        private Point startPoint = new Point(0, 0);
        private void PosProgramStart_MouseDown(object sender, MouseEventArgs e)
        {
            onClick = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void PosProgramStart_MouseMove(object sender, MouseEventArgs e)
        {
            if (onClick)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        private void PosProgramStart_MouseUp(object sender, MouseEventArgs e)
        {
            onClick = false;
        }

        private void PosProgramStart_Click(object sender, EventArgs e)
        {
            Lodings_popup loding = new Lodings_popup();
            loding.ShowDialog();
        }
    }
}
