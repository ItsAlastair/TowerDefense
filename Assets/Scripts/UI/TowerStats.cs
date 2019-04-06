using UnityEngine;
using UnityEngine.UI;

public class TowerStats : MonoBehaviour
{
    public Text level_T;
    public Text damage_T;
    public Text range_T;
    public Text fireRate_T;
    public Text upgradeCost_T;
    public Text refund_T;

    public void ShowCurrentTowerStats(Tower _currentTower)
    {
        level_T.text = Mathf.RoundToInt(_currentTower.level).ToString();
        damage_T.text = Mathf.RoundToInt(_currentTower.damage).ToString();
        range_T.text = Mathf.RoundToInt(_currentTower.range).ToString();
        fireRate_T.text = Mathf.RoundToInt(_currentTower.fireRate).ToString();
        upgradeCost_T.text = Mathf.RoundToInt(_currentTower.upgradeCost).ToString();
        refund_T.text = Mathf.RoundToInt(_currentTower.towerCost / 2).ToString();
    }
}
