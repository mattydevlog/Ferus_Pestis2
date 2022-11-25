using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceController : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private bool audio3D = true;
    [Tooltip("The time in seconds for which the audio clip should play during the contamination meter. A value of -1 means a desired play time has not been set.")]
    [SerializeField] [Range(0, 120)] int playTriggerTime = -1;
    [Tooltip("The time in seconds for which the audio clip should stop during the contamination meter. A value of -1 means a desired stop time has not been set.")]
    [SerializeField] [Range(0, 120)] int playStopTime = -1;

    [SerializeField] Contamination_System contaminationSystem;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (audio3D)
        {
           UpdateMaxDistance();
        }
        
        if(playTriggerTime > -1)
        {
            if(playTriggerTime == contaminationSystem.CurrentTime())
            {

            }
        }

    }

    private void UpdateMaxDistance()
    {
        audioSource.maxDistance = AudioManager.Instance.GetMaxDistance(audioSource.outputAudioMixerGroup.ToString());
    }

    private void PlayAudioClip()
    {
        audioSource.Play();
    }

    private void StopAudioClip()
    {
        audioSource.Stop();
    }
     
}
