using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Defender : MonoBehaviour
{

    [SerializeField] int energyCost = 100;

 



    public int GetEnergyCost()
    {
        return energyCost;
    }

    public void AddEnergy(int ammount)
    {
        FindObjectOfType<EnergyDisplay>().AddEnergy(ammount);
    }
}
