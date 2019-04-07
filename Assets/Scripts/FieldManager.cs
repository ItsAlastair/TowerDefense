using UnityEngine;
using UnityEngine.EventSystems;

public class FieldManager : MonoBehaviour
{
    private Camera mainCam;                                                                             
    private Field currentSelectedField = null;
    public static Tower selectedTower = null;

    private bool mouseOverUI = false;                                                                  
    public bool MouseOverUI { get => mouseOverUI; set => mouseOverUI = value; }


    private void Start()                                                                               
    {                                                                                                  
        mainCam = Camera.main;
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if(selectedTower != null) selectedTower.towerRange.SetActive(true);
        if (mainCam == null) mainCam = Camera.main;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitinfo, 300f))
            {
                if (hitinfo.transform.CompareTag("Field"))
                {
                    currentSelectedField = hitinfo.transform.GetComponent<Field>();
                    FindObjectOfType<FieldMenu>().CloseFieldMenu();
                    if (GameManager.inWave && !currentSelectedField.isWall)
                    {
                        ClearTowerRange();
                        return;
                    }
                    else if (currentSelectedField.towerOnField == null)
                    {
                        ClearTowerRange();
                        PanelHolder.ClosePanels();
                        FindObjectOfType<FieldMenu>().OpenFieldMenu(currentSelectedField);
                    }
                    else if(hitinfo.transform.GetComponent<Field>().towerOnField != null)
                    {
                        ClearTowerRange();
                        selectedTower = currentSelectedField.towerOnField;
                        PanelHolder.ClosePanels();
                        FindObjectOfType<TowerMenu>().OpenTowerMenu(currentSelectedField.towerOnField, currentSelectedField);
                        
                    }
                }
                else if(!mouseOverUI)
                {
                    if (selectedTower != null)
                    {
                        ClearTowerRange();
                        selectedTower = null;
                    }

                    PanelHolder.ClosePanels();
                }
            }
        }
    }

    private void ClearTowerRange()
    {
        if (selectedTower != null)
        {
            selectedTower.towerRange.SetActive(false);
            
        }
        selectedTower = null;
    }
}
