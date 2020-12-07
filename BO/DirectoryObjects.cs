using System;

namespace CeDirScan
{
    public class DirectoryObjects
    {
        public string path { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public double size { get; set; }//set as double because of issue with division making too small of a number for int32 error and to get the Ceiling
        public double getSizeOnDisk(string size)
        {
            double divide = Math.Ceiling(double.Parse(size) / 1024);
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
