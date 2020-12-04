using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DirectoryScanner
{
    public class Configuration
    {
        //TODO: --1-- the XML serialization stuff should be in it's own file and the sorting things should be in their own config object file
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

        public void GetConfigFileName()
        {
            //TODO: --4-- figure out how to get the file name here? likely for when i move stuff over into a custom dll for configs
        }

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
