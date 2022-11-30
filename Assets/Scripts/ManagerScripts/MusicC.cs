using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicC : MonoBehaviour
{

    public static MusicC instance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}//class





















