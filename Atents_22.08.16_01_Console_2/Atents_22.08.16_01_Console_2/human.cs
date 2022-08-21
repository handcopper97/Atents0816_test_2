using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atents_22._08._16_01_Console_2
{
    public class human : Character
    {
        public human()
        {
            type = "Player";
        }
        public override void TestPrintStatus(Character c)
        {
            Console.WriteLine($"이름\t:\t{c.Name}\nhp\t:\t{c.hp}/{c.maxHP}\nmp\t:\t{c.mp}/{c.maxMP}\n힘\t:\t{c.strenth}\n민첩\t:\t{c.dexterity}\n지능\t:\t{c.Intellegence}\n");
        }

        public override void Skill(Character target)
        {
            switch (type)
            {
                case ("Player"):

                    if (MP(5))
                    {
                        strenth *= Intellegence;
                        Attack(target);
                        strenth /= Intellegence;
                    }
                    else
                    {
                        Console.WriteLine($"플레이어의 MP가 {5 - mp} 부족하여 스킬 사용 실패");
                    }
                    break;
                case ("Monster"):
                    //플레이어만 구현

                    break;
                default: break;
            }


        }

        public override void Defancing(int d = 0)
        {
            defance = d;
        }
        public override bool MP(int m)
        {
            if (mp - m < 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}
