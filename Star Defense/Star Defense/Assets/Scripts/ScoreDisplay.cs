using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    //object refference
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI upgradeLvl;
    [SerializeField] TextMeshProUGUI health;
    [SerializeField] TextMeshProUGUI maxHealth;
    Player player;
    GameSession gameSession;

    void Start()
    {
        player = FindObjectOfType<Player>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        scoreText.text = gameSession.GetScore().ToString();
        if (upgradeLvl != null)
        { 
        upgradeLvl.text = player.GetUpgradeLevel().ToString() + "/5";
        }
        health.text = player.GetHealth().ToString() + "/";
        maxHealth.text = player.GetMaxHealth().ToString();
    }
}
