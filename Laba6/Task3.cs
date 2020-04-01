using System;
using System.IO;
using LibPrint;

namespace Laba6
{
    public class Task3
    {
        public static void Third()
        {
            string path = @"D:\Laba6.txt", 
                   Text="";
            string path1 = @"D:\Laba6_Second.txt";
            int count = 0;
            using (StreamReader first = new StreamReader(path))
            {
                string text = first.ReadToEnd();
                char[] S = text.ToCharArray();
                for(int i = 0; i < S.Length; i++)
                {
                    if (S[i] == '<')
                    {
                        S[i] = '{';
                        count++;
                    }
                    else if (S[i] == '>')
                    {
                        S[i] = '}';
                        count++;
                    }
                    Text += S[i];
                }
                first.Close();
            }
            Console.WriteLine(Text);
            Console.WriteLine($"Number of replacement:{count}");
            using (StreamWriter second = File.CreateText(path1))
            {
                second.Write(Text);
                second.Close();
            }          
        }
    }
}