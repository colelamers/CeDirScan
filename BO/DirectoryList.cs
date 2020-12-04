using System.Collections.Generic;

namespace DirectoryScanner
{
    public class DirectoryList
    {
        private List<string> Directories { get; set; }

        public DirectoryList()
        {
            Directories = new List<string>();
        }
    }
}