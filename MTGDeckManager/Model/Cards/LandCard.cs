using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Model.Cards
{
    public class LandCard : Card
    {
        private bool _canTapForMana;
        private string _landType;

        public bool CanTapForMana
        {
            get => _canTapForMana;
            set => _canTapForMana = value;
        }

        public string LandType
        {
            get => _landType;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _landType = value;
                }
            }
        }

        public LandCard() : base()
        {
        }

        public LandCard(int id, string name, string description, string manaCost, string rarity, string landType, bool canTapForMana = true)
            : base(id, name, description, manaCost, rarity)
        {
            LandType = landType;
            CanTapForMana = canTapForMana;
        }

        /// <summary>
        /// Auto Description for this LandCard
        /// </summary>
        public override string AutoDescription()
        {
            return $"{Name} ({LandType}) - Terrain qui peut produire du mana: {CanTapForMana}, Rareté: {Rarity}. {Description}";
        }

        /// <summary>
        /// Check if land card data is valid
        /// </summary>
        public override bool Check()
        {
            return base.Check() && !string.IsNullOrEmpty(LandType);
        }
    }
}
