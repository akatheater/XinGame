using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;

public class PinkCabinetController : MonoBehaviour
{
    [Header("Time for the cabinet to automatically return(seconds)(default: 5)")]
    public float closeTime;
    [Header("Move speed(default: 6)")]
    public float speed;
    [Header("Initial position(default x : -6.37)")]
    public Vector3 initial;
    [Header("Target position(default x : -5.0)")]
    public Vector3 target;
    [Header("Force exerted by the cabinet on the ball(default : 10)")]
    public float force;
    [HideInInspector]
    public bool drawerClosed;
    [HideInInspector]
    public bool drawerOpening;
    [HideInInspector]
    public bool drawerClosing;
    [HideInInspector]
    public bool canBeClicked;

    void Start()
    {
        initial = new Vector3(-6.37f, transform.localPosition.y, transform.localPosition.z);
        target = new Vector3(-5.0f, transform.localPosition.y, transform.localPosition.z);

        drawerClosed = true;
        drawerOpening = false;
        drawerClosing = false;

        canBeClicked = true;
    }

    void Update()
    {
        if (!drawerClosed)
        {
            if (drawerOpening)
            {
                OpenDrawer();
            }
            if (drawerClosing)
            {
                CloseDrawer();
            }
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
            canBeClicked = false;
            drawerClosed = false;
            drawerOpening = true;

            TimersManager.SetTimer(this, closeTime, SetDrawerClosing);
        }
    }

    void SetDrawerClosing()
    {
        drawerClosing = true;
    }

    void OpenDrawer()
    {
        if (transform.localPosition.x <= target.x)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {

            drawerOpening = false;
        }
    }

    void CloseDrawer()
    {
        if (transform.localPosition.x >= initial.x)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = initial;
            drawerClosing = false;
            drawerClosed = true;
            canBeClicked = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "green" || collision.transform.tag == "purple" || collision.transform.tag == "player")
        {
            collision.transform.GetComponent<Rigidbody>().AddForce(0, 0, force);
        }
    }
}
