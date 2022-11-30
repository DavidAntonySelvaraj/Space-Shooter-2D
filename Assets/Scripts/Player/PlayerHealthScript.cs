using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour
{
    public static PlayerHealthScript instance;

    [SerializeField]
    private float maxHealth = 500f;

    [SerializeField]
    private float health;

    [SerializeField]
    private GameObject destroyEffect;

    [SerializeField]
    private GameObject hitEffect;

    private CollectableScript collectable;

    private Slider playerHealthSlider;

    

    private void Awake()
    {
        playerHealthSlider = GameObject.FindWithTag(TagManager.PLAYER_HEALTH_SLIDER_TAG).GetComponent<Slider>();
        health = maxHealth;

        playerHealthSlider.minValue = 0f;
        playerHealthSlider.maxValue = health;
        playerHealthSlider.value = health;

    }

    public void TakeDamage(float damageAmount)
    {
        health-= damageAmount;
        playerHealthSlider.value = health;

        if(health<=0f)
        {
            Instantiate(destroyEffect, transform.position,Quaternion.identity);
            SoundManager.instance.PlayDestroySound();
            GameOverUiController.instance.OpenGameOverPannel();
            Destroy(gameObject);
        }
        else
        {
            SoundManager.instance.PlayHitSound();
            Instantiate(hitEffect,transform.position,Quaternion.identity);
            //UI
        }
        //SetHealthBar();
    }

    /*void SetHealthBar()
    {
        if (!playerHealthBar)
            return;

        playerHealthBarScale = playerHealthBar.transform.localScale;
        playerHealthBarScale.x = health / 100f;
        playerHealthBar.transform.localScale = playerHealthBarScale;
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag(TagManager.COLLECTABLE_TAG))
        {

            collectable = collision.GetComponent<CollectableScript>();

            if(collectable.type == CollectableType.Health)
            {
                health += collectable.healthValue;
                playerHealthSlider.value = health;

                if(health>maxHealth)
                    health = maxHealth;

                Destroy(collision.gameObject);
            }
        }

        if(collision.CompareTag(TagManager.METEOR_TAG))
        {
            TakeDamage(Random.Range(10, 20));
            Destroy(collision.gameObject);
        }
    }


}//class

























