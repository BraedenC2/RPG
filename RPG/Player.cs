using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG {

    public class Player {

        private string name;
        private int hp;
        private Weapon weapon;
        private Armor armor;

        public Player(string name, int hp, Weapon weapon, Armor armor) {

            Name = name;
            HP = hp;
            Weapon = weapon;
            Armor = armor;

        }

        public override string ToString() {
            return $"You, {Name}, have {HP}. You have {Weapon} and {Armor}";
        }

        public string Name {
            get => name;
            set { name = value; }
        }

        public int HP {
            get => hp;
            set {
                hp = value;
                if (hp <= 0) {
                    // GAME OVER
                    Console.WriteLine("Game Over! Your HP has reached 0.");
                    Environment.Exit(0);
                }
            }
        }

        public Weapon Weapon {
            get => weapon;
            set => weapon = value;
        }

        public Armor Armor {
            get => armor;
            set => armor = value;
        }


    }
}
