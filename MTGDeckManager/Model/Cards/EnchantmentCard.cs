using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Model.Cards
{
    public class EnchantmentCard : Card
    {
        public EnchantmentCard() : base()
        {
        }

        public EnchantmentCard(int id, string name, string description, string manaCost, string rarity, string subtype)
            : base(id, name, description, manaCost, rarity, subtype)
        {
        }

        /// <summary>
        /// Auto Description for this EnchantmentCard
        /// </summary>
        public override string AutoDescription()
        {
            return $"{Name} ({Subtype}) - Enchantement, Coût de mana: {ManaCost}, Rareté: {Rarity}. {Description}";
        }

        /// <summary>
        /// Check if enchantment card data is valid
        /// </summary>
        public override bool Check()
        {
            return base.Check() && !string.IsNullOrEmpty(Subtype);
        }
    }
}
