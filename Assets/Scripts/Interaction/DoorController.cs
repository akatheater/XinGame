using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;

public class DoorController : MonoBehaviour
{
    [Header("Time for the door to automatically close (seconds)(default: 5)")]
    public float closeTime;
    [Header("Closing speed(default: 400)")]
    public float speed;
    [Header("Wind zone's Gameobject")]
    public GameObject windZone;
    [HideInInspector]
    public bool doorClosed;
    [HideInInspector]
    public bool doorOpening;
    [HideInInspector]
    public bool doorClosing;
    [HideInInspector]
    public bool canBeClicked;
    
    void Start()
    {

        doorClosed = true;
        doorOpening = false;
        doorClosing = false;

        canBeClicked = true;
    }

    void Update()
    {
        if (!doorClosed)
        {
            windZone.SetActive(true);
            if (doorOpening)
            {
                OpenDoor();
            }
            if(doorClosing)
            {
                CloseDoor();
            }
        }  
        else
        {
            windZone.SetActive(false);
        }
    }



    private void OnMouseDown()
    {
        if (canBeClicked)
        {
            canBeClicked = false;
            doorClosed = false;
            doorOpening = true;

            TimersManager.SetTimer(this, closeTime, SetDoorClosing);
        }       
    }

    void SetDoorClosing()
    {
        doorClosing = true;
    }

    void OpenDoor()
    {

        if (transform.eulerAngles.y >= 260 || transform.eulerAngles.y <=30 )
        {
            transform.RotateAround(transform.position, transform.up, speed * Time.deltaTime);
        }
        else
        {
            doorOpening = false;
        }
    }

    void CloseDoor()
    {
        if (transform.eulerAngles.y >= 270 || transform.eulerAngles.y <= 40)
        {
            transform.RotateAround(transform.position, -transform.up, speed * Time.deltaTime);
        }           
        else
        {
            transform.eulerAngles.Set(0, 270, 0);
            doorClosing = false;
            doorClosed = true;
            canBeClicked = true;
        }
    }
}
