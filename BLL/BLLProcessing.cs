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
        public BLLProcessing()
        {

        }

        List<DirectoryObjects> dirObjList = new List<DirectoryObjects>();
        Configuration _config = Configuration.LoadFromFile("configuration.xml"); //TODO: remove the hardcoded file name. Pass through whatever file name they change it to

        private void StartProcessing()
        {
            if (dirObjList.Count > 0) { dirObjList.Clear(); }//empties the list in case the data is pulled more than once in the same session, otherwise ignores this

            try
            {
                //TODO: get pathing and radio button to write to config file. then read in from the processing file
                List<string> scannedItems = Directory.GetFiles(_config.Directory, "*.*", SearchOption.AllDirectories).ToList(); 
                foreach (string si in scannedItems)
                {
                    DirectoryObjects dirObj = new DirectoryObjects();
                    dirObj.type = System.IO.Path.GetExtension(si);
                    dirObj.path = System.IO.Path.GetDirectoryName(si);
                    dirObj.name = System.IO.Path.GetFileNameWithoutExtension(si);
                    dirObjList.Add(dirObj);
                }//Gets the directory object and adds it to the list

                //rbSort(gbRadioButtons); //TODO: Get this from config file

                /*TODO This all needs to be in the DirectoryScanner.cs file because you cannot access these dialogs in the processing
                sfdSaveFile.Filter = "Text File (*.txt)|*.txt|CSV File (*.csv)|*.csv|All Files (*.*)|*.*";
                if (sfdSaveFile.ShowDialog() == DialogResult.OK)
                {
                    using (Stream stream = File.Open(sfdSaveFile.FileName, FileMode.OpenOrCreate))
                    using (StreamWriter streamWriter = new StreamWriter(stream))
                    {
                        foreach (DirectoryObjects tObject in dirObjList)
                        {
                            streamWriter.WriteLine($"{tObject.type}, {tObject.name}, {tObject.path}");
                        }
                        streamWriter.Close();
                    }
                }
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }


        }

        private void rbSort(GroupBox g)
        {
            var checkedButton = g.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            switch (checkedButton.Text)
            {
                case "Name":
                    dirObjList = dirObjList.OrderBy(ms => ms.name).ToList();
                    break;
                case "File Path":
                    dirObjList = dirObjList.OrderBy(ms => ms.path).ToList();
                    break;
                case "File Type":
                    dirObjList = dirObjList.OrderBy(ms => ms.type).ToList();
                    break;
            }//finds which is checked and updates the list to match the new format
        }




    }
}
