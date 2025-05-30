using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class SpeedManage : MonoBehaviour
{
    private bool Speeding;
    private bool Stopping;
    public void Start()
    {
        Speeding = false;
        Stopping = false;
    }
    public void StopGaming()
    {
        switch(Stopping)
        {
            case false:
                Time.timeScale = 0;
                Stopping = true;
                break;
            case true:
                Time.timeScale = 1;
                Stopping = false;
                break;
        }

    }
    public void SpeedGaming()
    {
        switch (Speeding)
        {
            case false:
                Time.timeScale = 2;
                Speeding = true;
                break;
            case true:
                Time.timeScale = 1;
                Speeding = false;
                break;
        }
    }
}
