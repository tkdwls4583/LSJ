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
    public partial class Lodings_popup : Form
    {
        public Lodings_popup()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // 폼의 시작위치를 디스플레이의 가운데로 맞춤
        }

        private int index = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
             
            index %= imageList1.Images.Count;
            label3.Image = imageList1.Images[index++];

            if (index == 9)
            {              
                timer1.Stop();
                Main main = new Main();
                main.ShowDialog();

                this.Close();
                PosProgramStart.start.Close();
            }           
        }

        //private bool onClick;
        //private Point startPoint = new Point(0, 0);
        //private void PosProgramStart_MouseDown(object sender, MouseEventArgs e)
        //{
        //    onClick = true;
        //    startPoint = new Point(e.X, e.Y);
        //}

        //private void PosProgramStart_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (onClick)
        //    {
        //        Point p = PointToScreen(e.Location);
        //        Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
        //    }
        //}

        //private void PosProgramStart_MouseUp(object sender, MouseEventArgs e)
        //{
        //    onClick = false;
        //}

    }
}
