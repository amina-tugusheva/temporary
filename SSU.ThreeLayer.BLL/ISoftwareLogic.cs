
//Задание 10
//1) Создать абстрактный класс Программное_обеспечение с методами, позволяющими
//вывести на экран информацию о программном обеспечении, а также определить
//соответствие возможности использования(на момент текущей даты).
//2) Создать производные классы: Свободное(название, производитель), Условно-бесплатное
//(название, производитель, дата установки, срок бесплатного использования),
//Коммерческое(название, производитель, цена, дата установки, срок использования) со
//своими методами вывода информации на экран и определения возможности
//использования на текущую дату.
//3) Создать базу(массив) из n видов программного обеспечения, вывести полную
//информацию из базы на экран, а также организовать поиск программного обеспечения,
//которое допустимо использовать на текущую дату.

using System;
using System.Collections;
using SSU.ThreeLayer.Entities;

namespace SSU.ThreeLayer.BLL
{
    public interface ISoftwareLogic
    {
        void AddFreeSoftware(string name, string manufacturer);
        
        void AddTrialSoftware(string name, string manufacturer, DateTime installationDate, int trialDays);
        void AddCommercialSoftware(string name, string manufacturer, decimal price, DateTime installationDate, int licenseDays);
        void DeleteSoftware(string name);
        void DeleteSoftware(int index);
        IEnumerable GetAllSoftwares();
        Software GetSoftware(int index);
    }
}