using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefender(SquareIsClicked());
    }

    private void AttemptToPlaceDefender(Vector3 gridPos)
    {
        var EnergyDisplay = FindObjectOfType<EnergyDisplay>();
        int defenderCost = defender.GetEnergyCost();
        
        if (EnergyDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            EnergyDisplay.SpendEnergy(defenderCost);
        }
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }
    private Vector3 SquareIsClicked()
    {
        Vector3 clickPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 9);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector3 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }
    private void SpawnDefender(Vector3 worldPos)
    {
        Defender newDefender = Instantiate(defender, worldPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }

    private Vector3 SnapToGrid(Vector3 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector3(newX, newY, -1);
    }
}
