using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTGDeckManager.Model.Cards;

namespace MTGDeckManager.Model.Decks
{
    public class DecksCollection : ObservableCollection<Deck>
    {
        public DecksCollection() { }

        /// <summary>
        /// Add a new deck to the collection, checking if it's not already inside (by Id)
        /// </summary>
        public new void AddDeck(Deck deck)
        {
            if (!this.Any(d => d.Id == deck.Id))
            {
                this.Add(deck);
            }
        }

        /// <summary>
        /// Remove a specific deck from the collection
        /// </summary>
        public void DeleteDeck(Deck deck)
        {
            if (this.Contains(deck))
            {
                this.Remove(deck);
            }
        }
    }
}
