using System;
using System.Collections.Generic;
using System.Text;

namespace SSU.ThreeLayer.Entities
{
    [Serializable]
    class TrialSoftware : Software
    {
        public DateTime InstallationDate { get; set; }
        public int TrialDays { get; set; }
        //конструктор
        public TrialSoftware(string name, string manufacturer, DateTime installationDate, int trialDays) : base(name, manufacturer)
        {
            this.InstallationDate = installationDate;
            this.TrialDays = trialDays;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Trial Software: {Name} ({Manufacturer}), Trial Ends: {InstallationDate.AddDays(TrialDays)}");
        }

        public override bool CanBeUsedNow()
        {
            // Логика проверки возможности использования пробной версии ПО
            return DateTime.Now <= InstallationDate.AddDays(TrialDays);
        }
    }
}
