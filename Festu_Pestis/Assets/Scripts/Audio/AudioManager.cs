using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Contamination Transitions")]

    [Header("Flies Sound FX")]
    [SerializeField] AnimationCurve fliesCurve;
    [SerializeField] float fliesCurveDuration = 2;
    float timerFliesCurveDuration = 0;

    [SerializeField] float fliesVolume = 5;
    float currentFliesVolume = 0;

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

        if(timerPlayerHumanCurveDuration < playerHumanCurveDuration)
        {
            PlayerHumanFadeIn();
            Debug.Log(currentPlayerHumanVolume);
        }

        if(timerPatientHumanCurveDuration < patientHumanCurveDuration)
        {
            PatientHumanFadeIn();
        }

        if(timerFliesCurveDuration < fliesCurveDuration)
        {
            FliesFadeIn();
        }

    }

    private void FliesFadeIn()
    {
        timerFliesCurveDuration += Time.deltaTime;

        currentFliesVolume = fliesVolume * fliesCurve.Evaluate(timerFliesCurveDuration / fliesCurveDuration);
        audioMixer.SetFloat("FliesVolume", currentFliesVolume);
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
