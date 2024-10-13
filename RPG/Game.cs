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

        private static void CreatePlayer() {
            // User will give a name to their character
            // These are good names!! The player can have more than 1 weapon/armor!


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
                    random.Next(1, 100),
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
            // Reading data from a CSV file to generate the levels
            // We can write data too (stretch goal) to csv (the same file) to create saves
            // Right now we're focusing on not random map generation, but currently, the game itself.
            // Premade maps are okay. 

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
                case 1: // TODO: Start the Adventure
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
        public static double CheckRarity(Weapon weapon)
        {
            if (weapon.Description == "leginary")
            {
                return .75;
            }
            else if(weapon.Description=="rare") {
                return .5;
            }
            else if(weapon.Description=="common")
            {
                return .25;
            }
            else
            {
                return 1;
            }
        }
        public static void MakeinganAttack(Weapon weapon, Armor arms) {
        }

        public static int Battle( ref Monster Mod,ref  Player ThePlayer)
        {
            Random random = new Random();
            //testing to see who gose first. will just be a coin flip
            int turn = random.Next(2);
            while (true)
            {
                if (turn == 0)
                {
                    //monster turn
                    int Attack = Mod.Weapon.Damage;

                    
                    if (ThePlayer.HP == 0 || ThePlayer.HP < 0)
                    {
                        Console.WriteLine($"You have been slane by {ThePlayer.Name}. Now deleting system32 ");
                        return -1;
                    }
                }
                else
                {
                    //players turn
                    if (Mod.Health == 0 || Mod.Health < 0)
                    {
                        Console.WriteLine($"you have slane {Mod.Name}. ");
                        return 0;
                    }

                }
                
            }
            return 0;
            return 0;


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
