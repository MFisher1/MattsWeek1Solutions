using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Timer
            var Timer = new System.Timers.Timer(2000);

            //Variables
            //General
            int round = 1;
            int turn = 1;
            //Heros stats
            //-HP: health points
            int hp = 100;
            int healthPotions = 4;
            int skooma = 2;
            int rage = 0;
            int herosDamage = 0;
            string name;
            string herosMove;
            bool skoomaUsed = false;
            bool invalidMove = false;
            //wh = warhammer: does 50 damage but only hits 70% of the time
            //sw = sword: does 40 damage and hits 80% of the time
            //dg = dagger: does 15 damage but hits 100% of the time
            string weapon;

            //enemies stats
            int enemyHP = 200;
            int enemyRage = 0;
            int enemyDamage = 0;
            string enemyMove;

            //Start
            ChangeText("Drem Yol Yok Dovakin.", "Greetings Dragonborn");
            //pause code(for effect)
            System.Threading.Thread.Sleep(2000);
            Console.Write("(Press Enter)");
            Console.ReadKey();
            Console.Clear();
            ChangeText("Fos Los Hin For Uld Hun", "What Is Your Name Mighty Hero?");
            Console.WriteLine();
            name = Console.ReadLine();
            Console.Clear();

            //Game Intro
            Console.WriteLine(name + " you are the mighty Dovakin or DragonBorn. After training you're self to be the hero the world needs you to be(and much ale)"
             + "You are ready to face the evil dragon Alduin. Though you a much smaller (and obviously not a huge fricken dragon). You have"
             + " The power of dragon shouts, courage and Skooma(Pretty much skyrim PCP)! During the fight you will have 4 abilities to choose from."
             + "If you're rage is high enough (goes up for every successfull attack) the dragon spirit is awoken in you and you can unleash,"
             + "a mighty shout on your enemy. The more rage you have, the more powerful your shout. You're next ability is you're trusty sword"
             + "though it doesn't hurt as much as a shout, its sturdy and realiable and can be used on every turn. On a more stratigic side, you"
             + "carry on you 4 bottles of health potion, and 2 of Skooma (your skooma dealer got busted). The health potions can heal for 30"
             + "HP and the skooma increase your atack damage for you're next turn by 30 (50 if its used before a shout). and your rage by 2");
            Console.WriteLine("To play press ENTER ");
            Console.ReadKey();
            Console.Clear();
            //Pick weapon
            Console.WriteLine("To start off your adventure, " + name + " you must first pick out your weaponry. Each has different pros and cons so chose wisely");
            Console.WriteLine("(Press the coresponding letter next to a weapon then press enter to chose it)");
            Console.WriteLine("wh = warhammer: does 40 damage but only hits 70% of the time");
            Console.WriteLine("sw = sword: does 30 damage and hits 80% of the time");
            Console.WriteLine("dg = dagger: does 15 damage but hits 100% of the time");
            //Figure out weapon variable
            weapon = ChooseWeapon(Console.ReadLine());
            //If weapon is invalid loop until it isnt
            while (weapon == "Invalid")
            {
                Console.WriteLine("Invalid Choice, Pick Another Weapon");
                weapon = ChooseWeapon(Console.ReadLine());
            }
            Console.Clear();

            ChangeText("Bo Nu Dovah Kiin Ahrk Luft Hin Paal!", "Go Now Dragonborn And Face Your Foe!");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();

            //Game Start
            while (hp != 0 && enemyHP != 0)
            {
                //Basic Game Stats
                Console.WriteLine("Round: " + round);
                Console.WriteLine("Alduin's Health: " + enemyHP);
                Console.WriteLine("Alduins's Rage: " + enemyRage);
                Console.WriteLine("Your Health: " + hp);
                Console.WriteLine();
                //Heros Turn
                while(turn == 1 || invalidMove)
                {
                    
                        Console.Clear();
                        //Pick move
                        Console.WriteLine("Pick Your Move");
                        Console.WriteLine();
                        Console.WriteLine("S: Shout ");
                        if (rage < 4)
                        {
                            Console.Write("(not enough rage!)");
                        }
                        Console.WriteLine("W: " + weapon);
                        Console.WriteLine("H :Health Potion " + healthPotions);
                        if (healthPotions <= 0)
                        {
                            Console.Write(" (out of potions)");
                        }
                        Console.WriteLine("SK: Skooma: " + skooma);
                        if (skooma <= 0)
                        {
                            Console.Write(" (out of skooma)");
                        }
                        Console.WriteLine();
                       
                        herosMove = Console.ReadLine();
                        Console.Clear();
                        //If skooma was used last round add damage
                        if (skoomaUsed == true)
                        {
                            herosDamage += 30;
                        }
                        //Execute move

                        //Shout
                        if (herosMove == "S" && rage < 4)
                        {
                            //If skooma was used last round add damage
                            if (skoomaUsed == true)
                            {
                                herosDamage += 50;
                            }
                            herosDamage += 30 * rage;
                            enemyHP -= herosDamage;
                            rage = 0;
                            Console.WriteLine("You're mighty shout did " + herosDamage + " damage!");
                            skoomaUsed = false;
                        }
                        //Weapon
                        else if (herosMove == "W")
                        {
                            //If skooma was used last round add damage
                            if (skoomaUsed == true)
                            {
                                herosDamage += 30;
                            }
                            herosDamage += WeaponDamage(weapon);
                            Console.WriteLine("Your " + weapon + " did " + herosDamage + " damage.");
                            skoomaUsed = false;
                        }
                        //Health Potion
                        else if (herosMove == "H" && healthPotions > 0)
                        {
                            hp += 30;
                            Console.WriteLine("You healed yourself for 30 hp!");
                            healthPotions--;
                        }
                        //Skooma
                        else if (herosMove == "SK" && skooma > 0)
                        {
                            skoomaUsed = true;
                            Console.WriteLine("Your Skooma gave you strength");
                            skooma--;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Move");
                            invalidMove = true;
                        }
                    
                }
                    //set enemy turn and reset heros damage
                    turn = 2;
                    herosDamage = 0;
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();

                    //End of Heroes Turn
                
                    //Enemy Turn
                    if (turn == 2)
                    {
                        enemyMove = EnemyMove(enemyRage);
                        if (enemyMove == "fireball")
                        {
                            hp -= 30;
                            Console.WriteLine("Enemy Fireball did 30 damage!");
                        }
                        else if (enemyMove == "shout")
                        {
                            hp -= 30 * enemyRage;
                            Console.WriteLine("Enemy Shout did " + 30 * enemyRage + " damage!");
                            enemyRage = 0;
                        }
                        else if (enemyMove == "bite")
                        {
                            hp -= 20;
                        }
                        else
                        {
                            Console.WriteLine("Enemy Attack Failed!");
                        }
                        turn = 1;
                    }
                    //end of round
                    round++;
                    System.Threading.Thread.Sleep(1000);

                


            }

            //End of game
            if (enemyHP < 0 && hp < 0)
            {
                ChangeText("Lost grind yolus dinok nuz lost kuz hin paal voth hi! Nu hi fent velaaz ko mund do Sovengaurd ahrk joriin do keizaal fen dahmaan hi fah bok wah meyz!", "You have met a fierey death but have taken your foe with you! Now you shall feast in the halls of Sovengaurd and the people of skyrim will remember you for ages to come!");
            }
            else if (enemyHP < 0)
            {
                ChangeText("Dovahkiin! Hi lost krinaan Alduin, sav keizaal ahrk lask hinmaar unahzaal praal ko Sovengaurd!", "Congradulations Dragonborn! You have slain Alduin, saved skyrim and earned yourself an eternal seat in Sovengaurd!");
            }
            else if (hp < 0)
              {
                  ChangeText("Not only have you been eaten alive, but you have left the world to be destroyed by Alduin!", "Not only have you been eaten alive, but you have left the world to be destroyed by Alduin!");  
              }
            Console.ReadKey();
        }

        //Functions
        
        //Weapon functions
        //Choose weapon
        static string ChooseWeapon(string weapon)
        {
            
            if (weapon == "wh")
            {
                return "WarHammer";
            }
            else if (weapon == "sw")
            {
                return "Sword";
            }
            else if (weapon == "dg")
            {
                return "Dagger";
            }
            else
            {
                return "Invalid";
            }
        }

        //Weapon Damage
        static int WeaponDamage(string weapon)
        {
            //Chance
            Random rnd = new Random();
            int chance = rnd.Next(1, 10);
            int damage = 0;

            if (weapon == "WarHammer")
            {
                if (chance <= 7)
                {
                    damage = 40;
                }
            }
            else if (weapon == "Sword")
            {
                if (chance <= 8)
                {
                    damage = 30;
                }
            }
            else
            {
                damage = 15;
            }
            return damage;

        }

        //Change Text Function
        //Changes text from the dragon tongue to english
        static void ChangeText(string firstText, string secondText)
        {
            
            for (int i = 0; i < firstText.Length; i++)
            {
                Console.Write(firstText[i]);
                System.Threading.Thread.Sleep(50);

            }
            Console.WriteLine();
            System.Threading.Thread.Sleep(2000);
            for (int i = 0; i < secondText.Length; i++)
            {   
                Console.Write(secondText[i]);
                System.Threading.Thread.Sleep(50);
            }
         }

        //Enemy turn function
        static string EnemyMove(int rage)
        {
            //enemy's ability's
            //fireball - does a lot of damage but has a 70% chance of hitting
            //shout - very strong ability but can only be used if Alduins "RAGE" is full, also has a 70% chance of hitting
            //bite-week attack but always hits
            
            //rand int to decide which attack is used
            Random rnd = new Random();
            int move = rnd.Next(1, 4);
            int chance = rnd.Next(1, 10);
            //shout
            if (rage > 10 && move == 3)
            {
                //70% chance of hitting
                if (chance <= 7)
                {
                    return "shout";
                }
                    //attack failed
                else
                {
                    return "failled";
                }
                
            }
            // fireball
            else if (move == 1)
            {
                //70% chance of hitting
                if (chance <= 7)
                {
                    return "fireball";
                }
                //attack failled
                else
                {
                    return "failled";
                }
            }
            //bite
            else
            {
                return "bite";
            }


        }
    }
}
