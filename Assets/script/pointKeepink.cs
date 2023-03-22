using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointKeepink : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxNbCoin;
    public int currentNbCoin;
    public int aiPoint;
    public int playerPoint;

    public Text aiText;
    public Text playerText;
    public Text totalText;

  

    public delegate void StopCreatingCoin();
    public static event StopCreatingCoin stopCreatingCoin;

    public delegate void PlayerWin();
    public static event PlayerWin callPlayerWin;

    public delegate void AiWin();
    public static event AiWin callAiWin;

    public delegate void tied();
    public static event tied callTied;

    void Start()
    {
        
    }
    private void OnEnable()
    {
        SteeringAgent.playerCollectedCoin += playerGetPoint;
        SteeringAgent.aiCollectedCoin += aiGetPoint;
        Timer.endOfGame += getWinner;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void playerGetPoint()
    {
        playerPoint++;
        currentNbCoin++;
        playerText.text = "Player points : "+ playerPoint;
        totalText.text = "Total points : " + currentNbCoin + "/"+ maxNbCoin;
        if (currentNbCoin >= maxNbCoin)
        {
            //End Game
            if (stopCreatingCoin != null)
            {
                stopCreatingCoin();
                getWinner();
            }
        }
    }

    private void aiGetPoint()
    {
        aiPoint++;
        currentNbCoin++;
        aiText.text = "Ai points : " + aiPoint;
        totalText.text = "Total points : " + currentNbCoin + "/" + maxNbCoin;
        if (currentNbCoin >= maxNbCoin)
        {
            //End Game

            if (stopCreatingCoin != null)
            {
                stopCreatingCoin();
                getWinner();
            }
        }
    }


    private void getWinner()
    {
        if((maxNbCoin / 2) > playerPoint)
        {
            if (callAiWin != null)
            {
                callAiWin();
            }
        }
        else if(playerPoint > aiPoint)
        {
            
            if (callPlayerWin != null)
            {
                callPlayerWin();
            }
        }
        else if(playerPoint == aiPoint)
        {
            if (callTied != null)
            {
                callTied();
            }
        }
    }
}
