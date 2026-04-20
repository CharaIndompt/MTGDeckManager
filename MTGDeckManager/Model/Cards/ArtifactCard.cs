using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Model.Cards
{
    public class ArtifactCard : Card
    {
        private bool _isEquipment;
        private bool _isVehicle;
        private string _artifactType;

        public bool IsEquipment
        {
            get => _isEquipment;
            set => _isEquipment = value;
        }

        public bool IsVehicle
        {
            get => _isVehicle;
            set => _isVehicle = value;
        }

        public string ArtifactType
        {
            get => _artifactType;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _artifactType = value;
                }
            }
        }

        public ArtifactCard() : base()
        {
        }

        public ArtifactCard(int id, string name, string description, string manaCost, string rarity, string artifactType, bool isEquipment = false, bool isVehicle = false)
            : base(id, name, description, manaCost, rarity)
        {
            ArtifactType = artifactType;
            IsEquipment = isEquipment;
            IsVehicle = isVehicle;
        }

        /// <summary>
        /// Auto Description for this ArtifactCard
        /// </summary>
        public override string AutoDescription()
        {
            string typeInfo = ArtifactType;
            if (IsEquipment) typeInfo += " (Equipment)";
            if (IsVehicle) typeInfo += " (Vehicle)";
            return $"{Name} ({typeInfo}) - Artéfact, Coût de mana: {ManaCost}, Rareté: {Rarity}. {Description}";
        }

        /// <summary>
        /// Check if artifact card data is valid
        /// </summary>
        public override bool Check()
        {
            return base.Check() && !string.IsNullOrEmpty(ArtifactType);
        }
    }
}
