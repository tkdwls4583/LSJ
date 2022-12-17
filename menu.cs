using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using visual_project;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace menuu
{
    public partial class product : Interface // : 인터페이스 상속받기
    {
        String[] Name = new String[2];    //– 제품명,가격 값을 입력받음
        String[] s = new String[100];

        // 메뉴 추가버튼이 클릭되었을때 실행---------------------------------------------------------------------------------------------------------------------------------
        public void Drink_Insertion(String Name, String Price)
        {
            //   추가할 메뉴의 제품명 가격을 입력하는 창이 나온다.
            Drink_Insert(Name, Price);

        }
        public void Food_Insertion(String Name, String Price)
        {
            //   추가할 메뉴의 제품명 가격을 입력하는 창이 나온다.
            Food_Insert(Name, Price);
        }
        public void Thing_Insertion(String Name, String Price)
        {
            //   추가할 메뉴의 제품명 가격을 입력하는 창이 나온다.
            Thing_Insert(Name, Price);


        }
        // ----------------------------------------------------------------------------------------------------------------------------------------------------------



        //  메뉴 삭제버튼이 클릭되었을때 실행---------------------------------------------------------------------------------------------------------------------------------
        public void Drink_Delete(String Name)
        {
            // 삭제할 메뉴의 제품명을 입력하는 창이 나온다.
            Drink_Del(Name);

        }
        public void Food_Delete(String Name)
        {
            // 삭제할 메뉴의 제품명을 입력하는 창이 나온다.
            Food_Del(Name);

        }
        public void Thing_Delete(String Name)
        {
            // 삭제할 메뉴의 제품명을 입력하는 창이 나온다.
            Thing_Del(Name);

        }
        // ----------------------------------------------------------------------------------------------------------------------------------------------------------



        // 메뉴 수정버튼이 클릭되었을때 실행---------------------------------------------------------------------------------------------------------------------------------
        public void Drink_Correction(String Name, String Price, String newName)
        {
            Drink_Cor(Name, Price, newName);
            // 수정할 메뉴의 제품명을 입력하는 창이 나온다.
            // 클릭한 메뉴 제품명에 대한 값을 리턴받는다
            // DB에서 입력한 제품명과 메뉴이름이 같은것이 있다면
            //  메뉴의 제품명 가격 수량 기타를 입력하는 창이 나온다.
            // DB에 메뉴 이름을 해당하는 클래스에 접속 및 저장
        }
        public void Food_Correction(String Name, String Price, String newName)
        {
            Food_Cor(Name, Price, newName);
            // 수정할 메뉴의 제품명을 입력하는 창이 나온다.
            // 클릭한 메뉴 제품명에 대한 값을 리턴받는다
            // DB에서 입력한 제품명과 메뉴이름이 같은것이 있다면
            //  메뉴의 제품명 가격 수량 기타를 입력하는 창이 나온다.
            // DB에 메뉴 이름을 해당하는 클래스에 접속 및 저장
        }
        public void Thing_Correction(String Name, String Price, String newName)
        {
            Thing_Cor(Name, Price, newName);
            // 수정할 메뉴의 제품명을 입력하는 창이 나온다.
            // 클릭한 메뉴 제품명에 대한 값을 리턴받는다
            // DB에서 입력한 제품명과 메뉴이름이 같은것이 있다면
            //  메뉴의 제품명 가격 수량 기타를 입력하는 창이 나온다.
            // DB에 메뉴 이름을 해당하는 클래스에 접속 및 저장
        }
        public String[] Drink_BUTN() // 음료에서 Name의 값을 받아서 리턴하는 메소드
        {
            String[] N = Drink_BUN();
            return N;
        }
        public String[] Food_BUTN() // 음식에서 Name의 값을 받아서 리턴하는 메소드
        {
            String[] N = Food_BUN();
            return N;
        }
        public String[] Thing_BUTN()// 기타에서 Name의 값을 받아서 리턴하는 메소드
        {
            String[] N = Thing_BUN();
            return N;
        }

        public String[] Drink_BUTG()// 음료에서 Price의 값을 받아서 리턴하는 메소드
        {
            String[] G = Drink_BUG();
            return G;
        }
        public String[] Food_BUTG()// 음식에서 Price의 값을 받아서 리턴하는 메소드
        {
            String[] G = Food_BUG();
            return G;
        }
        public String[] Thing_BUTG()// 기타에서 Price의 값을 받아서 리턴하는 메소드
        {
            String[] G = Thing_BUG();
            return G;
        }
        //  ----------------------------------------------------------------------------------------------------------------------------------------------------------
        public String[] MemberID() // 회원정보 관리 DB를 인터페이스에서 수행하기 위한 메소드
        {
            String[] ID = MemberI();
            return ID;
        }
        public String[] MemberCall() // 회원정보 관리 DB를 인터페이스에서 수행하기 위한 메소드
        {
            String[] Call = MemberC();
            return Call;
        }
        public String[] Memberpoint() // 회원정보 관리 DB를 인터페이스에서 수행하기 위한 메소드
        {
            String[] point = MemberP();
            return point;
        }

        public void Modifying_information(String d, String Name, String Number, String Point) // 회원정보를 수정하는 메소드
        {
            Modifying_i(d, Name, Number, Point);

        }
        public void Delete_information(String Number)
        {
            Delete_i(Number);
        }
        public void PointPlus(String Sp0, String Sp1, String Sp2)
        {
            PP(Sp0, Sp1, Sp2);
        }
    }
}