using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenu : MonoBehaviour
{
    [HideInInspector] public Tower currentTower = null;
    private Field selectedField = null;
    

    public void OpenTowerMenu(Tower _tower, Field _field)
    {
        selectedField = _field;
        currentTower = _tower;
        PanelHolder.panelHolder.towerMenu.SetActive(true);
        currentTower.towerRange.SetActive(true);
    }

    public void UpgradeTower()
    {
        if (GameManager.currentCoins >= currentTower.upgradeCost)
        {
            GameManager.currentCoins -= currentTower.upgradeCost;
            currentTower.level++;
            currentTower.damage += 1;
            currentTower.range += 1;
            currentTower.upgradeCost *= 2;
        }
        else
        {
            Debug.LogError("not enough money for TowerUpgrade // Display Error on Screen or gray out this Button");
        }
    }

    public void SellTower()
    {
        if(currentTower != null)
        {
            selectedField.towerOnField = null;
            GameManager.currentCoins += currentTower.towerCost / 2;
            Destroy(currentTower.gameObject);
            currentTower = null;
            PanelHolder.ClosePanels();
        }
    }
}
