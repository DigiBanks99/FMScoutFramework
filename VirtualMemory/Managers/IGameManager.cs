using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Managers
{
    public interface IGameManager
    {
        bool FMLoaded { get; }
        bool FMLoading { get; set; }
        IVersion Version { get; }

        bool findFMProcess();
    }
}