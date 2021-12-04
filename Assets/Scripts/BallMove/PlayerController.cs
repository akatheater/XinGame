using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Force in the X-direction in the [ForceZone/Wind](default: -20)")]
    public float windXForce;
    [Header("Force in the Z-direction in the [ForceZone/Wind](default: 20)")]
    public float windZForce;
    [Header("Force in the Y-direction in the [ForceZone/DeskRebound & BedRebound](default: 5)")]
    public float reboundYForce;
    [Header("Force in the X-direction in the [ForceZone/GlobalForce](default: -1)")]
    public float force;

    Rigidbody rd;

    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wind")
        {
            rd.AddForce(windXForce, 0, windZForce);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "rebound")
        {
            rd.AddForce(0, reboundYForce, 0);
        }
        if (other.tag == "force")
        {
            rd.AddForce(force, 0, 0);
        }

    }


}
