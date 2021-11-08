using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float secondsToWait = 2f;
    [SerializeField] float levelSlowmo = 0.2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(NextLevel());
    }

   IEnumerator NextLevel()
    {
        Time.timeScale = levelSlowmo;
        yield return new WaitForSecondsRealtime(secondsToWait);
        Time.timeScale = 1f;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }
}
