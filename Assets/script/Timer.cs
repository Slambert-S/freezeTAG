using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float tmpTime;
    public Text timerText;
    int minutes, seconds;

    public delegate void timerEnd();
    public static event timerEnd endOfGame;


    void Update()
    {
        tmpTime = tmpTime - Time.deltaTime;

        minutes = (int)tmpTime / 60;

        seconds = (int)tmpTime % 60;
        if(seconds < 10)
        {
            timerText.text = minutes + ":0" + seconds;
        }
        else
        {

            timerText.text = minutes + ":" + seconds;
        }

        if(tmpTime <= 0)
        {
            if (endOfGame != null)
            {
                endOfGame();
                
            }
        }
    }
}
