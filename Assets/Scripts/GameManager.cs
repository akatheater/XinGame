using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Timers;

public class GameManager : MonoBehaviour
{
    [Header("Total game time(default: 120)")]
    public int time;
    [Header("Initial position( default : (-9.5f, -6.6f, -2.9f) )")]
    public Vector3 iniPosition;
    [Header("Don't change these below!")]
    public PlayerController pc;

    public Camera mainCamera;
    public Camera topCamera;
    Camera currentCamera;

    public GameObject playingUI;
    public TextMeshProUGUI timeLeft;
    public TextMeshProUGUI point;
    int currentPoint;

    public bool gameOver;

    public GameObject overUI;
    public TextMeshProUGUI grade;
    public TextMeshProUGUI detail;
    string currentGrade;
    string currentDetail;

    void Start()
    {
        currentPoint = 0;
        currentCamera = mainCamera;
        gameOver = false;
        TimersManager.SetLoopableTimer(this, 1f, Countdown);
    }

    void Update()
    {
        timeLeft.text = time + "s";
        point.text = currentPoint+" ";
        grade.text = currentGrade;
        detail.text = currentDetail;

        Grade();

        if(gameOver)
        {
            pc.transform.position = iniPosition;
            pc.transform.eulerAngles = new Vector3(0,0,0);
            pc.GetComponent<Rigidbody>().velocity = Vector3.zero;
            pc.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            GameObject[] greenBall= GameObject.FindGameObjectsWithTag("green");
            foreach(GameObject go in greenBall)
            {
                go.GetComponent<Rigidbody>().velocity = Vector3.zero;
                go.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }

            GameObject[] purpleBall = GameObject.FindGameObjectsWithTag("purple");
            foreach (GameObject go in purpleBall)
            {
                go.GetComponent<Rigidbody>().velocity = Vector3.zero;
                go.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }

            playingUI.SetActive(false);
            overUI.SetActive(true);
        }
    }

    void Countdown()
    {
        time--;
        if(time<=0)
        {
            gameOver = true;
            TimersManager.ClearTimer(Countdown);
        }
    }

    public void AddPoint(int p)
    {
        currentPoint += p;
    }

    //How to get different ratings
    public void Grade()
    {
        if(currentPoint==0)
        {
            currentGrade = "Fail";
            currentDetail = "Your point:"+currentPoint;
            //currentDetail = "You can change it as you will.";
        }
        else if(currentPoint==1 || currentPoint==2)
        {
            currentGrade = "Good";
            currentDetail = "Your point:" + currentPoint;
        }
        else if(currentPoint== 3 || currentPoint == 4)
        {
            currentGrade = "Great";
            currentDetail = "Your point:" + currentPoint;
        }
        else if(currentPoint==5)
        {
            currentGrade = "Excellent";
            currentDetail = "Your point:" + currentPoint;
        }
    }

    public void ChangeCamera()
    {
        if(currentCamera==mainCamera)
        {
            currentCamera = topCamera;
            topCamera.gameObject.SetActive(true);
            mainCamera.gameObject.SetActive(false);
        }
        else if(currentCamera==topCamera)
        {
            currentCamera = mainCamera;
            mainCamera.gameObject.SetActive(true);
            topCamera.gameObject.SetActive(false);
        }
    }

}
