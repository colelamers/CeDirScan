using System;
using System.Linq;
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
            _config.Save(confignName); //This needs to be delcared here right now. The load cannot occur unless this gets saved on startup.
            _config = Configuration.LoadFromFile(confignName); //TODO: --3-- try to get config file and other things into their own dll i can use
            ConfigCheck();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            _config.DirectoryPath = tbDirectory.Text;
            _config.SortingType = gbSortingOptions.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
            _config.SortingDirection = gbSortAscDesc.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;

            _config.Save("configuration.xml"); //TODO: --3-- need to get this in it's own config file so that it's abstracted from this code directly so i can just quickly reuse the config and deubgging as needed
            DoProcessing();

        }

        private void ConfigCheck()
        {
            //tbDirectory.Text = _config.DirectoryPath; //TODO: --2-- unsure i need this right now

            switch (_config.SortingType)
            {
                case "File Name":
                    rbSortByFileName.Checked = true;
                    break;
                case "File Path":
                    rbSortByFilePath.Checked = true;
                    break;
                case "File Size":
                    rbSortByFileSize.Checked = true;
                    break;
                case "File Type":
                    rbSortByFileType.Checked = true;
                    break;
            }

            switch (_config.SortingDirection)
            {
                case "File Name":
                    rbSortByFileName.Checked = true;
                    break;
                case "File Path":
                    rbSortByFilePath.Checked = true;
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
                    tbDirectory.Text = fileDialog.SelectedPath;
                }
            }
        }//Opens file path upon browse button click

        private void Log(string log)
        {
            DebugLogging.LogActivity(log);
        }
    }
}
