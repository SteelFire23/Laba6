using System;
using System.IO;
using LibPrint;

namespace Laba6
{
    public class Task1
    {
        static Log[] L = new Log[5];
        public static void First()
        {
        B:
            try
            {
                int N = 3, k = 0;
                Sport[] S = new Sport[N];
                string path = @"D:\Lab.dat";
                using (BinaryReader file = new BinaryReader(File.OpenRead(path)))
                {
                    for(int i = 0; i < S.Length; i++)
                    {
                        S[i].Name = file.ReadString();
                        S[i].Year = file.ReadInt32();
                        S[i].Exp = file.ReadInt16();
                        S[i].Who = (SportType)Enum.Parse(typeof(SportType), file.ReadString());
                    }
                    file.Close();
                }
                /*using (BinaryWriter file = new BinaryWriter(File.Open(path,FileMode.OpenOrCreate)))
                {                 
                    S[0].Name = "Петров А.А."; S[1].Name = "Шишкин С.К."; S[2].Name = "Кравченко Г.А.";
                    S[0].Year = 1950; S[1].Year = 1984; S[2].Year = 1981;
                    S[0].Exp = 22; S[1].Exp = 8; S[2].Exp = 10;
                    S[0].Who = SportType.T; S[1].Who = SportType.C; S[2].Who = SportType.C;
                    for(int i = 0; i < S.Length; i++)
                    {
                        file.Write(S[i].Name);
                        file.Write(S[i].Year);
                        file.Write(S[i].Exp);
                        file.Write(S[i].Who.ToString());
                    }
                    file.Close();
                }*/
            A: Console.Clear();
                Pt.P("Отлично, а теперь выберите действие:\n1 – Просмотр таблицы\n2 – Добавить запись\n3 – Удалить запись\n4 – Обновить запись\n5 – Поиск записей\n6 – Просмотреть лог\n7 - Выход");
                int number = int.Parse(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        Console.Clear(); Print(ref S, ref N); goto A;
                    case 2:
                        Console.Clear(); ++N; Add(ref N, ref S, ref L, ref k); goto A;
                    case 3:
                        Console.Clear(); Del(ref N, ref S, ref L, ref k); goto A;
                    case 4:
                        Console.Clear(); Update(ref S, ref L, ref k); goto A;
                    case 5:
                        Console.Clear(); Filter(ref S); goto A;
                    case 6:
                        Console.Clear(); PrintLog(ref L, ref k); goto A;
                    case 7:
                        Console.Clear();
                        using (BinaryWriter fileNew = new BinaryWriter(File.Open(path,FileMode.Append)))
                        {
                            for (int i = 0; i < S.Length; i++)
                            {
                                fileNew.Write(S[i].Name);
                                fileNew.Write(S[i].Year);
                                fileNew.Write(S[i].Exp);
                                fileNew.Write(S[i].Who.ToString());
                            }
                            fileNew.Close();
                        }
                        Console.WriteLine(" Удачи!"); break;
                }
            }
            catch { Pt.P("Где-то ошибка! Нажмите любую кнопку, чтобы начать заново."); Console.ReadKey(); Console.Clear(); goto B; }
            static void Print(ref Sport[] S, ref int N)
            {
                Console.WriteLine(" __________________________________________________________________________________ ");
                Console.WriteLine("|{0,0}", " Состав спортклуба                                                                |");
                Console.WriteLine("|__________________________________________________________________________________|");
                Console.WriteLine("|{0,0}                      |{1,-10}|{2,-24}|{3,-20}|", "ФИО", "Тип", "Год рождения", "Опыт(лет)");
                Console.WriteLine("|_________________________|__________|________________________|____________________|");
                Console.WriteLine("|{0,-20}     |{1,-10}|{2,-24}|{3,-20}|", S[0].Name, S[0].Who, S[0].Year, S[0].Exp);
                Console.WriteLine("|{0,-20}     |{1,-10}|{2,-24}|{3,-20}|", S[1].Name, S[1].Who, S[1].Year, S[1].Exp);
                Console.WriteLine("|{0,-20}     |{1,-10}|{2,-24}|{3,-20}|", S[2].Name, S[2].Who, S[2].Year, S[2].Exp);
                if (N > 3)
                {
                    for (int i = 3; i < N; i++)
                    {
                        if (N == S.Length) Console.WriteLine("|{0,-20}     |{1,-10}|{2,-24}|{3,-20}|", S[i].Name, S[i].Who, S[i].Year, S[i].Exp);
                    }
                }
                Console.WriteLine("|_________________________|__________|________________________|____________________|");
                Console.ReadKey();
            }
            static void Add(ref int N, ref Sport[] S, ref Log[] L, ref int k)
            {
                Pt.P("Начат процесс добавления записи. Пожалуйста следуйте инструкциям.");
                Array.Resize(ref S, S.Length + 1);
                Pt.P("Введите имя: ");
                S[N - 1].Name = Console.ReadLine();
                Pt.P("Введите год рождения: ");
                S[N - 1].Year = int.Parse(Console.ReadLine());
                Pt.P("Введите кол-во лет опыта:");
                S[N - 1].Exp = short.Parse(Console.ReadLine());
                Pt.P("Введите <1>,если это тренер.Введите <2>, если это спортсмен");
                S[N - 1].Who = (SportType)int.Parse(Console.ReadLine());
                if (k < 50)
                {
                    L[k].Action = " - Добавлена запись: " + S[N - 1].Name.ToString();
                    L[k].Time = DateTime.Now; ++k;
                }
                Pt.P("Запись успешно добавлена");
                Console.ReadKey();
            }
            static void Del(ref int N, ref Sport[] S, ref Log[] L, ref int k)
            {
                Pt.P("Введите номер записи которую хотите удалить");
                int Number = int.Parse(Console.ReadLine());
                Number -= 1;
                if (k < 50)
                {
                    L[k].Action = " - Запись удалена: " + S[Number].Name.ToString();
                    L[k].Time = DateTime.Now; ++k;
                }
                Sport[] Temp = new Sport[S.Length];
                Array.Copy(S, 0, Temp, 0, Number);
                Array.Copy(S, Number + 1, Temp, Number, S.Length - Number - 1);
                S = Temp;
                --N;
                Pt.P("Запись успешно удалена");
                Console.ReadKey();
            }
            static void Update(ref Sport[] S, ref Log[] L, ref int k)
            {
                Pt.P("Начат процесс обновления записи. Пожалуйста следуйте инструкциям.");
                Pt.P("Введите номер записи, которую нужно обновить");
                int Number = int.Parse(Console.ReadLine());
                Number -= 1;
                if (k < 50)
                {
                    L[k].Action = " - Запись обновлена: " + S[Number].Name.ToString();
                    L[k].Time = DateTime.Now; ++k;
                }
                Console.Clear();
                Pt.P("Теперь введите обновленные данные\nначнем с имени:");
                S[Number].Name = Console.ReadLine();
                Pt.P("Теперь введите год рождения:");
                S[Number].Year = int.Parse(Console.ReadLine());
                Pt.P("Введите кол-во лет опыта:");
                S[Number].Exp = short.Parse(Console.ReadLine());
                Pt.P("Введите <1>,если это тренер.Введите <2>, если это спортсмен");
                S[Number].Who = (SportType)int.Parse(Console.ReadLine());
                Pt.P("Запись успешно обновлена");
                Console.ReadKey();
            }
            static void Filter(ref Sport[] S)
            {
                Pt.P("Введите год рождения сотрудника, которого хотите найти");
                int Number = int.Parse(Console.ReadLine()), count = 0;
                for (int i = 0; i < S.Length; i++)
                {
                    if (S[i].Year == Number)
                    {
                        FiltPrint(ref S, i, count);
                        count++;
                    }
                    else if (i == S.Length - 1) { FiltPrint(ref S, i, count); }
                }
                Console.ReadKey();
            }
            static void FiltPrint(ref Sport[] S, int M, int Count)
            {
                if (Count == 0)
                {
                    Console.WriteLine(" __________________________________________________________________________________ ");
                    Console.WriteLine("|{0,0}", " Состав спортклуба                                                                |");
                    Console.WriteLine("|__________________________________________________________________________________|");
                    Console.WriteLine("|{0,0}                      |{1,-10}|{2,-24}|{3,-20}|", "ФИО", "Тип", "Год рождения", "Опыт(лет)");
                    Console.WriteLine("|_________________________|__________|________________________|____________________|");
                }
                Console.WriteLine("|{0,-20}     |{1,-10}|{2,-24}|{3,-20}|", S[M].Name, S[M].Who, S[M].Year, S[M].Exp);
                if (M == S.Length - 1) Console.WriteLine("|_________________________|__________|________________________|____________________|");
            }
            static void PrintLog(ref Log[] L, ref int k)
            {
                for (int i = 0; i < k; i++)
                {
                    Console.WriteLine(L[i].Time + L[i].Action);
                }
                TimeSpan Max = L[k].Time.Subtract(L[k - 1].Time);
                for (int i = k; i >= 0; i--)
                {
                    for (int j = 0; j < k; j++)
                    {
                        if (L[i].Time.Subtract(L[j].Time) > Max) { Max = L[i].Time.Subtract(L[j].Time); }
                    }
                }
                Console.WriteLine("\n" + Max + " - Самый долгий период бездействия пользователя");
                Console.ReadKey();
            }
        }
        public static void AddLog(String name, int year, int exp, SportType type)
        {

        }

    }
    struct Sport
    {
        public string Name;
        public int Year;
        public short Exp;
        public SportType Who;
    }
    struct Log
    {
        public string Action;
        public DateTime Time;
    }
    public enum SportType : byte
    {
        T = 1,
        C
    }



}

