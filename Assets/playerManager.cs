using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverScreen;
    public GameObject gamePauseScreen;
    public GameObject finishMapScreen;
    public static bool finishMap;
    public GameObject GameControl;
    // Start is called before the first frame update

    void Start()
    {
        gameOver = false;
        gamePauseScreen.SetActive(false);
        finishMapScreen.SetActive(false);
        finishMap = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            gameOverScreen.SetActive(true);
        }
        
    }

    public void buttonPlayFinish()
    {
        SceneManager.LoadScene("homeScreen");
    }

    public void buttonHome()
    {
        SceneManager.LoadScene("homeScreen");
    }
    public void GamePause()
    {
        gamePauseScreen.SetActive(true);
        AudioManager.instance.Play("Click");
    }

    public void buttonX()
    {
        gamePauseScreen.SetActive(false);
    }

    public void FinishMapScreen()
    {
        finishMapScreen.SetActive(true);

    }
    public void OffGameControl()
    {
        GameControl.SetActive(false);
    }
}
