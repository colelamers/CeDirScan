using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DirectoryScanner
{
    public class BLLProcessing
    {
        Configuration _config;


        List<DirectoryObjects> dirObjList = new List<DirectoryObjects>();
        public BLLProcessing()
        {
            _config = Configuration.LoadFromFile("configuration.xml"); //TODO: --3-- Figure out someway to make my own DLL for debuglogging and xml serialization
        }

        private List<DirectoryObjects> ScanDirectory()
        {
            Log("Scanning Directory");
            try
            {
                List<DirectoryObjects> dirObjList = new List<DirectoryObjects>();


                List<string> subDirs = Directory.GetDirectories(_config.DirectoryPath).Select(d => new { Attr = new DirectoryInfo(d).Attributes, Dir = d })
                      .Where(x => !x.Attr.HasFlag(FileAttributes.System))
                      .Where(x => !x.Attr.HasFlag(FileAttributes.Hidden))
                      .Select(x => x.Dir)
                      .ToList();
                //Gets a list of all directories except for hidden files

                foreach (string dir in subDirs)
                {

                    List<string> filesInDirectory = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories).ToList();
                    //Directory.GetFiles(...) returns only files, it does not get the directories. Directory.GetFileSystemEntries returns all folders too

                    foreach (string file in filesInDirectory)
                    {
                        DirectoryObjects dirObj = new DirectoryObjects();
                        FileInfo n = new FileInfo(file);
                        dirObj.type = Path.GetExtension(file);
                        dirObj.path = Path.GetDirectoryName(file);
                        dirObj.name = Path.GetFileNameWithoutExtension(file);
                        dirObj.size = dirObj.getSizeOnDisk(n.Length.ToString());
                        dirObjList.Add(dirObj);
                    }//Gets the directory object and adds it to the list
                }//for every directory in the list

                //TODO: --2-- If subDirs.Count == 0, then scan only files in list
                dirObjList = SortList(dirObjList); //sorts the list

                return dirObjList;

            }
            catch (Exception ex)
            {
                //TODO: --1-- need to revise code so that when an access denied occurs, it just skips that file instead of stopping the whole program
                Log($"Error: {ex}");
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
                            streamWriter.WriteLine($"{tObject.type}, {tObject.path}, {tObject.name}, {tObject.size}");
                        }
                        streamWriter.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
                Log($"Error: {ex}");
            }
        }


        private List<DirectoryObjects> SortList(List<DirectoryObjects> dirOb)
        {
            //TODO: --3-- Has to be a better way to clean this up without so much redundant code...
            string sortingType = _config.SortingType;
            string sortingDirection = _config.SortingDirection;

            if (sortingDirection == "Ascending")
            {
                switch (sortingType)
                {
                    //TODO: --2-- have a radio button in a group box, read from the config file, that determines if it'll be in ascending or descending order
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
                    //TODO: --2-- have a radio button in a group box, read from the config file, that determines if it'll be in ascending or descending order
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

        private void Log(string log)
        {
            DebugLogging.LogActivity(log);
        }


    }
}
