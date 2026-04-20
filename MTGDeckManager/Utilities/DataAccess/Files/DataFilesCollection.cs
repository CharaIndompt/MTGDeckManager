using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Utilities.DataAccess.Files
{
    /// <summary>
    /// Collection of DataFile objects
    /// </summary>
    public class DataFilesCollection : ObservableCollection<DataFile>
    {
        public DataFilesCollection() { }

        /// <summary>
        /// Add a new DataFile to the collection
        /// </summary>
        public new void AddFile(DataFile file)
        {
            if (!this.Any(f => f.Concern == file.Concern))
            {
                this.Add(file);
            }
        }

        /// <summary>
        /// Get file path by its concern code
        /// </summary>
        public string GetFilePathByCodeFunction(string concernCode)
        {
            var file = this.FirstOrDefault(f => f.Concern.ToUpper() == concernCode.ToUpper());
            if (file != null)
            {
                return file.FullPath;
            }
            return null;
        }
    }
}
