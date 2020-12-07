using System.IO;
using System.Xml.Serialization;

namespace CeDirScan
{
    public class Configuration
    {
        public string DirectoryPath { get; set; }
        public string SortingType { get; set; }
        public string SortingDirection { get; set; }

        public void Save(string fileName)
        {
            if (!File.Exists(Path.GetFullPath(fileName)))
            {
                using (StreamWriter sw = File.CreateText(fileName)) { }//just creates and closes the file if it does not exist
            }
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer XML = new XmlSerializer(typeof(Configuration));
                XML.Serialize(stream, this);
            }

        }//When called, saves the parameters set at that time from the config file

        public static Configuration LoadFromFile(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                var XML = new XmlSerializer(typeof(Configuration));
                return (Configuration)XML.Deserialize(stream);
            }
        }//Loads in the config file

        public Configuration()
        {
            DirectoryPath = "";
            SortingType = "";
            SortingDirection = "";

        }
    }
}
