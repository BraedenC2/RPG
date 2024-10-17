using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RPG {
    public class Map {
        private Monster monster;
        private Weapon weapon;
        private Armor armor;
        private string room;
        private bool hasDoor;
        private static Random random = new Random();
        private List<Monster> possibleMonsters;
        private List<Weapon> possibleWeapons;
        private List<Armor> possibleArmor;

        public Map() {
            LoadMonstersFromFile(@"monsters.csv");
            LoadWeaponsFromFile(@"Wepon.csv");
            LoadArmorFromFile(@"Armor.csv");
            GenerateRoom();
        }

        private void LoadMonstersFromFile(string fileName) {
            possibleMonsters = new List<Monster>();
            string[] lines = File.ReadAllLines(fileName);

            for (int i = 1; i < lines.Length; i++) {
                string[] parts = lines[i].Split(',');
                if (parts.Length == 9)
                {
                    string name = parts[0];
                    string description = parts[1];
                    int health = int.Parse(parts[2]);
                    bool flying = bool.Parse(parts[3]);
                    string species = parts[4];
                    string[] catchphrases = new string[] { parts[5], parts[6], parts[7] };
                    int damage = int.Parse(parts[8]);

                    possibleMonsters.Add(new Monster(name, description, health, flying, damage, species, catchphrases));
                }
            }
        }
        private static int GetLineCount(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found", path);
            }
            int line = 0;
            using StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                reader.ReadLine();
                line++;
                Console.WriteLine(line);
            }

            reader.Close();
            return line;
        }
        private void LoadWeaponsFromFile(string fileName) {
            int lines = GetLineCount(fileName);
            possibleWeapons = new List<Weapon>(lines-1);

            
            using StreamReader read =new StreamReader(fileName);
            read.ReadLine();
            for (int i = 0;i <lines -1;i++) {
                string Line = read.ReadLine();
                string[] parts = Line.Split(',');
                if (parts.Length == 7) {
                    string name = parts[0];
                    string type = parts[1];
                    int damage = int.Parse(parts[2]);
                    int coolDown = int.Parse(parts[3]);
                    int durability = int.Parse(parts[4]);
                    char rarity = char.Parse(parts[5]);
                    string description = parts[6];

                    possibleWeapons.Add(new Weapon(name, type, damage, coolDown, durability, rarity, description));
                }
            }
        }
        private void LoadArmorFromFile(string fileName)
        {
            int AmountOfLines = GetLineCount(fileName);
            possibleArmor = new List<Armor>(AmountOfLines-1);

            
            StreamReader reader =new StreamReader(fileName);
          
            reader.ReadLine();
            for (int i =0;i<AmountOfLines-1;i++)
            {
                string line = reader.ReadLine();
                string[] parts = line.Split(',');
                if (parts.Length == 7)
                {
                    string name = parts[0];
                    string type = parts[1];
                    int defense = int.Parse(parts[2]);
                    
                    int durability = int.Parse(parts[3]);
                    char rarity = char.Parse(parts[4]);
                    string description = parts[5];

                    possibleArmor.Add(new Armor(name, type, defense, durability, rarity, description));
                }
            }
        }
        private void GenerateRoom() {
            if (random.Next(2) == 0 && possibleMonsters.Count > 0) {
                monster = possibleMonsters[random.Next(possibleMonsters.Count)];
            }
            if (random.Next(2) == 0 && possibleWeapons.Count > 0) {
                weapon = possibleWeapons[random.Next(possibleWeapons.Count)];
            }
            if (random.Next(2) == 0 && possibleWeapons.Count > 0)
            {
                armor = possibleArmor[random.Next(possibleArmor.Count)];
            }
            hasDoor = true;
            GenerateRoomDescription();
        }

        public void GenerateRoomDescription() {
            Console.WriteLine("You enter a new room.");

            if (monster != null) {
                Console.WriteLine($"There's a {monster.Name} here! {monster.Description}");
                Console.WriteLine($"The {monster.Name} shouts: \"{monster.GetRandomCatchphrase()}\"");
            }

            if (weapon != null) {
                Console.WriteLine($"You see a {weapon.Name} on the ground. {weapon.Description}");
            }

            Console.WriteLine("You spot a door leading to the next room.");
        }

        public Monster GetMonster() {
            return monster;
        }
        //help
        public Weapon GetWeapon() {
            return weapon;
        }
        public Armor GetArmor()
        {
            return armor;
        }
        public bool HasDoor() {
            return hasDoor;
        }

        public void RemoveWeapon() {
            weapon = null;
            GenerateRoomDescription();
        }
    }
}