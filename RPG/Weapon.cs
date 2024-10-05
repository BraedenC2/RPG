using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG {
    public class Weapon {

        private string name;
        private string type;
        private int damage;
        private int coolDown;
        private int durability;
        private char rarity;
        private string description;

        // It is to mention, we do not need *mostly* custom set's.
        // For rarity for example, there are 3 workable characters, however
        // the user has no input on the rarity, the game does. So as long as the game works,
        // set's like rarity cannot be broken in any way by the user. 

        public Weapon(string name, string type, int damage, int coolDown, int durability, char rarity, string description) {
        
            Name = name;
            this.type = type;
            Damage = damage;
            CoolDown = coolDown;
            Durability = durability;
            Rarity = rarity;
            Description = description;
        
        }

        public override string ToString() {
            return $"{Name} is a {Type}. It does {Damage} damage, and has a cool down of {CoolDown} turns." +
                $"You can use {Name} {Durability} times. ";
        }

        public string Description {
            get => description;
            set => description = value;
        }
    
        public char Rarity {
            get => rarity;
            set => rarity = value;
        }
        public string Name {
            get => name;
            set => name = value;
        }

        public string Type {
            get => type;
        }

        public int Damage {
            get => damage;
            set => damage = value;
        }

        public int CoolDown {
            get => coolDown;
            set => coolDown = value;
        }

        public int Durability {
            get => durability;
            set {
                if (value <= 0) {
                    // Remove weapon
                } else {
                    durability = value;
                }
            }
        }
    
    
    }
}
