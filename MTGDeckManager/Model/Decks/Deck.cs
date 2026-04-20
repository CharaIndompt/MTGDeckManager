using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Model.Decks
{
    public class Deck
    {
        private string _name;
        private string _format;
        private int _id;

        public int Id
        {
            get => _id;
            set
            {
                if (value >= 0)
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
                if (!string.IsNullOrEmpty(value))
                {
                    _name = value;
                }
            }
        }

        public string Format
        {
            get => _format;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _format = value;
                }
            }
        }

        public Deck()
        {
            Cards = new ObservableCollection<Cards.Card>();
        }

        public Deck(int id, string name, string format)
        {
            Id = id;
            Name = name;
            Format = format;
            Cards = new ObservableCollection<Cards.Card>();
        }

        public ObservableCollection<Cards.Card> Cards { get; set; }

        /// <summary>
        /// Add a card to the deck
        /// </summary>
        public void AddCard(Cards.Card card)
        {
            if (card != null && !Cards.Contains(card))
            {
                Cards.Add(card);
            }
        }

        /// <summary>
        /// Remove a card from the deck
        /// </summary>
        public void RemoveCard(Cards.Card card)
        {
            if (Cards.Contains(card))
            {
                Cards.Remove(card);
            }
        }

        /// <summary>
        /// Get all creature cards in the deck
        /// </summary>
        public List<Cards.CreatureCard> CreatureCards => Cards.OfType<Cards.CreatureCard>().ToList();

        /// <summary>
        /// Get all land cards in the deck
        /// </summary>
        public List<Cards.LandCard> LandCards => Cards.OfType<Cards.LandCard>().ToList();

        /// <summary>
        /// Check if deck is valid (has a name and at least 60 cards for Commander)
        /// </summary>
        public bool Check()
        {
            return !string.IsNullOrEmpty(Name) && Cards.Count >= 60;
        }
    }
}
