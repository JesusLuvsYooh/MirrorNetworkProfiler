using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Unity.Profiling;

public class PlayerScript : NetworkBehaviour
{
    private int counter;

    public override void OnStartClient()
    {
        InvokeRepeating(nameof(ReapterFunction), 1.0f, 1.0f);
    }

    public void ReapterFunction()
    {
        Cmd();
    }

    public void Update()
    {
        if (isServer)
        {
            NetworkStats.PlayerCount.Sample(NetworkManager.singleton.numPlayers);
        }

        if (isLocalPlayer)
        {
            if (Input.GetMouseButton(0))
            {
                Cmd();
            }
        }
    }

    [Command]
    public void Cmd()
    {
        counter += 1;
        print("Cmd");
        Rpc();
        NetworkStats.CommandCount.Value += 1;
        
    }

    [ClientRpc]
    public void Rpc()
    {
        print("Rpc");
        NetworkStats.ClientRpcCount.Value += 1;
    }

}
