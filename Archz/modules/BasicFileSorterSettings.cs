using System;
using System.Collections.Generic;
using System.Text;

namespace Archz.modules
{
    public class BasicFileSorterSettings
    {
        public List<string> ObservedFolders { get; set; }

        /// <summary>
        /// Key is definition, category is value
        /// </summary>
        public Dictionary<string, string> ExtensionsDefinition { get; set; }
        public Dictionary<string, string> CategoryFolders { get; set; }

        public int ScanFrequencyInMin { get; set; }

        private int DefaultScanFrequencyInMin = 1;

        public int GetScanFrequencyInMillisec()
        {
            return ScanFrequencyInMin * 60 * 1000;
        }

        

        public BasicFileSorterSettings()
        {
            ObservedFolders = new List<string>();
            ExtensionsDefinition = new Dictionary<string, string>();
            CategoryFolders = new Dictionary<string, string>();
            ScanFrequencyInMin = DefaultScanFrequencyInMin;
        }
    }
}
