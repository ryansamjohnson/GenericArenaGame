using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    class Program
    {
        private enum Events { AttackPlayer, AttackEnemy, DaysGen, Critical };

        static void Main(string[] args)
        {
            bool play = true;
            
            Console.WriteLine("Welcome to the arena! Prepare to face fearsome enemies!");
            Console.WriteLine("Try to make your living as a gladiator!");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("In this game, you will create a warrior will be given the days before your next battle.");
            Console.WriteLine("During that time before, you can chose to spend one day to train your warrior or rest until the battle.");
            Console.WriteLine("Remember not to train too hard.");
            Console.ReadLine();
            Console.Clear();
            while (play == true)
            {
                Console.WriteLine("Time to create your character.");
                Console.ReadLine();
                Character player = null;
                while (player == null)
                {
                    Console.WriteLine("What class will your character be?");
                    Console.WriteLine();
                    Console.WriteLine("Fighter - A more strength centered warrior. Good attack, but slow.");
                    Console.WriteLine("Myrmidon - A lightweight warrior. High speed and luck. Good at criticals.");
                    Console.WriteLine("Knight - Heavily armored warrior. High defense, but lower accuracy.");
                    Console.WriteLine("Cavalier - Horseback warrior. High attack, but less defense.");
                    Console.WriteLine("Tactician - Balanced warrior. Good all-around stats.");
                    Console.WriteLine();
                    #region Class Inputs
                    string classInput = Console.ReadLine().Trim().ToLower();
                    if (classInput == "fighter")
                        player = new FighterPlayer();
                    else if (classInput == "myrmidon")
                        player = new MyrmidonPlayer();
                    else if (classInput == "knight")
                        player = new KnightPlayer();
                    else if (classInput == "cavalier")
                        player = new CavalierPlayer();
                    else if (classInput == "tactician")
                        player = new TacticianPlayer();
                    else
                        Console.WriteLine("Please choose a class.");
                    #endregion
                }
                Console.WriteLine();
                Console.WriteLine("What is the character's name?");
                player.name = Console.ReadLine();
                player.energy = 100;
                player.tempHealth = player.health;
                Console.WriteLine();
                player.DisplayStats();
                Console.Clear();
                int battles = 0;
                while (player.tempHealth > 0)
                {
                    Character enemy = GenerateEnemy(battles);
                    BlacksmithDays--;
                    if (BlacksmithDays < 0)
                        BlacksmithDays = 0;
                    player = Training(player);
                    player.tempHealth = player.health;
                    GenerateBattle(player, enemy, battles);
                    battles++;
                    player.gold += (50 * battles + player.tempHealth);
                    if (battles >= 5 && player.IsPromoted == false) 
                    {
                        Character oldClass = player;
                        if (player.Class == "Myrmidon" && player.IsPromoted == false)
                        {
                            Console.WriteLine("Your battles have allowed you to exceed the limits of your current class.");
                            Console.WriteLine("Would you like to promote to the Weapon Master class?");
                            string confirm = Console.ReadLine();
                            if (confirm.Trim().ToLower() == "y" || confirm.Trim().ToLower() == "yes")
                            {
                                player = new WeaponMasterPlayer(oldClass);
                                player.tempHealth = player.health;
                                Console.WriteLine("You've been promoted to Weapon Master! New stats and skills are at your disposal!");
                                Console.ReadLine();
                            }
                        }
                        else if (player.Class == "Cavalier" && player.IsPromoted == false)
                        {
                            //Console.WriteLine("You've been promoted to Paladin! New stats and skills are at your disposal!");
                            //Console.ReadLine();
                            Console.WriteLine("Your battles have allowed you to exceed the limits of your current class.");
                            Console.WriteLine("Would you like to promote to the Weapon Master class?");
                            string confirm = Console.ReadLine();
                            if (confirm.Trim().ToLower() == "y" || confirm.Trim().ToLower() == "yes")
                            {
                                player = new WeaponMasterPlayer(oldClass);
                                player.tempHealth = player.health;
                                Console.WriteLine("You've been promoted to Weapon Master! New stats and skills are at your disposal!");
                                Console.ReadLine();
                            }
                        }
                        else if (player.Class == "Knight" && player.IsPromoted == false)
                        {
                            //Console.WriteLine("You've been promoted to General! New stats and skills are at your disposal!");
                            //Console.ReadLine();
                            Console.WriteLine("Your battles have allowed you to exceed the limits of your current class.");
                            Console.WriteLine("Would you like to promote to the Weapon Master class?");
                            string confirm = Console.ReadLine();
                            if (confirm.Trim().ToLower() == "y" || confirm.Trim().ToLower() == "yes")
                            {
                                player = new WeaponMasterPlayer(oldClass);
                                player.tempHealth = player.health;
                                Console.WriteLine("You've been promoted to Weapon Master! New stats and skills are at your disposal!");
                                Console.ReadLine();
                            }
                        }
                        else if (player.Class == "Tactician" && player.IsPromoted == false)
                        {
                            Console.WriteLine("You've been promoted to Grandmaster! New stats and skills are at your disposal!");
                            Console.ReadLine();
                        }
                        else if (player.Class == "Fighter" && player.IsPromoted == false)
                        {
                            Console.WriteLine("You've been promoted to Warrior! New stats and skills are at your disposal!");
                            Console.ReadLine();
                        }
                    }
                    player.energy = 100;
                }
                Console.WriteLine("So ends the tale of " + player.name + ".");
                Console.WriteLine("But like all fallen warriors, their legacy will live on.");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Would you like to play again? (Yes/No)");
                string response = Console.ReadLine().ToLower().Trim();
                if (response == "no")
                {
                    Console.WriteLine("Then we await your return, warrior.");
                    Console.ReadLine();
                    return;
                }
                Console.Clear();
            }
        }

        static Character Training(Character player)
        {
            Random rand = new Random();
            int days = rand.Next(3, 8);
            int daysTrained = 0;
            for (int i = 0; i < days; i++)
            {
                Console.WriteLine("You have " + (days - i) + " days until the next battle.");
                Console.WriteLine("You have " + player.energy + " energy.");
                Console.WriteLine("Would you like to rest or train? (Train/Rest)");
                if (BlacksmithDays != 0)
                {
                    Console.WriteLine("Days left on weapon smith: " + BlacksmithDays);
                    BlacksmithDays--;
                }
                string response = Console.ReadLine();
                Console.WriteLine();
                #region Train
                if (response.ToLower().Trim() == "train")
                {
                    if (daysTrained <= 2)
                    {
                        int healthInc = rand.Next(10, 16);
                        int attkInc = rand.Next(1, 9);
                        int defInc = rand.Next(1, 6);
                        int spdInc = rand.Next(1, 6);
                        player.health += healthInc;
                        player.attk += attkInc;
                        player.def += defInc;
                        player.spd += spdInc;
                        Console.WriteLine("Your stats increased!");
                        Console.ReadLine();
                        Console.WriteLine("Health increased by " + healthInc + "!");
                        Console.ReadLine();
                        Console.WriteLine("Attack increased by " + attkInc + "!");
                        Console.ReadLine();
                        Console.WriteLine("Defense increased by " + defInc + "!");
                        Console.ReadLine();
                        Console.WriteLine("Speed increased by " + spdInc + "!");
                        Console.ReadLine();
                        player.DisplayStats();
                        player.energy -= 15;
                    }
                    else
                    {
                        int healthDec = rand.Next(10, 16);
                        int attkDec = rand.Next(1, 9);
                        int defDec = rand.Next(1, 6);
                        int spdDec = rand.Next(1, 6);
                        player.health -= healthDec;
                        player.attk -= attkDec;
                        player.def -= defDec;
                        player.spd -= spdDec;
                        Console.WriteLine("You overworked your body.");
                        Console.ReadLine();
                        Console.WriteLine("Health decreased by " + healthDec + "!");
                        Console.ReadLine();
                        Console.WriteLine("Attack decreased by " + attkDec + "!");
                        Console.ReadLine();
                        Console.WriteLine("Defense decreased by " + defDec + "!");
                        Console.ReadLine();
                        Console.WriteLine("Speed decreased by " + spdDec + "!");
                        Console.ReadLine();
                        player.DisplayStats();
                        player.energy -= 20;
                    }
                }
                #endregion
                #region Rest
                else if (response.ToLower().Trim() == "rest")
                {
                    player.energy += 25;
                    if (player.energy > 100)
                        player.energy = 100;
                    Console.WriteLine("You rested and gained 25% of your energy.");
                    Console.WriteLine();
                    player.DisplayStats();
                    Console.WriteLine();
                }
                #endregion
                #region Weapon Shop
                else if (response.ToLower().Trim() == "weapon shop")
                {
                    player = WeaponShop(player);
                    if (BlacksmithDays != 0)
                        BlacksmithDays++;
                    i--;
                }
                #endregion
                else if (response.ToLower().Trim() == "check")
                {
                    player.DisplayStats();
                    if (BlacksmithDays != 0)
                        BlacksmithDays++;
                    i--;
                }
                #region Else
                else
                {
                    Console.WriteLine("Please choose train or rest");
                    if (BlacksmithDays != 0)
                        BlacksmithDays++;
                    i--;
                }
                #endregion
            }

            Console.WriteLine();
            Console.WriteLine("The battle is about to begin!");
            Console.Clear();
            return player;
        }

        static Character PotionShop(Character player, List<Item> itemList)
        {
            Console.WriteLine("Welcome to the potion shop!");
            Console.WriteLine();
            bool buying = true;
            do{
                Console.WriteLine("You have " + player.gold + " gold.");
                Console.WriteLine("Would you like to: ");
                Console.WriteLine();
                Console.WriteLine("Buy             Sell");
                Console.WriteLine("Leave");
                Console.WriteLine();
                string input = Console.ReadLine().ToLower().Trim();
                switch (input)
                {
                    case "buy":
                        Console.WriteLine("Here are today's items:");
                        Console.WriteLine();
                        foreach (Item item in itemList)
                        {
                            Console.WriteLine(item.Name + "     " + item.BaseCost);
                        }
                        Console.WriteLine();
                        Console.ReadLine();
                        Console.WriteLine("What would you like to buy?");
                        string buyInput = Console.ReadLine().ToLower().Trim();
                        foreach (Item item in itemList)
                        {
                            if (buyInput == item.Name.ToLower().Trim())
                            {
                                Console.WriteLine();
                                Console.WriteLine("You want to buy a " + item.Name + "?");
                                string buyOption = Console.ReadLine().Trim().ToLower();
                                if (buyOption == "yes")
                                {
                                    if (player.gold >= item.BaseCost)
                                    {
                                        player.gold -= item.BaseCost;
                                        Console.WriteLine("You bought the " + item.Name + ".");
                                        Console.ReadLine();
                                        // How do I create an if statement that can check if the player.inventory contains
                                        //an object with the Potion abstract class. Problem is the item is of a derrived class like SmallHealthPotion.
                                        //if (player.Inventory.Contains(IItem.Name.Trim().ToLower()))
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You don't have enough gold!");
                                        Console.ReadLine();
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        break;
                    case "sell":
                        Console.Clear();
                        Console.WriteLine("Here are your potions.");
                        Console.WriteLine();
                        foreach(Item potion in player.Inventory)
                        {
                            Console.WriteLine(potion.Name + "     " + potion.SellPrice);
                        }
                        Console.WriteLine();
                        Console.ReadLine();
                        Console.WriteLine("What would you like to sell?");
                        string sellInput = Console.ReadLine().ToLower().Trim();
                        foreach (Item item in itemList)
                        {
                            if (sellInput == item.Name.ToLower().Trim())
                            {
                                Console.WriteLine();
                                if (item.Quantity == 1)
                                {
                                    Console.WriteLine("You want to sell your " + item.Name + "for " + item.SellPrice + "?");
                                    string option = Console.ReadLine().Trim().ToLower();
                                    if (option == "yes")
                                    {
                                        player.gold += (int)item.SellPrice;
                                        Console.WriteLine();
                                        Console.WriteLine("Thank you.");
                                        Console.ReadLine();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Alright then.");
                                        Console.ReadLine();
                                        break;
                                    }
                                }
                                
                                else
                                {
                                    Console.WriteLine("You want to sell some of your " + item.Name + "s for " + item.SellPrice + " a each?");
                                    string option = Console.ReadLine().Trim().ToLower();
                                    if (option == "yes")
                                    {
                                        bool sell = false;
                                        do
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("How many?");
                                            string strNumber = Console.ReadLine().Trim().ToLower();
                                            int number;
                                            if (int.TryParse(strNumber, out number))
                                            {
                                                if (number > item.Quantity)
                                                {
                                                    Console.WriteLine();
                                                    Console.WriteLine("That is more than what you have.");
                                                    Console.ReadLine();
                                                }
                                                else
                                                {
                                                    player.gold += (int)(item.SellPrice * number);
                                                    item.Quantity -= number;
                                                    Console.WriteLine();
                                                    Console.WriteLine("Thank you.");
                                                    Console.ReadLine();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Please enter a number.");
                                                Console.ReadLine();
                                            }
                                            player.gold += (int)item.SellPrice;
                                            Console.WriteLine();
                                            Console.WriteLine("Thank you.");
                                            Console.ReadLine();
                                        } while (sell == false);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Alright then.");
                                        Console.ReadLine();
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        buying = false;
                        break;
                }
            }while (buying == true);
            return player;
        }

        static List<Item> GeneratePotionShopItems(int day, int battle)
        {
            List<Item> potionList = new List<Item>();
            switch (battle)
            {
                case 0:
                    potionList.Add(new SmallHealthPotion());
                    return potionList;
                default:
                    potionList.Add(new SmallHealthPotion());
                    return potionList;
            }
        }

        static Character WeaponShop(Character player)
        {
            Console.WriteLine("Blacksmith: Welcome to my shop! What can I do for you today?");
            Console.WriteLine("Commision a weapon               Upgrade a weapon");
            Console.WriteLine("Check on weapon");
            string response = Console.ReadLine().Trim().ToLower();
            switch (response)
            {
                case "commision a weapon":
                    int weaponID = 10000;
                    Weapon tempWeapon = new Weapon();
                    Console.WriteLine("What kind of weapon do you want?");
                    Console.WriteLine("Axe      Sword       Lance");
                    Console.WriteLine("Hammer   Katana      Poleaxe");
                    string answerType = Console.ReadLine().Trim().ToLower();
                    switch (answerType)
                    {
                        case "axe":
                            weaponID = weaponID + 1204;
                            break;
                        case "sword":
                            weaponID = weaponID + 204;
                            break;
                        case "lance":
                            weaponID = weaponID + 2204;
                            break;
                        case "hammer":
                            weaponID = weaponID + 1235;
                            break;
                        case "katana":
                            weaponID = weaponID + 235;
                            break;
                        default:
                            weaponID = weaponID + 2235;
                            break;
                    }
                    if (weaponID == 11235 || weaponID == 10235 || weaponID == 12235)
                    {
                        Console.WriteLine("Alright. I will get it done for you then.");
                        Console.WriteLine("Come check on it in a couple of days.");
                        Console.ReadLine();
                        BlacksmithFull = true;
                        BlacksmithWeapon = GenerateWeapon(weaponID);
                        break;
                        
                    }
                    Console.WriteLine();
                    Console.WriteLine("What material do you want it to be?");
                    Console.WriteLine("Iron     Steel       Silver");
                    string answerMaterial = Console.ReadLine().Trim().ToLower();
                    switch (answerMaterial)
                    {
                        case "iron":
                            weaponID = weaponID + 30;
                            break;
                        case "steel":
                            weaponID = weaponID + 40;
                            break;
                        case "silver":
                            weaponID = weaponID + 50;
                            break;
                        default:
                            weaponID = weaponID + 30;
                            break;
                    }
                    Console.WriteLine("Alright then. I'll get it done for you.");
                    Console.WriteLine("Come check on it in a couple of days.");
                    Console.ReadLine();
                    BlacksmithFull = true;
                    BlacksmithWeapon = GenerateWeapon(weaponID);
                    break;
                case "forge":
                    player = Forge(player);
                    break;
                case "check on weapon":
                    if (BlacksmithFull == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You didn't commision me to make you a weapon. ");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        if (BlacksmithDays == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("I've finished your new " + BlacksmithWeapon.WeaponType.Trim().ToLower() + ".");
                            Console.ReadLine();
                            Console.WriteLine("It'll cost you " + BlacksmithWeapon.BaseCost + " gold pieces.");
                            Console.WriteLine("Ready to buy? (Yes/No)");
                            string payResponse = Console.ReadLine().Trim().ToLower();
                            if (payResponse == "yes")
                            {
                                if (player.gold >= BlacksmithWeapon.BaseCost)
                                {
                                    player.gold = player.gold - BlacksmithWeapon.BaseCost;
                                    player.EquippedWeapon = BlacksmithWeapon;
                                    Console.WriteLine("Thank you for your business! Come back and see me again!");
                                    Console.ReadLine();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Ummm I don't think that's going to cover it.");
                                    Console.ReadLine();
                                    Console.WriteLine("Come back when you've got the money for this.");
                                    Console.ReadLine();
                                    break;
                                }
                            }
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Well something is wrong.");
                    break;
            }
            return player;
        }

        static Character FortuneTeller(Character player, Character enemy)
        {
            Console.WriteLine("Welcome to my tent! Allow me to look into your fate! Only 25 gold pieces.");
            Console.WriteLine("Pay the fortune teller for a reading? (Yes/No)");
            string answer = Console.ReadLine().Trim().ToLower();
            string enemyWeapon = enemy.EquippedWeapon.WeaponType.Trim().ToLower();
            if (answer == "yes")
            {
                player.gold = player.gold - 25;
                string enemyClass = enemy.Class;
                switch (enemyClass)
                {
                    case "Cavalier":
                        Console.WriteLine("It seems your next opponent will be on horseback.");
                        break;
                    case "Myrmidon":
                        Console.WriteLine("It seems your next opponent will be a fast one.");
                        break;
                    case "Fighter":
                        Console.WriteLine("It seems your next opponent will be a strong one.");
                        break;
                    case "Knight":
                        Console.WriteLine("It seems your next opponent will be slow but strong.");
                        break;
                    case "Tactician":
                        Console.WriteLine("It seems your next opponent is a smart one.");
                        break;
                    default:
                        Console.WriteLine("It seems your next opponent is very powerful indeed!");
                        break;
                }

                if (enemyWeapon == "axe")
                {
                    Console.WriteLine("He seems to be fond of using " + enemyWeapon + "es.");
                }
                else 
                    Console.WriteLine("He seems to be fond of using " + enemyWeapon + "s.");
                
                Console.ReadLine();
                Console.WriteLine("Well then, that is your fate. I wish you good luck in your battle! Feel free to visit me again.");
                Console.ReadLine();
            }
            else 
            {
                Console.WriteLine("That's fine. Feel free to visit me again.");
                Console.ReadLine();
            }
            return player;
        }

        static Character Forge(Character player)
        {
            Weapon tempWeapon = player.EquippedWeapon;
            return player;
        }

        static Weapon GenerateWeapon(int ID)
        {
            Weapon tempWeapon = new Weapon();
            switch (ID)
            {
                case 10234:
                    tempWeapon = new IronSword();
                    if (BlacksmithFull == true)
                    {
                        BlacksmithDays = 2;
                    }
                    return tempWeapon;
                case 10235:
                    tempWeapon = new IronKatana();
                    if (BlacksmithFull == true)
                    {
                        BlacksmithDays = 4;
                    }
                    return tempWeapon;
                case 11234:
                    tempWeapon = new IronAxe();
                    if (BlacksmithFull == true)
                    {
                        BlacksmithDays = 2;
                    }
                    return tempWeapon;
                case 11235:
                    tempWeapon = new Hammer();
                    if (BlacksmithFull == true)
                    {
                        BlacksmithDays = 4;
                    }
                    return tempWeapon;
                case 12234:
                    tempWeapon = new IronLance();
                    if (BlacksmithFull == true)
                    {
                        BlacksmithDays = 4;
                    }
                    return tempWeapon;
                case 12235:
                    tempWeapon = new Poleaxe();
                    if (BlacksmithFull == true)
                    {
                        BlacksmithDays = 4;
                    }
                    return tempWeapon;
                default:
                    tempWeapon = new IronSword();
                    if (BlacksmithFull == true)
                    {
                        BlacksmithDays = 2;
                    }
                    return tempWeapon;
            }
        }

        static Character GenerateBattle(Character player, Character enemy, int battles)
        {
            #region Beginning changes
            player.tempHealth -= (100 - player.energy);
            
            Console.WriteLine("This is battle " + (battles + 1));
            Attack attacking;
            int defUpCounter = -1;
            int spdUpCounter = -1;
            bool enemyChecked = false;
            bool isAttacking = true;
            int skillCounter = 0;
            bool PlayerTurn = true;
            #endregion

            #region Battle Loop
            do
            {
                #region Stat Increase Counters
                if (defUpCounter >= 0)
                {
                    if (defUpCounter == 4)
                    {
                        player.def = player.def / 2;
                        defUpCounter = -1;
                    }
                    else
                        defUpCounter++;
                }
                if (spdUpCounter >= 0)
                {
                    if (spdUpCounter == 4)
                    {
                        player.spd = player.spd / 2;
                        spdUpCounter = -1;
                    }
                    else
                        spdUpCounter++;
                }
                #endregion
                #region Player Turn
                if (PlayerTurn == true)
                {
                    Console.WriteLine("Player Health: " + player.tempHealth);
                    if (enemyChecked)
                    {
                        Console.WriteLine("Enemy Health: " + enemy.tempHealth);
                    }
                    Console.WriteLine("Would you like to: ");
                    Console.WriteLine("Attack               Defend");
                    Console.WriteLine("Check                Use Skill");
                    string command = Console.ReadLine();
                    Console.WriteLine();
                    #region Player Attack
                    if (command.ToLower().Trim() == "attack")
                    {
                        Console.WriteLine("Attacking...");
                        attacking = new Attack(Program.PlayerAttack);
                        if (attacking(player, enemy) == true)
                        {
                            Console.WriteLine("PlayerSpd " + player.spd);
                            Console.WriteLine("PlayerLck " + player.luck);
                            int critChance = (player.spd / 2) + player.luck - enemy.spd;
                            Console.WriteLine("CritChance " + critChance);
                            int critActual = RNG(Events.Critical);
                            Console.WriteLine("CritActual " + critActual);
                            if (critChance > critActual)
                            {
                                int damage = enemy.Defend(player) - enemy.tempHealth;
                                if (damage >= 0)
                                    damage = 0;
                                enemy.tempHealth += damage *3;
                                Console.WriteLine("Critical!! Enemy took " + (damage*3) + " damage!");
                                Console.ReadLine();
                                if (enemy.tempHealth <= 0)
                                {
                                    Console.WriteLine("You defeated the enemy!");
                                    Console.ReadLine();
                                    Console.Clear();
                                    return player;
                                }
                                if (skillCounter != 0)
                                    skillCounter--;
                                PlayerTurn = false;
                            }
                            else
                            {
                                int damage = enemy.Defend(player) - enemy.tempHealth;
                                if (damage >= 0)
                                    damage = 0;
                                enemy.tempHealth += damage;
                                Console.WriteLine("Hit! Enemy took " + damage + " damage!");
                                Console.ReadLine();
                                if (enemy.tempHealth <= 0)
                                {
                                    Console.WriteLine("You defeated the enemy!");
                                    Console.ReadLine();
                                    Console.Clear();
                                    return player;
                                }
                                if (skillCounter != 0)
                                    skillCounter--;
                                PlayerTurn = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You missed!");
                            Console.ReadLine();
                            if (skillCounter != 0)
                                skillCounter--;
                            PlayerTurn = false;
                        }
                    }
                    #endregion
                    #region Player Defend
                    if (command.ToLower().Trim() == "defend")
                    {
                        int tempDef = player.def / 2;
                        player.def += tempDef;
                        Console.WriteLine("You are defending.");
                        Console.ReadLine();
                        Console.WriteLine("Enemy is attacking...");
                        attacking = new Attack(Program.EnemyAttack);
                        if (attacking(player, enemy) == true)
                        {
                            int critChance = (player.spd / 2) + player.luck - enemy.spd;
                            int critActual = RNG(Events.Critical);
                            if (critChance > critActual)
                            {
                                int damage = player.Defend(enemy) - player.tempHealth;
                                if (damage >= 0)
                                    damage = 0;
                                player.tempHealth += damage * 3;
                                if (player.tempHealth <= 0)
                                {
                                    Console.WriteLine("Oh no! Critical!! You took " + (damage *3) + " mortal damage!");
                                    Console.WriteLine("You did not survive...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    return player;
                                }
                                else
                                {
                                    Console.WriteLine("Oh no! Critical!! You took " + (damage*3) + " damage!");
                                    Console.ReadLine();
                                    Console.Clear();
                                    if (skillCounter != 0)
                                        skillCounter--;
                                    PlayerTurn = true;
                                }
                            }
                            else
                            {
                                int damage = player.Defend(enemy) - player.tempHealth;
                                if (damage >= 0)
                                    damage = 0;
                                player.tempHealth += damage;
                                if (player.tempHealth <= 0)
                                {
                                    Console.WriteLine("You took " + damage + " mortal damage!");
                                    Console.WriteLine("You did not survive...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    return player;
                                }
                                else
                                {
                                    Console.WriteLine("You took " + damage + " damage!");
                                    Console.ReadLine();
                                    Console.Clear();
                                    if (skillCounter != 0)
                                        skillCounter--;
                                    PlayerTurn = true;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Enemy missed!");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        player.def -= tempDef;
                    }
                    #endregion
                    #region Player Check
                    if (command.ToLower().Trim() == "check")
                    {
                        enemyChecked = true;
                        enemy.DisplayStats();
                        PlayerTurn = false;
                    }
                    #endregion
                    #region Player Use Skill
                    if (command.ToLower().Trim() == "useskill" || command.ToLower().Trim() == "use skill")
                    {
                        if (skillCounter == 0)
                        {
                            switch (player.Class)
                            {
                                case "Fighter":
                                    int tempAttk = player.attk;
                                    player.attk += tempAttk;
                                    Console.WriteLine("Using " + player.name + "'s Overwhelm attack!");
                                    Console.ReadLine();
                                    Console.WriteLine("Attack is raised by " + tempAttk + "!");
                                    Console.ReadLine();
                                    int damage = enemy.Defend(player) - enemy.tempHealth;
                                    if (damage >= 0)
                                        damage = 0;
                                    enemy.tempHealth += damage;
                                    Console.WriteLine("The enemy took " + damage + " damage!");
                                    Console.ReadLine();
                                    player.attk -= tempAttk;
                                    if (enemy.tempHealth <= 0)
                                    {
                                        Console.WriteLine("You defeated the enemy!");
                                        Console.ReadLine();
                                        Console.Clear();
                                        return player;
                                    }
                                    skillCounter += 5;
                                    PlayerTurn = false;
                                    break;
                                case "Myrmidon":
                                    Console.WriteLine("Using " + player.name + "'s Test Your Luck skill!");
                                    Console.ReadLine();
                                    Console.WriteLine("Heads or tails?");
                                    string choice = Console.ReadLine().Trim().ToLower();
                                    Random rand = new Random();
                                    int coinFlip = rand.Next(0, 2);
                                    if ((coinFlip == 0 && choice == "heads") || (coinFlip == 1 && choice == "tails"))
                                    {
                                        Console.WriteLine("You won the coin toss!");
                                        Console.ReadLine();
                                        int damageMyrmidon = enemy.Defend(player) - enemy.tempHealth;
                                        if (damageMyrmidon >= 0)
                                            damageMyrmidon = 0;
                                        enemy.tempHealth += damageMyrmidon * 3;
                                        Console.WriteLine("The enemy took " + (damageMyrmidon * 3) + " damage!");
                                        Console.ReadLine();
                                        if (enemy.tempHealth <= 0)
                                        {
                                            Console.WriteLine("You defeated the enemy!");
                                            Console.ReadLine();
                                            Console.Clear();
                                            return player;
                                        }
                                        PlayerTurn = false;
                                    }
                                    if ((coinFlip == 0 && choice == "tails") || (coinFlip == 1 && choice == "heads"))
                                    {
                                        Console.WriteLine("You lost the coin toss.");
                                        Console.ReadLine();
                                        Console.WriteLine("The enemy took no damage.");
                                        Console.ReadLine();
                                        PlayerTurn = false;
                                    }
                                    skillCounter += 5;
                                    break;
                                case "Cavalier":
                                    Console.WriteLine("Using " + player.name + "'s Swift Movement skill!");
                                    Console.ReadLine();
                                    player.spd = player.spd * 2;
                                    Console.WriteLine("Player speed is raised for 3 turns!");
                                    Console.ReadLine();
                                    skillCounter += 5;
                                    spdUpCounter++;
                                    PlayerTurn = false;
                                    break;
                                case "Knight":
                                    Console.WriteLine("Using " + player.name + "'s Great Shield skill!");
                                    Console.ReadLine();
                                    player.def = player.def * 2;
                                    Console.WriteLine("Player defense is raised for 3 turns!");
                                    Console.ReadLine();
                                    skillCounter += 5;
                                    PlayerTurn = false;
                                    defUpCounter++;
                                    break;
                                default:
                                    Console.WriteLine("Using " + player.name + "'s Strategy skill!");
                                    Console.ReadLine();
                                    int tempAttack = enemy.attk / 2;
                                    int tempAcc = enemy.acc / 2;
                                    int tempSpd = enemy.spd / 2;
                                    player.attk += tempAttack;
                                    player.def += tempAcc;
                                    player.spd += tempSpd;
                                    Console.WriteLine(player.name + " is using the enemy's weakness to attack.");
                                    Console.ReadLine();
                                    int damageTactician = enemy.Defend(player) - enemy.tempHealth;
                                    if (damageTactician >= 0)
                                        damageTactician = 0;
                                    enemy.tempHealth += damageTactician;
                                    Console.WriteLine("The enemy took " + damageTactician + " damage!");
                                    Console.ReadLine();
                                    if (enemy.tempHealth <= 0)
                                    {
                                        Console.WriteLine("You defeated the enemy!");
                                        Console.ReadLine();
                                        Console.Clear();
                                        return player;
                                    }
                                    skillCounter += 5;
                                    PlayerTurn = false;
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine(player.name + " tried to use a skill, but is too tired!");
                            Console.ReadLine();
                            skillCounter++;
                            PlayerTurn = false;
                        }
                    }
                    #endregion
                }
                #endregion

                #region Enemy Turn
                else
                {
                    Console.WriteLine("Enemy is attacking...");
                    attacking = new Attack(Program.EnemyAttack);
                    if (attacking(player, enemy) == true)
                    {
                        int critChance = (player.spd / 2) + player.luck - enemy.spd;
                        int critActual = RNG(Events.Critical);
                        if (critChance > critActual)
                        {
                            int damage = player.Defend(enemy) - player.tempHealth;
                            if (damage >= 0)
                                damage = 0;
                            player.tempHealth += damage * 3;
                            if (player.tempHealth <= 0)
                            {
                                Console.WriteLine("Oh no! Critical!! You took " + (damage * 3) + " mortal damage!");
                                Console.WriteLine("You did not survive...");
                                Console.ReadLine();
                                Console.Clear();
                                return player;
                            }
                            else
                            {
                                Console.WriteLine("Oh no! Critical!! You took " + (damage *3) + " damage!");
                                Console.ReadLine();
                                Console.Clear();
                                PlayerTurn = true;
                            }
                        }
                        else
                        {
                            int damage = player.Defend(enemy) - player.tempHealth;
                            if (damage >= 0)
                                damage = 0;
                            player.tempHealth += damage;
                            if (player.tempHealth <= 0)
                            {
                                Console.WriteLine("You took " + damage + " mortal damage!");
                                Console.WriteLine("You did not survive...");
                                Console.ReadLine();
                                Console.Clear();
                                return player;
                            }
                            else
                            {
                                Console.WriteLine("You took " + damage + " damage!");
                                Console.ReadLine();
                                Console.Clear();
                                PlayerTurn = true;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enemy missed!");
                        Console.ReadLine();
                        Console.Clear();
                        PlayerTurn = true;
                    }
                }
                #endregion
            } while (isAttacking == true);
            return player;
            #endregion 
        }

        static Character GenerateEnemy(int battles)
        {
            Random rand = new Random();
            int battleLimit = battles * 5;
            int enemyClass = rand.Next(0, 5);
            switch (enemyClass)
            {
                #region Fighter
                case 0:
                    FighterEnemy fighter = new FighterEnemy();
                    fighter.name = "Enemy Fighter";
                    fighter.attk += rand.Next(0 + battleLimit, battles + battleLimit);
                    fighter.spd += rand.Next(0 + battleLimit, battles + battleLimit);
                    fighter.def += rand.Next(0 + battleLimit, battles + battleLimit);
                    fighter.health += rand.Next(0 + battleLimit, battles + battleLimit);
                    fighter.tempHealth = fighter.health;
                    if (battles <= 5)
                    {
                        fighter.EquippedWeapon = new IronAxe();
                    }
                    if (battles > 5 && battles <= 10)
                    {
                        //Steel Axe
                        fighter.EquippedWeapon = new IronAxe();
                    }
                    if (battles > 10 && battles <= 17)
                    {
                        //Silver Axe
                        fighter.EquippedWeapon = new IronAxe();
                    }
                    else
                    {
                        //legendary
                        fighter.EquippedWeapon = new IronAxe();
                    }
                    return fighter;
                #endregion
                #region Myrmidon
                case 1:
                    MyrmidonEnemy myrmidon = new MyrmidonEnemy();
                    myrmidon.name = "Enemy Myrmidon";
                    myrmidon.attk += rand.Next(0 + battleLimit, battles + battleLimit);
                    myrmidon.spd += rand.Next(0 + battleLimit, battles + battleLimit);
                    myrmidon.def += rand.Next(0 + battleLimit, battles + battleLimit);
                    myrmidon.health += rand.Next(0 + battleLimit, battles + battleLimit);
                    myrmidon.tempHealth = myrmidon.health;
                    if (battles <= 5)
                    {
                        myrmidon.EquippedWeapon = new IronSword();
                    }
                    if (battles > 5 && battles <= 10)
                    {
                        //Steel Axe
                        myrmidon.EquippedWeapon = new IronSword();
                    }
                    if (battles > 10 && battles <= 17)
                    {
                        //Silver Axe
                        myrmidon.EquippedWeapon = new IronSword();
                    }
                    else
                    {
                        //legendary
                        myrmidon.EquippedWeapon = new IronSword();
                    }
                    return myrmidon;
                #endregion
                #region Knight
                case 2:
                    KnightEnemy knight = new KnightEnemy();
                    knight.name = "Enemy Knight";
                    knight.attk += rand.Next(0 + battleLimit, battles + battleLimit);
                    knight.spd += rand.Next(0 + battleLimit, battles + battleLimit);
                    knight.def += rand.Next(0 + battleLimit, battles + battleLimit);
                    knight.health += rand.Next(0 + battleLimit, battles + battleLimit);
                    knight.tempHealth = knight.health;
                    if (battles <= 5)
                    {
                        knight.EquippedWeapon = new IronLance();
                    }
                    if (battles > 5 && battles <= 10)
                    {
                        //Steel Axe
                        knight.EquippedWeapon = new IronLance();
                    }
                    if (battles > 10 && battles <= 17)
                    {
                        //Silver Axe
                        knight.EquippedWeapon = new IronLance();
                    }
                    else
                    {
                        //legendary
                        knight.EquippedWeapon = new IronLance();
                    }
                    return knight;
                #endregion
                #region Cavalier
                case 3:
                    CavalierEnemy cavalier = new CavalierEnemy();
                    cavalier.name = "Enemy Cavalier";
                    cavalier.attk += rand.Next(0 + battleLimit, battles + battleLimit);
                    cavalier.spd += rand.Next(0 + battleLimit, battles + battleLimit);
                    cavalier.def += rand.Next(0 + battleLimit, battles + battleLimit);
                    cavalier.health += rand.Next(0 + battleLimit, battles + battleLimit);
                    cavalier.tempHealth = cavalier.health;
                    if (battles <= 5)
                    {
                        cavalier.EquippedWeapon = new IronLance();
                    }
                    if (battles > 5 && battles <= 10)
                    {
                        //Steel Axe
                        cavalier.EquippedWeapon = new IronLance();
                    }
                    if (battles > 10 && battles <= 17)
                    {
                        //Silver Axe
                        cavalier.EquippedWeapon = new IronLance();
                    }
                    else
                    {
                        //legendary
                        cavalier.EquippedWeapon = new IronLance();
                    }
                    return cavalier;
                #endregion
                #region Tactician
                default:
                    TacticianEnemy tactician = new TacticianEnemy();
                    tactician.name = "Enemy Tactician";
                    tactician.attk += rand.Next(0 + battleLimit, battles + battleLimit);
                    tactician.spd += rand.Next(0 + battleLimit, battles + battleLimit);
                    tactician.def += rand.Next(0 + battleLimit, battles + battleLimit);
                    tactician.health += rand.Next(0 + battleLimit, battles + battleLimit);
                    tactician.tempHealth = tactician.health;
                    if (battles <= 5)
                    {
                        tactician.EquippedWeapon = new IronSword();
                    }
                    if (battles > 5 && battles <= 10)
                    {
                        //Steel Axe
                        tactician.EquippedWeapon = new IronSword();
                    }
                    if (battles > 10 && battles <= 17)
                    {
                        //Silver Axe
                        tactician.EquippedWeapon = new IronSword();
                    }
                    else
                    {
                        //legendary
                        tactician.EquippedWeapon = new IronSword();
                    }
                    return tactician;
                #endregion
            }
        }

        static bool PlayerAttack(Character player, Character enemy)
        {
            int hitPercent = player.CalculateHit(enemy);
            int hitActual = RNG(Events.AttackPlayer);
            if (hitActual <= hitPercent)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool EnemyAttack(Character player, Character enemy)
        {
            int hitPercent = enemy.CalculateHit(player);
            int hitActual = RNG(Events.AttackEnemy);
            if (hitActual <= hitPercent)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static int RNG(Events rngEvent)
        {
            Random rand = new Random();
            switch (rngEvent)
            {
                case Events.AttackPlayer:
                    int numPlayer = (rand.Next(0, 101) + rand.Next(0, 101)) / 2;
                    return numPlayer;
                case Events.AttackEnemy:
                    int numEnemy = rand.Next(0, 101);
                    return numEnemy;
                case Events.DaysGen:
                    int days = rand.Next(3, 8);
                    return days;
                case Events.Critical:
                    int critChance = rand.Next(0, 101);
                    return critChance;
            }
            return 0;
        }

        delegate bool Attack(Character player, Character enemy);

        static Weapon BlacksmithWeapon = new Weapon();
        static int BlacksmithDays = 0;
        static bool BlacksmithFull = false;
    }
}
