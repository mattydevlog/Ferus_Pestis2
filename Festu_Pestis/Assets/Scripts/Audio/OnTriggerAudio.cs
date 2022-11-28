using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerAudio : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool playOnce = true;
    bool audioPlayed = false;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();    
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (!playOnce)
            {
                audioSource.Play();
            } 
            else if(playOnce && !audioPlayed)
            {
                audioSource.Play();
                audioPlayed = true;
            }
            
        }

    }
}
