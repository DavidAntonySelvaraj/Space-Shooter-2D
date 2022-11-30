using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject[] meteors;

    private Vector3 randSpawnPos;

    [SerializeField]
    private float minIntervalTime = 3f, maxIntervalTime = 8f;

   

    private int randSpawnNum;

    [SerializeField]
    private float minX, maxX;

    [SerializeField]
    private int minSpawnNo = 1, maxSpawnNo = 4;

    

    private void Start()
    {
        SpawnMeteors();
        Invoke("SpawnMeteors", Random.Range(minIntervalTime,maxIntervalTime));

        //we can also use 
        //InvokeRepeating(); .........but its not useful in this case.
    }


    

    void SpawnMeteors()
    {
        randSpawnNum = Random.Range(minSpawnNo,maxSpawnNo);

        for(int i = 0;i<randSpawnNum;i++)
        {
            randSpawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);
            Instantiate(meteors[Random.Range(0, meteors.Length)],randSpawnPos,Quaternion.identity);
            

        }
        Invoke("SpawnMeteors", Random.Range(maxIntervalTime, minIntervalTime));

    }


   





}//class







































