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
        private int hp = 100, maxHP = 100, strenth = 10, dexterity = 5, Intellegence = 7, randNum = 0;
        string[] nameArray = { "1번", "2번", "3번", "4번", "5번" };
        Random random;

        public Character(string name)
        {
            random = new Random();

            Genarate();
            this.name = name;

            TestPrintStatus(this);
        }
        public Character()
        {
            random = new Random();
            randNum = random.Next(5);
            name = nameArray[randNum];
            Genarate();

            TestPrintStatus(this);
        }

        void Genarate()
        {

            maxHP = random.Next(100, 201);
            hp = maxHP;
            strenth = random.Next(20) + 1;
            dexterity = random.Next(20) + 1;
            Intellegence = random.Next(20) + 1;

        }
        void TestPrintStatus(Character c)
        {
            Console.WriteLine($"이름\t:\t{c.name}\nhp\t:\t{c.hp}/{c.maxHP}\n힘\t:\t{c.strenth}\n민첩\t:\t{c.dexterity}\n지능\t:\t{c.Intellegence}\n");
        }

        public void Attack(Character target)
        {
            int damage = strenth;
            Console.WriteLine($"{name}이 {target.name}에게 피해를 {damage}만큼 가했습니다.\n");
            target.TakeDamage(damage, this);
        }
        public void TakeDamage(int d, Character attacker)
        {
            TestPrintStatus(attacker);
            TestPrintStatus(this);
            hp -= d;
            Console.WriteLine($"\n{name}의 체력은 {d}만큼의 피해를 입었습니다.\n현재 {name}의 체력은 {hp + d}에서 {hp}로 변경\n");
            if (hp <= 0)
            {
                Console.WriteLine("전투가 종료되었습니다.");
                Console.WriteLine($"{name}은 사망하였습니다.");
            }


        }

        public void Fight(Character target)
        {
            bool die = false;
            while (!die)
            {
                Attack(target);
                die = HP(this,target);

                target.Attack(this);
                die = HP(this, target);
            }
        }

        bool HP(Character a, Character b)
        {
            if (a.hp <= 0 || b.hp <= 0)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
