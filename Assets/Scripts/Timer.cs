using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
    //Mike if you're reading this, I wasn't able to make the waypoints work the way I wanted also for the seeking behaviour for the
    //CarRival... I wasn't able to make it behave properly. The code works, it seeks every single CarAI object in the scene but the problem is 
    //it move towards the AIs so fast and destroys every single CarAI in an instant so I just disabled it from the CarRival object. You can 
    //try to enable it and see what I was talking about, only if you want to.


    public Text timerTxt;
    private float timerF;
    public Text xminutes;
    public Text xseconds;
    public Text xmseconds;

    public Text rScore;
    public Text yScore;

    public Text lose;
    public Text win;
    public Text draw;
    public Button resetbutton;
    public GameObject panel;

    RivalCarController rc;
    Car c;
	// Use this for initialization
	void Start () {
        //Sets value for variable timerF (Setter)
        SetTime(20.0f);
        c = GameObject.FindObjectOfType<Car>();
        rc = GameObject.FindObjectOfType<RivalCarController>();
       
	}
	
	// Update is called once per frame
	void Update () {
        //Calling TimeFunction
        TimeFunction();
        //timerTxt.text = timerF.ToString();

        int minutes = Mathf.FloorToInt(timerF / 60f);
        int seconds = Mathf.FloorToInt(timerF - minutes * 60);
        int mseconds = Mathf.FloorToInt(timerF * 1000f);
        //Modulo sends back mseconds value to 1000 seconds
        mseconds = (mseconds % 1000);

        //Displays the time on the UI text
        //timerTxt.text = minutes.ToString() + ":" + seconds.ToString() + ":" + mseconds.ToString();

        xminutes.text = minutes.ToString();
        xseconds.text = " : " + seconds.ToString();
        xmseconds.text = " : " + mseconds.ToString();

        rScore.text = "Rival's score: " + rc.GetRivalScore().ToString();
        yScore.text = "Your score: " + c.GetYourScore().ToString();
        draw.text = "It's a DRAW!";

    }

    private void TimeFunction()
    {
        //If timerF is greater than 0 then deltatime is subtracted throughout the loop
        //else, if it goes down to 0, set timer to 0 
        if(GetTime() > 0)
        {
           timerF -= Time.deltaTime;
        }
        else
        {
            //GameOver();
            ManageScore();
            //Debug.Log(rc.GetRivalScore());
            //Debug.Log(c.GetYourScore());
            SetTime(0.0f);
        }

        /*if(GetTime() == 0)
        {
            ManageScore();
        }*/
    }

    public float GetTime()
    {
        return timerF;
    }

    public void SetTime(float timeF)
    {
        timerF = timeF;
    }

    public void ManageScore()
    {
        

        if (rc.GetRivalScore() < c.GetYourScore())
        {
            Debug.Log(rc.GetRivalScore());
            lose.gameObject.SetActive(true);
        }
        else if(rc.GetRivalScore() > c.GetYourScore())
        {
            Debug.Log(c.GetYourScore());
            win.gameObject.SetActive(true);            
        }
        else if(rc.GetRivalScore() == c.GetYourScore())
        { 
            draw.gameObject.SetActive(true);
            Debug.Log("Draw");

        }

        rScore.gameObject.SetActive(true);
        yScore.gameObject.SetActive(true);
        resetbutton.gameObject.SetActive(true);
        panel.gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("CarDestroyed").SetActive(false);
        GameObject.FindGameObjectWithTag("You").SetActive(false);
        GameObject.FindGameObjectWithTag("Rival").SetActive(false);
        GameObject.FindGameObjectWithTag("TimerContainer").SetActive(false);

        Time.timeScale = 0;

    }

    public void ResetLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
