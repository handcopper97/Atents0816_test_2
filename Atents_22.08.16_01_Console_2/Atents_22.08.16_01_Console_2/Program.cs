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
            

            //Character human1 = new Character();

            //Character human2 = new Character("테스트용");

            //human1.Fight(human2);
            Console.WriteLine("전투 조우!\n");

            human h1 = new human();
            Orc e = new Orc();

            Fighting(h1, e);




            Console.ReadKey();
        }

        public static void Fighting(Character p, Character m)
        {
            int menu = 0;
            bool die = false;


            Console.WriteLine("\n전투 시작!\n");

            while (!die)
            {
                Console.WriteLine("\n플레이어의 행동을 선택하세요.(1, 2, 3)\n");
                Console.WriteLine("\n1.\t공격\n2.\t스킬\n3.\t방어\n\n");
                menu = int.Parse(Console.ReadLine());
                Console.WriteLine($"\n{menu}번 행동을 선택하셨습니다.\n");

                switch (menu)
                {
                    case 1:
                        p.Attack(m);
                        p.TestPrintStatus(p);
                        m.TestPrintStatus(m);

                        die = m.HP(p, m);
                        continue;
                        break;
                    case 2:
                        p.Skill(m);
                        p.TestPrintStatus(p);
                        m.TestPrintStatus(m);

                        die = m.HP(p, m);
                        continue;
                        break;
                    case 3:
                        p.Defancing();
                        m.Attack(p);
                        p.TestPrintStatus(p);
                        m.TestPrintStatus(m);

                        die = m.HP(p, m);
                        continue;
                        break;
                    default:
                        
                        Console.WriteLine("\n잘못된 값을 입력하셨습니다.\n1~3번까지의 숫자를 선택해주세요.\n");
                        continue;
                        break;

                }

            }
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
