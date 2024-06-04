using System;
using System.Collections.Generic;
using System.Text;

namespace SSU.ThreeLayer.Entities
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
