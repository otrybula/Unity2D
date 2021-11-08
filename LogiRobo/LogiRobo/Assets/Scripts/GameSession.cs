using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int lives = 3;
    [SerializeField] int coins = 0;
    [SerializeField] int coinScore = 100;

    [SerializeField] Text livesDisplay;
    [SerializeField] Text scoreDisplay;

    private void Awake()
    {
        int gameSessionNumber = FindObjectsOfType<GameSession>().Length;
        if (gameSessionNumber > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        livesDisplay.text = lives.ToString();
        scoreDisplay.text = coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
     
    }

    public void PlayerLifesControl()
    {
        if (lives > 1)
        {
            LifeLost();
        }
        else
        {
            SessionReset();
        }
    }

    public void CoinAdded(int value)
        {
        coins+=value;
        scoreDisplay.text = coins.ToString();
    }


    private void LifeLost()
    {
        lives--;
        livesDisplay.text = lives.ToString();
        var CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
    }


    private void SessionReset()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
