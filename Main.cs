using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace visual_project
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent(); //컴포넌트 초기화
            StartPosition = FormStartPosition.CenterScreen; // 폼의 시작위치를 디스플레이의 가운데로 맞춤
        }
       
        private void button1_Click(object sender, EventArgs e) // 주문 버튼 (주문 창으로 이동)
        {
            this.Visible = false;
            Order showOrder = new Order();
            showOrder.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e) // 시재맞추기 버튼 (시재맞추기 창으로 이동)
        {
            this.Visible = false;
            cash showOrder = new cash();
            showOrder.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e) // 매출조회 버튼 (매출조회 창으로 이동)
        {
            this.Visible = false;
            Sales showOrder = new Sales();
            showOrder.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("종료하시겠습니까?","종료 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private bool onClick;
        private Point startPoint = new Point(0, 0);
        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            onClick = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (onClick)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            onClick = false;
        }
    }
}
