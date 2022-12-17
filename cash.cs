using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace visual_project
{
    public partial class cash : Form
    {
        //권종 및 금액..
        int num_chk; //권종 분류
        int num_add; //금액 합계

        //계산기..
        bool calculator_chk = false; // 계산기 체크값 ON될시 true, Off일시 false
        public bool isNewNum = true; // 계산기 관련 함수  

        public cash()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // 폼의 시작위치를 디스플레이의 가운데로 맞춤
        }

        private void cash_Load(object sender, EventArgs e)
        {
            using (TextReader tReader = new StreamReader("./temp.txt")) //메모장을 읽는 함수
            {
                // 파일의 내용을 모두 읽어와 줄바꿈을 기준으로 배열형태로 쪼갭니다.
                string[] stringLines
                    = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);
                int len = stringLines.Length;
                // 한줄씩 가져와서..
                foreach (string stringLine in stringLines)
                {
                    // 빈 문자열이 아니면..
                    if (stringLine != string.Empty)
                    {
                        // 구분자를 이용해서 배열형태로 쪼갭니다.
                        {
                            tb_result.Text = stringLines[18]; //모두 더한 값
                            tb_10_result.Text = stringLines[17]; //10원 값
                            tb_10.Text = stringLines[16];
                            tb_50_result.Text = stringLines[15]; // 50원 값
                            tb_50.Text = stringLines[14];
                            tb_100_result.Text = stringLines[13]; //100원 값 ....
                            tb_100.Text = stringLines[12];
                            tb_500_result.Text = stringLines[11];
                            tb_500.Text = stringLines[10];
                            tb_1000_result.Text = stringLines[9];
                            tb_1000.Text = stringLines[8];
                            tb_5000_result.Text = stringLines[7];
                            tb_5000.Text = stringLines[6];
                            tb_10000_result.Text = stringLines[5];
                            tb_10000.Text = stringLines[4];
                            tb_50000_result.Text = stringLines[3];
                            tb_50000.Text = stringLines[2];
                            tb_100000_result.Text = stringLines[1];
                            tb_100000.Text = stringLines[0];
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) // 상단의 주문 버튼 이벤트 처리기
        {
            this.Visible = false;
            Order showOrder = new Order();
            showOrder.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e) // 상단의 시재맞추기 버튼 이벤트처리기
        {
            this.Visible = false;
            cash showOrder = new cash();
            showOrder.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e) // 상단의 매출조회 버튼 이벤트 처리기
        {
            this.Visible = false;
            Sales showOrder = new Sales();
            showOrder.ShowDialog();
        }
        private void button5_Click(object sender, EventArgs e) //정산마감 버튼 이벤트 처리기
        {
            string Conn = "Server=localhost;Port=3306;Database=cafe_menu;Uid=root;Pwd=dltkdwls12!;";
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                conn.Open();
                MySqlCommand msc = new MySqlCommand("update cash_tb set m_100000=m_100000+ " + tb_100000.Text + ", m_50000=m_50000+" + tb_50000.Text + ", m_10000=m_10000+" + tb_10000.Text + ", m_5000=m_5000+" + tb_5000.Text + ", m_1000=m_1000+" + tb_1000.Text + ", m_500=m_500+ " + tb_500.Text + ", m_100=m_100+" + tb_100.Text + ", m_50=m_50+" + tb_50.Text + ", m_10=m_10+" + tb_10.Text, conn);
                msc.ExecuteNonQuery();
                // db 닫아주는 문장 삽입
            }

            //하루 현금시재를 저장 -> 매출조회에도 정보가 넘어감
            //화면이 초기화 됨
            StreamWriter writer;
            writer = File.AppendText("result.txt");
            int divide = num_add / 10; // 총 매출금액에서 나누기 10하여 부가세 도출
            int sum = num_add - divide; // 총 매출금액에서 부가세를 뺀 합계금액 도출

            string divide_str = divide.ToString(); // 인트형 부가세 금액을 스트링형식으로 변환
            string sum_str = sum.ToString(); // 인트형 합계 금액을 스트링형식으로 변환

            string lgsText; // 부가세용 스트링 변수
            string lgsText2; // 합계용 스트링 변수

            lgsText = divide_str.Replace(",", ""); // 부가세의 콤마가 있다면 콤마제거
            lgsText2 = sum_str.Replace(",", ""); // 합계에 콤파가 있다면 콤마 제거

            divide_str = string.Format("{0:#,##0}", Convert.ToDouble(lgsText)); // 부가세에 콤마 삽입
            sum_str = string.Format("{0:#,##0}", Convert.ToDouble(lgsText2)); // 합계에 콤마 삽입

            writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd") + " " + tb_result.Text + " " + tb_result.Text + " " + divide_str + " " + sum_str); // 총매출부터 부가세 등등 내역을 메모장으로 저장

            writer.Close();

            StreamWriter writer2;
            writer2 = File.CreateText("temp.txt");
            writer2.WriteLine("0");
            writer2.WriteLine("0");
            writer2.WriteLine("0");
            writer2.WriteLine("0");
            writer2.WriteLine("0");
            writer2.WriteLine("0");
            writer2.WriteLine("0");
            writer2.WriteLine("0");
            writer2.WriteLine("0");
            writer2.WriteLine("0");
            writer2.WriteLine("0");
            writer2.WriteLine("0");
            writer2.WriteLine("0");
            writer2.WriteLine("0");
            writer2.WriteLine("0");
            writer2.WriteLine("0");
            writer2.WriteLine("0");
            writer2.WriteLine("0");
            writer2.WriteLine("0");
            writer.Close();

            Application.Restart(); // 폼 초기화 (재실행)
        }
        private void button6_Click(object sender, EventArgs e) //확인 버튼 이벤트 처리기
        {
            //현금시재를 저장 -> 매출정보에 포함되지않음, 다른화면에 갔다와도 정보가 그대로 있어야함 
            //현금시재를 저장 -> 매출정보에 포함되지않음, 다른화면에 갔다와도 정보가 그대로 있어야함 
            StreamWriter writer;
            writer = File.CreateText("temp.txt"); //프로젝트 폴더 -> Debug폴더에 temp이름의 메모장으로 저장됨 이걸 이용하여 임시저장된 시재를 불러옴
            writer.WriteLine(tb_100000.Text);
            writer.WriteLine(tb_100000_result.Text);
            writer.WriteLine(tb_50000.Text);
            writer.WriteLine(tb_50000_result.Text);
            writer.WriteLine(tb_10000.Text);
            writer.WriteLine(tb_10000_result.Text);
            writer.WriteLine(tb_5000.Text);
            writer.WriteLine(tb_5000_result.Text);
            writer.WriteLine(tb_1000.Text);
            writer.WriteLine(tb_1000_result.Text);
            writer.WriteLine(tb_500.Text);
            writer.WriteLine(tb_500_result.Text);
            writer.WriteLine(tb_100.Text);
            writer.WriteLine(tb_100_result.Text);
            writer.WriteLine(tb_50.Text);
            writer.WriteLine(tb_50_result.Text);
            writer.WriteLine(tb_10.Text);
            writer.WriteLine(tb_10_result.Text);
            writer.WriteLine(tb_result.Text);
            writer.Close();

            this.Visible = false;
            Main main = new Main();
            main.ShowDialog();
        }
        private void button7_Click(object sender, EventArgs e) //취소 버튼 이벤트 처리기
        {
            using (TextReader tReader = new StreamReader("./temp.txt"))
            {
                // 파일의 내용을 모두 읽어와 줄바꿈을 기준으로 배열형태로 쪼갭니다.
                string[] stringLines
                    = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);
                int len = stringLines.Length;
                // 한줄씩 가져와서..
                foreach (string stringLine in stringLines)
                {
                    // 빈 문자열이 아니면..
                    if (stringLine != string.Empty)
                    {
                        // 구분자를 이용해서 배열형태로 쪼갭니다.
                        {
                            tb_result.Text = stringLines[18];
                            tb_10_result.Text = stringLines[17];
                            tb_10.Text = stringLines[16];
                            tb_50_result.Text = stringLines[15];
                            tb_50.Text = stringLines[14];
                            tb_100_result.Text = stringLines[13];
                            tb_100.Text = stringLines[12];
                            tb_500_result.Text = stringLines[11];
                            tb_500.Text = stringLines[10];
                            tb_1000_result.Text = stringLines[9];
                            tb_1000.Text = stringLines[8];
                            tb_5000_result.Text = stringLines[7];
                            tb_5000.Text = stringLines[6];
                            tb_10000_result.Text = stringLines[5];
                            tb_10000.Text = stringLines[4];
                            tb_50000_result.Text = stringLines[3];
                            tb_50000.Text = stringLines[2];
                            tb_100000_result.Text = stringLines[1];
                            tb_100000.Text = stringLines[0];
                        }
                    }
                }
            }

            this.Visible = false;
            Main main = new Main();
            main.ShowDialog();

            //다시 들어갔을때 그전의 저장했던 시재창 정보가 뜸

        }

        private void button4_Click(object sender, EventArgs e) // 프로그램 종료버튼
        {
            if (MessageBox.Show("종료하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // tb_100000_click ~ tb_10_click까지 권종 텍스트박스 클릭시 num_chk 값을 변화하여 키패드 및 키보드를 통해 값을 어느곳에 입력할지 해석함
        private void tb_100000_Click(object sender, EventArgs e)
        {
            tb_100000.Text = "";
            num_chk = 100000;
            zero_num(); //권종 텍스트박스 0으로 만들어주는 함수 호출
        }

        private void tb_50000_Click(object sender, EventArgs e)
        {
            tb_50000.Text = "";
            num_chk = 50000;
            zero_num(); //권종 텍스트박스 0으로 만들어주는 함수 호출
        }

        private void tb_10000_Click(object sender, EventArgs e)
        {
            tb_10000.Text = "";
            num_chk = 10000;
            zero_num(); //권종 텍스트박스 0으로 만들어주는 함수 호출
        }

        private void tb_5000_Click(object sender, EventArgs e)
        {
            tb_5000.Text = "";
            num_chk = 5000;
            zero_num(); //권종 텍스트박스 0으로 만들어주는 함수 호출
        }

        private void tb_1000_Click(object sender, EventArgs e)
        {
            tb_1000.Text = "";
            num_chk = 1000;
            zero_num(); //권종 텍스트박스 0으로 만들어주는 함수 호출
        }

        private void tb_500_Click(object sender, EventArgs e)
        {
            tb_500.Text = "";
            num_chk = 500;
            zero_num(); //권종 텍스트박스 0으로 만들어주는 함수 호출
        }

        private void tb_100_Click(object sender, EventArgs e)
        {
            tb_100.Text = "";
            num_chk = 100;
            zero_num(); //권종 텍스트박스 0으로 만들어주는 함수 호출
        }

        private void tb_50_Click(object sender, EventArgs e)
        {
            tb_50.Text = "";
            num_chk = 50;
            zero_num(); //권종 텍스트박스 0으로 만들어주는 함수 호출
        }

        private void tb_10_Click(object sender, EventArgs e)
        {
            tb_10.Text = "";
            num_chk = 10;
            zero_num(); //권종 텍스트박스 0으로 만들어주는 함수 호출
        }

        // 모든 숫자 버튼을 하나로 처리하는 메소드
        private void btn_clik(object sender, EventArgs e)
        {
            System.Windows.Forms.Button num_btn = (System.Windows.Forms.Button)sender;
            SetNum(num_btn.Text); //SetNum 함수 호출
        }

        public void SetNum(string num)
        {
            switch (num_chk)
            {
                case 100000:
                    if (tb_100000.Text == "0")
                    {
                        tb_100000.Text = Convert.ToString(num);
                    }
                    else
                    {
                        tb_100000.Text += Convert.ToString(num);
                    }
                    tb_100000_result.Text = Convert.ToString(Convert.ToInt64(tb_100000.Text) * 100000);
                    break;
                case 50000:
                    if (tb_50000.Text == "0")
                    {
                        tb_50000.Text = Convert.ToString(num);
                    }
                    else
                    {
                        tb_50000.Text += Convert.ToString(num);
                    }
                    tb_50000_result.Text = Convert.ToString(Convert.ToInt64(tb_50000.Text) * 50000);

                    break;
                case 10000:
                    if (tb_10000.Text == "0")
                    {
                        tb_10000.Text = Convert.ToString(num);
                    }
                    else
                    {
                        tb_10000.Text += Convert.ToString(num);
                    }
                    tb_10000_result.Text = Convert.ToString(Convert.ToInt64(tb_10000.Text) * 10000);
                    break;
                case 5000:
                    if (tb_5000.Text == "0")
                    {
                        tb_5000.Text = Convert.ToString(num);
                    }
                    else
                    {
                        tb_5000.Text += Convert.ToString(num);
                    }
                    tb_5000_result.Text = Convert.ToString(Convert.ToInt64(tb_5000.Text) * 5000);
                    break;
                case 1000:
                    if (tb_1000.Text == "0")
                    {
                        tb_1000.Text = Convert.ToString(num);
                    }
                    else
                    {
                        tb_1000.Text += Convert.ToString(num);
                    }
                    tb_1000_result.Text = Convert.ToString(Convert.ToInt64(tb_1000.Text) * 1000);
                    break;
                case 500:
                    if (tb_500.Text == "0")
                    {
                        tb_500.Text = Convert.ToString(num);
                    }
                    else
                    {
                        tb_500.Text += Convert.ToString(num);
                    }
                    tb_500_result.Text = Convert.ToString(Convert.ToInt64(tb_500.Text) * 500);
                    break;
                case 100:
                    if (tb_100.Text == "0")
                    {
                        tb_100.Text = Convert.ToString(num);
                    }
                    else
                    {
                        tb_100.Text += Convert.ToString(num);
                    }
                    tb_100_result.Text = Convert.ToString(Convert.ToInt64(tb_100.Text) * 100);
                    break;
                case 50:
                    if (tb_50.Text == "0")
                    {
                        tb_50.Text = Convert.ToString(num);
                    }
                    else
                    {
                        tb_50.Text += Convert.ToString(num);
                    }
                    tb_50_result.Text = Convert.ToString(Convert.ToInt64(tb_50.Text) * 50);
                    break;
                case 10:
                    if (tb_10.Text == "0")
                    {
                        tb_10.Text = Convert.ToString(num);
                    }
                    else
                    {
                        tb_10.Text += Convert.ToString(num);
                    }
                    tb_10_result.Text = Convert.ToString(Convert.ToInt64(tb_10.Text) * 10);
                    break;
            }
            result_add(); // 합계 함수 호출

        }

        //십만원권 부터 십원까지 키보드를 통해 텍스트가 변화하는 경우 아래 함수로 들어옴
        private void tb_TextChanged(object sender, EventArgs e)
        {
            switch (num_chk)
            {
                case 100000:
                    if (tb_100000.TextLength > 0)
                    {
                        tb_100000_result.Text = Convert.ToString(Convert.ToInt64(tb_100000.Text) * 100000);
                    }
                    break;
                case 50000:
                    if (tb_50000.TextLength > 0)
                    {
                        tb_50000_result.Text = Convert.ToString(Convert.ToInt64(tb_50000.Text) * 50000);
                    }
                    break;
                case 10000:
                    if (tb_10000.TextLength > 0)
                    {
                        tb_10000_result.Text = Convert.ToString(Convert.ToInt64(tb_10000.Text) * 10000);
                    }
                    break;
                case 5000:
                    if (tb_5000.TextLength > 0)
                    {
                        tb_5000_result.Text = Convert.ToString(Convert.ToInt64(tb_5000.Text) * 5000);
                    }
                    break;
                case 1000:
                    if (tb_1000.TextLength > 0)
                    {
                        tb_1000_result.Text = Convert.ToString(Convert.ToInt64(tb_1000.Text) * 1000);
                    }
                    break;
                case 500:
                    if (tb_500.TextLength > 0)
                    {
                        tb_500_result.Text = Convert.ToString(Convert.ToInt64(tb_500.Text) * 500);
                    }
                    break;
                case 100:
                    if (tb_100.TextLength > 0)
                    {
                        tb_100_result.Text = Convert.ToString(Convert.ToInt64(tb_100.Text) * 100);
                    }
                    break;
                case 50:
                    if (tb_50.TextLength > 0)
                    {
                        tb_50_result.Text = Convert.ToString(Convert.ToInt64(tb_50.Text) * 50);
                    }
                    break;
                case 10:
                    if (tb_10.TextLength > 0)
                    {
                        tb_10_result.Text = Convert.ToString(Convert.ToInt64(tb_10.Text) * 10);
                    }
                    break;
            }
            result_add(); //합계 함수 호출
        }

        //권종 텍스트박스에 다시 0을 넣어주는 함수
        private void zero_num()
        {
            if (tb_100000.Text == ("")) //십만원권의 텍스트박스 안의 텍스트가 없으며
            {
                if (num_chk != 100000) //십만원권 이외의 텍스트박스를 클릭했을 경우
                {
                    tb_100000.Text = "0"; //십만원권의 텍스트박스의 텍스트를 0으로 바꿈
                }
            }

            if (tb_50000.Text == (""))
            {
                if (num_chk != 50000)
                {
                    tb_50000.Text = "0";
                }
            }

            if (tb_10000.Text == (""))
            {
                if (num_chk != 10000)
                {
                    tb_10000.Text = "0";
                }
            }
            if (tb_5000.Text == (""))
            {
                if (num_chk != 5000)
                {
                    tb_5000.Text = "0";
                }
            }
            if (tb_1000.Text == (""))
            {
                if (num_chk != 1000)
                {
                    tb_1000.Text = "0";
                }
            }
            if (tb_500.Text == (""))
            {
                if (num_chk != 500)
                {
                    tb_500.Text = "0";
                }
            }
            if (tb_100.Text == (""))
            {
                if (num_chk != 100)
                {
                    tb_100.Text = "0";
                }
            }
            if (tb_50.Text == (""))
            {
                if (num_chk != 50)
                {
                    tb_50.Text = "0";
                }
            }
            if (tb_10.Text == (""))
            {
                if (num_chk != 10)
                {
                    tb_10.Text = "0";
                }
            }
        }

        private void button15_Click(object sender, EventArgs e) //키패드의 AC함수 -> 수정
        {
            tb_100000.Text = "0";
            tb_100000_result.Text = "0";
            tb_50000.Text = "0";
            tb_50000_result.Text = "0";
            tb_10000.Text = "0";
            tb_10000_result.Text = "0";
            tb_5000.Text = "0";
            tb_5000_result.Text = "0";
            tb_1000.Text = "0";
            tb_1000_result.Text = "0";
            tb_500.Text = "0";
            tb_500_result.Text = "0";
            tb_100.Text = "0";
            tb_100_result.Text = "0";
            tb_50.Text = "0";
            tb_50_result.Text = "0";
            tb_10.Text = "0";
            tb_10_result.Text = "0";

            result_add(); //합계 함수 호출
        }

        //키패드 및 키보드 입력 후 아래 함수로 들어와 매출의 합산을 구함
        private void result_add()
        {
            //권종 금액에 콤마가 들어있기 때문에 스트링을 인트형식으로 바꾸지 못함.
            //그러므로 아래 코드는 콤마를 Replace를 통하여 제거하는 작업
            string A = tb_100000_result.Text.Replace(",", "");
            string B = tb_50000_result.Text.Replace(",", "");
            string C = tb_10000_result.Text.Replace(",", "");
            string D = tb_5000_result.Text.Replace(",", "");
            string E = tb_1000_result.Text.Replace(",", "");
            string F = tb_500_result.Text.Replace(",", "");
            string G = tb_100_result.Text.Replace(",", "");
            string H = tb_50_result.Text.Replace(",", "");
            string I = tb_10_result.Text.Replace(",", "");

            try
            {
                num_add = Int32.Parse(A) + Int32.Parse(B) + Int32.Parse(C) + Int32.Parse(D) + Int32.Parse(E) + Int32.Parse(F) + Int32.Parse(G) + Int32.Parse(H) + Int32.Parse(I);
                tb_result.Text = Convert.ToString(num_add);
            }

            catch
            {

            }
        }

        ////////////////////////////////////////////////////////////
        /// 원단위 콤마 작업 -> 0이 3개 붙을 때마다 콤마를 붙혀줌///   
        private void tb_result_TextChanged(object sender, EventArgs e)
        {
            string lgsText;
            lgsText = tb_result.Text.Replace(",", "");
            try
            {
                tb_result.Text = string.Format("{0:#,##0}", Convert.ToDouble(lgsText));
            }
            catch { }
            tb_cash_result.Text = tb_result.Text;
        }
      

        /// 원단위 콤마 작업 -> 0이 3개 붙을 때마다 콤마를 붙혀줌/// 
        private void tb_result_TextChanged_1(object sender, EventArgs e)
        {
            string lgsText;
            lgsText = tb_result.Text.Replace(",", "");
            try
            {
                tb_result.Text = string.Format("{0:#,##0}", Convert.ToDouble(lgsText));
            }
            catch { }
            tb_cash_result.Text = tb_result.Text;
        }
        private void tb_100000_result_TextChanged(object sender, EventArgs e)
        {
            string lgsText;

            lgsText = tb_100000_result.Text.Replace(",", "");
            tb_100000_result.Text = string.Format("{0:#,##0}", Convert.ToDouble(lgsText));
        }

        private void tb_50000_result_TextChanged(object sender, EventArgs e)
        {
            string lgsText;
            lgsText = tb_50000_result.Text.Replace(",", "");
            tb_50000_result.Text = string.Format("{0:#,##0}", Convert.ToDouble(lgsText));
        }

        private void tb_10000_result_TextChanged(object sender, EventArgs e)
        {
            string lgsText;
            lgsText = tb_10000_result.Text.Replace(",", "");
            tb_10000_result.Text = string.Format("{0:#,##0}", Convert.ToDouble(lgsText));
        }

        private void tb_5000_result_TextChanged(object sender, EventArgs e)
        {
            string lgsText;
            lgsText = tb_5000_result.Text.Replace(",", "");
            tb_5000_result.Text = string.Format("{0:#,##0}", Convert.ToDouble(lgsText));
        }

        private void tb_1000_result_TextChanged(object sender, EventArgs e)
        {
            string lgsText;
            lgsText = tb_1000_result.Text.Replace(",", "");
            tb_1000_result.Text = string.Format("{0:#,##0}", Convert.ToDouble(lgsText));
        }

        private void tb_500_result_TextChanged(object sender, EventArgs e)
        {
            string lgsText;
            lgsText = tb_500_result.Text.Replace(",", "");
            tb_500_result.Text = string.Format("{0:#,##0}", Convert.ToDouble(lgsText));
        }

        private void tb_100_result_TextChanged(object sender, EventArgs e)
        {
            string lgsText;
            lgsText = tb_100_result.Text.Replace(",", "");
            tb_100_result.Text = string.Format("{0:#,##0}", Convert.ToDouble(lgsText));
        }

        private void tb_50_result_TextChanged(object sender, EventArgs e)
        {
            string lgsText;
            lgsText = tb_50_result.Text.Replace(",", "");
            tb_50_result.Text = string.Format("{0:#,##0}", Convert.ToDouble(lgsText));
        }

        private void tb_10_result_TextChanged(object sender, EventArgs e)
        {
            string lgsText;
            lgsText = tb_10_result.Text.Replace(",", "");
            tb_10_result.Text = string.Format("{0:#,##0}", Convert.ToDouble(lgsText));
        }
        private void tb_MouseClick(object sender, MouseEventArgs e)
        {
            calculator_chk = false;
        }

        private bool onClick;
        private Point startPoint = new Point(0, 0);
        private void cash_MouseDown(object sender, MouseEventArgs e)
        {
            onClick = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void cash_MouseMove(object sender, MouseEventArgs e)
        {
            if (onClick)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        private void cash_MouseUp(object sender, MouseEventArgs e)
        {
            onClick = false;
        }

        private void tb_cash_result_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn;
            MySqlCommand cmd;
            string total_cash = "";
            string Conn = "Server=localhost;Port=3306;Database=cafe_menu;Uid=root;Pwd = dltkdwls12!;";
            conn = new MySqlConnection(Conn);
            conn.Open();
            cmd = new MySqlCommand("", conn);

            String sql = "SELECT sum(total_cash) FROM sales_tb";

            cmd.CommandText = sql;
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                total_cash = reader["sum(total_cash)"].ToString();
            }
            tb_cash_result.Text = total_cash;
        }
    }
    }

