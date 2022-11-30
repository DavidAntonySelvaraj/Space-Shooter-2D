using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public static EnemySpawnerScript instance;


    [SerializeField]
    private GameObject[] enemies;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    [SerializeField]
    private float SpawnWaitTime = 2f;

    [SerializeField]
    private Transform[] SpawnPoints;


    private void Start()
    {
        StartCoroutine(_SpawnWave(SpawnWaitTime));
    }
    private void Awake()
    {
        if(instance==null)
            instance = this;
    }
    

    void SpawnNewEnemies()
    {
        if (spawnedEnemies.Count > 0)
            return;

        for(int i = 0;i<SpawnPoints.Length;i++)
        {
            GameObject newEnemy = Instantiate(enemies[Random.Range(0,enemies.Length)],SpawnPoints[i].position,Quaternion.identity);
            spawnedEnemies.Add(newEnemy);
        }

        //GameplayUIController.Instance.SetWave();
        GameplayUIController.Instance.SetInfo(1);
    }
    IEnumerator _SpawnWave(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SpawnNewEnemies();

    }

    public void CheckToSpawnWave(GameObject ShipToRemove)
    {
        spawnedEnemies.Remove(ShipToRemove);

        if (spawnedEnemies.Count == 0)
            StartCoroutine(_SpawnWave(SpawnWaitTime));
    }

}//class
















