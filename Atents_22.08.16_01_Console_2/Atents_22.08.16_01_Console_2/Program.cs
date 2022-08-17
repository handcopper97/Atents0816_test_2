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
            Console.WriteLine("손동욱");//내 이름 출력

            int level = 1, hp = 10;
            float exp = 90;
            string name = "너굴맨";
            Console.WriteLine($"{name}의 레벨은 {level}이고 HP는 {hp}이고 exp는 {exp}%다.\n");

            string result = $"이름 : {name}\n레벨 : {level}\nHP : {hp}\nexp : {exp}%\n\n";
            Console.WriteLine(result);


            Console.Write("이름을 입력하세요 : ");
            name = Console.ReadLine();

            Console.Write($"{name}의 레벨을 입력하세요 : ");
            level = int.Parse(Console.ReadLine());

            Console.Write($"{name}의 hp를 입력하세요 : ");
            hp = int.Parse(Console.ReadLine());

            Console.Write($"{name}의 경험치를 입력하세요 : ");
            exp = float.Parse(Console.ReadLine());

            result = $"\n이름 : {name}\n레벨 : {level}\nHP : {hp}\nexp : {exp*100:F3}%\n\n";
            Console.WriteLine(result);



            Console.ReadKey();
        }
    }
}
