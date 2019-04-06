using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerMenu : MonoBehaviour
{
    [HideInInspector] public Tower currentTower = null;
    private Field selectedField = null;

    public Dropdown attackFocus_Drop;
    

    public void OpenTowerMenu(Tower _tower, Field _field)
    {
        selectedField = _field;
        currentTower = _tower;
        PanelHolder.panelHolder.towerMenu.SetActive(true);
        currentTower.towerRange.SetActive(true);
        attackFocus_Drop.captionText.text = selectedField.towerOnField.attackFocus.ToString();
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

    public void ChangeAttackFocus()
    {
        if (attackFocus_Drop.captionText.text == "First") selectedField.towerOnField.attackFocus = Tower.AttackFocus.First;
        if (attackFocus_Drop.captionText.text == "Last") selectedField.towerOnField.attackFocus = Tower.AttackFocus.Last;
        if (attackFocus_Drop.captionText.text == "Random") selectedField.towerOnField.attackFocus = Tower.AttackFocus.Random;
    }
}
