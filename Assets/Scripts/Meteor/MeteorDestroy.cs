using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDestroy : MonoBehaviour
{

    


   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(TagManager.COLLECTABLE_TAG))
        {
            Destroy(gameObject);
        }
    }
}
