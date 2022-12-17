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
using System.Xml.Linq;
using Calculate;
using menuu;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Utilities.Collections;

namespace visual_project
{
    public partial class Order : Form
    {
        public int d;
        public int f;
        public int t;
        public static Order order;

        public Calculate.Sales sales;
        DataTable table;

        product product = new product();
        public Order()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // 폼의 시작위치를 디스플레이의 가운데로 맞춤
            order = this;

            sales = new Calculate.Sales();
            table = new DataTable();
            sales.LoadProducts();
            //MessageBox.Show(sales.ProductInfo.Keys.Count.ToString());
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            menu_s();
            d = 1;
          
            // DataGridView 와 DataTable 초기화
            table.Columns.Add("상품명");
            table.Columns.Add("수량");
            table.Columns.Add("가격");
            table.Columns[0].Unique = true;
            dataGridView1.DataSource = table;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[0].Width = 182;
            dataGridView1.Columns[1].Width = 49;
            dataGridView1.Columns[2].Width = 103;
            RefreshLabels();
        }
        public void menu_s()
        {
            product product = new product();
            String[] N = product.Drink_BUTN();
            String[] G = product.Drink_BUTG();
            button4.Text = N[0] + "\n" + G[0];            
            button5.Text = N[1] + "\n" + G[1];
            button6.Text = N[2] + "\n" + G[2];
            button7.Text = N[3] + "\n" + G[3];
            button8.Text = N[4] + "\n" + G[4];
            button9.Text = N[5] + "\n" + G[5];
            button10.Text = N[6] + "\n" + G[6];
            button11.Text = N[7] + "\n" + G[7];
            button12.Text = N[8] + "\n" + G[8];
            button13.Text = N[9] + "\n" + G[9];
            button14.Text = N[10] + "\n" + G[10];
            button15.Text = N[11] + "\n" + G[11];
            button16.Text = N[12] + "\n" + G[12];
            button17.Text = N[13] + "\n" + G[13];
            button18.Text = N[14] + "\n" + G[14];
            button19.Text = N[15] + "\n" + G[15];
            button20.Text = N[16] + "\n" + G[16];
            button21.Text = N[17] + "\n" + G[17];
            button22.Text = N[18] + "\n" + G[18];
            button23.Text = N[19] + "\n" + G[19];
            button24.Text = N[20] + "\n" + G[20];
            button25.Text = N[21] + "\n" + G[21];
            button26.Text = N[22] + "\n" + G[22];
            button27.Text = N[23] + "\n" + G[23];
            button28.Text = N[24] + "\n" + G[24];
            button29.Text = N[25] + "\n" + G[25];
            button30.Text = N[26] + "\n" + G[26];
            button31.Text = N[27] + "\n" + G[27];
            button32.Text = N[28] + "\n" + G[28];
            button33.Text = N[29] + "\n" + G[29];
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

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e) { } //목록 리스트 출력 판넬

