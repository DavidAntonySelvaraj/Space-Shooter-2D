using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CollectableType
{
    Blaster,Laser,MiniRocket,Rocket,Health
}

public class CollectableScript : MonoBehaviour
{



    public CollectableType type;

    [SerializeField]
    private float moveSpeed = 5f;

    private Vector3 tempPos;

    [HideInInspector]
    public float healthValue;

    private float minHealthValue = 10f , maxHealthValue = 30f;

    private void Start()
    {
        healthValue = Random.Range(minHealthValue, maxHealthValue);
    }

    private void Update()
    {
        tempPos = transform.position;
        tempPos.y -= moveSpeed*Time.deltaTime;
        transform.position = tempPos;
    }
    private void OnDisable()
    {
        SoundManager.instance.PlayPickUpSound();
    }



}//class



















































