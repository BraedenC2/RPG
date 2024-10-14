using System.Reflection.Metadata.Ecma335;

namespace RPG
{
    public class Monster
    {

        private bool flying;
        private string name;
        private string description;
        private string species;
        private int health;
        private int damage;
        

        public Monster(string name, string description, int health, bool flying, int damage, string species, string[] catchphrases)
        {
            Name = name;
            Description = description;
            Health = health;
            Flying = flying;
            this.damage = damage;
            this.species = species;
            Catchphrases = catchphrases;

        }
        public override string ToString()
        {
            if (flying) return $"{Name} has {Health}. {Name} can do {Damage} damage and can fly.";
            else return $"{Name} has {Health}. {Name} can do {Damage} damage.";
        }

        public string GetRandomCatchphrase() {
            return Catchphrases[new Random().Next(Catchphrases.Length)];
        }

        public string[] Catchphrases { get; }

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

        public string Species {
            get => species;
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

        public int Damage {
            get => damage;
        }
    }

}
