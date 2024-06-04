//Свободное(название, производитель)
//своими методами вывода информации на экран и определения возможности
//использования на текущую дату. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr18
{
    [Serializable]
    class FreeSoftware : Software
    {
        //конструктор
        public FreeSoftware(string name, string manufacturer) : base(name, manufacturer)
        {
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Free Software: {Name} ({Manufacturer})");
        }

        public override bool CanBeUsedNow()
        {

            //SecurityAnalyzer analyzer = new SecurityAnalyzer();
            //bool isSafe = analyzer.AnalyzeCode(this.Code); // Предположим, что у класса Software есть свойство Code, содержащее исходный код

            //return isSafe;
            return true;
        }
    }
}
