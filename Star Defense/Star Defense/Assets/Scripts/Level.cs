using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] float delayTime = 3f;
    IEnumerator DelayGameOver()
    {
            yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene("Game Over");
    }


    public void LoadGameOver()
    {
        StartCoroutine(DelayGameOver());
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Playspace");
    }
    public void LoadStartMenu()
    {
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene("Start Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }



}
