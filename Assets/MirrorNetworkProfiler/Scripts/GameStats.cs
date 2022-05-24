using Unity.Profiling;

class GameStats
{
    public static readonly ProfilerCategory MirrorNetworkProfiler = ProfilerCategory.Scripts;

    public static readonly ProfilerCounter<int> PlayerCount =
        new ProfilerCounter<int>(MirrorNetworkProfiler, "Player Count", ProfilerMarkerDataUnit.Count);

    public static ProfilerCounterValue<int> CommandCount =
        new ProfilerCounterValue<int>(MirrorNetworkProfiler, "Command Count",
            ProfilerMarkerDataUnit.Count, ProfilerCounterOptions.FlushOnEndOfFrame);

    public static ProfilerCounterValue<int> ClientRpcCount =
        new ProfilerCounterValue<int>(MirrorNetworkProfiler, "ClientRpc Count",
            ProfilerMarkerDataUnit.Count, ProfilerCounterOptions.FlushOnEndOfFrame);

    public static ProfilerCounterValue<int> TargetRpcCount =
        new ProfilerCounterValue<int>(MirrorNetworkProfiler, "TargetRpc Count",
            ProfilerMarkerDataUnit.Count, ProfilerCounterOptions.FlushOnEndOfFrame);
}
