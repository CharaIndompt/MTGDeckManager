using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Model.Cards
{
    public class SorceryCard : Card
    {
        private string _spellType;

        public string SpellType
        {
            get => _spellType;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _spellType = value;
                }
            }
        }

        public SorceryCard() : base()
        {
        }

        public SorceryCard(int id, string name, string description, string manaCost, string rarity, string spellType)
            : base(id, name, description, manaCost, rarity)
        {
            SpellType = spellType;
        }

        /// <summary>
        /// Auto Description for this SorceryCard
        /// </summary>
        public override string AutoDescription()
        {
            return $"{Name} ({SpellType}) - Rituel, Coût de mana: {ManaCost}, Rareté: {Rarity}. {Description}";
        }

        /// <summary>
        /// Check if sorcery card data is valid
        /// </summary>
        public override bool Check()
        {
            return base.Check() && !string.IsNullOrEmpty(SpellType);
        }
    }
}
