//Создать производные классы: 
//Коммерческое(название, производитель, цена, дата установки,
//срок использования) со своими методами вывода информации на экран
//и определения возможности использования на текущую дату. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace pr18
{

    [Serializable]
    class CommercialSoftware : Software
    {
        public decimal Price { get; set; }
        public DateTime InstallationDate { get; set; }
        public int LicenseDays { get; set; }

        //конструктор 
        public CommercialSoftware(string name, string manufacturer, decimal price, DateTime installationDate, int licenseDays) : base(name, manufacturer)
        {
            this.Price = price;
            this.InstallationDate = installationDate;
            this.LicenseDays = licenseDays;
        }
       
        public override void DisplayInfo()
        {
            Console.WriteLine($"Commercial Software: {Name} ({Manufacturer}), Price: {Price}, License Ends: {InstallationDate.AddDays(LicenseDays)}");
            //return $"Commercial Software: {Name} ({Manufacturer}), Price: {Price}, License Ends: {InstallationDate.AddDays(LicenseDays)}";
        }

        public override bool CanBeUsedNow()
        {
            // Логика проверки возможности использования коммерческого ПО
            return DateTime.Now <= InstallationDate.AddDays(LicenseDays);
        }
    }
}
