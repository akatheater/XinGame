using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCabinetController : MonoBehaviour
{
    [Header("Rotate speed(default: 400)")]
    public float speed;
    [HideInInspector]
    public bool cabinetRotating;
    [HideInInspector]
    public bool canBeClicked;

    int[] stopRotation= {180,270,0,90 };
    int currentY;

    void Start()
    {
        cabinetRotating = false;

        canBeClicked = true;
        currentY = 0;
    }

    void Update()
    {
        if (cabinetRotating)
        {
            CabinetRotate();
        }      
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    private void OnMouseDown()
    {
        if (canBeClicked)
        {
            currentY++;
            if (currentY > 3)
            {
                currentY = 0;
            }
            canBeClicked = false;
            cabinetRotating = true;

            //Debug.Log("currentY: " + currentY);
        }
    }


    void CabinetRotate()
    {
        
        transform.RotateAround(transform.position, transform.up, speed * Time.deltaTime);
        if(currentY!=2)
        {
            if(transform.eulerAngles.y>=stopRotation[currentY])
            {
                cabinetRotating = false;
                canBeClicked = true;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, stopRotation[currentY], transform.eulerAngles.z);                
            }
        }
        else
        {
            //Debug.Log("transform.y = " + transform.eulerAngles.y);
            if (transform.eulerAngles.y <=50)
            {
                cabinetRotating = false;
                canBeClicked = true;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, stopRotation[currentY], transform.eulerAngles.z);
            }

        }
       
    }

}
