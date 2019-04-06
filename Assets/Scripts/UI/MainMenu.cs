using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void SmallLevel()
    {
        GameManager.GM.levelSize = 1;
        PanelHolder.panelHolder.statsPanel.SetActive(true);
        GameManager.GM.SetStats();
        SceneManager.LoadScene("SmallLevel", LoadSceneMode.Single);
    }

    public void MediumLevel()
    {
        GameManager.GM.levelSize = 2;
        PanelHolder.panelHolder.statsPanel.SetActive(true);
        GameManager.GM.SetStats();
        SceneManager.LoadScene("MediumLevel", LoadSceneMode.Single);
    }

    public void BigLevel()
    {
        GameManager.GM.levelSize = 3;
        PanelHolder.panelHolder.statsPanel.SetActive(true);
        GameManager.GM.SetStats();
        SceneManager.LoadScene("BigLevel", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
