using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{


    [SerializeField]
    private float speed;

    [SerializeField]
    private float minDamage,maxDamage;

    
    private float Damage;

    [SerializeField]
    private AudioClip shootSound;

    private void OnEnable()
    {
        if(shootSound)
            AudioSource.PlayClipAtPoint(shootSound,new Vector3(0f,6f,0f));
    }

    private void Update()
    {
        HandleProjectileMovement();
        Damage = Random.Range(minDamage,maxDamage);
    }
    void HandleProjectileMovement()
    {
        transform.Translate(0f,speed*Time.deltaTime,0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(TagManager.PLAYER_TAG))
        {
            //PlayerHealthScript.instance.TakeDamage(Damage);
            collision.GetComponent<PlayerHealthScript>().TakeDamage(Damage);
            Debug.Log("Player Hit");
        }
        if(collision.CompareTag(TagManager.ENEMY_TAG)||collision.CompareTag(TagManager.METEOR_TAG))
        {
            Debug.Log("Enemy Hit");
            collision.GetComponent<EnemyHealthScript>().TakeDamage(Damage);
        }
        if(!collision.CompareTag(TagManager.UNTAGGED_TAG)&&!collision.CompareTag(TagManager.COLLECTABLE_TAG))
        {
            gameObject.SetActive(false);
        }
    }



}//class
















































