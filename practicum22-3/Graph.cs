//III.Тематические задачи.
//Во входном файле задается: в первой сторке N – количество городов; начиная со
//второй строки через пробел названия N-городов и их координаты в декартовой системе; с
//новой строки матрица смежности графа, описывающая схему дорог(вес ребра
//рассчитывается по координат городов).
//Пример входного файла:
//5
//Березовка 170 120
//Еремеевка 120 150
//Октябрьское 100 50
//Рузаевка 50 100
//Сосновка 200 130
//0 1 0 0 1
//1 0 1 1 1
//0 1 0 1 1
//0 1 1 0 0
//1 1 1 0 0
//Остальные данные, необходимые для решения задачи, вводятся с клавиатуры.
//5. Найти кратчайший путь, соединяющие города А и В, проходящий через город С, но не
//проходящий через город D.

//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace practicum22_3
{
    class Graph
    {
        private class Node  //вложенный класс для скрытия данных и алгоритмов
        {
            private int[,] array;   //матрица смежности
            public int this[int i, int j]   //индексатор для обращения к матрице смежности
            {
                get
                {
                    return array[i, j];
                }
                set
                {
                    array[i, j] = value;
                }
            }

            public int Size //свойство для получения размерности матрицы смежности
            {
                get
                {
                    return array.GetLength(0);
                }
            }

            private bool[] nov; //вспомогательный массив: если i-ый элемент массива равен 
                                //true, то i-ая вершина еще не просмотрена; если i-ый 
                                //элемент  равен false, то i-ая вершина  просмотрена

            public void NovSet()    //метод помечает все вершины графа как непросмотреные
            {
                for (int i = 0; i < Size; i++)
                {
                    nov[i] = true;
                }
            }
            
            public bool NovGet(int i)    //метод помечает все вершины графа как непросмотреные
            {
                return nov[i];
            }
            //конструктор вложенного класса, инициализирует матрицу смежности и
            // вспомогательный массив
            public Node(int[,] a)
            {
                array = a;
                nov = new bool[a.GetLength(0)];
            }
            //реализация алгоритма Дейкстры 
            public long[] Dijkstr(int v, out int[] p, int cityC, int cityD)
            {
                nov[v] = false;     // помечаем вершину v как просмотренную
                                    //создаем матрицу с
                int[,] c = new int[Size, Size];
                for (int i = 0; i < Size; i++)
                {
                    for (int u = 0; u < Size; u++)
                    {
                        if ((array[i, u] == 0 || i == u))
                        {
                            c[i, u] = int.MaxValue;
                        }
                        else
                        {
                            c[i, u] = array[i, u];
                        }
                    }
                }
                //создаем матрицы d и p
                long[] d = new long[Size];
                p = new int[Size];
                for (int u = 0; u < Size; u++)
                {
                    if (u != v)
                    {
                        d[u] = c[v, u];
                        p[u] = v;
                    }
                }
                for (int i = 0; i < Size - 1; i++)  // на каждом шаге цикла
                {
                    // выбираем из множества V\S такую вершину w, что D[w] минимально
                    long min = int.MaxValue;
                    int w = 0;
                    for (int u = 0; u < Size; u++)
                    {
                        if (nov[u] && min > d[u])
                        {
                            min = d[u];
                            w = u;
                        }
                    }
                    nov[w] = false; //помещаем w в множество S
                                    //для каждой вершины из множества V\S определяем кратчайший путь от
                                    // источника до этой вершины
                    for (int u = 0; u < Size; u++)
                    {
                        long distance = d[w] + c[w, u];
                        if (nov[u] && d[u] > distance && w != cityD)
                        {
                            if ((w == cityC && u != v) || (w != v && u == cityC)) // Добавляем условие, что путь обязательно должен проходить через cityC
                            {
                                d[u] = distance;
                                p[u] = w;
                            }
                            //else 
                            //{
                            //    long reverseDistance = distance + c[u, cityC]; // Добавляем расстояние от текущей вершины до cityC
                            //    if (d[cityC] > reverseDistance) // Проверяем, является ли новый путь короче
                            //    {
                            //        d[cityC] = reverseDistance;
                            //        p[cityC] = u;
                            //    }
                            //}
                        }
                    }
        
                }
                return d;   //в качестве результата возвращаем массив кратчайших путей для аданного  источника
            }

            //восстановление пути от вершины a до вершины b для алгоритма Дейкстры
            public void WayDijkstr(int a, int b, int[] p, ref Stack<int> items)
            {
                items.Push(b);   //помещаем вершину b в стек
                if (a == p[b])  //если предыдущей для вершины b является вершина а, то
                {
                    items.Push(a);  //помещаем а в стек и завершаем восстановление пути
                }
                else        //иначе метод рекурсивно вызывает сам себя для поиска пути
                {               //от вершины а до вершины, предшествующей вершине b
                    WayDijkstr(a, p[b], p, ref items);
                }
            }

        }   //конец вложенного клаcса

        private Node graph; //закрытое поле, реализующее АТД «граф»

        public Graph(string name, ref Dictionary<string, int> cityToVertex)   //конструктор внешнего  класса
        {
            using (StreamReader file = new StreamReader(name))
            {
                int count = int.Parse(file.ReadLine());
                string line;
                string[] mas;
                //string[] city = file.ReadLine().Split(' ');
                string city;
                SPoint p = new SPoint();
                List<SPoint> number = new List<SPoint>();
                ///*Dictionary<string, int> */cityToVertex = new Dictionary<string, int>();
                for (int i = 0; i < count; i++)
                {
                    line = file.ReadLine();
                    mas = line.Split(' ');
                    //string cityes = city[0];
                    city = mas[0];
                    p.x = int.Parse(mas[1]);
                    p.y = int.Parse(mas[2]);
                    number.Add(p);

                    //cityToVertex.Add(city, i);
                    cityToVertex[city] = i;
                    mas = null;
                }
                int[,] a = new int[count, count];
                for (int i = 0; i < count; i++)
                {
                    line = file.ReadLine();
                    mas = line.Split(' ');
                    for (int j = 0; j < count && i != j; j++)
                    {
                        int elMas = int.Parse(mas[j]);
                        a[i, j] = (int)(elMas * (Math.Sqrt(Math.Pow(number[i].x - number[j].x, 2) +
                            Math.Pow(number[i].y - number[j].y, 2))));
                        a[j, i] = a[i, j];
                    }
                }
                graph = new Node(a);
                
                
            }
            //foreach (KeyValuePair<string, int> pair in cityToVertex)
            //{
            //    Console.WriteLine("Ключ: " + pair.Key + ", Значение: " + pair.Value);
            //}
            //Console.WriteLine(cityToVertex);
        }
        //метод выводит матрицу смежности на консольное окно
        public void Show()
        {
            for (int i = 0; i < graph.Size; i++)
            {
                for (int j = 0; j < graph.Size; j++)
                {
                    Console.Write("{0,4}", graph[i, j]);
                }
                Console.WriteLine();
            }
        }


        public void Dijkstr(int v, int b, int C, int D, ref Dictionary<string, int> cityToVertex)
{
    //помечаем все вершины графа как непросмотренные
    graph.NovSet();
    int[] p;
    long[] d = graph.Dijkstr(v, out p, C, D); //запускаем алгоритм Дейкстры

    //анализируем полученные данные и выводим их на экран
    for (int i = 0; i < graph.Size; i++)
    {
        if (i != v && i == b)
        {
            if (d[i] != int.MaxValue)
            {
                Stack<int> items = new Stack<int>();
                graph.WayDijkstr(v, i, p, ref items);
                List<string> itemsTowns = new List<string>();
                while (items.Count != 0)
                {
                    int vertex = items.Pop();
                    string cityName = cityToVertex.FirstOrDefault(x => x.Value == vertex).Key;
                    itemsTowns.Add(cityName);
                }

                Console.Write("Длина кратчайшего пути из " + cityToVertex.FirstOrDefault(x => x.Value == v).Key + " в " + cityToVertex.FirstOrDefault(x => x.Value == b).Key + ": " + d[i] + " ");
                foreach (var t in itemsTowns)
                {
                    Console.Write(t + " ");
                }
            }
            else
                    {
                        Console.Write("пути нет");
                    }
            Console.WriteLine();
        }
    }
}
        public int graphSize()
        {
            return graph.Size;
        }
    }
}
