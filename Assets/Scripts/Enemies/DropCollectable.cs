using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCollectable : MonoBehaviour
{

    [SerializeField]
    private GameObject[] collectables;


    public void CheckToSpawnACollectable()
    {
        if(Random.Range(0,3)>1.5f)
        {
            Instantiate(collectables[Random.Range(0,collectables.Length)],transform.position,Quaternion.identity);
        }
    }


}//class









































