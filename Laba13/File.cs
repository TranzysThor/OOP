using System;
using System.IO;
using System.Text;

namespace Laba13
{
    public static class file
    {
        /*
        6. Найдите и выведите сохраненную информацию в файле xxxlogfile.txt о действиях пользователя за определенный 
        день/ диапазон времени/по ключевому слову. Посчитайте количество записей в нем. Удалите часть информации, оставьте только записи за текущий час.
        7. Обязательно обрабатывайте возможные ошибки. В случае с потоками необходимо использовать конструкцию using.
        Если необходимо «построить» путь, то следует использовать методы класса Path
         */
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
                    Console.WriteLine($"{drive.Name} Free Space: {drive.TotalFreeSpace}");
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
                                      $"Drive Total Size: {drive.TotalSize}"
                                      + $"Drive Available Space: {drive.AvailableFreeSpace}"
                                      + $"Drive Lable: {drive.VolumeLabel}");
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
                    Console.WriteLine($"File Not Found");
                }
            }

            public static void GetFileInfo(string filePath)
            {
                Console.WriteLine("\n---------------------------------------------------------\n");
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    Console.WriteLine($"File Name: {file.Name}\n"
                                      + $"File Extension: {file.Extension}"
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
                    Console.WriteLine($"File Creation Time: {file.CreationTime}"
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
        a. Прочитать список файлов и папок заданного диска. 
        Создать директорий XXXInspect, создать текстовый файл xxxdirinfo.txt и сохранить туда информацию. 
        Создать копию файла и переименовать его. Удалить первоначальный файл.
        b. Создать еще один директорий XXXFiles. Скопировать в него все файлы с заданным расширением из заданного пользователем директория. 
        Переместить XXXFiles в XXXInspect.
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
                DirectoryInfo directory = new DirectoryInfo(drives[1].Name);
                directory.CreateSubdirectory(path);
                using (FileStream fs = File.Create(path + @"\amddirinfo.txt"))
                {
                }
            }
        }
    }
}    