using MySql.Data.MySqlClient;
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
    public partial class Membership : Form
    {
        public Membership()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // 폼의 시작위치를 디스플레이의 가운데로 맞춤
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("Server = localhost;Database=cafe_menu;Uid=root;");
                // SQL 서버와 연결.
                // Server = localhost : 로컬 호스트 (내 컴퓨터) 서버와 연결
                // Database = 스키마 이름
                // Uid = DB 로그인 아이디
                // Pwd = DB 로그인 비밀번호

                connection.Open();
                // SQL 서버 연결

                string insertQuery = "INSERT INTO account_info (id, call_number,point) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "','" + 0 + "');";

                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(textBox1.Text + "님 회원가입 완료");
                    // 정상 회원가입 안내 메시지박스를 띄운다.
                    connection.Close();
                    // SQL 연결을 끊는다.
                    Close();
                    // Form2를 닫는다. (Form1의 로그인 창으로 돌아가기 위함)
                }
                else
                // 아니라면,
                {
                    MessageBox.Show("비정상 입력 정보, 재확인 요망");
                    // 오류 메시지박스를 띄운다.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // 예외값 발생 시 해당 정보와 관련된 메시지박스를 띄운다.
            }
        }

        private void button49_Click(object sender, EventArgs e) // 종료버튼
        {
            if (MessageBox.Show("종료하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private bool onClick;
        private Point startPoint = new Point(0, 0);
        private void Membership_MouseDown(object sender, MouseEventArgs e)
        {
            onClick = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void Membership_MouseMove(object sender, MouseEventArgs e)
        {
            if (onClick)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        private void Membership_MouseUp(object sender, MouseEventArgs e)
        {
            onClick = false;
        }
    }
}
