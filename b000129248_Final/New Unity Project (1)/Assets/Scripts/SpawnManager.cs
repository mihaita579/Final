using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject PowerUPPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNum = 1;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNum);
        Instantiate(PowerUPPrefab, GenerateSpwanPosition(), PowerUPPrefab.transform.rotation);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void SpawnEnemyWave(int enemyToSpawn)
    {
        for (int i = 0; i < enemyToSpawn; i++)
        {
            Instantiate(enemyPrefab3, GenerateSpwanPosition(), enemyPrefab3.transform.rotation);
            if (i == 5)
            { Instantiate(enemyPrefab2, GenerateSpwanPosition(), enemyPrefab2.transform.rotation); }
        }



    }


    private Vector3 GenerateSpwanPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0 && gameManager.isGameActive)
        {
            waveNum++;
            SpawnEnemyWave(waveNum);
            Instantiate(PowerUPPrefab, GenerateSpwanPosition(), PowerUPPrefab.transform.rotation);
        }
    }
}
