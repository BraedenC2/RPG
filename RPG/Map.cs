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
        private string room;
        private bool hasDoor;
        private static Random random = new Random();
        private List<Monster> possibleMonsters;
        private List<Weapon> possibleWeapons;

        public Map() {
            LoadMonstersFromFile("monsters.csv");
            LoadWeaponsFromFile("weapons.csv");
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

        private void LoadWeaponsFromFile(string fileName) {
            possibleWeapons = new List<Weapon>();

            string[] lines = File.ReadAllLines(fileName);

            for (int i = 1; i <lines.Length; i++) {
                string[] parts = lines[i].Split(',');
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

        private void GenerateRoom() {
            if (random.Next(2) == 0 && possibleMonsters.Count > 0) {
                monster = possibleMonsters[random.Next(possibleMonsters.Count)];
            }
            if (possibleWeapons.Count > 0) {
                weapon = possibleWeapons[random.Next(possibleWeapons.Count)];
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

        public Weapon GetWeapon() {
            return weapon;
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