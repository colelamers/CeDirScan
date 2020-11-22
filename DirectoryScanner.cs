using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectoryScanner
{
    public partial class DirectoryScanner : Form
    {
        BLLProcessing _bllProcessing = new BLLProcessing();
        List<DirectoryObjects> dirObjList = new List<DirectoryObjects>();
        Configuration _config = new Configuration();
        public DirectoryScanner()
        {
            _config = Configuration.LoadFromFile("configuration.xml"); //TODO: remove the hardcoded file name. Pass through whatever file name they change it to
            InitializeComponent(); 
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (dirObjList.Count > 0) { dirObjList.Clear(); }//empties the list in case the data is pulled more than once in the same session, otherwise ignores this
            DebugLogging.LogActivity("dd000000000");
            try
            {
                //TODO: get pathing and radio button to write to config file. then read in from the processing file
                List<string> scannedItems = Directory.GetFiles(tbDirectory.Text, "*.*", SearchOption.AllDirectories).ToList(); //gets the files throughout the whole directory in each folder
                foreach (string si in scannedItems)
                {
                    DirectoryObjects dirObj = new DirectoryObjects();
                    dirObj.type = Path.GetExtension(si);
                    dirObj.path = Path.GetDirectoryName(si);
                    dirObj.name = Path.GetFileNameWithoutExtension(si);
                    dirObjList.Add(dirObj);
                }//Gets the directory object and adds it to the list

                rbSort(gbRadioButtons); //updates the object list according to how they're to be sorted

                sfdSaveFile.Filter = "Text File (*.txt)|*.txt|CSV File (*.csv)|*.csv|All Files (*.*)|*.*";
                if (sfdSaveFile.ShowDialog() == DialogResult.OK)
                {
                    using (Stream stream = File.Open(sfdSaveFile.FileName, FileMode.OpenOrCreate))
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var fileDialog = new FolderBrowserDialog())
            {
                fileDialog.SelectedPath = "c:\\"; //sets the default path for the browser to open

                if (fileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fileDialog.SelectedPath))
                {
                    var path = fileDialog.SelectedPath;
                    tbDirectory.Text = path;
                }
            }
        }

        private void Log(string log)
        {
            DebugLogging.LogActivity(log);
        }

        //TODO: Add stuff to a datatable for viewing and if the user wants it, they can save it using the save dialog
        //TODO: Add an option for a user to select directories and display them. then pass them through as into an enumerable list, foreach one scan the directory and add to text file and add together.
    }
}
