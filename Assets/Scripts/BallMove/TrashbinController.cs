using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashbinController : MonoBehaviour
{
    public GameObject player;
    [Header("Force in the X-direction to cueball(default: -60)")]
    public float xForce;
    [Header("Force in the Y-direction to cueball(default: 60)")]
    public float yForce;
    [Header("Force in the Z-direction to cueball(default: 0)")]
    public float zForce;

    void Start()
    {
        player.GetComponent<Rigidbody>().AddForce(xForce, yForce, zForce);
    }

}
