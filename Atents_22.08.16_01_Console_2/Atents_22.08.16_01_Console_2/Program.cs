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
            //Console.WriteLine("손동욱");//내 이름 출력

            //int level, hp, maxHP;
            //float exp, maxExp;
            //string name;

            //Console.WriteLine($"{name}의 레벨은 {level}이고 HP는 {hp}이고 exp는 {exp}%다.\n");

            //string result = $"이름 : {name}\n레벨 : {level}\nHP : {hp}\nexp : {exp}%\n\n";
            //Console.WriteLine(result);


            //Console.Write("이름을 입력하세요 : ");
            //name = Console.ReadLine();

            //Console.Write($"{name}의 레벨을 입력하세요 : ");
            //level = int.Parse(Console.ReadLine());

            //Console.Write($"{name}의 hp를 입력하세요 : ");
            //hp = int.Parse(Console.ReadLine());

            //Console.Write($"{name}의 maxHp를 입력하세요 : ");
            //maxHP = int.Parse(Console.ReadLine());


            //Console.Write($"{name}의 경험치를 입력하세요 : ");
            //exp = float.Parse(Console.ReadLine());

            //Console.Write($"{name}의 max경험치를 입력하세요 : ");
            //maxExp = float.Parse(Console.ReadLine());

            ////result = $"\n이름 : {name}\n레벨 : {level}\nHP : {hp}\nexp : {exp * 100:F3}%\n\n";
            ////Console.WriteLine(result);

            //PrintCharacter(name, level, hp, maxHP, exp, maxExp);
            //Console.WriteLine("경험치를 추가합니다.\n");
            //Console.Write("추가할 경험치 : ");
            //string temp = Console.ReadLine();
            //float sum = exp + float.Parse(temp);
            //if (sum >= 1)
            //{
            //    Console.WriteLine("\n레벨업");
            //}
            //else
            //{


            //    Console.WriteLine($"\n현재 경험치는 {sum}입니다.\n\n\n");
            //}

            //exp = 0.0f;
            //sum = 0;
            //Console.WriteLine($"\n반복문 시작.\n현재 경험치는 {sum}입니다.");
            //while (sum < 1)
            //{
            //    Console.Write("추가할 경험치를 입력해주세요 : ");
            //    temp = Console.ReadLine();

            //    sum += exp + float.Parse(temp);

            //    Console.WriteLine($"\n현재 경험치는 {sum}입니다.");
            //}

            //while (sum > 1)
            //{
            //    sum -= 1;
            //    Console.WriteLine($"\n레벨업\n현재 경험치는 {sum * 100:f1}%입니다.");
            //}
            int temp;
            temp = calcul();


            print(temp);

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

        //private static void PrintCharacter(string name, int level, int hp, int maxHP, float exp, float maxExp)
        //{
           
        //    string result = $"\n이름 : {name}\n레벨 : {level}\nHP/maxHP : {hp}/{maxHP}\nexp/maxExp : {exp * 100:F3}%/{maxExp*100:F3}\n\n";

        //    Console.WriteLine(result);


        //}
    }
}
