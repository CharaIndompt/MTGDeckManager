using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Model.Cards
{
    /// <summary>
    /// Represents a SpellCard (Instant or Sorcery) - cards that go to graveyard after resolution
    /// </summary>
    public class SpellCard : Card
    {
        public SpellCard() : base()
        {
        }

        public SpellCard(int id, string name, string description, string manaCost, string rarity, string subtype)
            : base(id, name, description, manaCost, rarity, subtype)
        {
        }

        /// <summary>
        /// Auto Description for this SpellCard
        /// </summary>
        public override string AutoDescription()
        {
            return $"{Name} ({Subtype}) - Sort ({GetType().Name.Replace("Card", "")}), Coût de mana: {ManaCost}, Rareté: {Rarity}. {Description}";
        }

        /// <summary>
        /// Check if spell card data is valid
        /// </summary>
        public override bool Check()
        {
            return base.Check();
        }
    }
}
