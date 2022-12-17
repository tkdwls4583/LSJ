using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HorseRacing
{
    class Program
    {
        static int sel;
        static Thread[] horse = new Thread[3];
        static int posA = 0, posB = 0, posC = 0;
        static Random rnd = new Random(DateTime.Now.Millisecond);
        static bool gameOver = false;
        static void GameOver(int index)
        {
            if (gameOver == true)
                return;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(index.ToString() + "번 말이 우승했습니다. ");
            Console.SetCursorPosition(0, 1);
            if (sel == index)
                Console.WriteLine("당신의 말이 승리했습니다. ");
            else
                Console.WriteLine("당신의 말이 패배했습니다. ");
            gameOver = true;
        }
        static void Horse1()
        {
            while (posA < 40)
            {
                System.Threading.Thread.Sleep(50);
                Console.SetCursorPosition(posA, 5);
                Console.Write(" @1>");
                posA += rnd.Next(0, 2);
            }
            GameOver(1);
        }
        static void Horse2()
        {
            while (posB < 40)
            {
                System.Threading.Thread.Sleep(50);
                Console.SetCursorPosition(posB, 8);
                Console.Write(" @2>");
                posB += rnd.Next(0, 2);
            }
            GameOver(2);
        }
        static void Horse3()
        {
            while (posC < 40)
            {
                System.Threading.Thread.Sleep(50);
                Console.SetCursorPosition(posC, 11);
                Console.Write(" @3>");
                posC += rnd.Next(0, 2);
            }
            GameOver(3);
        }
        static void Main(string[] args)
        {
            horse[0] = new Thread(Horse1);
            horse[1] = new Thread(Horse2);
            horse[2] = new Thread(Horse3);
            Console.Write("당신의 말을 선택하세요 (1-3) ");
            sel = Console.Read() - 48;
            Console.WriteLine("당신이 선택한 말은 " + sel.ToString() + "번말 입니다.");
            horse[0].Start();
            horse[1].Start();
            horse[2].Start();
        }
    }
}