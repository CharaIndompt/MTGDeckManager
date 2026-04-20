using MTGDeckManager.Model.Cards;
using MTGDeckManager.Model.Decks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Utilities.Interfaces
{
    public interface IDataAccess
    {
        /// <summary>
        /// Access string to the external source (file path, connection string ...)
        /// </summary>
        string AccessPath { get; set; }

        /// <summary>
        /// Retrieve cards informations from the external source
        /// </summary>
        /// <returns>A CardsCollection</returns>
        CardsCollection GetAllCards();

        /// <summary>
        /// Retrieve creature cards informations from the external source
        /// </summary>
        /// <returns>A CardsCollection with only creature cards</returns>
        CardsCollection GetAllCreatureCards();

        /// <summary>
        /// Retrieve land cards informations from the external source
        /// </summary>
        /// <returns>A CardsCollection with only land cards</returns>
        CardsCollection GetAllLandCards();

        /// <summary>
        /// Retrieve decks informations from the external source
        /// </summary>
        /// <returns>A DecksCollection</returns>
        DecksCollection GetAllDecks();

        /// <summary>
        /// Update source from the actual CardsCollection
        /// </summary>
        bool UpdateAllCards(CardsCollection cards);

        /// <summary>
        /// Update source from the actual DecksCollection
        /// </summary>
        bool UpdateAllDecks(DecksCollection decks);
    }
}
