using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playGame()
    {
        SceneManager.LoadScene(1);
        
    }
    public void goToMenu()
    {
        SceneManager.LoadScene(0);

    }
    public void quitGame()
    {
        Application.Quit();
    }
}
