using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Managers
{
    public class GameManager64 : IGameManager
    {
        public bool FMLoaded { get; private set; }

        public bool FMLoading { get; set; }

        public IVersion Version
        {
            get;
            private set;
        }

        public bool findFMProcess()
        {
            FMProcess fmProcess = new FMProcess();
            Process[] fmProcesses = Process.GetProcessesByName(FMScoutFrameworkConfigurationManager.Instance.ProcessName);

            if (fmProcesses.Length > 0)
            {
                Process activeProcess = fmProcesses[0];

                fmProcess.Pointer = ProcessMemoryAPI.OpenProcess(0x001F0FFF, 1, (uint)activeProcess.Id);
                fmProcess.EndPoint = ProcessManager.GetProcessEndPoint(fmProcess.Pointer);
                fmProcess.Process = activeProcess;
                fmProcess.BaseAddress = activeProcess.MainModule.BaseAddress;
            }

            return FMLoaded;
        }
    }
}
