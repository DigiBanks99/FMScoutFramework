using FMScoutFramework.Core;
using FMScoutFramework.Core.Entities;
using System;
using System.Linq;

namespace FMScoutCmd
{
    public class Program
    {
        protected Program() { }

        public static void Main(string[] args)
        {
            var fmCoreRunner = new FmCoreRunner(new FmCore(DatabaseModeEnum.Realtime, true));
            fmCoreRunner.Run().Wait();
            var cities = fmCoreRunner.FmData.Cities;
            if (cities.Any())
            {
                foreach (var city in cities)
                    Console.WriteLine(city);
            }
        }
    }
}
