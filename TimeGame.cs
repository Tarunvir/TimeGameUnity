using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class TimeGame : MonoBehaviour
{
    float roundStartDelayTime = 3;
    float roundStartTime;
    int waitTime;
    bool roundStarted;
    void Start()
    {
        print("Press the spacebar when you think the time is up ");
        Invoke("SetNewRandomTime", roundStartDelayTime);
    }
    //------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && roundStarted)
        {
            roundStarted = false;
            KeyPressed();
        }
    }

    void KeyPressed()
    {
        float playerWaitTime = Time.time - roundStartTime;
        float error = Mathf.Abs(playerWaitTime - waitTime);

        print("You waited for " + playerWaitTime + " seconds. That is " + error + " seconds off. " + GenerateMessage(error));
        Invoke("SetNewRandomTime", roundStartDelayTime);
    }
    string GenerateMessage(float error)
    {
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
        return message;
    }

    void SetNewRandomTime()
    //references in Invoke
    {
        waitTime = Random.Range(4, 11);
        print(waitTime + " seconds.");
        roundStartTime = Time.time;
        roundStarted = true;
    }
}
