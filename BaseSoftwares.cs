using SSU.ThreeLayer.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SSU.ThreeLayer.DAL
{
    public class BaseSoftwares : IBaseSoftwares
    {
        int index; //номер клиента, генерируется автоматически
        Dictionary<int, Software> softwares; //список клиентов

        public BaseSoftwares() //конструктор класса
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream f = new FileStream("data.dat", FileMode.OpenOrCreate);
            if (f.Length == 0) //файл пуст, создаю новую базу
            {
                softwares = new Dictionary<int, Software>();
                index = 0;
            }
            else // иначе выполняю дисериализацию
            {
                softwares = (Dictionary<int, Software>)formatter.Deserialize(f);
                ICollection key = softwares.Keys; // ищу последний ключ
                foreach (int item in key)
                {
                    index = item;
                }
            }
            f.Close();

        }
        ~BaseSoftwares()
        {
            SaveBaseSoftwares();
        }
        public void AddSoftware(Software software) //добавление нового клиента в хеш-таблицу:
        { //ключ – index, значение – экземпляр класса Client
            index++;
            software.id = index;
            software.Add(index, software);
        }
        ////добавление информации о покупке по номеру клиента
        //public void AddBuying(int index, DateTime data, double sum)
        //{
        //    Client item = clients[index];
        //    item.AddBuying(data, sum);
        //}
        ////добавление информации о покупке по фамилии клиента
        //public void AddBuying(string name, DateTime data, double sum)
        //{
        //    ICollection key = clients.Keys; //прочитали все ключи
        //    foreach (int index in key)
        //    {
        //        //использовуем ключ для получения значения хеш-таблицы
        //        Client item = clients[index];
        //        //если фамилия соответсвует фамиили клиента, то мы нашли нужного клиента
        //        if (string.Compare(name, item.name) == 0)
        //        {
        //            AddBuying(index, data, sum); //и добавляет новую покупку по текущему ключу
        //            break;
        //        }
        //    }
        //}
        //удаляем клиента по номеру
        public void DeleteSoftware(int index)
        {
            softwares.Remove(index);
        }
        //удаляем клиента по фамилии
        public void DeleteSoftware(string name)
        {
            ICollection key = softwares.Keys;
            foreach (int index in key)
            {
                Software item = softwares[index];
                if (string.Compare(name, item.name) == 0)
                {
                    DeleteSoftware(index);
                    break;
                }
            }
        }

        public Software GetSoftware(int index)
        {
            return softwares[index];
        }

        public IEnumerable GetAllSoftwares()
        {
            return softwares.Values;
        }

        void SaveBaseSoftwares()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream f = new FileStream("data.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(f, softwares);
            }
        }
                
    }
}
