using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }


    public void SplashToStartMenu(float splashWaitTime)
    {
        StartCoroutine(SplashLoadCoroutine(splashWaitTime));
    }

    IEnumerator SplashLoadCoroutine(float splashWaitTime)
    {
        yield return new WaitForSeconds(splashWaitTime);
        SceneManager.LoadScene("Start Screen");
    }

    public void StartGame()
    {
    
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene("Options Screen");
    }


    public void QuitGame()
    {
        Application.Quit();
    }

}
