using System;
using System.Text;
using System.Runtime.InteropServices;

namespace KabisAPITest
{
    internal class Program
    {
        /* Тут находятся все функции экспорта, которые содержит библиотека kapi32.dll и kapi32u.dll */

        [DllImport("kapi32u.dll", CallingConvention = CallingConvention.StdCall)]
        extern public static IntPtr ScanForPass(string strAppName);

        [DllImport("kapi32.dll", CallingConvention = CallingConvention.StdCall)]
        extern public static string PtrToStr(IntPtr intPtr);

        [DllImport("kapi32.dll", CallingConvention = CallingConvention.StdCall)]
        extern public static bool OpenDataBase(string strDataBase, string strPassword);

        [DllImport("kapi32.dll", CallingConvention = CallingConvention.StdCall)]
        extern public static string EnumTables();

        [DllImport("kapi32.dll", CallingConvention = CallingConvention.StdCall)]
        extern public static int GetTableCount();

        [DllImport("kapi32.dll", CallingConvention = CallingConvention.StdCall)]
        extern public static string EnumFields(string strTable);

        [DllImport("kapi32.dll", CallingConvention = CallingConvention.StdCall)]
        extern public static int GetFieldCount(string strTable);

        [DllImport("kapi32.dll", CallingConvention = CallingConvention.StdCall)]
        extern public static string SelectAllFrom(string strTable, bool bOutput);

        [DllImport("kapi32.dll", CallingConvention = CallingConvention.StdCall)]
        extern public static string UnloadTable(string strTable, string strFile, int iType, bool bOutput);

        [DllImport("kapi32.dll", CallingConvention = CallingConvention.StdCall)]
        extern public static int GetTableRecords(string strTable);

        [DllImport("kapi32.dll", CallingConvention = CallingConvention.StdCall)]
        extern public static bool CloseDataBase();

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

        Repeat:

            if (OpenDataBase("C:\\KABIS\\Data\\Books.dbx", PtrToStr(ScanForPass("C:\\KABIS\\KABIS.EXE"))))
            {
                Console.WriteLine("База данных была успешно открыта!");
                string strTables = EnumTables();

                if (!string.IsNullOrEmpty(strTables))
                {
                    Console.WriteLine(strTables);
                    Console.Write("\nУкажите наименование таблицы для выгрузки: ");

                    string strTable = Console.ReadLine();
                    int iRecords = GetTableRecords(strTable);

                    if (iRecords != -1)
                        Console.WriteLine("Количество записей в указанной таблице: {0}", iRecords);

                    if (!string.IsNullOrEmpty(UnloadTable(strTable, (strTable + ".txt"), 2, false)))
                        Console.WriteLine("Таблица \"{0}\" была успешно выгружена!", strTable);
                    else
                        Console.WriteLine("Не удалось выгрузить таблицу \"{0}\"", strTable);
                }
                else
                    Console.WriteLine("Не получить перечень таблиц в базе данных.");

                if (CloseDataBase())
                    Console.WriteLine("Соединение с базой данных было закрыто.");
            }
            else
                Console.WriteLine("Не удалось открыть базу данных.");

            Console.WriteLine("Нажмите клавишу \"1\" для повтора ввода.\nИли нажмите любую другую клавишу чтобы завершить выполнение программы...");

            if (Console.ReadKey().KeyChar == '1')
            {
                CloseDataBase();
                Console.Clear();

                goto Repeat;
            }
        }
    }
}