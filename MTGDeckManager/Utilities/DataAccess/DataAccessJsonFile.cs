using MTGDeckManager.Model.Cards;
using MTGDeckManager.Model.Decks;
using MTGDeckManager.Utilities.DataAccess.Files;
using MTGDeckManager.Utilities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Utilities.DataAccess
{
    public class DataAccessJsonFile : DataAccess, IDataAccess
    {
        public DataAccessJsonFile(string filePath) : base(filePath)
        {
        }

        public DataAccessJsonFile(string filePath, string[] extensions) : base(filePath, extensions)
        {
        }

        public DataAccessJsonFile(DataFilesManager dfm) : base(dfm)
        {
        }

        public override CardsCollection GetAllCards()
        {
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("CARDS");
            if (IsValidAccessPath)
            {
                string jsonFile = File.ReadAllText(AccessPath);
                CardsCollection cards = new CardsCollection();
                
                JsonSerializerSettings settings = new JsonSerializerSettings 
                { 
                    TypeNameHandling = TypeNameHandling.All 
                };
                cards = JsonConvert.DeserializeObject<CardsCollection>(jsonFile, settings);
                return cards;
            }
            else
            {
                return null;
            }
        }

        public override CardsCollection GetAllCreatureCards()
        {
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("CREATURES");
            if (IsValidAccessPath)
            {
                string jsonFile = File.ReadAllText(AccessPath);
                CardsCollection creatures = new CardsCollection();
                
                JsonSerializerSettings settings = new JsonSerializerSettings 
                { 
                    TypeNameHandling = TypeNameHandling.All 
                };
                creatures = JsonConvert.DeserializeObject<CardsCollection>(jsonFile, settings);
                return creatures;
            }
            else
            {
                return null;
            }
        }

        public override CardsCollection GetAllLandCards()
        {
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("LANDS");
            if (IsValidAccessPath)
            {
                string jsonFile = File.ReadAllText(AccessPath);
                CardsCollection lands = new CardsCollection();
                
                JsonSerializerSettings settings = new JsonSerializerSettings 
                { 
                    TypeNameHandling = TypeNameHandling.All 
                };
                lands = JsonConvert.DeserializeObject<CardsCollection>(jsonFile, settings);
                return lands;
            }
            else
            {
                return null;
            }
        }

        public override DecksCollection GetAllDecks()
        {
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("DECKS");
            if (IsValidAccessPath)
            {
                string jsonFile = File.ReadAllText(AccessPath);
                DecksCollection decks = new DecksCollection();
                
                JsonSerializerSettings settings = new JsonSerializerSettings 
                { 
                    TypeNameHandling = TypeNameHandling.All 
                };
                decks = JsonConvert.DeserializeObject<DecksCollection>(jsonFile, settings);
                return decks;
            }
            else
            {
                return null;
            }
        }

        public override bool UpdateAllCards(CardsCollection cards)
        {
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("CARDS");
            if (IsValidAccessPath)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings 
                { 
                    TypeNameHandling = TypeNameHandling.All 
                };
                string json = JsonConvert.SerializeObject(cards, Formatting.Indented, settings);
                File.WriteAllText(AccessPath, json);
                return true;
            }
            else
            {
                Console.WriteLine("UpdateAllCards error: can't update datasource file");
                return false;
            }
        }

        public override bool UpdateAllDecks(DecksCollection decks)
        {
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("DECKS");
            if (IsValidAccessPath)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings 
                { 
                    TypeNameHandling = TypeNameHandling.All 
                };
                string json = JsonConvert.SerializeObject(decks, Formatting.Indented, settings);
                File.WriteAllText(AccessPath, json);
                return true;
            }
            else
            {
                Console.WriteLine("UpdateAllDecks error: can't update datasource file");
                return false;
            }
        }
    }
}
