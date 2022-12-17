using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Calculate
{
    public partial class Sales
    {
        // 필드 선언
        int amountReceived;
        int change;
        public int totalPrice;
        int amountToReceive;
        int total_cash;
        public DateTime date;
        bool isRefunded;
        bool isCash;
        Dictionary<string, int[]> productInfo;
        Dictionary<string, int[]> orderInfo;

        // 생성자 : 기본값으로 초기화
        public Sales()
        {
            amountReceived = 0;
            change = 0;
            totalPrice = 0;
            amountToReceive = 0;
            total_cash = 0;
            date = DateTime.Parse(date.ToString());
            isRefunded = false;
            isCash = false;
            // key는 제품명, value의 0번 인덱스는 가격 1번인덱스는 재고 수
            productInfo = new Dictionary<string, int[]>();

            // key는 제품명, value의 0번 인덱스는 가격 1번인덱스는 상품 수
            orderInfo = new Dictionary<string, int[]>();
        }
        public void LoadProducts()
        {
            string conn = "Server=localhost;Port=3306;Database=cafe_menu;Uid=root;Pwd=dltkdwls12!;"; // DB 연결문
            string[] tableNames = { "menu_table", "menu_table_food", "menu_table_thing" }; // DB table 이름
            using (MySqlConnection Conn = new MySqlConnection(conn))
            {
                Conn.Open();
                string sql = string.Format("SELECT * FROM {0} UNION SELECT * FROM {1} UNION SELECT * FROM {2}", tableNames[0], tableNames[1], tableNames[2]);
                MySqlCommand cmd = new MySqlCommand(sql, Conn);
                MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    productInfo.Add((string)mySqlDataReader["Name"], new int[] { int.Parse((string)mySqlDataReader["Price"]), 99 });
                }
                mySqlDataReader.Dispose();

            }           
        }

        public Dictionary<string, int[]> OrderInfo
        {
            get
            {
                return this.orderInfo;
            }
        }
        public Dictionary<string, int[]> ProductInfo
        {
            get
            {
                return this.productInfo;
            }
        }
        //프로퍼티 정의
        public int AmountReceived
        {
            get
            {
                return amountReceived;
            }
        }

        public int AmountToReceive
        {
            get
            {
                return amountToReceive;
            }
        }
        public int Change
        {
            get
            {
                return change;
            }
        }
        public int TotalCount
        {
            get
            {
                int count = 0;

                foreach(KeyValuePair<string, int[]> order in orderInfo)
                {
                    count += order.Value[1];
                }

                return count;
            }
        }
        public int TotalPrice
        {
            get
            {
                return totalPrice;
            }
        }

        public int Total_Cash
        {
            get
            {
                return total_cash;
            }
        }
        // 로드한 물품 정보들을 정리하는 메소드
        public void LoadProducts(string name, int price, int quantity)
        {
            productInfo.Add(name, new int[] { price, quantity });
        }

        // 계산 기능 수행하는 메소드
        public void CheckOut()
        {
            int temp = 0;
            // 각 물품의 가격과 수량을 곱하여 총 가격 계산
            foreach (KeyValuePair<string, int[]> kvp in orderInfo)
                temp += kvp.Value[0] * kvp.Value[1];

            totalPrice = temp;
            amountToReceive = totalPrice - amountReceived;

            if (amountToReceive < 0)
            {
                change = -amountToReceive;
                amountToReceive = 0;
            }
            else
            {
                change = 0;
            }

            // 현재 날짜 저장
            date = DateTime.Now;

            // 현재 날짜 저장
            date = DateTime.Now;
        }

        // 재고수와 주문 수량을 비교하는 메소드
        public bool CheckStock(string s)
        {
            return productInfo[s][1] > orderInfo[s][1];
        }

        // 새로운 주문을 추가하거나, 상품의 수를 1늘린다.
        public void AddOrder(string s)
        {
            if (!orderInfo.ContainsKey(s))
            {
                if (productInfo[s][1] != 0)
                {
                    orderInfo.Add(s, new int[] { productInfo[s][0], 1 });
                }
                else
                {
                    throw new NoAmountException();
                }
            }
            else
            {
                IncAmount(s);
            }

        }

        // 선택한 상품 수를 1개 늘리거나 줄이는 메소드
        public void IncAmount(string s)
        {
            //if (CheckStock(s))
                orderInfo[s][1]++;
            //else throw new NoAmountException();
        }
        public void DecAmount(string s)
        {
            if (orderInfo[s][1] != 0)
                orderInfo[s][1]--;
        }


        // 해당 주문을 환불된 주문으로 설정하는 메소드
        public bool Refund()
        {
            if (isRefunded)
                return true;
            else
            {
                isRefunded = true; return false;
            }
        }

        // 해당 주문을 현금결제로 설정하는 메소드
        public void setCashOrder()
        {
            isCash = true;
        }

        // 해당 주문을 카드결제로 설정하는 메소드
        public void setCardOrder()
        {
            isCash = true;
            if (isCash == true)
            {
                int temp = 0;

                // 각 물품의 가격과 수량을 곱하여 총 가격 계산
                foreach (KeyValuePair<string, int[]> kvp in orderInfo)
                    temp += kvp.Value[0] * kvp.Value[1];

                totalPrice = temp;
                total_cash = temp;
                amountToReceive = totalPrice - amountReceived;


                if (amountToReceive < 0)
                {
                    change = -amountToReceive;
                    amountToReceive = 0;
                }
                else
                {
                    change = 0;
                }
            }
        }

        // 전체 주문을 취소하는 메소드
        public void CancelOrder()
        {
            amountReceived = 0;
            change = 0;
            totalPrice = 0;
            amountToReceive = 0;
            date = new DateTime();
            isRefunded = false;
            isCash = false;            
            orderInfo = new Dictionary<string, int[]>();
        }

        // 선택한 주문을 취소하는 메소드
        public void SelectCancelOrder(string s)
        {
            orderInfo.Remove(s);
        }

        // 받은 금액을 추가하는 메소드
        public void ReceiveMoney(int amount)
        {
            amountReceived = amount;
        }
    }

    // 재고 부족 예외
    public class NoAmountException : Exception
    {
        public NoAmountException() { }
    }
}