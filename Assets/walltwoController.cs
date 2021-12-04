using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walltwoController : MonoBehaviour
{
    public float force;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "green" || collision.transform.tag == "purple" || collision.transform.tag == "player")
        {
            collision.transform.GetComponent<Rigidbody>().AddForce(0, 0, force*50);
        }
    }
}