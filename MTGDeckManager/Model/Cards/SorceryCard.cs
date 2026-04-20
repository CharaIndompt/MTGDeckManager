using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Model.Cards
{
    /// <summary>
    /// Represents a Sorcery card - can only be cast during your main phase
    /// </summary>
    public class SorceryCard : SpellCard
    {
        public SorceryCard() : base()
        {
        }

        public SorceryCard(int id, string name, string description, string manaCost, string rarity, string subtype)
            : base(id, name, description, manaCost, rarity, subtype)
        {
        }

        /// <summary>
        /// Auto Description for this SorceryCard
        /// </summary>
        public override string AutoDescription()
        {
            return $"{Name} ({Subtype}) - Rituel, Coût de mana: {ManaCost}, Rareté: {Rarity}. {Description}";
        }
    }
}
