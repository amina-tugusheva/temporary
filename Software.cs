using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SSU.ThreeLayer.Entities
{
    [Serializable]
    public abstract class Software : IComparable<Software>
    {
        public int id;
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int CompareTo(Software other)
        {
            return string.Compare(this.Name, other.Name);
        }
        //конструктор 
        public Software(string name, string manufacturer)
        {
            this.Name = name;
            this.Manufacturer = manufacturer;
        }
        public abstract void DisplayInfo();
        public abstract bool CanBeUsedNow();
        //public int id;
        //public string name;
        //public ArrayList buying; //список покупок

        //[Serializable]
        //public struct Buying //информация о каждой покупке
        //{
        //    DateTime data; //дата покупки
        //    double sum; //сумма покупки
        //    public Buying(DateTime data, double sum) //конструктор структуры
        //    {
        //        this.data = data;
        //        this.sum = sum;
        //    }
        //    public override string ToString()
        //    {
        //        return String.Format("{0} {1}\n", data.ToShortDateString(), sum);
        //    }
        //}
        //public Client(string name) //конструктор класса
        //{
        //    this.name = name;
        //    buying = new ArrayList();
        //}
        //public void AddBuying(DateTime data, double sum) //добавление данных о покупке
        //{
        //    Buying item = new Buying(data, sum);
        //    buying.Add(item);
        //}

        //public override string ToString()
        //{
        //    string str = $"Имя: {name}" + Environment.NewLine;
        //    str += "Сведенья о покупках: " + Environment.NewLine;
        //    foreach (Buying item in buying)
        //    {
        //        str += item;
        //    }
        //    return str + Environment.NewLine;
        //}
    }
}
