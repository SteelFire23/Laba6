using System;
using System.Collections.Generic;
using System.IO;

namespace Laba6
{
    class Task4
    {
        public static void Fourth()
        {
            string path = @"D:\Lab.dat",
                   pathDirectory=@"D:\Lab6_Temp",
                   newPath = @"D:\Lab6_Temp\Lab.dat",
                   secondNewPath = @"D:\Lab6_Temp\Lab_backup.dat";
            Directory.CreateDirectory(pathDirectory);
            File.Copy(path, newPath, true);
            File.Copy(newPath, newPath, true);
            //File.Copy(newPath, secondNewPath, true);
            using(BinaryReader fileRead=new BinaryReader(File.OpenRead(newPath)))
            {
                using(BinaryWriter fileWrite=new BinaryWriter(File.Open(secondNewPath, FileMode.OpenOrCreate)))
                {
                    while (fileRead.PeekChar() > -1)
                    {
                        fileWrite.Write(fileRead.ReadByte());
                    }
                    fileWrite.Close();
                }
                fileRead.Close();
            }
            FileInfo file = new FileInfo(newPath);     
            Console.WriteLine($"Размер файла:{file.Length} байт\n" +
                $"Время последнего изменения:{file.LastWriteTime}\n" +
                $"Время последнего доступа к файлу:{file.LastAccessTime}");
        }
    }
}
