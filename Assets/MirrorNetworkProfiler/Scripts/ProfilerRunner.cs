using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfilerRunner : MonoBehaviour
{
    private float time = 0.0f;
    public float interpolationPeriod = 0.1f;

    void Update()
    {
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = time - interpolationPeriod;

            ResetCounters();
        }
    }

    void ResetCounters()
    {
        Debug.Log("ResetCounters");
        NetworkStats.Reset();
    }
}
