using SSU.ThreeLayer.BLL;
using SSU.ThreeLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.ThreeLayer.Common
{
    public static class DependencyResolver
    {
        static private IBaseSoftwares baseSoftwares;
        static private ISoftwareLogic softwareLogic;

        static public IBaseSoftwares BaseSoftwares
        {
            get => baseSoftwares ?? (baseSoftwares = new BaseSoftwares());

        }
        static public ISoftwareLogic SoftwareLogic
        {
            get => softwareLogic ?? 
            (softwareLogic = new SoftwareLogic(BaseSoftwares));
        }


     }
}
