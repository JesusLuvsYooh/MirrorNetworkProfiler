using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class StartupAutomater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NetworkManager.singleton.StartHost();
    }
}
