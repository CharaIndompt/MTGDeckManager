using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Utilities.DataAccess.Files
{
    /// <summary>
    /// The paths and subjects are stored in a config text file like this:
    /// FOLDER,C:\Path\To\Data\Folder\
    /// CARDS,Cards.csv
    /// CREATURES,Creatures.csv
    /// LANDS,Lands.csv
    /// DECKS,Decks.csv
    /// 
    /// This DataFilesManager class retrieves all files and stores informations (fullPath, concern) in a collection of DataFile objects
    /// </summary>
    public class DataFilesManager
    {
        public DataFilesManager(string configFile)
        {
            List<string> listToRead = new List<string>();

            listToRead = File.ReadAllLines(configFile).ToList();

            // Directory path is in the first line of the config file 
            string directory = listToRead[0].Split(',')[1];
            DataFile.FilesPathDir = directory;

            listToRead.RemoveAt(0);
            foreach (string s in listToRead)
            {
                string[] fields = s.Split(',');

                DataFiles.AddFile(new DataFile(fileName: fields[1], concern: fields[0]));
            }
        }

        public DataFilesCollection DataFiles { get; set; } = new DataFilesCollection();
    }
}
