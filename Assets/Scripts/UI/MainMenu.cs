using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Transform mainCam;
    bool mainMenu;
    bool upgradeMenu;
    bool levelSelection;
    bool optionsMenu;

    private void Awake()
    {
        mainCam = Camera.main.transform;
    }

    public void StartButton()
    {
        mainMenu = false;
        upgradeMenu = false;
        levelSelection = true;
        optionsMenu = false;
    }

    public void UpgradeButton()
    {
        mainMenu = false;
        upgradeMenu = true;
        levelSelection = false;
        optionsMenu = false;
    }

    public void BackButton()
    {
        mainMenu = true;
        upgradeMenu = false;
        levelSelection = false;
        optionsMenu = false;
    }

    public void OptionsButton()
    {
        mainMenu = false;
        upgradeMenu = false;
        levelSelection = false;
        optionsMenu = true;
    }

    private void Update()
    {
        if (mainMenu)
        {
            mainCam.localRotation = Quaternion.Lerp(mainCam.rotation, Quaternion.Euler(0, 0, 0), 0.1f);
        }
        if (upgradeMenu)
        {
            mainCam.localRotation = Quaternion.Lerp(mainCam.rotation, Quaternion.Euler(0, 90, 0), 0.1f);
        }
        if (levelSelection)
        {
            mainCam.localRotation = Quaternion.Lerp(mainCam.rotation, Quaternion.Euler(-90, 0, 0), 0.1f);
        }
        if (optionsMenu)
        {
            mainCam.localRotation = Quaternion.Lerp(mainCam.rotation, Quaternion.Euler(0, -90, 0), 0.1f);
        }
    }



    public void SmallLevel()
    {
        GameManager.GM.levelSize = 1;
        PanelHolder.panelHolder.statsPanel.SetActive(true);
        GameManager.GM.SetStats();
        GameManager.GM.BGM.Play();
        SceneManager.LoadScene("SmallLevel", LoadSceneMode.Single);
    }

    public void MediumLevel()
    {
        GameManager.GM.levelSize = 2;
        PanelHolder.panelHolder.statsPanel.SetActive(true);
        GameManager.GM.SetStats();
        GameManager.GM.BGM.Play();
        SceneManager.LoadScene("MediumLevel", LoadSceneMode.Single);
    }

    public void BigLevel()
    {
        GameManager.GM.levelSize = 3;
        PanelHolder.panelHolder.statsPanel.SetActive(true);
        GameManager.GM.SetStats();
        GameManager.GM.BGM.Play();
        SceneManager.LoadScene("BigLevel", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
