using System;
using System.IO;
using System.Text;

namespace Laba6
{
    class Task2
    {
        public static void Second()
        {
            string path = @"D:\Binary_Laba6.dat",
                   secondPath = @"D:\Binary2_Laba6.dat";
           using(BinaryWriter file = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
           {
                for(int i = 1; i < 101; i++)
                {
                    file.Write(i);
                    file.Write(1.0 / i);
                }
                file.Close();
           }
           using(BinaryReader fileRead = new BinaryReader(File.Open(path, FileMode.Open)))
           {
                using (BinaryWriter secondFile = new BinaryWriter(File.Open(secondPath, FileMode.OpenOrCreate)))
                {
                    while (fileRead.PeekChar() > -1)
                    {
                        int temp = fileRead.ReadInt32();
                        double temp2 = fileRead.ReadDouble();
                        secondFile.Write(temp2);
                    }
                    secondFile.Close();
                }
                fileRead.Close();               
           }
            using (BinaryReader secondFileRead = new BinaryReader(File.Open(secondPath, FileMode.Open)))
            {
                while (secondFileRead.PeekChar() > -1)
                {
                    double temp = secondFileRead.ReadDouble();
                    Console.WriteLine(temp);
                }
                secondFileRead.Close();
            }
        }
    }
}
    
