using System;
using menuu;
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
    public partial class Menu_insert_popup : Form
    {
        public static Menu_insert_popup menu_Insert_Popup;
        public Menu_insert_popup()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // 폼의 시작위치를 디스플레이의 가운데로 맞춤
            menu_Insert_Popup = this;
            this.button2.Click += button2_Click;
        }

        public void menuevent()
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
        public void menuevent_F()
        {
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
        public void menuevent_T()
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
        private void button1_Click(object sender, EventArgs e) // 메뉴추가 버튼
        {
            //메뉴추가 메소드 연결
            product product = new product();
            if (Order.order.d == 1)
            {
                product.Drink_Insertion(textBox1.Text, textBox2.Text);
                menuevent();
            }
            else if (Order.order.f == 1)
            {
                product.Food_Insertion(textBox1.Text, textBox2.Text);
                menuevent_F();
            }
            else if (Order.order.t == 1)
            {
                product.Thing_Insertion(textBox1.Text, textBox2.Text);
                menuevent_T();
            }
        }

        private void button2_Click(object sender, EventArgs e) //메뉴추가 취소버튼
        {
            if (MessageBox.Show("종료하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private bool onClick;
        private Point startPoint = new Point(0, 0);
        private void Menu_insert_popup_MouseDown(object sender, MouseEventArgs e)
        {
            onClick = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void Menu_insert_popup_MouseMove(object sender, MouseEventArgs e)
        {
            if (onClick)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        private void Menu_insert_popup_MouseUp(object sender, MouseEventArgs e)
        {
            onClick = false;
        }
    }
}
