using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atents_22._08._16_01_Console_2
{
    public class Character
    {
        private string name;
        private int hp = 100, maxHP = 100, strenth = 10, dexterity = 5, Intellegence = 7;

        string[] nameArray = { "1번", "2번", "3번", "4번", "5번" };

        public Character()
        {
            Random random = new Random();
            int randomNum = random.Next();
            name = nameArray[randomNum % 4];
            resetRendom(randomNum, random);
            while (randomNum % 201 < 100)
            {
                resetRendom(randomNum, random);
            }
            maxHP = randomNum % 201;
            hp = maxHP;


            randomNum = random.Next();
            while (true)
            {
                strenth = randomNum % 21;
                randomNum = random.Next();
                if (strenth != 0)
                {
                    break;
                }
            }
            while (true)
            {
                randomNum = random.Next();
                dexterity = randomNum % 21;
                if (dexterity != 0)
                {
                    break;
                }
            } while (true)
            {
                randomNum = random.Next();
                Intellegence = randomNum % 21;
                if (Intellegence != 0)
                {
                    break;
                }
            }

            TestPrintStatus(this);
        }
        void TestPrintStatus(Character c)
        {
            Console.WriteLine($"이름\t:\t{c.name}\nhp\t:\t{c.hp}/{c.maxHP}\n힘\t:\t{c.strenth}\n민첩\t:\t{c.dexterity}\n지능\t:\t{c.Intellegence}\n");
        }

        void resetRendom(int r, Random rr)
        {
            r = rr.Next();
        }

        //public Character(string newName)
        //{
        //    name = newName;
        //}
    }
    internal class test
    {
    }
}
