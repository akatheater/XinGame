using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;

public class PlantController : MonoBehaviour
{
    [Header("Time for the chair to automatically return(seconds)(default: 3)")]
    public float closeTime;
    [Header("Move speed(default: 5)")]
    public float speed;
    [Header("Initial position(default z : 1.43)")]
    public Vector3 initial;
    [Header("Target position(default z : 0.14)")]
    public Vector3 target;
    [Header("Force exerted by the plant on the ball(default : 10)")]
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
        initial = new Vector3(transform.localPosition.x, transform.localPosition.y, 1.43f);
        target = new Vector3(transform.localPosition.x, transform.localPosition.y, 0.14f);

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
        if (transform.localPosition.z >= target.z)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        else
        {

            drawerOpening = false;
        }
    }

    void CloseDrawer()
    {
        if (transform.localPosition.z <= initial.z)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = initial;
            drawerClosing = false;
            drawerClosed = true;
            canBeClicked = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "green" || collision.transform.tag == "purple" || collision.transform.tag == "player")
        {
            collision.transform.GetComponent<Rigidbody>().AddForce(0, 0, force);
        }
    }
}
