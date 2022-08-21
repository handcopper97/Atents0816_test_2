using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Atents_22._08._16_01_Console_2
{
    public class Orc : Character
    {
        //스테이터스
        public string mName;
        //public bool Monster = true, Boss = false, head_start = true; //몬스터여부, 보스여부, 선제공격여부

        string[] mNameArray = { "오크 병사", "오크 정예병", "오크 궁수", "오크 주술사", "오크 족장" };
        
        
        public Orc()
        {
            
            type = "Monster";
            
            //Genarate();
            ////Console.WriteLine("\naa\n");
            //TestPrintStatus(this);
        }
        public override void Genarate()
        {
            random = new Random(DateTime.Now.Millisecond);
            mName = mNameArray[random.Next(0, 5)];
            name = mName;

            int[] stat;
            int minHP, maxmaxHP, minStr, minDex, minInt;
            switch (mName)
            {
                case ("오크 병사"):
                    stat = SetMonster(150, 150, 5, 3, 1);
                    //printM(stat);
                    break;
                case ("오크 정예병"):
                    stat = SetMonster(300, 300, 7, 7, 1);
                    //printM(stat);
                    break;
                case ("오크 궁수"):
                    stat = SetMonster(70, 70, 3, 5, 1);
                    //printM(stat);
                    break;
                case ("오크 주술사"):
                    stat = SetMonster(100, 100, 3, 3, 8);
                    //printM(stat);
                    break;

                case ("오크 족장"):
                    stat = SetMonster(800, 800, 9, 9, 3);
                    type = "Boss";
                    //printM(stat);
                    break;
                default:
                    Console.Error.WriteLine("\n잘못된 몬스터 식별 값입니다.\n");
                    Console.WriteLine($"\n지금 입력된 값은 {mName}입니다.\n");

                    stat = SetMonster(100, 100, 5, 5, 5);
                    name = mNameArray[random.Next(0, mNameArray.Length)];
                    
                    break;
            }


            maxHP = stat[1];
            hp = maxHP;
            strenth = stat[2];
            dexterity = stat[3];
            Intellegence = stat[4];
            
        }

        public int[] SetMonster(int Hp = 100, int maxHp = 200, int Str = 5, int Dex = 5, int Int = 5)
        {
            int[] stat = { Hp, maxHp, Str, Dex, Int };
            return stat;
        }

        public void printM(int[] s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(s[i]);
            }
        }

        

    }
}
