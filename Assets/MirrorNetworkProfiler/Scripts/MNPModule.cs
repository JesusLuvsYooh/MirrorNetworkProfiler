using Unity.Profiling.Editor;

[System.Serializable]
[ProfilerModuleMetadata("Command Counter per second.")]
public class MNPModule : ProfilerModule
{
    static readonly ProfilerCounterDescriptor[] k_Counters = new ProfilerCounterDescriptor[]
    {
        new ProfilerCounterDescriptor(NetworkStats.CommandCount.ToString(), NetworkStats.MirrorNetworkProfiler),
        new ProfilerCounterDescriptor(NetworkStats.ClientRpcCount.ToString(), NetworkStats.MirrorNetworkProfiler),
        new ProfilerCounterDescriptor(NetworkStats.TargetRpcCount.ToString(), NetworkStats.MirrorNetworkProfiler),
    };

    public MNPModule() : base(k_Counters) { }

    public override ProfilerModuleViewController CreateDetailsViewController()
    {
        return new MNPViewController(ProfilerWindow);
    }
}