using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHolder : MonoBehaviour
{
    public static PanelHolder panelHolder;

    [Header("SelectTowerMenu")]
    public GameObject selectTowerMenu;

    [Header("TowerMenu")]
    public GameObject towerMenu;

    [Header("FieldMenu")]
    public GameObject fieldMenu;

    [Header("PlayerStats")]
    public GameObject statsPanel;

    [Header("TowerStats")]
    public GameObject towerStats;

    [Header("Warnings")]
    public GameObject warningPanel;

    [Header("GameOver")]
    public GameObject gameOverPanel;

    List<GameObject> allPanels = new List<GameObject>();

    private void Awake()
    {
        if (panelHolder == null) panelHolder = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        

        for (int i = 3; i < transform.childCount; i++)
        {
            allPanels.Add(transform.GetChild(i).gameObject);
        }
    }

    public static void ClosePanels()
    {
        foreach (GameObject go in panelHolder.allPanels)
        {
            go.SetActive(false);
            FindObjectOfType<FieldManager>().MouseOverUI = false;
        }
    }

    public IEnumerator WarningText(string message)
    {
        warningPanel.SetActive(true);
        GameManager.GM.warning_T.text = message;
        yield return new WaitForSeconds(3f);
        warningPanel.SetActive(false);
    }
}
