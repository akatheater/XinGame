using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeskController : MonoBehaviour
{

    [Header("Table up/down speed(default: 4)")]
    public float speed;
    [Header("Initial position(default y : 7.23)")]
    public Vector3 topPosition;
    [Header("Target position(default y : -9.31")]
    public Vector3 bottomPosition;
    [Header("Rebound zone's GameObject")]
    public GameObject reboundZone;
    [HideInInspector]
    public bool deskTop;
    [HideInInspector]
    public bool deskBottom;
    [HideInInspector]
    public bool deskDown;
    [HideInInspector]
    public bool deskUp;
    [HideInInspector]
    public bool canBeClicked;

    void Start()
    {
        //If you want to change the initial/target position, change these.
        //¡ý¡ý¡ý¡ý¡ý¡ý¡ý
        topPosition = new Vector3(transform.localPosition.x, -7.23f, transform.localPosition.z);
        bottomPosition = new Vector3(transform.localPosition.x, -9.31f, transform.localPosition.z);
        //¡ü¡ü¡ü¡ü¡ü¡ü¡ü

        deskTop = true;
        deskBottom = false;
        deskDown = false;
        deskUp = false;

        canBeClicked = true;
    }

    void Update()
    {
        if(deskDown)
        {
            DeskDown();
        }
        if(deskUp)
        {
            DeskUp();
        }
        if(deskBottom)
        {
            reboundZone.SetActive(true);
        }
        if(!deskBottom)
        {
            reboundZone.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (canBeClicked)
        {
            if(deskTop)
            {
                canBeClicked = false;
                deskTop = false;
                deskDown = true;
            }
            if(deskBottom)
            {
                canBeClicked = false;
                deskBottom = false;
                deskUp = true;
            }

        }
    }

    void DeskDown()
    {
        if (transform.localPosition.y >= bottomPosition.y)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = bottomPosition;
            deskDown = false;
            deskBottom = true;
            canBeClicked = true;
        }
    }

    void DeskUp()
    {
        if (transform.localPosition.y <= topPosition.y)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = topPosition;
            deskUp = false;
            deskTop = true;
            canBeClicked = true;
        }
    }
}
