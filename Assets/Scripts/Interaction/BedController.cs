using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;

public class BedController : MonoBehaviour
{
    [Header("Rebound zone Gameobject")]
    public GameObject reboundZone;
    [Header("Time for the rebound bounce zone to disappear (seconds)(default: 5)")]
    public float closeTime;

    void Start()
    {
        //closeTime = 5;
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        reboundZone.SetActive(true);
        TimersManager.SetTimer(this, closeTime, RemoveRebound);
    }

    void RemoveRebound()
    {
        reboundZone.SetActive(false);
    }
}
