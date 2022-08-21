using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atents_22._08._16_01_Console_2
{

    public class Character
    {
        protected string name;
        public int hp = 100, maxHP = 100, strenth = 10, dexterity = 5, Intellegence = 7, randNum = 0, mp = 100, maxMP = 100;
        public string[] nameArray = { "1번", "2번", "3번", "4번", "5번" };
        protected Random random;

        public string type; //몬스터여부, 보스여부, 플레이어여부
        public int skill_d, skill_m, skill_c; //스킬 데미지, 소비 마나, 쿨다운
        public int defance = 0;


        public string Name => name;
        public Character(string newName)
        {
            random = new Random(DateTime.Now.Millisecond);
            name = newName;

            Genarate();

            TestPrintStatus(this);
        }
        public Character()
        {
            //if ()
            //{


            //}
            //else
            //{
            random = new Random(DateTime.Now.Millisecond);
            randNum = random.Next();
            name = nameArray[randNum % 5];
            Genarate();

            TestPrintStatus(this);
            //}

        }

        public virtual void Genarate()
        {
            maxHP = random.Next(100, 201);
            hp = maxHP;
            maxMP = random.Next(50, 101);
            mp = maxMP;

            strenth = random.Next(20) + 1;
            dexterity = random.Next(20) + 1;
            Intellegence = random.Next(20) + 1;

        }
        public virtual void TestPrintStatus(Character c)
        {
            Console.WriteLine($"이름\t:\t{c.name}\nhp\t:\t{c.hp}/{c.maxHP}\n힘\t:\t{c.strenth}\n민첩\t:\t{c.dexterity}\n지능\t:\t{c.Intellegence}\n");
        }

        public void Attack(Character target)
        {

            randNum = random.Next(100);
            int damage = 0;

            //크리티컬 판정 검증
            if (randNum <= 29)
            {
                damage = strenth * 2;
                Console.WriteLine($"{Name}이 {target.Name}에게 치명타 피해를 {damage}만큼 가했습니다.\n");
            }
            else
            {
                damage = strenth;
                Console.WriteLine($"{Name}이 {target.Name}에게 피해를 {damage}만큼 가했습니다.\n");
            }

            target.TakeDamage(damage, this);
        }
        public void TakeDamage(int d, Character attacker)
        {
            if (defance > d)
            {
                Console.WriteLine($"\n방어 성공!\n{name}의 체력은 {d}만큼의 피해를 {defance}만큼의 방어로 막았습니다.\n");
                defance = 0;
            }
            else
            {
                hp -= d;
                Console.WriteLine($"\n{name}의 체력은 {d}만큼의 피해를 입었습니다.\n현재 {name}의 체력은 {hp + d}에서 {hp}로 변경\n");
                if (hp <= 0)
                {
                    Console.WriteLine("전투가 종료되었습니다.");
                    Console.WriteLine($"{name}은 사망하였습니다.\n\n");
                }
            }

            //TestPrintStatus(this);

        }

        public void Fight(Character target)
        {
            bool die = false;
            while (!die)
            {
                Attack(target);
                die = HP(this, target);
                TestPrintStatus(this);
                TestPrintStatus(target);


                target.Attack(this);
                die = HP(this, target);

                TestPrintStatus(this);
                TestPrintStatus(target);


            }
        }

        public bool HP(Character a, Character b)
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

        

        public virtual void Skill(Character target)
        {
        }

        public virtual bool MP(int m)
        {
            return true;
        }
        public virtual void Defancing(int d = 0)
        {
        }


    }

}
