using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Contamination Transitions")]

    [Header("Animal Noise Sound FX")]
    [SerializeField] AnimationCurve animalNoiseCurve;
    [SerializeField] float animalNoiseCurveDuration = 2;
    float timerAnimalNoiseCurveDuration = 0;

    [SerializeField] float animalNoiseVolume = 5;
    float currentAnimalNoiseVolume = 0;

    [Header("Player Human Sound FX")]
    [SerializeField] AnimationCurve playerHumanCurve;
    [SerializeField] float playerHumanCurveDuration = 2;
    float timerPlayerHumanCurveDuration = 0;

    [SerializeField] float playerHumanVolume = 10;
    float currentPlayerHumanVolume = 0;

    [Header("Patient Human Sound FX")]
    [SerializeField] AnimationCurve patientHumanCurve;
    [SerializeField] float patientHumanCurveDuration = 2;
    float timerPatientHumanCurveDuration = 0;

    [SerializeField] float patientHumanVolume = 5;
    float currentPatientHumanVolume;

    [Header("Required Components")]
    [SerializeField] AudioMixer audioMixer;

    private void Update()
    {

        if (timerPlayerHumanCurveDuration < playerHumanCurveDuration)
        {
            PlayerHumanFadeIn();
            Debug.Log(currentPlayerHumanVolume);
        }

        if (timerPatientHumanCurveDuration < patientHumanCurveDuration)
        {
            PatientHumanFadeIn();
        }

        if (timerAnimalNoiseCurveDuration < animalNoiseCurveDuration)
        {
            AnimalNoiseFadeIn();
        }

    }

    private void AnimalNoiseFadeIn()
    {
        timerAnimalNoiseCurveDuration += Time.deltaTime;

        currentAnimalNoiseVolume = animalNoiseVolume * animalNoiseCurve.Evaluate(timerAnimalNoiseCurveDuration / animalNoiseCurveDuration);
        audioMixer.SetFloat("AnimalNoiseVolume", currentAnimalNoiseVolume);
    }

    private void PlayerHumanFadeIn()
    {
        timerPlayerHumanCurveDuration += Time.deltaTime;

        currentPlayerHumanVolume = playerHumanVolume * playerHumanCurve.Evaluate(timerPlayerHumanCurveDuration / playerHumanCurveDuration);
        audioMixer.SetFloat("PlayerHumanVolume", currentPlayerHumanVolume);
    }

    private void PatientHumanFadeIn()
    {
        timerPatientHumanCurveDuration += Time.deltaTime;

        currentPatientHumanVolume = patientHumanVolume * patientHumanCurve.Evaluate(timerPatientHumanCurveDuration / patientHumanCurveDuration);
        audioMixer.SetFloat("PatientHumanVolume", currentPatientHumanVolume);
    }
}
