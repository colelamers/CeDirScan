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
        public DirectoryScanner()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (dirObjList.Count > 0) { dirObjList.Clear(); }//empties the list in case the data is pulled more than once in the same session, otherwise ignores this

            List<string> scannedItems = Directory.GetFiles(tbDirectory.Text, "*.*", SearchOption.AllDirectories).ToList(); //gets the files throughout the whole directory in each folder
            //TODO: Need error catching scanning directories because of admin privledges
            foreach (string si in scannedItems)
            {
                DirectoryObjects dirObj = new DirectoryObjects();
                dirObj.type = System.IO.Path.GetExtension(si);
                dirObj.path = System.IO.Path.GetDirectoryName(si);
                dirObj.name = System.IO.Path.GetFileNameWithoutExtension(si);
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
                        streamWriter.WriteLine($"{tObject.type}, {tObject.name}, {tObject.path}");
                    }
                    streamWriter.Close();
                }
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

        //TODO: Add stuff to a datatable for viewing and if the user wants it, they can save it using the save dialog
    }
}
