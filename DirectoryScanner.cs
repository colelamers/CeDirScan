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
        Configuration _config = new Configuration();
        public DirectoryScanner()
        {
            InitializeComponent();
            DebugLogging.CreateDebugLogger();
            string confignName = "configuration.xml";
            _config.Save(confignName);
            _config = Configuration.LoadFromFile(confignName); //TODO: remove the hardcoded file name. Pass through whatever file name they change it to
            ConfigCheck();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            _config.DirectoryPath = tbDirectory.Text;
            _config.Sort = gbRadioButtons.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
            _config.Save("configuration.xml");//TODO: remove the hardcoded file name. Pass through whatever file name they change it to. Must be way I can get the file to update upon setting instead of what I have above
            DoProcessing();

        }

        private void ConfigCheck()
        {
            tbDirectory.Text = _config.DirectoryPath;

            switch (_config.Sort)
            {
                case "Name":
                    rbSortByName.Checked = true;
                    break;
                case "File Path":
                    rbSortByFilePath.Checked = true;
                    break;
                case "File Type":
                    rbSortByFileType.Checked = true;
                    break;
            }
        }//Configuration file read in and check from previous session data

        private void DoProcessing()
        {
            BLLProcessing _bllProcessing = new BLLProcessing();
            _bllProcessing.StartProcessing();
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
        }//Opens file path upon browse button click

        private void Log(string log)
        {
            DebugLogging.LogActivity(log);
        }

        //TODO: Add an option for a user to select directories and display them. then pass them through as into an enumerable list, foreach one scan the directory and add to text file and add together.
    }
}
