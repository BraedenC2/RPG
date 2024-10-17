using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG {
    public static class Game {

        private static Random random = new Random();
        private static Player? player;
        private static Weapon? weapon;
        private static Armor? armor;
        private static Map room1;

        private static void CreatePlayer() {

            Console.WriteLine("""
                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                                                      
                            WELCOME, TRAVELER OF THE UNKNOWN...        
                                                                      
                           YOU HAVE STUMBLED UPON A STRANGE REALM      
                        WHERE DARKNESS AND LIGHT INTERTWINE AS ONE.    
                                                                      
                           TELL US... WHAT NAME SHALL YOU BEAR?       
                                                                      
                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                """);

            int randomDeath = random.Next(0, 10);
            string? userName = Console.ReadLine();
            if (string.IsNullOrEmpty(userName)) {
                Console.WriteLine("""
                    ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                                                          
                               YOU DARE TO STAY SILENT, NAMELESS ONE?      
                                                                          
                               IN THIS WORLD, TO HAVE NO NAME IS TO BE     
                              NOTHING... AND NOTHING HAS NO PLACE HERE.    
                                                                          
                             THE SHADOWS CONSUME YOU FOR YOUR INSOLENCE.   
                                                                          
                                        YOU HAVE DIED.                    
                                                                          
                    ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                    """);
                Environment.Exit(0);
            } else {
                weapon = new Weapon("Foible", "Sword", random.Next(1, 5), random.Next(0, 2), random.Next(3, 7), 'c', "Your very first sword.\n Crafted from this new world.\n May you use it for your protection.");
                armor = new Armor($"{userName}'s sleepy clothes", "Pajamas", 1, 3, 'c', "You feel very comfortable in this 'armor'. \nNot much protection, but at least it's not a birthday suit.");

                player = new Player(
                    userName,
                    100,
                    weapon,
                    armor);
            }

            Console.WriteLine($@"
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                                      
            AH, WELCOME, {player.Name}...               
                                                      
        YOUR NAME CARRIES WEIGHT IN THIS REALM.        
        THE FATES HAVE LONG WHISPERED OF YOUR ARRIVAL. 
                                                      
            STEP FORWARD, {player.Name}, AND LET        
          THE STORY OF YOUR LEGEND UNFOLD BEFORE YOU.  
                                                      
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
press any key to continue...
");


            /*
             Program will assign that name to the Player class,
            as well as a random weapon, HP, MP, and armor.
            (The Player attributes (weapon, hp... etc), may be changed or added to)
             */
        }

        private static void PreStartGame() {

            CreatePlayer();

            Console.ReadKey();
            Console.Clear();

            ObtainMSG($"{weapon.Name}", 'c');

            PlayerRelease();


        }

        private static void PlayerRelease() {
            Console.WriteLine($"""
                 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                 Ah, the sword... yes, I bestow it upon you 
                 not for glory, but for survival. This blade 
                 is forged from the very essence of this land, 
                 a tool to cut through the darkness ahead. 

                 You see, this realm is unforgiving. Shadows 
                 and creatures untold will stand in your path, 
                 but they are not your true enemy...

                 Your journey is one of balance, of light and 
                 shadow. You must find the source of the decay, 
                 and only then will you uncover the truth of 
                 your purpose here.

                 Use this sword wisely, {player.Name}. Your fate 
                 awaits beyond the veil.
                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                press any key to continue...
                """);

            Console.ReadKey();
            Console.Clear();

            TitleScreen();
            MainMenu();
        }

        private static void StartingLevel() {
            Console.Clear();

            Console.WriteLine("""
                     ______
                  ,-' ;  ! `-.
                 / :  !  :  . \
                |_ ;   __:  ;  |
                )| .  :)(.  !  |
                |"    (##)  _  |
                |  :  ;`'  (_) (
                |  :  :  .     |
                )_ !  ,  ;  ;  |
                || .  .  :  :  |
                |" .  |  :  .  |
                |mt-2_;----.___|

                press any key to open the door⠀⠀
                """);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine($"""
                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                      With a low, grinding creak, the massive door 
                      slowly swings open, its ancient hinges groaning 
                      under the weight of centuries. Cold air rushes 
                      out from the darkness beyond, carrying with it 
                      the faint scent of damp stone and forgotten secrets.

                      You step forward, and the air grows heavy around 
                      you, as if the very walls of this place are watching 
                      your every move. The chamber before you is vast, 
                      its ceiling lost in shadow, and the only sound 
                      that greets you is the soft, steady drip of water 
                      echoing through the endless void.

                      The door shuts behind you with a thundering boom, 
                      sealing you within. There is no turning back now, 
                      {player.Name}. What lies ahead may be more than you 
                      bargained for... or exactly what you were meant to 
                      find.
                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                press any key to continue...
                """);
            Console.ReadKey();
            Level1();
        }
        private static void Level1() {
            Console.Clear();
            room1 = new Map();
            int action = 0;
            if (room1.GetMonster() == null) {
                ObtainMSG(room1.GetWeapon().Name, room1.GetWeapon().Rarity);
                player.Weapon = room1.GetWeapon();
                Level1();
            } else {
                do {
                    try {
                        Console.WriteLine($"""
                What will you do??
                Options:
                
                [1] Run
                [2] Fight {room1.GetMonster()?.Name ?? "no monster"}
                """);
                        action = int.Parse(Console.ReadLine());
                    } catch (Exception e) {
                        Console.WriteLine("Must be a valid choice");
                    }

                } while (action <= 0 || action >= 3);
                Action(action);
            }
            

        }

        private static void Action(int action) {
            switch (action) {
                case 1:
                    int punishment = random.Next(1, 50);
                    Console.WriteLine($"As you run to the door, {room1.GetMonster().Name} does {punishment} damage to you.");
                    Console.WriteLine($"You hear {room1.GetMonster().Name} laugh at your cowardness.");
                    player.HP -= punishment;
                    if (player.HP <= 0) {
                        Console.WriteLine("How sad... You've died.");
                        Environment.Exit(0);
                    }
                    Console.WriteLine($"You, {player.Name} have {player.HP} left.");
                    Level1();
                    break;
                case 2:
                    Battle();

                    break;
            }
        }
        private static void MainMenu() {
            Console.Clear();
            byte userSelection = 0;
            try {
                Console.WriteLine("""
                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                                [1] Start Adventure
                                [2] Controls
                                [3] Equipment
                                [4] Exit

                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                  SELECT AN OPTION:
                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                """);
                userSelection = byte.Parse(Console.ReadLine());
            } catch (Exception ex) {
                Console.WriteLine("Invalid");
                Thread.Sleep(1500);
                MainMenu();
            }

            switch (userSelection) {
                case 1: StartingLevel();
                    break;
                case 2: ControlScreen();
                    break;
                case 3: EquipmentScreen();
                    break;
                case 4: // TODO: Exit the game
                    break; 
                default: MainMenu();
                    break;
            }
        }

        private static void EquipmentScreen() {
            Console.Clear();
            Console.WriteLine("""
                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                   EQUIPMENT MENU
                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                   Weapons:
                   --------
                   Your weapon is your primary tool for combat. You 
                   can only equip one weapon at a time, so choose wisely.
                
                """);
            switch (weapon.Rarity) {
                case 'c': Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 'r': Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 'l': Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    break;
            }
            Console.WriteLine($"""
                [Equipped Weapon: {weapon.Name}]
                -----------------------------------
                {weapon.Type}
                {weapon.Description}

                Damage: {weapon.Damage}
                Cooldown: {weapon.CoolDown}
                Durability: {weapon.Durability}

                -----------------------------------

                """);
            Console.ResetColor();
            Console.WriteLine("""
                Armor:
                ------
                Armor protects you from the dangers of this world.
                Like your weapon, you may only wear one piece of 
                armor at a time.
                """);
            switch (armor.Rarity) {
                case 'c':
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 'r':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 'l':
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    break;
            }
            Console.WriteLine($"""

                [Equipped Weapon: {armor.Name}]
                -----------------------------------
                {armor.Type}
                {armor.Description}

                Defense: {armor.Defense}
                Durability: {weapon.Durability}

                """);
            Console.ResetColor();
            Console.WriteLine("""
                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                  EQUIP YOUR GEAR WISELY
                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                  Your armor and weapon will define how you face the 
                  challenges ahead. Some equipment may be better suited 
                  for certain enemies or areas, so pay close attention to 
                  your environment and enemies’ strengths and weaknesses.
                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                              PRESS ANY KEY TO RETURN
                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                
                """);
            Console.ReadKey();
            MainMenu();
        }

        private static void ControlScreen() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("""
                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                    HOW TO PLAY
                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                   Interact With The Game:
                   ---------
                   [Y] - Approve the action
                   [N] - Disapprove the action

                   (Other unique prompts will prompt you with available actions)

                   Inventory:
                   ----------
                   [I] - Open/Close Inventory

                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                SURVIVE THE CHAMBER
                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                  Use your wits, explore the environment, and fight to 
                  uncover the secrets hidden within. Be cautious, as 
                  dangers lurk in every shadow, and your choices may 
                  determine your fate...
                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                PRESS ANY KEY TO RETURN
                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                
                """);
            Console.ResetColor();
            Console.ReadKey();
            MainMenu();
        }
        private static void TitleScreen() {
            Console.WriteLine("Welcome to the...");

            Console.Beep(65, 500); // C2
            Console.Beep(98, 500); // G2
            Console.Beep(130, 1000); // C3
            Thread.Sleep(1000);
            Console.Beep(65, 500); // C2
            Console.Beep(98, 500); // G2
            Console.Beep(130, 500); // C3
            Console.Beep(165, 500); // C3
            Console.Beep(65, 500); Console.Beep(65, 500); Console.Beep(65, 500);
            Console.Beep(98, 500); Console.Beep(98, 500); Console.Beep(98, 500);
            Console.Beep(130, 300); Console.Beep(130, 300); Console.Beep(130, 300);
            Console.Beep(196, 200); // G3
            Console.Beep(196, 200); // G3
            Console.Beep(196, 200); // G3
            Console.Beep(261, 150); // C4
            Console.WriteLine("""
                 _______           _______  _______  ______   _______  _______ 
                (  ____ \|\     /|(  ___  )(       )(  ___ \ (  ____ \(  ____ )
                | (    \/| )   ( || (   ) || () () || (   ) )| (    \/| (    )|
                | |      | (___) || (___) || || || || (__/ / | (__    | (____)|
                | |      |  ___  ||  ___  || |(_)| ||  __ (  |  __)   |     __)
                | |      | (   ) || (   ) || |   | || (  \ \ | (      | (\ (   
                | (____/\| )   ( || )   ( || )   ( || )___) )| (____/\| ) \ \__
                (_______/|/     \||/     \||/     \||/ \___/ (_______/|/   \__/
                """);
            Console.Beep(261, 150); Console.Beep(261, 150); Console.Beep(261, 150);
            Console.Beep(261, 150); Console.Beep(261, 150);
            Console.Beep(392, 100); // G4
            Console.Beep(329, 200); // E4
            Console.Beep(261, 150);
            Console.Beep(261, 400); Console.Beep(261, 150);
            Console.Beep(392, 100); // G4
            Console.Beep(329, 50); // E4
            Console.Beep(261, 150);
            Console.Beep(196, 100); Console.Beep(196, 100);
            Console.Beep(261, 200); Console.Beep(329, 100);
            Console.Beep(196, 200);
            Console.Beep(65, 1000);
            Console.Beep(261, 150); Console.Beep(261, 150);
            Console.Beep(392, 100);
            Console.Beep(329, 200);
            Console.Beep(261, 150);
            Console.Beep(261, 400); Console.Beep(261, 150);
            Console.Beep(392, 100);
            Console.Beep(329, 50);
            Console.Beep(261, 150);
            Console.Beep(261, 500);
            Console.Beep(196, 500);
            Console.Beep(165, 750);
            Console.Beep(65, 1000);
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("W3lcome to th3...");
            Console.WriteLine("""
                   _______           _______  _______  ______   _______  _______ 
                 (  ____ \|\     /|(  ___  )(       )(  ___ \ (  ____ \(  ____ )
                 | (    \/| )   ( || (   ) || () () || (   ) )| (    \/| (    )|
                | |      | (___) || (___) || || || || (__/ / | (__    | (____)|
                  | |      |  ___  ||  ___  || |(_)| ||  __ (  |  __)   |     __)
                   | |     | (   ) || (   ) || |   | || (  \ \ | (      | (\ (   
                   (____/\| )   ( | )   ( | )   ( | )___) )| (____/\| ) \ \__
                  (______/|/     \ |/     \ |/     \ |/ \___/ (_______/|/   \__/
                """);
            Console.Beep(130, 500);
            Console.Beep(196, 500);
            Console.Beep(261, 500);
            Console.Beep(261, 2000);
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("W3lc0m3 t0 *he...");
            Console.WriteLine("""
                (  _ _ \ \   /|(  ___  )(       )(  _   ( ___ \(   _ )
                 | (  \/|    (  (     | () () ||     )| (   \/| (  )|
                |  |   | (___)  (___) | |   || (__ / | (__  | (   )|
                  |      |  ___   ___   | |_  |  _ (   __)   |   __)
                   |     | (   ) (   ) | |   | (  \ \ | (     | (\ (   
                   ( __ \|    ( | )   ( | )   ( )___) )|  __/\| ) \ \__
                  (______/|     \ |/     |/    |/ \___/ (______/|/   \__/
                """);
            Console.Beep(165, 2000);
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("W#lc0m? t> th%...");
            Console.WriteLine("""
                _  _   _  ___  (   )  _    __  _  _  \  ___ / \   ( _ _ _  _    / \  (
                /   \_  |  (   )     /   |   |  \/   \  ___)    (    ___  |  |     /
                \_/     (  )     __/|   |   |     \  /  ___/ \_/ |      _  | / \__/ \
                """);
            Console.Beep(65, 3000);
            Console.WriteLine("\n\nP?e$s @ny k#y t* co^tin%e\r\n\r\n");
            Console.ReadKey();
            Console.Clear();
        }

        private static void ObtainMSG(string message, char rarity) {

            switch (rarity) {
                case 'c': Console.Beep(800, 150);
                    break;
                case 'r':
                    Console.Beep(900, 150);
                    Console.Beep(1000, 150);
                    break;
                case 'l':
                    Console.Beep(1000, 150);
                    Console.Beep(1200, 150);
                    Console.Beep(1400, 200);
                    break;
                default:
                    break;
            }
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"""
                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                            
                    YOU HAVE OBTAINED:      
                    {message}               
                                            
                    USE IT WISELY...         
                                            
                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                press any key to continue...
                """);
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

        public static int CheckRarity(Player player) {
            if (player.Weapon.Rarity == 'l') {
                return 5;
            } else if (player.Weapon.Rarity == 'r') {
                return 3;
            } else if (player.Weapon.Rarity == 'c') {
                return 2;
            } else {
                return 0;
            }
        }

        public static void Battle() {
            Console.Clear();
            Random random = new Random();
            // Making this easier to read...
            Monster monster = room1.GetMonster();
            // 0 for monster, 1 for player
            int turn = random.Next(2); 

            Console.WriteLine($"A wild {monster.Name} appears!");

            while (true) {
                Console.WriteLine($"\n{player.Name} HP: {player.HP} | {monster.Name} HP: {monster.Health}");

                if (turn == 0) {
                    // Monster's turn
                    Console.WriteLine($"\n{monster.Name}'s turn!");
                    MakingAnAttack(monster, player, random, turn);

                    if (player.HP <= 0) {
                        Console.WriteLine($"You have been slain by {monster.Name}.");
                        Environment.Exit(0);
                    }

                    // switching to player's turn... if alive
                    turn = 1;
                } else {
                    // Player's turn
                    Console.WriteLine("\nYour turn!");
                    MakingAnAttack(monster, player, random, turn);

                    if (monster.Health <= 0) {
                        Console.WriteLine($"You have slain {monster.Name}!");
                        Console.WriteLine("\n*You go to the next room*");
                        break;
                    }
                    // Switch to monster's turn
                    turn = 0; 
                }
            }

            Console.WriteLine("The battle is over. Press any key to continue...");
            Console.ReadKey();
            Level1();
        }

        public static void MakingAnAttack(Monster monster, Player player, Random random, int turn) {
            int attempt = random.Next(100);
            int attemptChance;

            if (monster.Flying) {
                attemptChance = 50;
            } else {
                attemptChance = 75;
            }

            if (attempt < attemptChance)
            {
                // Monster's turn
                if (turn == 0)
                {

                    if (player.Armor.Durability <= 0) {
                        player.Armor.Durability = 0;
                        player.Armor.Defense = 0;
                    }
                    Console.WriteLine("ARMOR DURABILITY: " + player.Armor.Durability);

                    int baseAttack = monster.Damage;
                    int subtracted = player.Armor.Defense;
                    baseAttack = baseAttack - subtracted;
                    if (baseAttack < 0) baseAttack = 0;
                    player.Armor.Durability--;


                    player.HP = player.HP - baseAttack;
                    Console.WriteLine($"{monster.Name} attacks you for {baseAttack} damage!");

                    if (player.HP <= 0) {
                        player.HP = 0;
                        Console.WriteLine($"You have died... You put up a good fight. {monster.Name} will remember you.");
                    }
                } else // the player's turn
                  {
                    Console.WriteLine($"Do you want to swing {player.Weapon.Name}?\n1(yes)\n2(no)");
                    int choice = 0;
                    while (true) {
                        try {
                            choice = int.Parse(Console.ReadLine());
                            if (choice == 1 || choice == 2) {
                                break;
                            } else {
                                Console.WriteLine("Invalid choice. Please enter 1 for yes or 2 for no.");
                            }
                        } catch (Exception e) {
                            Console.WriteLine("Invalid input. Please enter a number (1 for yes, 2 for no).");
                        }
                    }

                    Console.Clear();


                    if (choice == 1) {
                        if (player.Weapon.Durability <= 0) {
                            player.Weapon.Durability = 0;
                            player.Weapon.Damage = 1;
                            Console.WriteLine($"Your {player.Weapon.Name} has broken! You're now attacking with a broken {player.Weapon.Type}.");
                        }
                        Console.WriteLine("WEAPON DURABILITY: " + player.Weapon.Durability);

                        int damage = player.Weapon.Damage;
                        monster.Health -= damage;
                        player.Weapon.Durability--;
                        Console.WriteLine($"You hit {monster.Name} for {damage} damage!");


                    } else {
                        Console.WriteLine("You decide not to attack this turn.");
                    }
                }
            } else {
                Console.WriteLine($"{(turn == 0 ? monster.Name : player.Name)} STUMBLED!");
            }
        }

        private static void Main() {

            PreStartGame();

            // Dictionary reference for the game:

            /*
             * Item Obtaining Rarities:

             Common: Console.Beep(800, 150);

             Rare:  Console.Beep(900, 150);
                    Console.Beep(1000, 150);

             Legendary: Console.Beep(1000, 150);
                        Console.Beep(1200, 150);
                        Console.Beep(1400, 200);

             */

        }
    }
}
