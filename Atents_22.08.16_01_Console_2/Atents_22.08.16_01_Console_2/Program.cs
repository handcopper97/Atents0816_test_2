using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atents_22._08._16_01_Console_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character human1 = new Character();
            
            Character human2 = new Character("테스트용");

            human1.Fight(human2);

            Console.ReadKey();
        }
        private static void print(int a)
        {
            for(int i=1; i < 10; i++)
            {
                Console.WriteLine($"{a}*{i}\t=\t{a*i}");
            }
            

        }

        private static int calcul()
        {
            int a;
            while (true)
            {
                Console.Write("계산할 숫자\t: ");
                a = int.Parse(Console.ReadLine());
                if (a <= 9 && a >= 2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n 잘못된 값을 입력하셨습니다.\n 2~9까지의 숫자를 다시 입력해주세요.\n");
                }
            }
            return a;
        }
    }
}
