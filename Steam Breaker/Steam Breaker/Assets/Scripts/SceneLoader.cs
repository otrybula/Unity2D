using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadFirstScene()
    {
        FindObjectOfType<GameSession>().DestroyItself();
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LevelTransition()
    {
        SceneManager.LoadScene("Level Transition");
    }
    public void StartNext()
    {
        FindObjectOfType<GameSession>().NextLevel();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

}
