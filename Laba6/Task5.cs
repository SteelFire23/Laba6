using System;
using System.Collections.Generic;
using System.IO;

namespace Laba6
{
    class Task5
    {
        public static void Fifth()
        {
            string path = $@"D:\{Console.ReadLine()}.bmp";
            using (BinaryReader file=new BinaryReader(File.OpenRead(path)))
            {
                file.ReadChars(2);
                int size = file.ReadInt32();
                file.ReadBytes(12);
                int width = file.ReadInt32();
                int heigth = file.ReadInt32();
                file.ReadBytes(2);
                int pixels = file.ReadInt32();
                string temp = "";
                switch (file.ReadInt16())
                {
                    case 0:
                        temp = "Без сжатия"; break;
                    case 1:
                        temp = "8 bit RLE сжатие"; break;
                    case 2:
                        temp = "4 bit RLE сжатие"; break;
                }
                file.ReadBytes(4);
                int HRes = file.ReadInt32();
                int VRes = file.ReadInt32();
                Console.WriteLine($"Размер файла: {size} байта\n" +
                    $"Ширина в пикселях: {width}\n" +
                    $"Высота в пикселях: {heigth}\n" +
                    $"Количество бит на пиксель: {pixels}\n" +
                    $"Горизонтальное разрешение: {HRes}\n" +
                    $"Вертикальное разрешение: {VRes}\n" +
                    $"Сжатие: {temp}");
                file.Close();
            }
        }
    }
}
