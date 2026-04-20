using MTGDeckManager.Model.Cards;
using MTGDeckManager.Model.Decks;
using MTGDeckManager.Utilities.DataAccess.Files;
using MTGDeckManager.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Utilities.DataAccess
{
    public class DataAccessCsvFile : DataAccess, IDataAccess
    {
        public DataAccessCsvFile(string filePath) : base(filePath)
        {
        }

        public DataAccessCsvFile(DataFilesManager dfm) : base(dfm) { }

        public override CardsCollection GetAllCards()
        {
            List<string> listToRead = new List<string>();
            CardsCollection cards = new CardsCollection();
            
            string temp = DataFilesManager.DataFiles.GetFilePathByCodeFunction("CARDS");
            AccessPath = temp;
            
            if (IsValidAccessPath)
            {
                listToRead = File.ReadAllLines(AccessPath).ToList();
                // Remove first title line
                listToRead.RemoveAt(0);
                
                foreach (string s in listToRead)
                {
                    Card card = GetCard(s);
                    if (card != null)
                    {
                        cards.AddCard(card);
                    }
                }
                return cards;
            }
            else
            {
                return null;
            }
        }

        public override CardsCollection GetAllCreatureCards()
        {
            List<string> listToRead = new List<string>();
            CardsCollection creatures = new CardsCollection();
            
            string temp = DataFilesManager.DataFiles.GetFilePathByCodeFunction("CREATURES");
            AccessPath = temp;
            
            if (IsValidAccessPath)
            {
                listToRead = File.ReadAllLines(AccessPath).ToList();
                listToRead.RemoveAt(0);
                
                foreach (string s in listToRead)
                {
                    CreatureCard creature = GetCreatureCard(s);
                    if (creature != null)
                    {
                        creatures.AddCard(creature);
                    }
                }
                return creatures;
            }
            else
            {
                return null;
            }
        }

        public override CardsCollection GetAllLandCards()
        {
            List<string> listToRead = new List<string>();
            CardsCollection lands = new CardsCollection();
            
            string temp = DataFilesManager.DataFiles.GetFilePathByCodeFunction("LANDS");
            AccessPath = temp;
            
            if (IsValidAccessPath)
            {
                listToRead = File.ReadAllLines(AccessPath).ToList();
                listToRead.RemoveAt(0);
                
                foreach (string s in listToRead)
                {
                    LandCard land = GetLandCard(s);
                    if (land != null)
                    {
                        lands.AddCard(land);
                    }
                }
                return lands;
            }
            else
            {
                return null;
            }
        }

        public override DecksCollection GetAllDecks()
        {
            List<string> listToRead = new List<string>();
            DecksCollection decks = new DecksCollection();
            
            string temp = DataFilesManager.DataFiles.GetFilePathByCodeFunction("DECKS");
            AccessPath = temp;
            
            if (IsValidAccessPath)
            {
                listToRead = File.ReadAllLines(AccessPath).ToList();
                listToRead.RemoveAt(0);
                
                foreach (string s in listToRead)
                {
                    Deck deck = GetDeck(s);
                    if (deck != null)
                    {
                        decks.AddDeck(deck);
                    }
                }
                return decks;
            }
            else
            {
                return null;
            }
        }

        private static Card GetCard(string csvLine)
        {
            string[] fields = csvLine.Split(';');
            switch (fields[0])
            {
                case "CREATURE":
                    return GetCreatureCard(csvLine);
                case "LAND":
                    return GetLandCard(csvLine);
                default:
                    return null;
            }
        }

        private static CreatureCard GetCreatureCard(string csvLine)
        {
            string[] fields = csvLine.Split(';');
            if (!string.IsNullOrEmpty(fields[0]) && fields[0].Equals("CREATURE"))
            {
                return new CreatureCard(
                    id: int.Parse(fields[1]),
                    name: fields[2],
                    description: fields[3],
                    manaCost: fields[4],
                    rarity: fields[5],
                    power: int.Parse(fields[6]),
                    toughness: int.Parse(fields[7]),
                    creatureType: fields[8]
                );
            }
            return null;
        }

        private static LandCard GetLandCard(string csvLine)
        {
            string[] fields = csvLine.Split(';');
            if (!string.IsNullOrEmpty(fields[0]) && fields[0].Equals("LAND"))
            {
                return new LandCard(
                    id: int.Parse(fields[1]),
                    name: fields[2],
                    description: fields[3],
                    manaCost: fields[4],
                    rarity: fields[5],
                    landType: fields[6],
                    canTapForMana: bool.Parse(fields[7])
                );
            }
            return null;
        }

        private static Deck GetDeck(string csvLine)
        {
            string[] fields = csvLine.Split(';');
            if (!string.IsNullOrEmpty(fields[0]) && fields[0].Equals("DECK"))
            {
                return new Deck(
                    id: int.Parse(fields[1]),
                    name: fields[2],
                    format: fields[3]
                );
            }
            return null;
        }

        public override bool UpdateAllCards(CardsCollection cards)
        {
            throw new NotImplementedException();
        }

        public override bool UpdateAllDecks(DecksCollection decks)
        {
            throw new NotImplementedException();
        }
    }
}
