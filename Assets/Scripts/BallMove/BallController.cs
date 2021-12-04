using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Force in the X-direction in the [ForceZone/Wind](default: -5)")]
    public float windXForce;
    [Header("Force in the Z-direction in the [ForceZone/Wind](default: -5)")]
    public float windZForce;
    [Header("Force in the Y-direction in the [ForceZone/DeskRebound & BedRebound](default: 5)")]
    public float reboundYForce;

    Rigidbody rd;

    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "wind")
        {
            rd.AddForce(windXForce, 0, windZForce);
        }
        if (other.tag == "rebound")
        {
            rd.AddForce(0, reboundYForce, 0);
        }
    }

    public void DestroyMyself()
    {
        Destroy(transform.gameObject);
    }
}
