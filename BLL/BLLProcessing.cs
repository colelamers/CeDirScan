using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CeDirScan
{
    public class BLLProcessing
    {
        Configuration _config;

        List<DirectoryObjects> dirObjList = new List<DirectoryObjects>();
        public BLLProcessing()
        {
            //TODO: --3-- At some point, try to get my ProjectLogging DLL imported and use that instead of this hardcoded stuff
            _config = Configuration.LoadFromFile("configuration.xml");
        }

        private List<DirectoryObjects> ScanDirectory()
        {
            Log("Scanning Directory");
            try
            {
                //Gets a list of all directories except for hidden files/folders
                List<string> subDirs = Directory.GetDirectories(_config.DirectoryPath).Select(d => new { Attr = new DirectoryInfo(d).Attributes, Dir = d })
                      .Where(x => !x.Attr.HasFlag(FileAttributes.System))
                      .Where(x => !x.Attr.HasFlag(FileAttributes.Hidden))
                      .Select(x => x.Dir)
                      .ToList();

                List<DirectoryObjects> dirObjList = new List<DirectoryObjects>();

                if (subDirs.Count > 0)
                {
                    foreach (string dir in subDirs)
                    {
                        List<string> filesInDirectory = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories).ToList();
                        CreateObjectAndFillList(dirObjList, filesInDirectory);
                    }
                }//Gets all files in a list of directories
                else
                {
                    List<string> filesInPath = Directory.GetFiles(_config.DirectoryPath).ToList();
                    CreateObjectAndFillList(dirObjList, filesInPath);
                }//Gets all files in a directory that has no subdirectories

                //sorts the list
                dirObjList = SortList(dirObjList);

                return dirObjList;
            }
            catch (Exception ex)
            {
                //TODO: --2-- need to revise code so that when an access denied occurs, it just skips that file instead of stopping the whole program
                Log($"Error: {ex}");
                return dirObjList;
            }
        }
        /// <summary>
        /// This passes in two lists and adds the files from one to the other
        /// </summary>
        /// <param name="dirObjList"> List of Directory Objects; Files</param>
        /// <param name="filesInDirectory"> List of files in a specific directory</param>
        private void CreateObjectAndFillList(List<DirectoryObjects> dirObjList, List<string> filesInDirectory)
        {
            foreach (string file in filesInDirectory)
            {
                DirectoryObjects dirObj = new DirectoryObjects();
                FileInfo n = new FileInfo(file);
                dirObj.type = Path.GetExtension(file);
                dirObj.path = Path.GetDirectoryName(file);
                dirObj.name = Path.GetFileNameWithoutExtension(file);
                dirObj.size = dirObj.getSizeOnDisk(n.Length.ToString());
                dirObjList.Add(dirObj);
            }
        }//Builds Directory Objects and adds them to a list

        /// <summary>
        /// Beginning of the processing functions being performed
        /// </summary>
        public void StartProcessing()
        {
            dirObjList.Clear();
            dirObjList = ScanDirectory(); 
            //TODO: --1-- Think about putting into a datatable and returning an excel file

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
                            streamWriter.WriteLine($"{tObject.type}, {tObject.path}, {tObject.name}, {tObject.size}");
                        }
                        streamWriter.Close();
                    }
                }//Saves the file
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
                Log($"Error: {ex}");
            }
        }
        /// <summary>
        /// Sorts the list based off the parameter set in the xml config file
        /// </summary>
        /// <param name="dirOb">The list of collected directory files and their data</param>
        /// <returns></returns>
        private List<DirectoryObjects> SortList(List<DirectoryObjects> dirOb)
        {
            string sortingType = _config.SortingType;
            string sortingDirection = _config.SortingDirection;

            //TODO: --2-- possible to revise the if/else statement below to not be as redundant?
            if (sortingDirection == "Ascending")
            {
                switch (sortingType)
                {
                    case "File Name":
                        dirOb = dirOb.OrderBy(ms => ms.name).ToList();
                        break;
                    case "File Path":
                        dirOb = dirOb.OrderBy(ms => ms.path).ToList();
                        break;
                    case "File Size":
                        dirOb = dirOb.OrderBy(ms => ms.size).ToList();
                        break;
                    case "File Type":
                        dirOb = dirOb.OrderBy(ms => ms.type).ToList();
                        break;
                }//finds which is checked and updates the list to match the new format
            }
            else
            {
                switch (sortingType)
                {
                    case "File Name":
                        dirOb = dirOb.OrderByDescending(ms => ms.name).ToList();
                        break;
                    case "File Path":
                        dirOb = dirOb.OrderByDescending(ms => ms.path).ToList();
                        break;
                    case "File Size":
                        dirOb = dirOb.OrderByDescending(ms => ms.size).ToList();
                        break;
                    case "File Type":
                        dirOb = dirOb.OrderByDescending(ms => ms.type).ToList();
                        break;
                }//finds which is checked and updates the list to match the new format
            }
            Log($"Sort: {sortingType}, {sortingDirection}");
            return dirOb;
        }//Sorts the List

        /// <summary>
        /// Performs data logging to the debuglogging file
        /// </summary>
        /// <param name="log"></param>
        private void Log(string log)
        {
            DebugLogging.LogActivity(log);
        }
    }
}
