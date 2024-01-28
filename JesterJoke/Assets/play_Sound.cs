using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class play_Sound : MonoBehaviour
{
    AudioSource soundSource;

    // Start is called before the first frame update
    void Start()
    {
        soundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound(AudioClip theSound)
    {
        soundSource.PlayOneShot(theSound); 
    }
}
