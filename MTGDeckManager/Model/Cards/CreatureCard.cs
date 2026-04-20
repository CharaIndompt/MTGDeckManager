using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Model.Cards
{
    public class CreatureCard : Card
    {
        private int _power;
        private int _toughness;
        private string _creatureType;

        public int Power
        {
            get => _power;
            set
            {
                if (value >= 0)
                {
                    _power = value;
                }
            }
        }

        public int Toughness
        {
            get => _toughness;
            set
            {
                if (value >= 0)
                {
                    _toughness = value;
                }
            }
        }

        public string CreatureType
        {
            get => _creatureType;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _creatureType = value;
                }
            }
        }

        public CreatureCard() : base()
        {
        }

        public CreatureCard(int id, string name, string description, string manaCost, string rarity, int power, int toughness, string creatureType)
            : base(id, name, description, manaCost, rarity)
        {
            Power = power;
            Toughness = toughness;
            CreatureType = creatureType;
        }

        /// <summary>
        /// Auto Description for this CreatureCard
        /// </summary>
        public override string AutoDescription()
        {
            return $"{Name} ({CreatureType}) - {Power}/{Toughness}, Coût de mana: {ManaCost}, Rareté: {Rarity}. {Description}";
        }

        /// <summary>
        /// Check if creature card data is valid
        /// </summary>
        public override bool Check()
        {
            return base.Check() && !string.IsNullOrEmpty(CreatureType);
        }
    }
}
