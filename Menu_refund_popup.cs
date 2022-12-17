using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace visual_project
{
    public partial class Menu_refund_popup : Form
    {
        string conn = "Server=localhost;Port=3306;Database=cafe_menu;Uid=root;Pwd=dltkdwls12!;"; // DB 연결용 문자열
        string query;
        public Menu_refund_popup()
        {
            InitializeComponent();

            // 폼의 시작위치를 디스플레이의 가운데로 맞춤
            StartPosition = FormStartPosition.CenterScreen;
        }


        private void PrintData(string cmd) // 불러온 데이터를 출력하는 함수
        {
            using (MySqlConnection Conn = new MySqlConnection(conn))
            {
                Conn.Open();
                MySqlCommand command = new MySqlCommand(cmd, Conn);
                MySqlDataReader table = command.ExecuteReader();


                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("주문번호");
                dataTable.Columns.Add("기간");
                dataTable.Columns.Add("결제방식");
                dataTable.Columns.Add("총금액");
                int index = 0;
                string dateTime = "";
                string payMethod = "";
                string totalPrice = "";
                while (table.Read())
                {
                    index = (int)table["no"];
                    dateTime = DateTime.Parse((string)table["date"]).ToString("yyyy-MM-dd");
                    if (int.Parse((string)table["total_cash"]) != 0)
                        payMethod = "현금";
                    else
                        payMethod = "카드";
                    totalPrice = (string)table["total"];
                    dataTable.Rows.Add(index,dateTime, payMethod, totalPrice);
                }
                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns["주문번호"].Visible = false;
              
            }
        }

        private void button1_Click(object sender, EventArgs e) // 검색버튼
        {
            string date1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string date2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            string tableName = "sales_tb"; // DB 테이블 명
            string searchQuery = string.Format("SELECT * FROM {0} WHERE date BETWEEN \'{1}\' AND \'{2}\'", tableName, date1, date2);
            query = searchQuery;
            PrintData(searchQuery);

       
        }

        private void button2_Click(object sender, EventArgs e) //환불버튼
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                if (MessageBox.Show("환불하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (MySqlConnection Conn = new MySqlConnection(conn))
                    {
                        Conn.Open();
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            string deleteQuery = string.Format("DELETE FROM sales_tb WHERE no = \'{0}\'", row.Cells[0].Value.ToString());
                            MySqlCommand msc = new MySqlCommand(deleteQuery, Conn);
                            msc.ExecuteNonQuery();

                        }
                        MessageBox.Show("환불 완료", "완료");
                        PrintData(query);
                    }
                }
            }
            else
            {
                MessageBox.Show("선택된 주문이 없습니다.", "오류");
            }
        }

        private void button3_Click(object sender, EventArgs e) //취소버튼
        {
            if (MessageBox.Show("종료하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private bool onClick;
        private Point startPoint = new Point(0, 0);
        private void Menu_refund_popup_MouseDown(object sender, MouseEventArgs e)
        {
            onClick = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void Menu_refund_popup_MouseMove(object sender, MouseEventArgs e)
        {
            if (onClick)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        private void Menu_refund_popup_MouseUp(object sender, MouseEventArgs e)
        {
            onClick = false;
        }
    }
}