        private void button34_Click(object sender, EventArgs e) //메뉴선정: 음료류 버튼
        {
            //버튼이 눌리면 표에 음료이름과 가격이 출력됨
            d = 1;
            f = 0;
            t = 0;
            menu_s();
        }
        private void button35_Click(object sender, EventArgs e) //메뉴선정: 디저트류 버튼
        {
            //버튼이 눌리면 표에 디저트이름과 가격이 출력됨
            d = 0;
            f = 1;
            t = 0;
            product product = new product();
            String[] N = product.Food_BUTN();
            String[] G = product.Food_BUTG();
            Order.order.button4.Text = N[0] + "\n" + G[0];
            Order.order.button5.Text = N[1] + "\n" + G[1];
            Order.order.button6.Text = N[2] + "\n" + G[2];
            Order.order.button7.Text = N[3] + "\n" + G[3];
            Order.order.button8.Text = N[4] + "\n" + G[4];
            Order.order.button9.Text = N[5] + "\n" + G[5];
            Order.order.button10.Text = N[6] + "\n" + G[6];
            Order.order.button11.Text = N[7] + "\n" + G[7];
            Order.order.button12.Text = N[8] + "\n" + G[8];
            Order.order.button13.Text = N[9] + "\n" + G[9];
            Order.order.button14.Text = N[10] + "\n" + G[10];
            Order.order.button15.Text = N[11] + "\n" + G[11];
            Order.order.button16.Text = N[12] + "\n" + G[12];
            Order.order.button17.Text = N[13] + "\n" + G[13];
            Order.order.button18.Text = N[14] + "\n" + G[14];
            Order.order.button19.Text = N[15] + "\n" + G[15];
            Order.order.button20.Text = N[16] + "\n" + G[16];
            Order.order.button21.Text = N[17] + "\n" + G[17];
            Order.order.button22.Text = N[18] + "\n" + G[18];
            Order.order.button23.Text = N[19] + "\n" + G[19];
            Order.order.button24.Text = N[20] + "\n" + G[20];
            Order.order.button25.Text = N[21] + "\n" + G[21];
            Order.order.button26.Text = N[22] + "\n" + G[22];
            Order.order.button27.Text = N[23] + "\n" + G[23];
            Order.order.button28.Text = N[24] + "\n" + G[24];
            Order.order.button29.Text = N[25] + "\n" + G[25];
            Order.order.button30.Text = N[26] + "\n" + G[26];
            Order.order.button31.Text = N[27] + "\n" + G[27];
            Order.order.button32.Text = N[28] + "\n" + G[28];
            Order.order.button33.Text = N[29] + "\n" + G[29];
        }
        private void button36_Click(object sender, EventArgs e) //메뉴선정: 기타 버튼
        {
            //버튼이 눌리면 표에 기타가 출력됨 (텀블러,빨대,커피콩 등)
            d = 0;
            f = 0;
            t = 1;
            product product = new product();
            String[] N = product.Thing_BUTN();
            String[] G = product.Thing_BUTG();
            Order.order.button4.Text = N[0] + "\n" + G[0];
            Order.order.button5.Text = N[1] + "\n" + G[1];
            Order.order.button6.Text = N[2] + "\n" + G[2];
            Order.order.button7.Text = N[3] + "\n" + G[3];
            Order.order.button8.Text = N[4] + "\n" + G[4];
            Order.order.button9.Text = N[5] + "\n" + G[5];
            Order.order.button10.Text = N[6] + "\n" + G[6];
            Order.order.button11.Text = N[7] + "\n" + G[7];
            Order.order.button12.Text = N[8] + "\n" + G[8];
            Order.order.button13.Text = N[9] + "\n" + G[9];
            Order.order.button14.Text = N[10] + "\n" + G[10];
            Order.order.button15.Text = N[11] + "\n" + G[11];
            Order.order.button16.Text = N[12] + "\n" + G[12];
            Order.order.button17.Text = N[13] + "\n" + G[13];
            Order.order.button18.Text = N[14] + "\n" + G[14];
            Order.order.button19.Text = N[15] + "\n" + G[15];
            Order.order.button20.Text = N[16] + "\n" + G[16];
            Order.order.button21.Text = N[17] + "\n" + G[17];
            Order.order.button22.Text = N[18] + "\n" + G[18];
            Order.order.button23.Text = N[19] + "\n" + G[19];
            Order.order.button24.Text = N[20] + "\n" + G[20];
            Order.order.button25.Text = N[21] + "\n" + G[21];
            Order.order.button26.Text = N[22] + "\n" + G[22];
            Order.order.button27.Text = N[23] + "\n" + G[23];
            Order.order.button28.Text = N[24] + "\n" + G[24];
            Order.order.button29.Text = N[25] + "\n" + G[25];
            Order.order.button30.Text = N[26] + "\n" + G[26];
            Order.order.button31.Text = N[27] + "\n" + G[27];
            Order.order.button32.Text = N[28] + "\n" + G[28];
            Order.order.button33.Text = N[29] + "\n" + G[29];
        }
        private void button37_Click(object sender, EventArgs e) //메뉴추가 버튼
        {
            //메뉴추가 메소드 연결

            //메뉴추가 팝업창이 뜸
            //메뉴이름,가격,사진을 입력함 -> 확인버튼 누름 -> 메뉴추가됨
            Menu_insert_popup insertpop = new Menu_insert_popup();
            insertpop.ShowDialog();

            //표에 바로 메뉴가 추가되겠금 함
        }
        private void button38_Click(object sender, EventArgs e) //메뉴삭제 버튼
        {
            //메뉴삭제 메소드 연결

            //팝업창이 뜸 -> 메뉴리스트가 뜸 -> 삭제할 메뉴 클릭 -> 삭제하실껍니까 ? 라는 팝업창이 뜸
            // -> "확인"버튼을 누르면 메뉴삭제되고, "취소"버튼을 누르면 삭제취소
            Menu_delete_popup deletepop = new Menu_delete_popup();
            deletepop.ShowDialog();

            //표에 바로 메뉴가 삭제되겠금 함
        }
        private void button39_Click(object sender, EventArgs e) //메뉴수정 버튼
        {
            //메뉴수정 메소드 연결

            //팝업창이 뜸 -> 메뉴리스트가 뜸 -> 수정할 메뉴 클릭 -> 메뉴정보 팝업창이 뜸
            // -> 수정 후 "수정"버튼을 누르면 수정되고,"취소"버튼을 누르면 수정 취소
            Menu_modify_popup modifypop = new Menu_modify_popup();
            modifypop.ShowDialog();

            //표에 바로 메뉴가 수정되겠금 함
        }
        private void button40_Click(object sender, EventArgs e) //영수증발행 버튼
        {
            //영수증반환 메소드 연결
            //영수증 종이 화면상에 출력 (팝업창)
            Menu_receipt_popup receiptpop = new Menu_receipt_popup();           
            receiptpop.ShowDialog();
        }
        private void button41_Click(object sender, EventArgs e) //환불버튼
        {
            //환불 메소드 연결

            //환불할 물건선택 -> 환불하시겠습니까 ? 라는 팝업창 뜸
            //-> "환불"버튼을 누르면 환불됨, "취소"버튼을 누르면 환불 취소
            Menu_refund_popup refundpop = new Menu_refund_popup();
            refundpop.ShowDialog();
        }
        private void button42_Click(object sender, EventArgs e) //종료버튼
        {
            //주문창 닫기 -> 메뉴창으로 이동
            this.Visible = false;
            Main showmain = new Main();
            showmain.ShowDialog();
        }
        private void button43_Click(object sender, EventArgs e) //전체취소 버튼
        {
            if (MessageBox.Show("메뉴를 전체 취소하시겠습니까?", "전체 취소 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sales.CancelOrder();
                table.Clear();                
                RefreshLabels();
            }
        }
        private void button44_Click(object sender, EventArgs e) //선택취소 버튼
        {
            //메뉴창에 있는 메뉴선택 후 선택취소버튼을 누르면 취소됨
            try
            {
                string name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                if (dataGridView1.SelectedRows.Count > 0)
                {

                    sales.SelectCancelOrder(name);
                    table.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    dataGridView1.Refresh();
                    RefreshLabels();
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            catch (ArgumentException) { MessageBox.Show("선택된 상품이 없습니다!", "오류"); }
            catch (NullReferenceException) { MessageBox.Show("선택된 상품이 없습니다!", "오류"); }
        }
        private void button45_Click(object sender, EventArgs e) //수량변경+버튼
        {
            try
            {
                //메뉴창에 있는 메뉴 중 선택 후 수량 +버튼을 누름  -> 수량 + 1
                string name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                sales.IncAmount(name);
                RefreshLabels();
                PrintSalesToGrid();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("선택된 상품이 없습니다!", "오류");
            }
            catch (NullReferenceException) { MessageBox.Show("선택된 상품이 없습니다!", "오류"); }

            // 재고가 부족하면 오류메시지 출력
            catch (NoAmountException)
            {
                string name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                MessageBox.Show(string.Format("재고가 부족합니다! 재고 수량 : {0}", sales.ProductInfo[name][1].ToString()), "오류");
            }
        }
        private void button46_Click(object sender, EventArgs e) //수량변경-버튼
        {
            try
            {
                string name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                if (sales.OrderInfo[name][1] != 1)
                {
                    sales.DecAmount(name);
                    PrintSalesToGrid();
                    RefreshLabels();
                }
                //만약 수량 =0 이라면 메뉴를 취소할까요 ? 팝업창 띄우기 -> "예"누르면 0인 메뉴 취소
                else
                {
                    if (MessageBox.Show("해당메뉴를 취소할까요?", "선택취소", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (dataGridView1.SelectedRows.Count > 0)
                        {
                            sales.SelectCancelOrder(name);
                            table.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                            dataGridView1.Refresh();
                            RefreshLabels();
                        }
                    }
                }
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("선택된 상품이 없습니다!", "오류"); }
            catch (NullReferenceException) { MessageBox.Show("선택된 상품이 없습니다!", "오류"); }
        }
        private void button47_Click(object sender, EventArgs e) //카드결제 버튼
        {
            //"카드로 결제합니다" 팝업창 띄우기
            if (MessageBox.Show("카드로 결제합니다.", "카드결제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //카드 결제금액 -> 하루매출 메소드연결
                sales.setCardOrder();
                sales.CheckOut();
                product.pay(sales);
                if (MessageBox.Show("포인트를 적립하시겠습니까?", "Point", MessageBoxButtons.YesNo) == DialogResult.Yes) //포인트 적립
                {
                    Member_management3 insertpop = new Member_management3();
                    insertpop.ShowDialog();
                }
            }
        }
        private void button48_Click(object sender, EventArgs e) //현금결제 버튼
        {
            //"현금으로 결제합니다" 팝업창 띄우기
            if (MessageBox.Show("현금으로 결제합니다.", "카드결제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //현금 결제금액 -> 하루매출 메소드연결, 시재맞추기 메소드 연결
                sales.setCashOrder();
                sales.CheckOut();
                product.pay(sales);
                if (MessageBox.Show("포인트를 적립하시겠습니까?", "Point", MessageBoxButtons.YesNo) == DialogResult.Yes) // 포인트 적립
                {
                    Member_management3 insertpop = new Member_management3();
                    insertpop.ShowDialog();
                }
            }
        }
        private void button49_Click(object sender, EventArgs e) //전체 창 닫기 버튼 (프로그램 종료)
        {
            if (MessageBox.Show("종료하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void MenuButton_Click(object sender, EventArgs e) // 각 메뉴 버튼
        {
            try
            {
                dataGridView1.ForeColor = Color.Black;
                Button button = (Button)sender;
                string name = button.Text.Split('\n')[0];
                sales.AddOrder(name);
                RefreshLabels();
                PrintSalesToGrid();
            }
            catch (KeyNotFoundException)
            {
                MessageBox.Show("해당 메뉴가 없습니다.", "오류");
            }
            catch (NoAmountException)
            {
                string name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                MessageBox.Show(string.Format("재고가 부족합니다! 재고 수량 : {0}", sales.ProductInfo[name][1].ToString()), "오류");
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    int value = int.Parse(textBox2.Text);
                    sales.ReceiveMoney(value);
                    sales.CheckOut();
                    RefreshLabels();
                }
                catch (FormatException)
                {
                    MessageBox.Show("올바른 값이 아닙니다!", "오류");
                    textBox2.Text = "0";
                }
            }
        }

        private void button50_Click(object sender, EventArgs e) //회원가입 버튼
        {           
            Membership membership = new Membership();
            membership.ShowDialog();
        }

        private void button51_Click(object sender, EventArgs e) //회원관리 버튼
        {
            Member_management1 member_manage = new Member_management1();
            member_manage.ShowDialog();
        }
        private void PrintSalesToGrid()
        {
            dataGridView1.DataSource = table;
            foreach (KeyValuePair<string, int[]> kvp in sales.OrderInfo)
            {
                int Idx = SearchIndex(kvp.Key);
                // dataGridView1에 해당 주문이 없으면 추가
                if (Idx == -1)
                    table.Rows.Add(kvp.Key, kvp.Value[1], kvp.Value[0] * kvp.Value[1]);

                // dataGridView1에 해당 주문이 있으면 수량과 가격 업데이트
                else
                {
                    table.Rows[Idx][1] = kvp.Value[1];
                    table.Rows[Idx][2] = kvp.Value[0] * kvp.Value[1];
                }
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = String.Format($"{row.Index + 1}");
            }
            dataGridView1.DataSource = table;

        }
        private bool Check_Data(string s)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    if (value == s) { return true; }
                }
            }
            catch (NullReferenceException) { return false; }
            return false;
        }

        private int SearchIndex(string s)
        {
            if (!Check_Data(s))
                return -1;


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value.ToString() == s)
                    return row.Index;
            }
            return -1;
        }
        private void RefreshLabels()
        {
            sales.CheckOut();
            label10.Text = sales.TotalPrice.ToString();
            label11.Text = sales.AmountToReceive.ToString();
            textBox2.Clear();
            textBox2.Text = sales.AmountReceived.ToString();
            label12.Text = sales.Change.ToString();
        }

        private bool onClick;
        private Point startPoint = new Point(0, 0);
        private void Order_MouseDown(object sender, MouseEventArgs e)
        {
            onClick = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void Order_MouseMove(object sender, MouseEventArgs e)
        {
            if (onClick)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        private void Order_MouseUp(object sender, MouseEventArgs e)
        {
            onClick = false;
        }
    }
}
