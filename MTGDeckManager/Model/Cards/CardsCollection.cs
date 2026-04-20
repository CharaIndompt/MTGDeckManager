using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTGDeckManager.Model.Cards;

namespace MTGDeckManager.Model.Cards
{
    public class CardsCollection : ObservableCollection<Card>
    {
        public CardsCollection() { }

        /// <summary>
        /// Add a new card to the collection, checking if it's not already inside (by Id)
        /// </summary>
        public new void AddCard(Card card)
        {
            if (!this.Any(c => c.Id == card.Id))
            {
                this.Add(card);
            }
        }

        /// <summary>
        /// Remove a specific card from the collection
        /// </summary>
        public void DeleteCard(Card card)
        {
            if (this.Contains(card))
            {
                this.Remove(card);
            }
        }

        /// <summary>
        /// Get all CreatureCards from the collection
        /// </summary>
        public List<CreatureCard> CreatureCards => this.OfType<CreatureCard>().ToList();

        /// <summary>
        /// Get all LandCards from the collection
        /// </summary>
        public List<LandCard> LandCards => this.OfType<LandCard>().ToList();
    }
}
