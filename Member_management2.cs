using menuu;
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
    public partial class Member_management2 : Form
    {
        product product = new product();
        String d;

        public Member_management2()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // 폼의 시작위치를 디스플레이의 가운데로 맞춤
        }
        private void Member_management2_Load(object sender, EventArgs e)
        {
            textBox1.Text = Member_management1.member_Management1.Sp[0]; // 리스트박스의 클릭한 회원정보가 나타남
            d = textBox1.Text.ToString();
            textBox2.Text = Member_management1.member_Management1.Sp[1]; // 리스트박스의 클릭한 회원정보가 나타남
            textBox3.Text = Member_management1.member_Management1.Sp[2] ; // 리스트박스의 클릭한 회원정보가 나타남
        }

        private void button1_Click(object sender, EventArgs e) // 정보수정 버튼
        {
            product.Modifying_information(d, textBox1.Text, textBox2.Text, textBox3.Text);
        }

        private void button2_Click(object sender, EventArgs e) // 회원삭제 버튼
        {
            product.Delete_information(textBox2.Text);
        }

        private void button49_Click(object sender, EventArgs e) // 종료 버튼(창닫기)
        {
            if (MessageBox.Show("종료하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private bool onClick;
        private Point startPoint = new Point(0, 0);
        private void Member_management2_MouseDown(object sender, MouseEventArgs e)
        {
            onClick = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void Member_management2_MouseMove(object sender, MouseEventArgs e)
        {
            if (onClick)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        private void Member_management2_MouseUp(object sender, MouseEventArgs e)
        {
            onClick = false;
        }
    }
}
