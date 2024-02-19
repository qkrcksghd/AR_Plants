using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackedFlower : MonoBehaviour
{
    public GameObject baseFlower;
    public GameObject Gauge;
    public const string creationTimeKey = "PlantCreationTime";


    public void OnTracked()
    {
        if (PlayerPrefs.HasKey(creationTimeKey))
        {
            baseFlower.SetActive(true);
            Gauge.SetActive(true);
        }
    }
    public void OnLost()
    {
        Gauge.SetActive(false);
    }
}
