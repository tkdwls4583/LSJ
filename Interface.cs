using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Globalization;
using Calculate;
using visual_project;

namespace menuu
{
    public partial class Interface
    {
        string Conn = "Server=localhost;Port=3306;Database=cafe_menu;Uid=root;Pwd=dltkdwls12!;";
        //pwd=caching_sha2_password

        public void pay(Calculate.Sales sales)
        {
            // DB에 주문 정보 저장
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {               
                conn.Open();
                MySqlCommand msc = new MySqlCommand("insert into sales_tb(date, total,total_2, VAT, net_sales, count, total_cash) values('"
                    + sales.date.ToString("yyyy-MM-dd")
                    + "', '"
                    + sales.TotalPrice
                    + "', '"
                    + sales.TotalPrice
                    + "', '"
                    + sales.TotalPrice * 0.1
                    + "', '"
                    + sales.TotalPrice * 0.9
                    + "', '"
                    + sales.TotalCount
                    + "', '"
                    + sales.Total_Cash
                    + "')", conn);
                msc.ExecuteNonQuery();
                MessageBox.Show("결제 성공");
            }
        }

        public Dictionary<string, string[]> getSalesData()
        {
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                Dictionary<string, string[]> salesData = new Dictionary<string, string[]>();

                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM cafe_menu.sales_tb";
                    MySqlCommand msc = new MySqlCommand(sql, conn);
                    MySqlDataReader table = msc.ExecuteReader();
                    while (table.Read())
                    {
                        string[] orderInfo = new string[4];
                        orderInfo[0] = (string)table["total"];
                        orderInfo[1] = (string)table["VAT"];
                        orderInfo[2] = (string)table["net_sales"];
                        orderInfo[3] = (string)table["count"];
                        orderInfo[4] = (string)table["total_cash"];

                        salesData.Add((string)table["date"], orderInfo);
                    }
                    table.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }
                return salesData;
            }
        }
        public void Drink_Insert(String Name, String Price)
        {
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                int i = 0;
                String[] N = new String[100];
                String[] G = new String[100];

                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM cafe_menu.menu_table";
                    MySqlCommand msc = new MySqlCommand(sql, conn);
                    MySqlDataReader table = msc.ExecuteReader();
                    while (table.Read())
                    {
                        //Console.WriteLine("{0} {1}", table["Name"], table["Price"]);
                        N[i] = table["Name"].ToString();
                        G[i] = table["Price"].ToString();
                        i++;
                    }
                    table.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }
                for (int j = 0; j < 100; j++)
                {
                    if (Name == N[j])
                    {
                        MessageBox.Show("중복하는 제품명이 존재합니다.");
                        return;
                    }
                }
            }
            // 제품명과 가격을 DB에 삽입
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                conn.Open();
                MySqlCommand msc = new MySqlCommand("insert into menu_table(Name,Price) values('" + Name + "', '" + Price + "')", conn);
                msc.ExecuteNonQuery();
                MessageBox.Show("저장되었습니다.");
            }
            // 중복하는 제품이 있는지 확인하기 위해 제품명과 가격을 DB에서 가져와서 확인한다.

        }
        public void Food_Insert(String Name, String Price)
        {
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                int i = 0;
                String[] N = new String[100];
                String[] G = new String[100];

                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM cafe_menu.menu_table_food";
                    MySqlCommand msc = new MySqlCommand(sql, conn);
                    MySqlDataReader table = msc.ExecuteReader();
                    while (table.Read())
                    {
                        //Console.WriteLine("{0} {1}", table["Name"], table["Price"]);
                        N[i] = table["Name"].ToString();
                        G[i] = table["Price"].ToString();
                        i++;
                    }
                    table.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }
                for (int j = 0; j < 100; j++)
                {
                    if (Name == N[j])
                    {
                        MessageBox.Show("중복하는 제품명이 존재합니다.");
                        return;
                    }
                }
            }
            // 제품명과 가격을 DB에 삽입
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                conn.Open();
                MySqlCommand msc = new MySqlCommand("insert into menu_table_food(Name,Price) values('" + Name + "', '" + Price + "')", conn);
                msc.ExecuteNonQuery();
                MessageBox.Show("저장되었습니다.");
            }
            // 중복하는 제품이 있는지 확인하기 위해 제품명과 가격을 DB에서 가져와서 확인한다.

        }
        public void Thing_Insert(String Name, String Price)
        {
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                int i = 0;
                String[] N = new String[100];
                String[] G = new String[100];

                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM cafe_menu.menu_table_thing";
                    MySqlCommand msc = new MySqlCommand(sql, conn);
                    MySqlDataReader table = msc.ExecuteReader();
                    while (table.Read())
                    {
                        //Console.WriteLine("{0} {1}", table["Name"], table["Price"]);
                        N[i] = table["Name"].ToString();
                        G[i] = table["Price"].ToString();
                        i++;
                    }
                    table.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }
                for (int j = 0; j < 100; j++)
                {
                    if (Name == N[j])
                    {
                        MessageBox.Show("중복하는 제품명이 존재합니다.");
                        return;
                    }
                }
            }
            // 제품명과 가격을 DB에 삽입
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                conn.Open();
                MySqlCommand msc = new MySqlCommand("insert into menu_table_thing(Name,Price) values('" + Name + "', '" + Price + "')", conn);
                msc.ExecuteNonQuery();
                MessageBox.Show("저장되었습니다.");
            }
            // 중복하는 제품이 있는지 확인하기 위해 제품명과 가격을 DB에서 가져와서 확인한다.

        }
        public void Drink_Del(String Name)
        {
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                int i = 0;
                int l = 0;
                String[] N = new String[100];
                String[] G = new String[100];

                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM cafe_menu.menu_table";
                    MySqlCommand msc = new MySqlCommand(sql, conn);
                    MySqlDataReader table = msc.ExecuteReader();
                    while (table.Read())
                    {
                        //Console.WriteLine("{0} {1}", table["Name"], table["Price"]);
                        N[i] = table["Name"].ToString();
                        G[i] = table["Price"].ToString();
                        i++;
                    }
                    table.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }               
                for (int j = 0; j < 30; j++) // 데이터베이스에 없는 이름이 들어오면 삭제가 안됌. 
                { // l의 값은 0 이 기본임
                    if (Name == N[j]) // 삭제하고 싶은 값이 데이터베이스에 있는경우
                    {
                        // 데이터 베이스에 있다면 하나만 존재하기 때문에 l = 1 이됨
                        // 데이터 베이스에 존재하지 않는다면 이 문장을 거치지 않으므로 l = 0 이됨
                        l = 1; // l이 1이 삭제하고 싶은 제품명이 하나도 데이터베이스에 없다는 뜻
                    }
                    
                }
                
            }
            using (MySqlConnection conn = new MySqlConnection(Conn))
            { // 해당하는 이름이 존재한다면 삭제
                MySqlCommand msc = new MySqlCommand("delete from menu_table where Name = '" + Name + "';", conn);
                MySqlDataReader myReader;
                try
                {
                    conn.Open();
                    myReader = msc.ExecuteReader(); // 삭제하는 문장
                    MessageBox.Show("삭제됨"); // 값이 null일때도 삭제되는데 이 문제 해결해야함
                    while (myReader.Read())
                    {
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //  DB의 제품명을 모두 출력한다.
        }
        public void Food_Del(String Name)
        {
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                int i = 0;
                int l = 0;
                String[] N = new String[100];
                String[] G = new String[100];

                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM cafe_menu.menu_table_thing";
                    MySqlCommand msc = new MySqlCommand(sql, conn);
                    MySqlDataReader table = msc.ExecuteReader();
                    while (table.Read())
                    {
                        //Console.WriteLine("{0} {1}", table["Name"], table["Price"]);
                        N[i] = table["Name"].ToString();
                        G[i] = table["Price"].ToString();
                        i++;
                    }
                    table.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }
                for (int j = 0; j < 30; j++) // 데이터베이스에 없는 이름이 들어오면 삭제가 안됌. 
                { // l의 값은 0 이 기본임
                    if (Name == N[j]) // 삭제하고 싶은 값이 데이터베이스에 있는경우
                    {
                        // 데이터 베이스에 있다면 l = 1 이됨
                        // 데이터 베이스에 존재하지 않는다면 이 문장을 거치지 않으므로 l = 0 이됨
                        l = 1; // l이 1이 삭제하고 싶은 제품명이 하나도 데이터베이스에 없다는 뜻
                    }                    
                }             
            }
            using (MySqlConnection conn = new MySqlConnection(Conn))
            { // 해당하는 이름이 존재한다면 삭제
                MySqlCommand msc = new MySqlCommand("delete from menu_table_food where Name = '" + Name + "';", conn);
                MySqlDataReader myReader;
                try
                {
                    conn.Open();
                    myReader = msc.ExecuteReader(); // 삭제하는 문장
                    MessageBox.Show("삭제됨"); // 값이 null일때도 삭제되는데 이 문제 해결해야함
                    while (myReader.Read())
                    {
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //  DB의 제품명을 모두 출력한다.
        }
        public void Thing_Del(String Name)
        {
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                int i = 0;
                int l = 0;
                String[] N = new String[100];
                String[] G = new String[100];

                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM cafe_menu.menu_table_thing";
                    MySqlCommand msc = new MySqlCommand(sql, conn);
                    MySqlDataReader table = msc.ExecuteReader();
                    while (table.Read())
                    {
                        //Console.WriteLine("{0} {1}", table["Name"], table["Price"]);
                        N[i] = table["Name"].ToString();
                        G[i] = table["Price"].ToString();
                        i++;
                    }
                    table.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }

                for (int j = 0; j < 30; j++) // 데이터베이스에 없는 이름이 들어오면 삭제가 안됌. 
                { // l의 값은 0 이 기본임
                    if (Name == N[j]) // 삭제하고 싶은 값이 데이터베이스에 있는경우
                    {
                        // 데이터 베이스에 있다면 l = 1 이됨
                        // 데이터 베이스에 존재하지 않는다면 이 문장을 거치지 않으므로 l = 0 이됨
                        l = 1; // l이 1이 삭제하고 싶은 제품명이 하나도 데이터베이스에 없다는 뜻
                    }                  
                }
                
            }
            using (MySqlConnection conn = new MySqlConnection(Conn))
            { // 해당하는 이름이 존재한다면 삭제
                MySqlCommand msc = new MySqlCommand("delete from menu_table_thing where Name = '" + Name + "';", conn);
                MySqlDataReader myReader;
                try
                {
                    conn.Open();
                    myReader = msc.ExecuteReader(); // 삭제하는 문장
                    MessageBox.Show("삭제됨"); // 값이 null일때도 삭제되는데 이 문제 해결해야함
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //  DB의 제품명을 모두 출력한다.
        }
        public void Drink_Cor(String Name, String Price, String newName)
        {
            using (MySqlConnection conn = new MySqlConnection(Conn))
            { // 버튼 5에 수정할 제품명이 이름을 넣으면 수정됨.
                MySqlCommand msc = new MySqlCommand("update menu_table set Name = '" + newName + "', Price = '" + Price + "'" + "where Name = '" + Name + "';", conn);
                MySqlDataReader myReader;
                try
                {
                    conn.Open();
                    myReader = msc.ExecuteReader(); // 수정하는 문장
                    MessageBox.Show("수정되었습니다");
                    while (myReader.Read())
                    {
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void Food_Cor(String Name, String Price, String newName)
        {
            using (MySqlConnection conn = new MySqlConnection(Conn))
            { // 버튼 5에 수정할 제품명이 이름을 넣으면 수정됨.
                MySqlCommand msc = new MySqlCommand("update menu_table_food set Name = '" + newName + "', Price = '" + Price + "'" + "where Name = '" + Name + "';", conn);
                MySqlDataReader myReader;
                try
                {
                    conn.Open();
                    myReader = msc.ExecuteReader(); // 수정하는 문장
                    MessageBox.Show("수정되었습니다");
                    while (myReader.Read())
                    {
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void Thing_Cor(String Name, String Price, String newName)
        {
            using (MySqlConnection conn = new MySqlConnection(Conn))
            { // 버튼 5에 수정할 제품명이 이름을 넣으면 수정됨.
                MySqlCommand msc = new MySqlCommand("update menu_table_thing set Name = '" + newName + "', Price = '" + Price + "'" + "where Name = '" + Name + "';", conn);
                MySqlDataReader myReader;
                try
                {
                    conn.Open();
                    myReader = msc.ExecuteReader(); // 수정하는 문장
                    MessageBox.Show("수정되었습니다");
                    while (myReader.Read())
                    {
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public String[] Drink_BUN()
        {
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                int i = 0;
                String[] N = new String[30];
                String[] G = new String[30];

                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM cafe_menu.menu_table";
                    MySqlCommand msc = new MySqlCommand(sql, conn);
                    MySqlDataReader table = msc.ExecuteReader();
                    while (table.Read())
                    {
                        //Console.WriteLine("{0} {1}", table["Name"], table["Price"]);
                        N[i] = table["Name"].ToString();
                        G[i] = table["Price"].ToString();
                        i++;
                    }
                    table.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }
                return N;
            }
        }
        public String[] Food_BUN()
        {
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                int i = 0;
                String[] N = new String[30];
                String[] G = new String[30];

                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM cafe_menu.menu_table_food";
                    MySqlCommand msc = new MySqlCommand(sql, conn);
                    MySqlDataReader table = msc.ExecuteReader();
                    while (table.Read())
                    {
                        //Console.WriteLine("{0} {1}", table["Name"], table["Price"]);
                        N[i] = table["Name"].ToString();
                        G[i] = table["Price"].ToString();
                        i++;
                    }
                    table.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }
                return N;
            }
        }
        public String[] Thing_BUN()
        {
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                int i = 0;
                String[] N = new String[30];
                String[] G = new String[30];

                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM cafe_menu.menu_table_thing";
                    MySqlCommand msc = new MySqlCommand(sql, conn);
                    MySqlDataReader table = msc.ExecuteReader();
                    while (table.Read())
                    {
                        //Console.WriteLine("{0} {1}", table["Name"], table["Price"]);
                        N[i] = table["Name"].ToString();
                        G[i] = table["Price"].ToString();
                        i++;
                    }
                    table.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }
                return N;
            }
        }
        public String[] Drink_BUG()
        {
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                int i = 0;
                String[] N = new String[30];
                String[] G = new String[30];

                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM cafe_menu.menu_table";
                    MySqlCommand msc = new MySqlCommand(sql, conn);
                    MySqlDataReader table = msc.ExecuteReader();
                    while (table.Read())
                    {
                        //Console.WriteLine("{0} {1}", table["Name"], table["Price"]);
                        N[i] = table["Name"].ToString();
                        G[i] = table["Price"].ToString();
                        i++;
                    }
                    table.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }
                return G;
            }
        }
        public String[] Food_BUG()
        {
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                int i = 0;
                String[] N = new String[30];
                String[] G = new String[30];

                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM cafe_menu.menu_table_food";
                    MySqlCommand msc = new MySqlCommand(sql, conn);
                    MySqlDataReader table = msc.ExecuteReader();
                    while (table.Read())
                    {
                        //Console.WriteLine("{0} {1}", table["Name"], table["Price"]);
                        N[i] = table["Name"].ToString();
                        G[i] = table["Price"].ToString();
                        i++;
                    }
                    table.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }
                return G;
            }
        }
        public String[] Thing_BUG()
        {
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                int i = 0;
                String[] N = new String[30];
                String[] G = new String[30];

                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM cafe_menu.menu_table_thing";
                    MySqlCommand msc = new MySqlCommand(sql, conn);
                    MySqlDataReader table = msc.ExecuteReader();
                    while (table.Read())
                    {
                        //Console.WriteLine("{0} {1}", table["Name"], table["Price"]);
                        N[i] = table["Name"].ToString();
                        G[i] = table["Price"].ToString();
                        i++;
                    }
                    table.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }
                return G;
            }
        }

        // 회원관리
        public String[] MemberI() // id를 DB에서 가져옴
        {
            string Conn = "Server=localhost;Port=3306;Database=cafe_menu;Uid=root;Pwd=dltkdwls12!;";
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                int i = 0;
                String[] I = new String[100];
                String[] C = new String[100];
                String[] P = new String[100];
                
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM cafe_menu.account_info";
                    MySqlCommand msc = new MySqlCommand(sql, conn);
                    MySqlDataReader table = msc.ExecuteReader();
                    while (table.Read())
                    {
                        //Console.WriteLine("{0} {1}", table["Name"], table["Price"]);
                        I[i] = table["id"].ToString();
                        C[i] = table["call_number"].ToString();
                        P[i] = table["point"].ToString();
                        i++;
                    }
                    table.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }
                return I;
            }
        }
        public String[] MemberC() // Call_number를 DB에서 가져옴
        {
            string Conn = "Server=localhost;Port=3306;Database=cafe_menu;Uid=root;Pwd=dltkdwls12!;";

            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                int i = 0;
                String[] I = new String[100];
                String[] C = new String[100];
                String[] P = new String[100];
              
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM cafe_menu.account_info";
                    MySqlCommand msc = new MySqlCommand(sql, conn);
                    MySqlDataReader table = msc.ExecuteReader();
                    while (table.Read())
                    {
                        //Console.WriteLine("{0} {1}", table["Name"], table["Price"]);
                        I[i] = table["id"].ToString();
                        C[i] = table["call_number"].ToString();
                        P[i] = table["point"].ToString();
                        i++;
                    }
                    table.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }
                return C;
            }
        }
        public String[] MemberP() // point를 DB에서 가져옴
        {
            string Conn = "Server=localhost;Port=3306;Database=cafe_menu;Uid=root;Pwd=dltkdwls12!;";

            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                int i = 0;
                String[] I = new String[100];
                String[] C = new String[100];
                String[] P = new String[100];
                
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM cafe_menu.account_info";
                    MySqlCommand msc = new MySqlCommand(sql, conn);
                    MySqlDataReader table = msc.ExecuteReader();
                    while (table.Read())
                    {
                        //Console.WriteLine("{0} {1}", table["Name"], table["Price"]);
                        I[i] = table["id"].ToString();
                        C[i] = table["call_number"].ToString();
                        P[i] = table["point"].ToString();
                        i++;
                    }
                    table.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }
                return P;
            }
        }
        public void Modifying_i(String d, String Name, String Number, String Point)
        {          
            using (MySqlConnection conn = new MySqlConnection(Conn))
            { // 버튼 5에 수정할 제품명이 이름을 넣으면 수정됨.
                MySqlCommand msc = new MySqlCommand("update account_info set id = '" + Name + "', call_number = '" + Number + "', point = '" + Point + "'" + "where id = '" + d + "';", conn);
                MySqlDataReader myReader;
                try
                {
                    conn.Open();
                    myReader = msc.ExecuteReader(); // 수정하는 문장
                    MessageBox.Show("회원정보 수정되었습니다");
                    while (myReader.Read())
                    {
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void Delete_i(String Number)
        {         
            using (MySqlConnection conn = new MySqlConnection(Conn))
            { // 해당하는 이름이 존재한다면 삭제
                MySqlCommand msc = new MySqlCommand("delete from account_info where call_number = '" + Number + "';", conn);
                MySqlDataReader myReader;
                try
                {
                    conn.Open();
                    myReader = msc.ExecuteReader(); // 삭제하는 문장
                    MessageBox.Show("삭제되었습니다"); // 값이 null일때도 삭제되는데 이 문제 해결해야함
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void PP(String Sp0, String Sp1, String Sp2) // 포인트를 더하는 문장
        {           
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                int i = 0;
                double k = 0;
                String[] I = new String[100];
                String[] C = new String[100];
                String[] P = new String[100];
                Calculate.Sales sales = Order.order.sales;
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM cafe_menu.account_info";
                    MySqlCommand msc = new MySqlCommand(sql, conn);
                    MySqlDataReader table = msc.ExecuteReader();
                    while (table.Read())
                    {
                        //Console.WriteLine("{0} {1}", table["Name"], table["Price"]);
                        I[i] = table["id"].ToString();
                        C[i] = table["call_number"].ToString();
                        P[i] = table["point"].ToString();
                        if (Sp0 == I[i]) // 리스트박스에서 선택한 이름과 같다면
                        {
                            if (Sp1 == C[i])// 리스트박스에서 선택한 전화번호와 같다면
                            {
                                k = double.Parse(Sp2) + Order.order.sales.totalPrice * 0.1;// 주문금액의 10% 받아오기
                                Sp2 = k.ToString();
                                MessageBox.Show(Sp2);
                            }                          
                        }
                        i++;
                    }
                    table.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }
            }
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                MySqlCommand msc = new MySqlCommand("update account_info set id = '" + Sp0 + "', call_number = '" + Sp1 + "', point = '" + Sp2 + "'" + "where call_number = '" + Sp1 + "';", conn);
                MySqlDataReader myReader;
                try
                {
                    conn.Open();
                    myReader = msc.ExecuteReader(); // 수정하는 문장
                    MessageBox.Show("포인트가 적립 되었습니다");
                    while (myReader.Read())
                    {
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}