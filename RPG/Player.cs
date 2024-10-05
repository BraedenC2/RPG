using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG {

    // I, Braeden, will work on this :D
    class Player {

        // Player attributes. Make sure to override toString() so we can use it as a summrary method. 

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
                if (hp <= 0) {
                    // GAME OVER
                } else {
                    hp = value;
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
