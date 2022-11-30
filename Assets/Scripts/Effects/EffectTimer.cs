using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTimer : MonoBehaviour
{
    [SerializeField]
    private float timer;


    private void Start()
    {
        Destroy(gameObject,timer);
    }

}//class























