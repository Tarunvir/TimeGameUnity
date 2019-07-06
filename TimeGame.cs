using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGame : MonoBehaviour
{
    float roundStartTime;
    int waitTime;
    void Start()
    {
        print("Press the spacebar when you think the time is up ");
        SetNewRandomTime();
    }
    //------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            float playerWaitTime = Time.time - roundStartTime;
            float error = Mathf.Abs(playerWaitTime - waitTime);
            string message = "";
            if (error < .15f)
            {
                message = "Godlike!";
            }
            else if (error < .75f)
            {
                message = "Amazing!";
            }
            else if (error < 1.5f)
            {
                message = "Uhh..Passable.";
            }
            else
            {
                message = "You disgust me";
            }

            print("You waited for " + playerWaitTime + " seconds. That is " + error + " seconds off. " + message);
            SetNewRandomTime();
        }
    }
    //-----------------------------------------------------------
    void SetNewRandomTime()
    {
        waitTime = Random.Range(4, 11);
        roundStartTime = Time.time;
        print(waitTime + " seconds.");
    }
}
