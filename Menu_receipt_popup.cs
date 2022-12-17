using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlX.XDevAPI.Relational;

namespace visual_project
{
    public partial class Menu_receipt_popup : Form
    {
        DataTable table;
        DataTable orderInfo;
        public Menu_receipt_popup()
        {
            table = new DataTable();
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // 폼의 시작위치를 디스플레이의 가운데로 맞춤
            // 테이블 행 설정, DataGridView 정렬 설정
            table.Columns.Add("메뉴명");
            table.Columns.Add("단가");
            table.Columns.Add("수량");
            table.Columns.Add("금액");
            table.Columns[0].Unique = true;
            dataGridView1.DataSource = table;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[0].Width = 115; //메뉴명
            dataGridView1.Columns[1].Width = 60; //단가
            dataGridView1.Columns[2].Width = 25; //수량
            dataGridView1.Columns[3].Width = 70; //금액
        }
        public void GetOrderData() // 계산 창에서 영수증 출력할 데이터를 받아는 함수
        {
            table.Clear();
            Calculate.Sales sales = Order.order.sales;
            foreach (KeyValuePair<string, int[]> kvp in sales.OrderInfo)
            {
                int total = kvp.Value[0] * kvp.Value[1];
                table.Rows.Add(kvp.Key, kvp.Value[0], kvp.Value[1], total);
            }
        }
        
        private void PrintOrderData()
        {
            int totalSum = 0;
            // dataGridView에 table의 데이터를 출력
            dataGridView1.DataSource = table;
            // 판매 금액 계산
            try
            {
                foreach (DataRow row in table.Rows) { totalSum += (int)row[3]; }
            }
            catch(InvalidCastException)
            {                
            }
            // 판매금액을 textBox에 출력함
            textBox2.Text = totalSum.ToString();
        }
        private void Menu_receipt_popup_Load(object sender, EventArgs e)
        {
            GetOrderData();
            PrintOrderData();            
        }

        private void button1_Click(object sender, EventArgs e) //영수증 출력버튼 이벤트처리기
        {
            MessageBox.Show("영수증을 출력합니다.");
        }

        private void button2_Click(object sender, EventArgs e) //영수증출력하지않음 버튼 이벤트처리기
        {
            if (MessageBox.Show("종료하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private bool onClick;
        private Point startPoint = new Point(0, 0);
        private void Menu_receipt_popup_MouseDown(object sender, MouseEventArgs e)
        {
            onClick = true;
            startPoint = new Point(e.X, e.Y);
        }
        private void Menu_receipt_popup_MouseMove(object sender, MouseEventArgs e)
        {
            if (onClick)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }
        private void Menu_receipt_popup_MouseUp(object sender, MouseEventArgs e)
        {
            onClick = false;
        }
    }
}
