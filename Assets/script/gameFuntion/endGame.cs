using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endGame : MonoBehaviour
{
    // Start is called before the first frame update
    public pointKeepink linkToPoint;

    public GameObject gameOverScreen;
    public Text winnerText;
    public Text playerScore;
    public Text aiScore;
    void Start()
    {
        
    }
    private void OnEnable()
    {
        pointKeepink.callAiWin += aiWinn;
        pointKeepink.callPlayerWin += playerWin;
        pointKeepink.callTied += tied;
        freeze.callPlayerDied += aiWinn;
        
    }

    private void OnDisable()
    {
        pointKeepink.callAiWin -= aiWinn;
        pointKeepink.callPlayerWin -= playerWin;
        pointKeepink.callTied -= tied;
        freeze.callPlayerDied -= aiWinn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void playerWin()
    {
        gameOverScreen.gameObject.SetActive(true);
        winnerText.text = "Player win";
        playerScore.text = "Player : " + linkToPoint.playerPoint;
        aiScore.text = "Ai : " + linkToPoint.aiPoint;
        Time.timeScale = 0;
    }
    private void aiWinn()
    {
        gameOverScreen.gameObject.SetActive(true);
        winnerText.text = "Ai win";
        playerScore.text = "Player : " + linkToPoint.playerPoint;
        aiScore.text = "Ai : " + linkToPoint.aiPoint;
        Time.timeScale = 0;
    }

    private void tied()
    {
        gameOverScreen.gameObject.SetActive(true);
        winnerText.text = "Tied";
        playerScore.text = "Player : " + linkToPoint.playerPoint;
        aiScore.text = "Ai : " + linkToPoint.aiPoint;
        Time.timeScale = 0;
    }

}
