using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Model.Cards
{
    public class LandCard : Card
    {
        public LandCard() : base()
        {
        }

        public LandCard(int id, string name, string description, string manaCost, string rarity, string subtype)
            : base(id, name, description, manaCost, rarity, subtype)
        {
        }

        /// <summary>
        /// Auto Description for this LandCard
        /// </summary>
        public override string AutoDescription()
        {
            return $"{Name} ({Subtype}) - Terrain, Rareté: {Rarity}. {Description}";
        }

        /// <summary>
        /// Check if land card data is valid
        /// </summary>
        public override bool Check()
        {
            return base.Check() && !string.IsNullOrEmpty(Subtype);
        }
    }
}
