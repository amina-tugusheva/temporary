using SSU.ThreeLayer.DAL;
using SSU.ThreeLayer.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SSU.ThreeLayer.BLL
{
    public class SoftwareLogic : ISoftwareLogic
    {
        private IBaseSoftwares baseSoftwares;

        public SoftwareLogic(IBaseSoftwares baseSoftwares)
        {
            this.baseSoftwares = baseSoftwares;
        }

        public void AddFreeSoftware(string name, string manufacturer)
        {
            baseSoftwares.AddSoftware(new FreeSoftware(name, manufacturer));

        }
        public void AddTrialSoftware(string name, string manufacturer, DateTime installationDate, int trialDays)
        {
            baseSoftwares.AddSoftware(new TrialSoftware(name, manufacturer, installationDate, trialDays));

        }
        public void AddCommercialSoftware(string name, string manufacturer, decimal price, DateTime installationDate, int licenseDays)
        {
            baseSoftwares.AddSoftware(new CommercialSoftware(name, manufacturer, price, installationDate, licenseDays));

        }
        ////добавление информации о покупке по номеру клиента
        //public void AddBuying(int index, DateTime data, double sum)
        //{
        //    baseClients.AddBuying(index, data, sum);
        //}
        ////добавление информации о покупке по фамилии клиента
        //public void AddBuying(string name, DateTime data, double sum)
        //{
        //    baseClients.AddBuying(name, data, sum);
        //}
        //удаляем клиента по номеру
        public void DeleteSoftware(int index)
        {
            baseSoftwares.DeleteSoftware(index);
        }
        //удаляем клиента по фамилии
        public void DeleteSoftware(string name)
        {
            baseSoftwares.DeleteSoftware(name);
        }

        public Software GetSoftware(int index)
        {
            return baseSoftwares.GetSoftware(index);
        }

        public IEnumerable GetAllSoftwares()
        {
            return baseSoftwares.GetAllSoftwares();
        }
    }
}
