//Создать базу(массив) из n видов программного обеспечения, вывести полную
//информацию из базы на экран, а также организовать поиск программного обеспечения,
//которое допустимо использовать на текущую дату.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;

namespace pr18
{
    class Program
    {
        static void Print(List<Software> software)
        {
            if (software.Count == 0)
            {
                Console.WriteLine("Список объектов пуст.");
            }
            else
            {
                Console.WriteLine("Список объектов:");
                foreach (var s in software)
                {
                    //Console.WriteLine(s.ToString());
                    s.DisplayInfo();
                    s.CanBeUsedNow();
                    
                }
            }
        }
        static void Main(string[] args)
        {
            List<Software> software = new List<Software>();
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream f = new FileStream(@"C:\Users\PC\Desktop\inp.dat",
             FileMode.OpenOrCreate))
            {
                if (f.Length != 0)
                {
                    software = (List<Software>)formatter.Deserialize(f);
                }
            }
            software.Add(new FreeSoftware("Free App", "Company A"));
            software.Add(new TrialSoftware("Trial App", "Company B", DateTime.Now, 30));
            software.Add(new CommercialSoftware("Commercial App", "Company C", 99.99m, DateTime.Now, 365));
            Print(software);

            software.Sort();
            Console.WriteLine("----------после сортировки----------");
            Print(software);

            using (FileStream f = new FileStream(@"C:\Users\PC\Desktop\inp.dat",
                FileMode.OpenOrCreate))
            {
                formatter.Serialize(f, software);
            }

            // Ввод даты пользователем
            Console.WriteLine("Введите текущую дату (в формате dd.mm.yyyy):");
            string inputDate = Console.ReadLine();
            DateTime currentDate;

            // Проверка корректности введенной даты
            if (!DateTime.TryParseExact(inputDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out currentDate))
            {
                Console.WriteLine("Некорректный формат даты.");
                return;
            }

            // Поиск программного обеспечения, которое можно использовать на текущую дату
            List<Software> usableSoftware = software.Where(s => s.CanBeUsedNow()).ToList();

            // Вывод найденного программного обеспечения
            Console.WriteLine("Программное обеспечение, которое можно использовать на текущую дату:");
            Print(usableSoftware);
        }
    }
}


//////////////////////main
//Software[] softwareDatabase = new Software[]
//{
//new FreeSoftware { Name = "Free App", Manufacturer = "Company A" },
//new TrialSoftware { Name = "Trial App", Manufacturer = "Company B", InstallationDate = DateTime.Now, TrialDays = 30 },
//new CommercialSoftware { Name = "Commercial App", Manufacturer = "Company C", Price = 99.99m, InstallationDate = DateTime.Now, LicenseDays = 365 }
//};

////
////Software[] softwareDatabase;

////using (StreamReader sr = new StreamReader(@"C:\Users\PC\Desktop\C#\pr18\input.txt"))
////{
////    string line;
////    int count = 0;

////    while ((line = sr.ReadLine()) != null)
////    {
////        count++;
////    }

////    softwareDatabase = new Software[count];
////}

////using (StreamReader sr = new StreamReader(@"C:\Users\PC\Desktop\C#\pr18\input.txt"))
////{
////    int index = 0;
////    string line;

////    while ((line = sr.ReadLine()) != null)
////    {
////        string[] data = line.Split(',');

////        if (data[0] == "Free")
////        {
////            softwareDatabase[index] = new FreeSoftware { Name = data[1], Manufacturer = data[2] };
////        }
////        else if (data[0] == "Trial")
////        {
////            DateTime installationDate = DateTime.Now; // Default value
////            int trialDays = int.Parse(data[3]);
////            softwareDatabase[index] = new TrialSoftware { Name = data[1], Manufacturer = data[2], InstallationDate = installationDate, TrialDays = trialDays };
////        }
////        else if (data[0] == "Commercial")
////        {
////            decimal price = decimal.Parse(data[3]);
////            DateTime installationDate = DateTime.Now; // Default value
////            int licenseDays = int.Parse(data[4]);
////            softwareDatabase[index] = new CommercialSoftware { Name = data[1], Manufacturer = data[2], Price = price, InstallationDate = installationDate, LicenseDays = licenseDays };
////        }

////        index++;
////    }
////}

////static void Print(List<Software> objects)
////{
////    if (objects.Count == 0)
////    {
////        Console.WriteLine("Список объектов пуст.");
////    }
////    else
////    {
////        Console.WriteLine("Список объектов:");
////        foreach (Software item in objects)
////        {

////        }

////}
////static void Main(string[] args)
////{
////    List < Software > object = new List<Software>();
////    BinaryFormatter formatter = new BinaryFormatter();

////}
//Array.Sort(softwareDatabase);
//foreach (var software in softwareDatabase)
//{
//    software.DisplayInfo();
//    if (software.CanBeUsedNow())
//    {
//        Console.WriteLine("Can be used now.");
//    }
//    else
//    {
//        Console.WriteLine("Cannot be used now.");
//    }
//}

//// Поиск программного обеспечения, которое можно использовать на текущую дату
//foreach (var software in softwareDatabase)
//{
//    if (software.CanBeUsedNow())
//    {
//        Console.WriteLine($"Software that can be used now: {software.Name}");
//    }
//}