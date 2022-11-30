using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    [SerializeField]
    private GameObject healthBar;

    
    private Vector3 healthBarScale;

    [SerializeField]
    private float health = 100f;

    [SerializeField]
    private GameObject hitEffect;

    [SerializeField]
    private GameObject destroyEffect;


    private DropCollectable dropCollectable;

    private void Awake()
    {
        dropCollectable = GetComponent<DropCollectable>();
    }
    public void TakeDamage(float damageAmount)
    {

        health -= damageAmount;
        if(health <= 0f)
        {
            health = 0f;

            Instantiate(destroyEffect,transform.position, Quaternion.identity);

            if(gameObject.CompareTag(TagManager.ENEMY_TAG))
            {
                GameplayUIController.Instance.SetInfo(2);
                EnemySpawnerScript.instance.CheckToSpawnWave(gameObject);
            }
            else if(gameObject.CompareTag(TagManager.METEOR_TAG))
            {
                GameplayUIController.Instance.SetInfo(3);
            }

            SoundManager.instance.PlayDestroySound();

            dropCollectable.CheckToSpawnACollectable();

            Destroy(gameObject);
        }
        else
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            SoundManager.instance.PlayHitSound();
        }
        SetHealthBar();
        
    }


    void SetHealthBar()
    {
        if (!healthBar)
            return;

        healthBarScale = healthBar.transform.localScale;
        healthBarScale.x = health / 100f;
        healthBar.transform.localScale = healthBarScale;
    }

}//class

































