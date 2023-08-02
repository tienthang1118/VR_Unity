using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    //public AudioClip mainSound;
    public AudioClip imageSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //audioSource.PlayOneShot(imageSound);
    }

    public void PlayImageSound()
    {
        audioSource.PlayOneShot(imageSound);
    }
}
