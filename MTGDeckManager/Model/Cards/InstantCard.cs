using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Model.Cards
{
    /// <summary>
    /// Represents an Instant card - can be cast at any time
    /// </summary>
    public class InstantCard : SpellCard
    {
        public InstantCard() : base()
        {
        }

        public InstantCard(int id, string name, string description, string manaCost, string rarity, string subtype)
            : base(id, name, description, manaCost, rarity, subtype)
        {
        }

        /// <summary>
        /// Auto Description for this InstantCard
        /// </summary>
        public override string AutoDescription()
        {
            return $"{Name} ({Subtype}) - Éphémère, Coût de mana: {ManaCost}, Rareté: {Rarity}. {Description}";
        }
    }
}
