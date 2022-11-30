using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioClip destroySound;

    [SerializeField]
    private AudioClip hitSound;

    [SerializeField]
    private AudioClip[] pickUpSound;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void PlayDestroySound()
    {
        AudioSource.PlayClipAtPoint(destroySound, transform.position);
    }

    public void PlayHitSound()
    {
        AudioSource.PlayClipAtPoint(hitSound,transform.position);
    }

    public void PlayPickUpSound()
    {
        if(Random.Range(0,2)>0)
        {
            AudioSource.PlayClipAtPoint(pickUpSound[0], transform.position);
        }
        else
        {
            AudioSource.PlayClipAtPoint(pickUpSound[1], transform.position);

        }
    }





}//class



































