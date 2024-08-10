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

            if (OpenDataBase("\\\\192.168.100.72\\KABIS\\Data\\Books.dbx", PtrToStr(ScanForPass("\\\\192.168.100.72\\KABIS\\KABIS.EXE"))))
            {
                Console.WriteLine("База данных была успешно открыта через сетевую папку по IP-адресу компьютера!");
                int iRecords = GetTableRecords("Books");

                if (iRecords != -1)
                    Console.WriteLine("Кол-во книг в библиотечном фонде: {0}", iRecords);

                if (CloseDataBase())
                    Console.WriteLine("Соединение с базой данных было закрыто.");
            }
            else
                Console.WriteLine("Не удалось открыть базу данных.");

            Console.ReadKey();
        }
    }
}