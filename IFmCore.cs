using System;
using System.Collections.Generic;
using FMScoutFramework.Core.Entities;
using FMScoutFramework.Core.Entities.InGame;

namespace FMScoutFramework.Core
{
    public interface IFmCore
    {
        IEnumerable<City> Cities { get; }
        IEnumerable<Club> Clubs { get; }
        IEnumerable<Continent> Continents { get; }
        DatabaseModeEnum DatabaseMode { get; }
        MetaDataCls MetaData { get; }
        IEnumerable<Nation> Nations { get; }
        IEnumerable<Player> Players { get; }
        IEnumerable<PlayerStaff> PlayerStaff { get; }
        IEnumerable<Staff> Staff { get; }

        event Action GameLoaded;

        bool CheckProcessAndGame();
        void Dispose();
        void LoadData();
        void LoadData(bool refreshPersonCache);
        void LoadDataForCheckedGame(bool refreshPersonCache);
    }
}
