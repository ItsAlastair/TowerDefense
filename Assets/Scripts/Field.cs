﻿using UnityEngine;

public class Field : MonoBehaviour
{
    [Header("Colors")]
    public Renderer rend;
    public Color mouseOver;
    public Color wallColor;
    public Color normalColor;

    [Header("FieldToWall")]
    public int wallCost = 100;
    public int flatCost = 10;
    public bool isWall = false;
    [SerializeField] private float speed = 0.05f;
    private Vector3 flatPos;
    private Vector3 wallPos;

    [Header("Price for Wall")]
    public int priceForWall = 100;

    [Header("Tower")]
    [SerializeField] private Transform towerPivot = null;
    public Tower towerOnField = null;

    [Header("PathDebugger")]
    PathDebugger pd;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        normalColor = GetComponent<Renderer>().material.color;
        flatPos = transform.position;
        wallPos = transform.position + Vector3.up * 1.5f;
        pd = FindObjectOfType<PathDebugger>();
    }

    private void Update()
    {
        if (isWall)
        {
            transform.position = Vector3.Lerp(transform.position, wallPos, speed);
        }
        else if(!isWall && towerOnField == null)
        {
            transform.position = Vector3.Lerp(transform.position, flatPos, speed);
        }

        while (!pd.CheckPath())
        {
            //Display Error Text to destroy a Wall
            flatCost = 0;
            return;
        }
        flatCost = 100;
    }

    public void MakeWall()
    {
        if (GameManager.currentCoins >= wallCost)
        {
            GameManager.currentCoins -= wallCost;
            isWall = true;
            rend.material.color = wallColor;
        }
        else
        {
            PanelHolder.panelHolder.StartCoroutine("WarningText", "NO MONEY FOR A WALL");
        }
    }

    public void MakeFlat()
    {
        if (!isWall) return;
        if (GameManager.currentCoins >= flatCost)
        {
            GameManager.currentCoins -= flatCost;
            isWall = false;
            rend.material.color = normalColor;
        }
        else
        {
            PanelHolder.panelHolder.StartCoroutine("WarningText", "NO MONEY FOR FLAT LANDS");
        }
    }

    public void BuildTowerOnField(Tower _tower)
    {

        GameObject tempTower = Instantiate(_tower.gameObject, towerPivot.position, Quaternion.identity);
        towerOnField = tempTower.GetComponent<Tower>();

    }

    #region MouseOver
    private void OnMouseEnter()
    {
        if(towerOnField == null)
        {
            rend.material.color = mouseOver;
        }
        else
        {
            FindObjectOfType<TowerStats>().ShowCurrentTowerStats(towerOnField);
            PanelHolder.panelHolder.towerStats.SetActive(true);
            towerOnField.towerRange.SetActive(true);
        }
        

    }

    private void OnMouseExit()
    {
        if(isWall) rend.material.color = wallColor;
        else rend.material.color = normalColor;

        if (towerOnField != null)
        {
            PanelHolder.panelHolder.towerStats.SetActive(false);
            towerOnField.towerRange.SetActive(false);
        }
    }
    #endregion
}
