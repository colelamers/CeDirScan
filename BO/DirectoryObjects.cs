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
        public int size { get; set; }
        public int getSizeOnDisk(string size)
        {
            int divide = (int.Parse(size) / 1024);
            return divide;
        }//modifies the size to not just be the bytes but the representation of the disk space
        
        public DirectoryObjects()
        {
            path = "";
            type = "";
            name = "";
            size = 0;
        }

    }

}
