using Unity.Profiling;
using System;
using UnityEngine;
using System.Collections.Generic;

class NetworkStats
{
    public static readonly ProfilerCategory MirrorNetworkProfiler = ProfilerCategory.Network;

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

    public static void Reset()
    {
        Debug.Log("NetworkStats Reset");
        CommandCount.Value = 0;
        ClientRpcCount.Value = 0;
        TargetRpcCount.Value = 0;
    }
}
