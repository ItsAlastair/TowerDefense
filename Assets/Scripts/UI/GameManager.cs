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
    public static int currentLifes = 0;
    public int UPoints = 0;

    [Header("Spawner")]
    [HideInInspector] public Spawner spawner;
    
    public static bool readyForWave = true;
    public static bool inWave = false;

    public Text stage_T;
    public Text coins_T;
    public Text lifes_T;
    public Text wave_T;

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
        if (spawner == null)
        {
            spawner = FindObjectOfType<Spawner>();
            return;
        }
        wave_T.text = string.Format("{0:00.00}", spawner.countdown);
        stage_T.text = "Stage: " + currentStage.ToString();
        coins_T.text = "Coins: " + currentCoins.ToString();
        lifes_T.text = "Lifes: " + currentLifes.ToString();
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
            Debug.LogError("Destination Goal cannot be reached // Display Error on Screen or gray out this Button");
        }
    }


    public void Restart()
    {
        SetStats();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

}
