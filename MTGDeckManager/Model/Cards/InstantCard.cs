using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Model.Cards
{
    public class InstantCard : Card
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

        public InstantCard() : base()
        {
        }

        public InstantCard(int id, string name, string description, string manaCost, string rarity, string spellType)
            : base(id, name, description, manaCost, rarity)
        {
            SpellType = spellType;
        }

        /// <summary>
        /// Auto Description for this InstantCard
        /// </summary>
        public override string AutoDescription()
        {
            return $"{Name} ({SpellType}) - Éphémère, Coût de mana: {ManaCost}, Rareté: {Rarity}. {Description}";
        }

        /// <summary>
        /// Check if instant card data is valid
        /// </summary>
        public override bool Check()
        {
            return base.Check() && !string.IsNullOrEmpty(SpellType);
        }
    }
}
