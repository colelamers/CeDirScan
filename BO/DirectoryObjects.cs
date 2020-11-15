using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryScanner
{
    public class DirectoryObjects
    {
        public string path { get; set; }
        public string type { get; set; }
        public string name { get; set; }

        public DirectoryObjects()
        {
            path = "";
            type = "";
            name = "";
        }

    }

}
