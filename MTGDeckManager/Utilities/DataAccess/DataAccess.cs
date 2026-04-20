using MTGDeckManager.Model.Cards;
using MTGDeckManager.Model.Decks;
using MTGDeckManager.Utilities.DataAccess.Files;
using MTGDeckManager.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MTGDeckManager.Utilities.DataAccess
{
    public abstract class DataAccess : IDataAccess
    {
        private string _accessPath;

        /// <summary>
        /// Constructor with just the fileName for AccessPath
        /// </summary>
        public DataAccess(string filePath)
        {
            AccessPath = filePath;
        }

        /// <summary>
        /// Constructor with fileName and authorized file extensions
        /// </summary>
        public DataAccess(string filePath, string[] extensions)
        {
            Extensions = new List<string>(extensions.ToList());
            AccessPath = filePath;
        }

        /// <summary>
        /// Constructor associated with a DataFilesManager object
        /// </summary>
        public DataAccess(DataFilesManager dfm)
        {
            this.DataFilesManager = dfm;
        }

        public DataFilesManager DataFilesManager { get; set; }

        /// <summary>
        /// AccessPath file to the data source
        /// </summary>
        public virtual string AccessPath
        {
            get => _accessPath;
            set
            {
                _accessPath = value;
            }
        }

        /// <summary>
        /// List of authorized extensions (.txt, .csv, .json, .xml ...)
        /// </summary>
        public List<string> Extensions { get; set; }

        /// <summary>
        /// Continue to check AccessPath even after constructor
        /// </summary>
        public bool IsValidAccessPath => CheckAccessPath(AccessPath);

        public abstract CardsCollection GetAllCards();
        public abstract CardsCollection GetAllCreatureCards();
        public abstract CardsCollection GetAllLandCards();
        public abstract DecksCollection GetAllDecks();
        public abstract bool UpdateAllCards(CardsCollection cards);
        public abstract bool UpdateAllDecks(DecksCollection decks);

        /// <summary>
        /// Check AccessPath to the data source file
        /// </summary>
        public bool CheckAccessPath(string tryPath)
        {
            if (File.Exists(tryPath))
            {
                if (Extensions?.Any() ?? false)
                {
                    string pattern = "";
                    foreach (string ext in Extensions)
                    {
                        pattern += ext + "|";
                    }
                    pattern = pattern.Substring(0, pattern.Length - 1);
                    
                    if (!Regex.IsMatch(tryPath, pattern + "$"))
                    {
                        Console.WriteLine($"L'extension du fichier {tryPath} n'est pas valide, extensions attendues : {pattern}");
                        return false;
                    }
                    return true;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                Console.WriteLine($"Le fichier {tryPath} n'existe pas");
                return false;
            }
        }
    }
}
