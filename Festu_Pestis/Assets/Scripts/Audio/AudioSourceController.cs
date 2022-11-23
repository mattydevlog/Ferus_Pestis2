using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceController : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        UpdateMaxDistance();
    }

    private void UpdateMaxDistance()
    {
        audioSource.maxDistance = AudioManager.Instance.GetMaxDistance(audioSource.outputAudioMixerGroup.ToString());
    }
     
}
