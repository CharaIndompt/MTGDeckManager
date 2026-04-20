using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Model.Cards
{
    public class EnchantmentCard : Card
    {
        private bool _isAura;
        private bool _isCurse;
        private string _enchantmentType;

        public bool IsAura
        {
            get => _isAura;
            set => _isAura = value;
        }

        public bool IsCurse
        {
            get => _isCurse;
            set => _isCurse = value;
        }

        public string EnchantmentType
        {
            get => _enchantmentType;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _enchantmentType = value;
                }
            }
        }

        public EnchantmentCard() : base()
        {
        }

        public EnchantmentCard(int id, string name, string description, string manaCost, string rarity, string enchantmentType, bool isAura = false, bool isCurse = false)
            : base(id, name, description, manaCost, rarity)
        {
            EnchantmentType = enchantmentType;
            IsAura = isAura;
            IsCurse = isCurse;
        }

        /// <summary>
        /// Auto Description for this EnchantmentCard
        /// </summary>
        public override string AutoDescription()
        {
            string typeInfo = EnchantmentType;
            if (IsAura) typeInfo += " (Aura)";
            if (IsCurse) typeInfo += " (Curse)";
            return $"{Name} ({typeInfo}) - Enchantement, Coût de mana: {ManaCost}, Rareté: {Rarity}. {Description}";
        }

        /// <summary>
        /// Check if enchantment card data is valid
        /// </summary>
        public override bool Check()
        {
            return base.Check() && !string.IsNullOrEmpty(EnchantmentType);
        }
    }
}
