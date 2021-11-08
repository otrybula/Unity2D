using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDisplay : MonoBehaviour
{

    [SerializeField] int energy = 100;
    Text energyText;
    void Start()
    {
    energyText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        energyText.text = energy.ToString();
    }

    public void AddEnergy(int ammount)
    {
        energy += ammount;
        UpdateDisplay();
    }

    public void SpendEnergy(int ammount)
    {
       
        if (energy >= ammount)
        {
            energy -= ammount;
            UpdateDisplay();
        }
    }

    public bool HaveEnoughStars(int ammount)
    {
        return energy >= ammount;
    }

}
