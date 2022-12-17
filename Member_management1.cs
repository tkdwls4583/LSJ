using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using menuu;

namespace visual_project
{
    public partial class Member_management1 : Form
    {
        public static Member_management1 member_Management1;
        public String[] Sp = new String[3];

        public Member_management1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // 폼의 시작위치를 디스플레이의 가운데로 맞춤
            member_Management1 = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            product product = new product();
            String[] ID = product.MemberID();
            String[] Call = product.MemberCall();
            String[] Point = product.Memberpoint();

            listBox1.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                if (ID[i] == null)
                {
                    return;
                }
                listBox1.Items.Add(ID[i] + ' ' + Call[i] + ' ' + Point[i]);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            member_Management1.Close(); //창닫기
        }

        private void listBox1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            // 인덱스를 저장할 변수
            int selectedIndex = -1;

            // 마우스 포인터의 위치
            Point point = e.Location;

            // 리스트 박스의 IndexFromPoint 메서드 호출
            selectedIndex = listBox1.IndexFromPoint(point);

            if (selectedIndex != -1) // 빈 공간이 아닌 곳을 더블클릭 했을 때.
            {
                string selectedItem = listBox1.Items[selectedIndex] as string;
                Sp = selectedItem.Split(' '); // split으로 잘라서 이름, 전화번호, 포인트를 넘겨줌
                Member_management2 member = new Member_management2();
                member.ShowDialog();
            }
        }

        private bool onClick;
        private Point startPoint = new Point(0, 0);
        private void Member_management1_MouseDown(object sender, MouseEventArgs e)
        {
            onClick = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void Member_management1_MouseMove(object sender, MouseEventArgs e)
        {
            if (onClick)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        private void Member_management1_MouseUp(object sender, MouseEventArgs e)
        {
            onClick = false;
        }
    }
}
