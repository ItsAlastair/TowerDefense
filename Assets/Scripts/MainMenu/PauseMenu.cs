using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pausenPanel;
    private bool pause;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }

        if (pause)
        {
            Time.timeScale = 0;
            pausenPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pausenPanel.SetActive(false);
        }
    }

    public void Resume()
    {
        pause = false;
    }

    public void Restart()
    {
        pause = false;
        GameManager.GM.Restart();
    }

    public void BackToMenu()
    {
        pause = false;
        GameManager.GM.BGM.Stop();
        GameManager.GM.levelSize = 0;
        PanelHolder.panelHolder.statsPanel.SetActive(false);
        PanelHolder.ClosePanels();
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

}
