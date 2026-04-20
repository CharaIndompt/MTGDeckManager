using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Model.Cards
{
    public class ArtifactCard : Card
    {
        public ArtifactCard() : base()
        {
        }

        public ArtifactCard(int id, string name, string description, string manaCost, string rarity, string subtype)
            : base(id, name, description, manaCost, rarity, subtype)
        {
        }

        /// <summary>
        /// Auto Description for this ArtifactCard
        /// </summary>
        public override string AutoDescription()
        {
            return $"{Name} ({Subtype}) - Artéfact, Coût de mana: {ManaCost}, Rareté: {Rarity}. {Description}";
        }

        /// <summary>
        /// Check if artifact card data is valid
        /// </summary>
        public override bool Check()
        {
            return base.Check() && !string.IsNullOrEmpty(Subtype);
        }
    }
}
