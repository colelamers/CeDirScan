Program can scan your drive to a text file giving you the File Name, Path, Size, and Type. It can do it ascending and descending in the sorting option you choose. The text file is in CSV format.

Current Known Issues:
If a single file in a directory path does not have read or write permissions (such as in the WIN32 folder) the entire program will fail and not continuing executing the code. So as a compromise you'll need to select a specific directory instead of the entire root drive. However if all files have read/write permissions such as a secondary drive, it should run.
