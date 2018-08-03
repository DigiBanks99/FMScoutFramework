using FMScoutFramework.Core;
using System;
using System.Threading.Tasks;

namespace FMScoutCmd
{
    public class FmCoreRunner
    {
        private readonly IFmCore _fmCore;
        private bool _loaded;
        public FmCoreRunner(IFmCore fmCore)
        {
            _fmCore = fmCore;
            _loaded = false;
        }

        public IFmCore FmData
        {
            get
            {
                return _fmCore;
            }
        }

        public async Task Run()
        {
            if (_loaded)
                return;

            var task = new Task(_fmCore.LoadData);
            task.Start();
            await task;
            _loaded = true;
        }
    }
}
