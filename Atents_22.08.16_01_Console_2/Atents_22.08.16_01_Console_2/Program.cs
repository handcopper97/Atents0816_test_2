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
            float exp = 0.9f;
            string name = "너굴맨";
            Console.WriteLine($"{name}의 레벨은 {level}이고 HP는 {hp}이고 exp는 {exp}다.");


            Console.ReadKey();
        }
    }
}
