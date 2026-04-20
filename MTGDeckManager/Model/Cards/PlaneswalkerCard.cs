using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Model.Cards
{
    public class PlaneswalkerCard : Card
    {
        private int _startingLoyalty;
        private string _planeswalkerType;

        public int StartingLoyalty
        {
            get => _startingLoyalty;
            set
            {
                if (value >= 0)
                {
                    _startingLoyalty = value;
                }
            }
        }

        public string PlaneswalkerType
        {
            get => _planeswalkerType;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _planeswalkerType = value;
                }
            }
        }

        public PlaneswalkerCard() : base()
        {
        }

        public PlaneswalkerCard(int id, string name, string description, string manaCost, string rarity, string planeswalkerType, int startingLoyalty)
            : base(id, name, description, manaCost, rarity)
        {
            PlaneswalkerType = planeswalkerType;
            StartingLoyalty = startingLoyalty;
        }

        /// <summary>
        /// Auto Description for this PlaneswalkerCard
        /// </summary>
        public override string AutoDescription()
        {
            return $"{Name} ({PlaneswalkerType}) - Planeswalker, Loyauté de départ: {StartingLoyalty}, Coût de mana: {ManaCost}, Rareté: {Rarity}. {Description}";
        }

        /// <summary>
        /// Check if planeswalker card data is valid
        /// </summary>
        public override bool Check()
        {
            return base.Check() && !string.IsNullOrEmpty(PlaneswalkerType) && StartingLoyalty > 0;
        }
    }
}
