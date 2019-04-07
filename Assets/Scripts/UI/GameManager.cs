using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public int levelSize = 0;

    [Header("PlayerStats")]
    public int startStage = 0;
    public static int currentStage = 0;
    public int startCoins = 200;
    public static int currentCoins = 0;
    public int startLifes = 10;
    public static int currentLifes = 1;
    public int UPoints = 0;

    [Header("Spawner")]
    [HideInInspector] public Spawner spawner;
    
    public static bool readyForWave = true;
    public static bool inWave = false;

    [Header("Texts")]
    public Text stage_T;
    public Text coins_T;
    public Text lifes_T;
    public Text countdown_T;
    public Text warning_T;

    [Header("Sounds")]
    public AudioSource BGM;

    private void Awake()
    {
        if (GM == null) GM = this;
        else Destroy(gameObject);
        SetStats();
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        spawner = FindObjectOfType<Spawner>() == null ? null : FindObjectOfType<Spawner>();
    }

    private void Update()
    {
        if (spawner == null) spawner = FindObjectOfType<Spawner>();
        
        //if(spawner.useCountdown) countdown_T.text = string.Format("{0:00.00}", spawner.countdown);
        stage_T.text = "Stage: " + currentStage.ToString();
        coins_T.text = "Coins: " + currentCoins.ToString();
        lifes_T.text = "Lifes: " + currentLifes.ToString();

        if(currentLifes <= 0)
        {
            GameOver();
        }
    }

    public void SetStats()
    {
        currentStage = startStage;
        currentCoins = startCoins;
        currentLifes = startLifes;

        inWave = false;
        readyForWave = true;

    }

    public void NextWave()
    {
        if (readyForWave)
        {
            PanelHolder.ClosePanels();
            FindObjectOfType<Spawner>().StartWave();
        }
        else
        {
            PanelHolder.panelHolder.StartCoroutine("WarningText", "YOU ARE IN A FIGHT!");
        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
        PanelHolder.ClosePanels();
        PanelHolder.panelHolder.gameOverPanel.SetActive(true);
    }


    public void Restart()
    {
        PanelHolder.ClosePanels();
        PanelHolder.panelHolder.statsPanel.SetActive(true);
        SetStats();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

}
