using System;
using System.IO;
using System.Text;
using System.IO.Compression;

namespace Laba13
{
    public static class file
    {
        public static class AMDLog
        {
            private static string path = @"D:\2_course\OOP_1sem\amdlogfile.txt";

            public static void Write(string fileName, string filePath)
            {
                using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
                {
                    sw.WriteLine("\n---------------------------------------------------------\n" +
                                 $"Time: {DateTime.Now}\n" + $"File Name: {fileName}\n" + $"File Path: {filePath}");
                }
            }

            public static void Read()
            {
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }

            public static void Search(string time)
            {
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains(time))
                        {
                            Console.WriteLine(line);
                        }
                        else
                        {
                            Console.WriteLine("No actions and specified time");
                        }
                    }
                }
            }
        }

        public static class AMDDiskInfo
        {
            public static void FreeSpace()
            {
                Console.WriteLine("\n---------------------------------------------------------\n");
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (var drive in drives)
                {
                    Console.WriteLine($"{drive.Name}'s Free Space: {drive.TotalFreeSpace}");
                }
            }

            public static void FileSystem()
            {
                Console.WriteLine("\n---------------------------------------------------------\n");
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (var drive in drives)
                {
                    Console.WriteLine($"{drive.Name} File System: {drive.DriveFormat}");
                }
            }

            public static void DrivesInfo()
            {
                Console.WriteLine("\n---------------------------------------------------------\n");
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (var drive in drives)
                {
                    Console.WriteLine($"Drive Name: {drive.Name}\n" +
                                      $"Drive Total Size: {drive.TotalSize}\n"
                                      + $"Drive Available Space: {drive.AvailableFreeSpace}\n"
                                      + $"Drive Label: {drive.VolumeLabel}");
                }
            }
        }

        public static class AMDFileInfo
        {
            public static void FullPath(string filePath)
            {
                Console.WriteLine("\n---------------------------------------------------------\n");
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    Console.WriteLine($"Full Path to {file.Name}: {file.DirectoryName}");
                }
                else
                {
                    Console.WriteLine("File Not Found");
                }
            }

            public static void GetFileInfo(string filePath)
            {
                Console.WriteLine("\n---------------------------------------------------------\n");
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    Console.WriteLine($"File Name: {file.Name}\n"
                                      + $"File Extension: {file.Extension}\n"
                                      + $"File Size: {file.Length}");
                }
                else
                {
                    Console.WriteLine("File Not Found");
                }
            }

            public static void GetFileCreation(string filePath)
            {
                Console.WriteLine("\n---------------------------------------------------------\n");
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    Console.WriteLine($"File Creation Time: {file.CreationTime}\n"
                                      + $"File Change Time: {file.LastWriteTime}");
                }
                else
                {
                    Console.WriteLine("File Not Found");
                }
            }
        }

        public static class AMDDirInfo
        {
            public static void FileAmount(string dirPath)
            {
                Console.WriteLine("\n---------------------------------------------------------\n");
                DirectoryInfo dir = new DirectoryInfo(dirPath);
                if (dir.Exists)
                {
                    Console.WriteLine($"Amount of Files in Directory: {dir.GetFiles().Length}");
                }
                else
                {
                    Console.WriteLine("Directory Not Found");
                }
            }

            public static void DirCreationTime(string dirPath)
            {
                Console.WriteLine("\n---------------------------------------------------------\n");
                DirectoryInfo dir = new DirectoryInfo(dirPath);
                if (dir.Exists)
                {
                    Console.WriteLine($"Directory Creation Time: {dir.CreationTime}");
                }
                else
                {
                    Console.WriteLine("Directory Not Found");
                }
            }

            public static void SubDirectoriesAmount(string dirPath)
            {
                Console.WriteLine("\n---------------------------------------------------------\n");
                DirectoryInfo dir = new DirectoryInfo(dirPath);
                if (dir.Exists)
                {
                    Console.WriteLine($"Amount of Sub Directories: {dir.GetDirectories().Length}");
                }
                else
                {
                    Console.WriteLine("Directory Not Found");
                }
            }

            public static void RootDirectoriesList(string dirPath)
            {
                Console.WriteLine("\n---------------------------------------------------------\n");
                DirectoryInfo dir = new DirectoryInfo(dirPath);
                if (dir.Exists)
                {
                    Console.WriteLine($"Root Directories: {dir.Root}");
                }
                else
                {
                    Console.WriteLine("Directory Not Found");
                }
            }
        }

        public static class AMDFileManager
        {
            /*5. Создать класс XXXFileManager. Набор методов определите самостоятельно. С его помощью выполнить следующие действия:
        
        c. Сделайте архив из файлов директория XXXFiles. Разархивируйте его в другой директорий.*/
            public static void CreateDirectory(string driveLabel)
            {
                string path = @"D:\AMDInspect";
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (var drive in drives)
                {
                    if (drive.VolumeLabel == driveLabel)
                    {
                        string[] dirs = Directory.GetDirectories(drive.Name);
                        foreach (var dir in dirs)
                        {
                            Console.WriteLine(dir);
                        }
                    }
                }
                Directory.CreateDirectory(path);
               using(File.Create(path + @"\amddirinfo.txt"))
               {}
            }

            public static void MoveDelete()
            {
                string path = @"D:\AMDInspect";
                File.Move(path + @"\amddirinfo.txt", path + @"\amddirinfoRenamed.txt");
                File.Delete(path + @"\amddirinfo.txt");
            }
            /*public static void CopyFiles(string userDir)
            {
                Copy(userDir, @"D:\AMDFiles");
                Directory.Move(@"D:\AMDFiles", @"D:\AMDInspect\");
            }
            public static void Copy(string sourceDir, string targetDir)
            {
                foreach(var file in Directory.GetFiles(sourceDir))
                    File.Copy(file, Path.Combine(targetDir, Path.GetFileName(file)));
                
                foreach(var directory in Directory.GetDirectories(sourceDir))
                    Copy(directory, Path.Combine(targetDir, Path.GetFileName(directory)));
            }*/
            public static void Archive()
            {
                string startPath = @"D:\AMDInspect";
                string zipPath = @"D:\AMDInspect.zip";
                string extractPath = @"D:\2_course";

                ZipFile.CreateFromDirectory(startPath, zipPath);

                ZipFile.ExtractToDirectory(zipPath, extractPath);
            }
        }
    }
}    