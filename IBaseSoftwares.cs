using System;
using System.Collections;
using SSU.ThreeLayer.Entities;

namespace SSU.ThreeLayer.DAL
{
    public interface IBaseSoftwares
    {
        //
        void AddFree(string name, string manufacturer);
        void AddTrial(int index, string manufacturer, DateTime installDate, int trialPeriodDays);
        void AddCommercial(string name, string manufacturer, decimal price, DateTime installDate, int validityDays);
        void AddSoftware(BaseSoftwares software);
        void DeleteSoftware(string name);
        void DeleteSoftware(int index);
        IEnumerable GetAllSoftwares();
        Software GetSoftware(int index);
        //
    }
}