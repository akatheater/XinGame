using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortoiseController : MonoBehaviour
{
    [Header("Point for green ball(default : 2)")]
    public int greenPoint;
    [Header("Point for purple ball(default : 1)")]
    public int purplePoint;
    [Header("GameManager's Gameobject")]
    public GameManager gm;

    AudioSource eatAudio;

    void Start()
    {
        eatAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag=="green")
        {
            Debug.Log("Eat green ball!!");
            collision.transform.GetComponent<BallController>().DestroyMyself();
            gm.AddPoint(greenPoint);
            eatAudio.Play();
        }
        else if(collision.transform.tag=="purple")
        {
            Debug.Log("Eat purple ball!!");
            collision.transform.GetComponent<BallController>().DestroyMyself();
            gm.AddPoint(purplePoint);
            eatAudio.Play();
        }
    }
}
