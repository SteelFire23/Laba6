using System;
using System.Drawing;
using System.IO;
using LibPrint;

namespace Laba6
{
    class Task5Seek
    {
        public static void Fifth()
        {
            string path = $@"D:\{Console.ReadLine()}.bmp";
            using (FileStream file = new FileStream(path, FileMode.Open,FileAccess.Read))
            {
                String temp = "";
                switch (file.Seek(30, SeekOrigin.Begin))
                {
                    case 0:
                        temp="Без сжатия"; break;
                    case 1:
                        temp="8 bit RLE сжатие"; break;
                    case 2:
                        temp="4 bit RLE сжатие"; break;
                }              
                Console.WriteLine($"Размер файла: {file.Seek(3, SeekOrigin.Begin)} байта\n" +
                    $"Ширина в пикселях: {file.Seek(18,SeekOrigin.Begin)}\n" +
                    $"Высота в пикселях: {file.Seek(22,SeekOrigin.Begin)}\n" +
                    $"Количество бит на пиксель: {file.Seek(28,SeekOrigin.Begin)}\n" +
                    $"Горизонтальное разрешение: {file.Seek(38,SeekOrigin.Begin)}\n" +
                    $"Вертикальное разрешение: {file.Seek(42,SeekOrigin.Begin)}\n" +
                    $"Сжатие: {temp}");                
            }
        }
    }
}
  