using System;
using System.Diagnostics;

namespace FMScoutFramework.Core
{
    /// <summary>
    /// Holder for the Football Manager process
    /// </summary>
    public class FMProcess
    {
        public Process Process { get; set; }
        public IntPtr Pointer { get; set; }
        public int EndPoint { get; set; }
        public IntPtr BaseAddress { get; set; }
        public string VersionDescription { get; set; }
        public int HeapAddress { get; set; }
    }
}
