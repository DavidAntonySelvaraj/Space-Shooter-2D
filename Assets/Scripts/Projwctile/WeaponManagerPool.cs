using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagerPool : MonoBehaviour
{
    [SerializeField] private GameObject projectile;

    [SerializeField] private List<GameObject> projectilePool = new List<GameObject>();

    private GameObject projectileHolder;

    [SerializeField] private KeyCode keyToPressToShoot;

    private bool projectileSpawned;

    [SerializeField] private Transform projectileSpawnPoint;

    [SerializeField] private float shootWaitTime = .2f;

    private float shootTimer;

    private bool canShoot = false;

    [SerializeField] private bool isEnemy;



    private void Awake()
    {
        if (isEnemy)
        {
            projectileHolder = GameObject.FindWithTag(TagManager.ENEMY_PROJECTILE_TAG);
            ResetTimer();
        }
        else
        {
            projectileHolder = GameObject.FindWithTag(TagManager.PLAYER_PROJECTILE_TAG);
            //ResetTimer();
        }
    }

    private void Update()
    {
        if (Time.time > shootTimer)
            canShoot = true;

        

        HandleEnemyShooting();
        HandlePlayerShooting();
    }

    void HandlePlayerShooting()
    {
        if (isEnemy||!canShoot)
            return;

        if (Input.GetKeyDown(keyToPressToShoot))
        {
            GetObjectFromPoolOrSpawnANewOne();
            ResetTimer();
        }

    }


    void GetObjectFromPoolOrSpawnANewOne()
    {
        for(int i = 0; i < projectilePool.Count; i++)
        {
            if(!projectilePool[i].activeInHierarchy)
            {
                projectilePool[i].transform.position = projectileSpawnPoint.position;
                projectilePool[i].SetActive(true);
                projectileSpawned = true;
                break;
            }
            else
            {
                projectileSpawned = false;
            }
        }
        if(!projectileSpawned)
        {
            GameObject newProjectile = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);
            projectilePool.Add(newProjectile);
            newProjectile.transform.SetParent(projectileHolder.transform);
            projectileSpawned = true;
        }

    }


    void ResetTimer()
    {
        canShoot = false;


        //projectiles dont spawn at same time 
        if (isEnemy)
            shootTimer = Time.time + Random.Range(shootWaitTime, (shootWaitTime + 1f));
        else
            shootTimer = Time.time + shootWaitTime;

        //projectile spawn at same time
        /* shootTimer = Time.time + shootWaitTime;*/
    }

    void HandleEnemyShooting()
    {
        if (!isEnemy || !canShoot)
            return;
        ResetTimer();
        GetObjectFromPoolOrSpawnANewOne();
        
    }



}//class





















