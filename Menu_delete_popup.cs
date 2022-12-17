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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace visual_project
{
    public partial class Menu_delete_popup : Form
    {
        public Menu_delete_popup()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // 폼의 시작위치를 디스플레이의 가운데로 맞춤
        }
        public void menuevent() // 음료의 값을 버튼에 입력
        {
            product product = new product();
            String[] N = product.Drink_BUTN();
            String[] G = product.Drink_BUTG();
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
        public void menuevent_F() // 음식의 값을 버튼에 입력
        {
            product product = new product(); // 디저트류가 눌린상태..? 를 어떻게 받지
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
        public void menuevent_T() // 기타의 값을 버튼에 입력
        {
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
        private void button1_Click(object sender, EventArgs e) //검색버튼
        {
            if (checkBox1.Checked == false)
            {
                Order.order.d = 0;

            }
            if (checkBox2.Checked == false)
            {
                Order.order.f = 0;

            }
            if (checkBox3.Checked == false)
            {
                Order.order.t = 0;

            }
            listBox1.Items.Clear();
            product product = new product();
            if (Order.order.d == 1)
            {
                String[] N = product.Drink_BUTN();
                String[] G = product.Drink_BUTG();
                for (int i = 0; i < 30; i++)
                {
                    if (N[i] == null)
                    {
                        break;
                    }
                    listBox1.Items.Add(N[i]);
                }
            }
            if (Order.order.f == 1)
            {
                String[] N = product.Food_BUTN();
                String[] G = product.Food_BUTG();
                for (int i = 0; i < 30; i++)
                {
                    if (N[i] == null)
                    {
                        break;
                    }
                    listBox1.Items.Add(N[i]);
                }
            }
            if (Order.order.t == 1)
            {
                String[] N = product.Thing_BUTN();
                String[] G = product.Thing_BUTG();
                for (int i = 0; i < 30; i++)
                {
                    if (N[i] == null)
                    {
                        break;
                    }
                    listBox1.Items.Add(N[i]);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //종료버튼(팝업창 닫기)
        {
            if (MessageBox.Show("종료하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e) //삭제버튼
        {
            //textBox1에 입력된 메뉴를 찾는다
            product product = new product();
            if (Order.order.d == 1) // 음료 버튼이 눌려지고 삭제버튼을 눌렀을 때 
            {
                product.Drink_Delete(textBox2.Text);
                menuevent();
                // 밑 문장은 삭제된 값이 자동으로 검색란에 추가되기 위한 것
                String[] N = product.Drink_BUTN();
                String[] G = product.Drink_BUTG();
                listBox1.Items.Clear();
                for (int i = 0; i < 30; i++)
                {
                    if (N[i] == null)
                    {
                        return;
                    }
                    listBox1.Items.Add(N[i]);
                }

            }
            else if (Order.order.f == 1)
            {
                product.Food_Delete(textBox2.Text);
                menuevent_F();
                // 밑 문장은 삭제된 값이 자동으로 검색란에 추가되기 위한 것
                String[] N = product.Food_BUTN();
                String[] G = product.Food_BUTG();
                listBox1.Items.Clear();
                for (int i = 0; i < 30; i++)
                {
                    if (N[i] == null)
                    {
                        return;
                    }
                    listBox1.Items.Add(N[i]);
                }
            }
            else if (Order.order.t == 1)
            {
                product.Thing_Delete(textBox2.Text);
                menuevent_T();
                // 밑 문장은 삭제된 값이 자동으로 검색란에 추가되기 위한 것
                String[] N = product.Thing_BUTN();
                String[] G = product.Thing_BUTG();
                listBox1.Items.Clear();
                for (int i = 0; i < 30; i++)
                {
                    if (N[i] == null)
                    {
                        return;
                    }
                    listBox1.Items.Add(N[i]);
                }
            }
            //textBox2에 입력된 메뉴의 이름이 해당된 모든 메뉴를 출력한다
        }

        private bool onClick;
        private Point startPoint = new Point(0, 0);
        private void Menu_delete_popup_MouseDown(object sender, MouseEventArgs e)
        {
            onClick = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void Menu_delete_popup_MouseMove(object sender, MouseEventArgs e)
        {
            if (onClick)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }
        private void Menu_delete_popup_MouseUp(object sender, MouseEventArgs e)
        {
            onClick = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) //음료체크상자 체크상태
        {
            Order.order.d = 1;
            if (checkBox2.Checked)
            {
                Order.order.f = 1;
            }
            else
            {
                Order.order.f = 0;

            }
            if (checkBox3.Checked)
            {
                Order.order.t = 1;
            }
            else
            {
                Order.order.t = 0;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) //음식체크상자 체크상태
        {
            Order.order.f = 1;
            if (checkBox1.Checked)
            {
                Order.order.d = 1;
            }
            else
            {
                Order.order.d = 0;

            }
            if (checkBox3.Checked)
            {
                Order.order.t = 1;
            }
            else
            {
                Order.order.t = 0;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) //물건체크상자 체크상태
        {
            Order.order.t = 1;
            if (checkBox1.Checked)
            {
                Order.order.d = 1;
            }
            else
            {
                Order.order.d = 0;

            }
            if (checkBox2.Checked)
            {
                Order.order.f = 1;
            }
            else
            {
                Order.order.f = 0;
            }
        }
    }
}
