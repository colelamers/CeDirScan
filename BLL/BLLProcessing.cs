using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectoryScanner
{
    public class BLLProcessing
    {
        Configuration _config;
        
        List<DirectoryObjects> dirObjList = new List<DirectoryObjects>();
        public BLLProcessing()
        {
            _config = Configuration.LoadFromFile("configuration.xml"); //TODO: remove the hardcoded file name. Pass through whatever file name they change it to
        }

        private List<DirectoryObjects> ScanDirectory()
        {
            List<DirectoryObjects> dirObjList = new List<DirectoryObjects>();

            try
            {
                //TODO: get pathing and radio button to write to config file. then read in from the processing file
                List<string> scannedItems = Directory.GetFiles(_config.DirectoryPath, "*.*", SearchOption.AllDirectories).ToList();
                foreach (string si in scannedItems)
                {
                    DirectoryObjects dirObj = new DirectoryObjects();
                    dirObj.type = Path.GetExtension(si);
                    dirObj.path = Path.GetDirectoryName(si);
                    dirObj.name = Path.GetFileNameWithoutExtension(si);
                    dirObjList.Add(dirObj);
                }//Gets the directory object and adds it to the list
                SortList(dirObjList);
                return dirObjList;
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
                return dirObjList;
            }
        }

        public void StartProcessing()
        {
            dirObjList.Clear();
            dirObjList = ScanDirectory();

            try
            {
                SaveFileDialog sfdSaveFile = new SaveFileDialog();
                sfdSaveFile.Filter = "Text File (*.txt)|*.txt|CSV File (*.csv)|*.csv|All Files (*.*)|*.*";
                if (sfdSaveFile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(sfdSaveFile.FileName, FileMode.Create, FileAccess.Write))
                    using (StreamWriter streamWriter = new StreamWriter(stream))
                    {
                        foreach (DirectoryObjects tObject in dirObjList)
                        {
                            streamWriter.WriteLine($"{tObject.type}, {tObject.path}, {tObject.name}");
                        }
                        streamWriter.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
                Log(ex.ToString());
            }
        }


        private List<DirectoryObjects> SortList(List<DirectoryObjects> dirOb)
        {
            string sortingType = _config.Sort;
            switch (sortingType)
            {
                case "Name":
                    dirOb = dirOb.OrderBy(ms => ms.name).ToList();
                    break;
                case "File Path":
                    dirOb = dirOb.OrderBy(ms => ms.path).ToList();
                    break;
                case "File Type":
                    dirOb = dirOb.OrderBy(ms => ms.type).ToList();
                    break;
            }//finds which is checked and updates the list to match the new format
            Log("Sorting type: " + sortingType);
            return dirOb;
        }//Sorts the List

        private void Log(string log)
        {
            DebugLogging.LogActivity(log);
        }


    }
}
