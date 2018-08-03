using System;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Entities;

namespace FMScoutFramework.Core
{
    public class MetaDataCls
    {
        private readonly Global glob;
        private readonly IGameManager gameManager;

        internal MetaDataCls(FmCore fmCore, ObjectManager objectManager, IGameManager gameManager)
        {
            this.gameManager = gameManager;
            glob = new Global(gameManager.Version);
        }

        public string CurrentVersion
        {
            get { return gameManager.Version.Description; }
        }

        public DateTime InGameDate
        {
            get { return glob.InGameDate; }
        }
    }
}

