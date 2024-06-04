//1) Полную структуру классов и их взаимосвязь продумать самостоятельно.
//2) Для абстрактного класса определить, какие методы должны быть абстрактными, а какие
//обычными.
//3) Исходные данные считываются из файла.

//Создать абстрактный класс Программное_обеспечение с методами, позволяющими
//вывести на экран информацию о программном обеспечении, а также определить
//соответствие возможности использования(на момент текущей даты). 

//Задание 10. В абстрактном классе Программное_обеспечение реализовать метод
//CompareTo так, чтобы можно было отсортировать базу данных по названию ПО.
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
    abstract class Software : IComparable<Software>
    {
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
        
    }
}
