using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;

public class ChairController : MonoBehaviour
{
    [Header("Time for the chair to automatically return(seconds)(default: 3)")]
    public float closeTime;
    [Header("Move speed(default: 4)")]
    public float speed;
    [Header("Initial position(default z : -6.45)")]
    public Vector3 initial;
    [Header("Target position(default z : -4.4)")]
    public Vector3 target;
    [Header("Force exerted by the chair on the ball(default : 8)")]
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
        initial = new Vector3(transform.localPosition.x, transform.localPosition.y, -6.45f);
        target = new Vector3(transform.localPosition.x, transform.localPosition.y, -4.4f);

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
        if (transform.localPosition.z <= target.z)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {

            drawerOpening = false;
        }
    }

    void CloseDrawer()
    {
        if (transform.localPosition.z >= initial.z)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
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
