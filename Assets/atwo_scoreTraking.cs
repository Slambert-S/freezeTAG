using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class atwo_scoreTraking : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text winnerText;
    public Text playerScore;
    public Text aiScore;
    public Text collectible;

    public int scorePlayer=0;
    public int scoreAi=0;
    public int nbCollectible = 3;
    // Start is called before the first frame update
    void Start()
    {
        playerScore.text = "Player score : 0";
        aiScore.text = "Ai score : 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(int whoGotThePoint)
    {
        if(whoGotThePoint == 1)
        {
            scorePlayer++;
            nbCollectible--;
            playerScore.text = "Player score : " + scorePlayer.ToString();
            collectible.text = nbCollectible.ToString();
        }
        if(whoGotThePoint == 2)
        {
            scoreAi++;
            nbCollectible--;
            aiScore.text = "Ai score : " + scoreAi.ToString();
            collectible.text = nbCollectible.ToString();


        }
    }
}
