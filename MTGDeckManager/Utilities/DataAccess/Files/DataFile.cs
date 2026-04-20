using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Utilities.DataAccess.Files
{
    /// <summary>
    /// Represents a data file with its path and concern (subject)
    /// </summary>
    public class DataFile
    {
        private static string _filesPathDir;

        public static string FilesPathDir
        {
            get => _filesPathDir;
            set => _filesPathDir = value;
        }

        public string FileName { get; set; }
        public string Concern { get; set; }

        public DataFile()
        {
        }

        public DataFile(string fileName, string concern)
        {
            FileName = fileName;
            Concern = concern;
        }

        /// <summary>
        /// Get the full path of this file
        /// </summary>
        public string FullPath => Path.Combine(FilesPathDir, FileName);
    }
}
