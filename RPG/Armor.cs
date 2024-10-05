using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG {
    public class Armor {

        private string name;
        private string type;
        private int defense;
        private int durability;
        private char rarity;
        private string description;

        public Armor(string name, string type, int defense, int durability, char rarity, string description) {
            Name = name;
            this.type = type;
            Defense = defense;
            Durability = durability;
            Rarity = rarity;
            Description = description;
        }

        public override string ToString() {

            return $"{Name} is a {Type}. It provides {Defense} levels of protection, and can be used {Durability} times. ";

        }

        public string Description {
            get => description ;
            set => description = value ;
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

        public int Defense {
            get => defense;
            set {
                if (value < 0) {
                    throw new Exception("Armor has to have SOME defense.");
                } else {
                    defense = value;
                }
            }
        }

        public int Durability {
            get => durability;
            set {
                if (value <= 0) {
                    // Destory armor
                } else { 
                    durability = value;
                }
            }
        }
    }
}
