using menuu;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visual_project
{
    public partial class Sales : Form
    {
        /// <매출내역 관련 변수>
        string dateTimePicker1_temp; // 달력의 ~부터를 담는 변수 ex) 2022-11-25
        string dateTimePicker2_temp; // 달력의 ~까지를 담는 변수 ex) 2022-11-28
        string[] stringLines_str;
        string culumn_str;
        string path = "./result.txt";
        ListViewItem item; //리스트뷰 생성

        DataTable table;

        product product = new product();
        Interface c = new Interface();
        Dictionary<string, string[]> salesData;
        

        public Sales()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // 폼의 시작위치를 디스플레이의 가운데로 맞춤
            salesData = product.getSalesData();

            
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("판매 일자");
            table.Columns.Add("총 매출 금액");
            table.Columns.Add("매출 금액");
            table.Columns.Add("부가세");
            table.Columns.Add("순 매출 금액");
            table.Columns.Add("판매 물품 수");            
            table.Columns[0].Unique = true;
            dataGridView1.DataSource = table;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[0].Width = 149;
            dataGridView1.Columns[1].Width = 141;
            dataGridView1.Columns[2].Width = 127;
            dataGridView1.Columns[3].Width = 127;
            dataGridView1.Columns[4].Width = 122;
            dataGridView1.Columns[5].Width = 118;

            dateTimePicker1_temp = dateTimePicker1.Value.ToString("yyyy-MM-dd"); //dateTimePicker1_temp에 현재 달력값을 넣음
            dateTimePicker2_temp = dateTimePicker2.Value.ToString("yyyy-MM-dd");

        }

        private void button1_Click(object sender, EventArgs e) //메뉴버튼 이벤트처리기
        {
            this.Visible = false;
            Order showOrder = new Order();
            showOrder.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e) //시재맞추기버튼 이벤트처리기
        {
            this.Visible = false;
            cash showOrder = new cash();
            showOrder.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e) //매출조회 버튼 이벤트처리기
        {
            this.Visible = false;
            Sales showOrder = new Sales();
            showOrder.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e) //종료버튼 이벤트처리기
        {
            if (MessageBox.Show("종료하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) // 날짜선택 ~에서 부터
        {
            dateTimePicker1_temp = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) // 날짜선택 ~ 까지
        {
            dateTimePicker2_temp = dateTimePicker2.Value.ToString("yyyy-MM-dd");
        }

        private void button4_Click(object sender, EventArgs e) //기간조회 버튼 이벤트처리기
        {
            //listView1.Items.Clear(); // 리스트뷰 조회하기 전 기존 있던 내역들 리스트뷰에서 정리 후 내역 호출

            MySqlConnection conn;
            MySqlCommand cmd;

            string date = "";
            string total = "";
            string total_2;
            string VAT = "";
            string net_sales = "";
            string count = "";
          
            ListViewItem lvi;
            
            string Conn = "Server=localhost;Port=3306;Database=cafe_menu;Uid=root;Pwd=dltkdwls12!;";
            conn = new MySqlConnection(Conn);
            conn.Open();
            cmd = new MySqlCommand("", conn);

            String sql = "SELECT date,total,total_2,VAT,net_sales,count FROM cafe_menu_sales_tb";
            cmd.CommandText = sql;
            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            DataTable data1 = new DataTable();
            data1.Columns.Add("date");
            data1.Columns.Add("total");
            data1.Columns.Add("total_2");
            data1.Columns.Add("VAT");
            data1.Columns.Add("net_sales");
            data1.Columns.Add("count");

            while (reader.Read()) //칼럼의 값을 읽음
            {
                date = DateTime.Parse(reader["date"].ToString()).ToString("yyyyMMdd");
                total = reader["total"].ToString();
                total_2 = reader["total"].ToString();
                VAT = reader["VAT"].ToString();
                net_sales = reader["net_sales"].ToString();
                count = reader["count"].ToString();

                data1.Rows.Add(date, total, total_2, VAT, net_sales, count);

                //lvi = new ListViewItem(new string[] { date, total, total_2, VAT, net_sales, count });
                //listView1.Items.Add(lvi);
            }

            DataTable data2 = new DataTable();
            data2.Columns.Add("date");
            data2.Columns.Add("total");
            data2.Columns.Add("total_2");
            data2.Columns.Add("VAT");
            data2.Columns.Add("net_sales");
            data2.Columns.Add("count");

            //MessageBox.Show(data1.Rows[0]["date"].ToString());
            DateTime date_first = DateTime.ParseExact(data1.Rows[0]["date"].ToString(), "yyyyMMdd",null); //처음 날짜를 저장 (기준이 되는 날짜)
            int[] sum= new int[5];
            

            foreach (DataRow data_insert in data1.Rows)
            {
                DateTime date_compare= DateTime.ParseExact(data_insert["date"].ToString(), "yyyyMMdd", null);
                if (date_compare.Equals(date_first)) //날짜가 같은 경우 각 항목을 더해줌
                {
                    sum[0] += int.Parse(data_insert["total"].ToString());
                    sum[1] += int.Parse(data_insert["total"].ToString());
                    sum[2] += int.Parse(data_insert["VAT"].ToString());
                    sum[3] += int.Parse(data_insert["net_sales"].ToString());
                    sum[4] += int.Parse(data_insert["count"].ToString());
                }
                else
                {
                    data2.Rows.Add(date_first, sum[0], sum[1], sum[2], sum[3], sum[4]);
                    date_first = date_compare;
                    sum=new int[5]; //sum변수 초기화
                }
            }
            
            dataGridView1.DataSource = data2;

            reader.Close();           
        }
        
        private void tb_average_TextChanged(object sender, EventArgs e) //하루평균 콤마작업
        {
            string lgsText;
            lgsText = tb_average.Text.Replace(",", "");
            tb_average.Text = string.Format("{0:#,##0}", Convert.ToDouble(lgsText));
        }

        private bool onClick;
        private Point startPoint = new Point(0, 0);
        private void Sales_MouseDown(object sender, MouseEventArgs e)
        {
            onClick = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void Sales_MouseMove(object sender, MouseEventArgs e)
        {
            if (onClick)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        private void Sales_MouseUp(object sender, MouseEventArgs e)
        {
            onClick = false;
        }

    }
}
