using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public Text currentUPoints_T;
    public Text currentStartCoins_T;
    public Text currentStartStage_T;
    public Text currentStartLifes_T;



    void Update()
    {
        currentUPoints_T.text = "U-Points: " + GameManager.GM.UPoints.ToString();
        currentStartCoins_T.text = GameManager.GM.startCoins.ToString();
        currentStartStage_T.text = GameManager.GM.startStage.ToString();
        currentStartLifes_T.text = GameManager.GM.startLifes.ToString();
    }

    public void AddCoins()
    {
        if(GameManager.GM.UPoints >= 50)
        {
            GameManager.GM.UPoints -= 50;
            GameManager.GM.startCoins += 100;
        }
    }

    public void AddLifes()
    {
        if(GameManager.GM.UPoints >= 50)
        {
            GameManager.GM.UPoints -= 50;
            GameManager.GM.startLifes += 2;
        }
    }

    public void AddStage()
    {
        if (GameManager.GM.UPoints >= 50)
        {
            GameManager.GM.UPoints -= 50;
            GameManager.GM.startStage += 10;
        }
    }
}
