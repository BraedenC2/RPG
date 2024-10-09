using System.Reflection.Metadata.Ecma335;

namespace RPG
{
    class Monster
    {

        private bool flying;
        private string name;
        private string description;
        private int health;
        private Armor armor;

        public Monster(string name, string description, int health, bool flying, Armor armor)
        {
            Name = name;
            Description = description;
            Health = health;
            Flying = flying;

        }

        // Test

        public override string ToString()
        {
            return $"{name} has {health} left";
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("name cannot be null or empty");
                }
                name = value;
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("name cannot be null or empty");
                }
                description = value;
            }
        }
        public int Health
        {
            get { return health; }
            set
            {
                if (value >= 0)
                {
                    health = value;
                }
            }
        }
        public bool Flying
        {
            get { return flying; }
            set { flying = value; }
        }
        public Armor Armor
        {
            get { return armor; }
            set { armor = value; }
        }
    }

}
