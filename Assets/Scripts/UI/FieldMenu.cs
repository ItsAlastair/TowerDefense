using UnityEngine;
using UnityEngine.UI;

public class FieldMenu : MonoBehaviour
{
    private Field currentSelectedField = null;

    [Header("Buttons")]
    public Button buildTowerButton;
    public Button makeFlatButton;
    public Button makeWallButton;

    public void OpenFieldMenu(Field _selectedField)
    {
        currentSelectedField = _selectedField;
        if (!currentSelectedField.isWall)
        {
            buildTowerButton.interactable = false;
            makeFlatButton.interactable = false;
            makeWallButton.interactable = true;
        }
        else
        {
            buildTowerButton.interactable = true;
            makeFlatButton.interactable = true;
            makeWallButton.interactable = false;
        }

        PanelHolder.panelHolder.fieldMenu.SetActive(true);
    }

    public void FieldToWall()
    {
        currentSelectedField.MakeWall();
        CloseFieldMenu();
    }

    public void WallToField()
    {
        currentSelectedField.MakeFlat();
        CloseFieldMenu();
    }

    public void CloseFieldMenu()
    {
        PanelHolder.ClosePanels();
        currentSelectedField = null;
    }

    public void BuildTower()
    {
        if(currentSelectedField.towerOnField == null && currentSelectedField.isWall)
        {
            PanelHolder.ClosePanels();
            PanelHolder.panelHolder.selectTowerMenu.SetActive(true);
        }
        else
        {
            Debug.LogError("Field is not a Wall yet // Display Error on Screen or gray out this Button");
        }
        
    }

    public void SelectTower(Tower _tower)
    {
        if (GameManager.currentCoins >= _tower.towerCost)
        {
            GameManager.currentCoins -= _tower.towerCost;
            currentSelectedField.BuildTowerOnField(_tower);
            PanelHolder.ClosePanels();
        }
        else
        {
            Debug.LogError("not enough money // Display Error on Screen or gray out this Button");
        }
    }
}
