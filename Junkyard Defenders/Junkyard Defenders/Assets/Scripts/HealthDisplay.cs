using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{

    [SerializeField] float baseLives = 5;
    float lives;
    [SerializeField] int damage = 1;
    Text livesText;

// Start is called before the first frame update
void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    // Update is called once per frame
    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void RemoveLives()
    {
        lives -= damage;
        UpdateDisplay();
        if (lives <= 0)
        { 
            LevelLost();
        }
    }

    private void LevelLost()
    {
      FindObjectOfType<LevelController>().HandleLooseCondition();
    }
}
