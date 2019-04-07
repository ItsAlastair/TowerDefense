using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Timer")]
    [HideInInspector] public int waveIndex = 0;
    private float timeBetweenWaves = 30f;
    [HideInInspector] public float countdown = 1;

    [Header("Spawn")]
    public Transform spawnPos;
    //public ParticleSystem spawneffect;
    public bool useCountdown = false;
    bool inWave = false;
    
    [Header("Enemy")]
    public GameObject[] enemys;
    [SerializeField] private int wavesForExtraEnemy = 3;
    private int currentEnemys = 1;

    [Header("DifficultyLevel")]
    [SerializeField] private int wavesToNextLevel = 20;
    private int currentLevel = 1;

    private void Start()
    {
        waveIndex = GameManager.currentStage;
        InvokeRepeating("ScanForEnemys", 1f, 0.5f);
    }

    public void StartWave()
    {
        if (!inWave && GameManager.readyForWave) StartCoroutine(SpawnWave());
    }

    private void Update()
    {
        if(waveIndex >= wavesToNextLevel)
        {
            wavesToNextLevel += 10;
            currentLevel++;
        }
        if(waveIndex >= wavesForExtraEnemy)
        {
            wavesForExtraEnemy += 3;
            currentEnemys++;
        }

        if (useCountdown && !inWave && GameManager.readyForWave)
        {
            if (countdown < 0)
            {
                StartCoroutine(SpawnWave());
                timeBetweenWaves = 10f;
                countdown = timeBetweenWaves;
                return;
            }
            countdown -= Time.deltaTime;
            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        }
        else countdown = timeBetweenWaves;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        GameManager.inWave = true;
        GameManager.currentStage = waveIndex;
        GameManager.GM.UPoints++;
        inWave = true;
        for (int i = 0; i < currentEnemys; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        //spawneffect.Play();
        

        GameObject GO = Instantiate(enemys[Random.Range(0, enemys.Length -1)], spawnPos.position, Quaternion.identity);
        Enemy GO_E = GO.GetComponent<Enemy>();
        GO_E.health *= currentLevel;
    }

    void ScanForEnemys()
    {
        Enemy[] remainingEnemys = FindObjectsOfType<Enemy>();
        if (inWave)
        {
            if (remainingEnemys.Length <= 0)
            {
                inWave = false;
                GameManager.readyForWave = true;
                GameManager.inWave = false;
            }
        }
    }
}


