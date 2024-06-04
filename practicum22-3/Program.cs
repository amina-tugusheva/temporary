using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicum22_3
{
    struct SPoint //описание структуры
    {
        public int x, y; //поля структуры
        public SPoint(int x, int y) //конструктор структуры
        {
            this.x = x;
            this.y = y;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, int> cityindex = new Dictionary<string, int>();
            Graph g = new Graph(@"C:\Users\PC\Desktop\C#\practicum22-3\input.txt", ref cityindex);

            
            Console.WriteLine("Graph:");
            g.Show();
            foreach (KeyValuePair<string, int> pair in cityindex)
            {
                Console.WriteLine("Ключ: " + pair.Key + ", Значение: " + pair.Value);
            }
            Console.WriteLine(cityindex);

            int sizeGraph = g.graphSize();
            Console.Write("Город A: ");
            //int a = int.Parse(Console.ReadLine());
            int a = cityindex[Console.ReadLine()];
            Console.Write("Город B: ");
            //int b = int.Parse(Console.ReadLine());
            int b = cityindex[Console.ReadLine()];
            Console.Write("Город C: ");
            //int c = int.Parse(Console.ReadLine());
            int c = cityindex[Console.ReadLine()];
            Console.Write("Город D: ");
            //int d = int.Parse(Console.ReadLine());
            int d = cityindex[Console.ReadLine()];
            g.Dijkstr(a, b,c , d, ref cityindex);
            
        }
    }
}
