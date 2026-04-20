using MTGDeckManager.Utilities.EntriesValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Model.Cards
{
    public abstract class Card
    {
        private const int MINIMUM_NAME_LENGTH = 2;
        private const int MINIMUM_DESCRIPTION_LENGTH = 5;

        private string _name;
        private string _description;
        private int _id;
        private string _manaCost;
        private string _rarity;

        public Card(int id, string name, string description, string manaCost, string rarity)
        {
            Id = id;
            Name = name;
            Description = description;
            ManaCost = manaCost;
            Rarity = rarity;
        }

        public Card()
        {
        }

        public int Id
        {
            get => _id;
            set
            {
                if (ValidUtils.CheckIfPositiveNumber(value))
                {
                    _id = value;
                }
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (ValidUtils.CheckEntryDescription(value, MINIMUM_NAME_LENGTH))
                {
                    _name = value;
                }
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (ValidUtils.CheckEntryDescription(value, MINIMUM_DESCRIPTION_LENGTH))
                {
                    _description = value;
                }
            }
        }

        public string ManaCost
        {
            get => _manaCost;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _manaCost = value;
                }
            }
        }

        public string Rarity
        {
            get => _rarity;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _rarity = value;
                }
            }
        }

        /// <summary>
        /// Generate auto description of this card
        /// </summary>
        /// <returns>auto description</returns>
        public abstract string AutoDescription();

        /// <summary>
        /// Check if card data is valid
        /// </summary>
        /// <returns>true if valid</returns>
        public virtual bool Check()
        {
            return !string.IsNullOrEmpty(Name) && 
                   !string.IsNullOrEmpty(Description) && 
                   Id > 0;
        }
    }
}
