using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;

public class BedDrawerController : MonoBehaviour
{
    [Header("Time for the door to automatically close (seconds)(default: 5)")]
    public float closeTime;
    [Header("Speed of drawer closing(default: 8)")]
    public float speed;
    [Header("Initial position(default x : 5.1)")]
    public Vector3 initial;
    [Header("Target position(default x : 3.19)")]
    public Vector3 target;
    [Header("Force exerted by the drawer on the ball(default : 8)")]
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
        initial = new Vector3(5.1f, transform.localPosition.y, transform.localPosition.z);
        target = new Vector3(3.19f, transform.localPosition.y, transform.localPosition.z);

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
        if (transform.localPosition.x >= target.x)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else
        {

            drawerOpening = false;
        }
    }

    void CloseDrawer()
    {
        if (transform.localPosition.x <= initial.x)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
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
        Debug.Log("enter!!!");
        if (collision.transform.tag == "green" || collision.transform.tag == "purple" || collision.transform.tag == "player")
        {
            collision.transform.GetComponent<Rigidbody>().AddForce(force, 0, 0);
        }
    }
}
