using System;
using LibPrint;

namespace Laba6
{
    class MainPoint
    {
        static void Main(string[] args)
        {
            A:try
            {
                Pt.P("Enter the number of task");
                int number = int.Parse(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        Console.Clear(); Task1.First(); break;
                    case 2:
                        Console.Clear(); Task2.Second(); break;
                    case 3:
                        Console.Clear(); Task3.Third(); break;
                    case 4:
                        Console.Clear(); Task4.Fourth(); break;
                    case 5:
                        Console.Clear(); Task5.Fifth(); break;
                }
            }
            catch { Pt.P("Something wrong ! Please repeat."); goto A; }
        }
    }
}
