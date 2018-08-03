using FMScoutFramework.Core.Entities;
using FMScoutFramework.Core.Entities.InGame;
using FMScoutFramework.Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FMScoutFramework.Core
{
    public class FmCore : IDisposable, IFmCore
    {
        private IGameManager _gameManager = null;
        private ObjectManager _objectManager = null;
        private readonly bool _use64Bit = false;

        public DatabaseModeEnum DatabaseMode { get; private set; }

        public event Action GameLoaded = () => { };

        public FmCore(DatabaseModeEnum databaseMode, bool use64Bit)
        {
            DatabaseMode = databaseMode;
            _use64Bit = use64Bit;
        }

        public FmCore()
        {
            DatabaseMode = DatabaseModeEnum.Realtime;
        }

        #region Objects
        public IEnumerable<Continent> Continents { get { return GetListFromStore<Continent>(); } }
        public IEnumerable<City> Cities { get { return GetListFromStore<City>(); } }
        public IEnumerable<Club> Clubs { get { return GetListFromStore<Club>(); } }
        public IEnumerable<Nation> Nations { get { return GetListFromStore<Nation>(); } }
        public IEnumerable<Player> Players { get { return GetListFromStore<Player>(); } }
        public IEnumerable<Staff> Staff { get { return GetListFromStore<Staff>(); } }
        public IEnumerable<PlayerStaff> PlayerStaff { get { return GetListFromStore<PlayerStaff>(); } }

        private IQueryable<T> GetListFromStore<T>()
        {
            return ((Dictionary<int, T>)_objectManager.ObjectStore[typeof(T)]).Values.AsQueryable();
        }
        #endregion

        public void LoadData()
        {
            LoadData(false);
        }

        public void LoadData(bool refreshPersonCache)
        {
            CheckProcessAndGame();
            LoadDataForCheckedGame(refreshPersonCache);
        }

        public bool CheckProcessAndGame()
        {
            if (_gameManager == null)
            {
                /*if (_use64Bit)
                    _gameManager = new GameManager64();
                else*/
                    _gameManager = new GameManager();
                _gameManager.FMLoading = true;
                _gameManager.findFMProcess();
                _gameManager.FMLoading = false;
            }

            return _gameManager.FMLoaded;
        }

        public void LoadDataForCheckedGame(bool refreshPersonCache)
        {
            if (_objectManager == null)
                _objectManager = new ObjectManager(_gameManager, DatabaseMode);

            _objectManager.Load(refreshPersonCache);
            GameLoaded();
        }

        public MetaDataCls MetaData { get { return new MetaDataCls(this, this._objectManager, _gameManager); } }

        #region IDisposable Members
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
        #endregion
    }
}

