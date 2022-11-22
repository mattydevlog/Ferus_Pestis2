using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

    [Header("Audio Contamination Transitions")]

    [Header("Animal Noise Sound FX")]
    [Tooltip("The contamination level that should trigger the audio curve")]
    [SerializeField] int animalNoiseTriggerLevel = 0;
    bool animalNoiseActive = false;

    [SerializeField] AnimationCurve animalNoiseCurve;
    [SerializeField] float animalNoiseCurveDuration = 2;
    float timerAnimalNoiseCurveDuration = 0;
    [SerializeField] float animalNoiseVolume = 5;
    float currentAnimalNoiseVolume = 0;

    [Header("Player Human Sound FX")]
    [Tooltip("The contamination level that should trigger the audio curve")]
    [SerializeField] int playerHumanTriggerLevel = 0;
    bool playerHumanActive = false;

    [SerializeField] AnimationCurve playerHumanCurve;
    [SerializeField] float playerHumanCurveDuration = 2;
    float timerPlayerHumanCurveDuration = 0;
    [SerializeField] float playerHumanVolume = 10;
    float currentPlayerHumanVolume = 0;

    [Header("Patient Human Sound FX")]
    [Tooltip("The contamination level that should trigger the audio curve")]
    [SerializeField] int patientHumanTriggerLevel = 0;
    bool patientHumanActive = false;

    [SerializeField] AnimationCurve patientHumanCurve;
    [SerializeField] float patientHumanCurveDuration = 2;
    float timerPatientHumanCurveDuration = 0;
    [SerializeField] float patientHumanVolume = 5;
    float currentPatientHumanVolume;

    [Header("Audio Group 3D Max Hearing Distance")]

    [Header("Contamination 0")]
    [SerializeField] float patientDistance0 = 5f;
    [SerializeField] float animalNoiseDistance0 = 5f;

    [Header("Contamination 1")]
    [SerializeField] float patientDistance1 = 10f;
    [SerializeField] float animalNoiseDistance1 = 10f;

    [Header("Contamination 2")]
    [SerializeField] float patientDistance2 = 15f;
    [SerializeField] float animalNoiseDistance2 = 15f;

    [Header("Contamination 3")]
    [SerializeField] float patientDistance3 = 20f;
    [SerializeField] float animalNoiseDistance3 = 20f;

    [Header("Contamination 4")]
    [SerializeField] float patientDistance4 = 30f;
    [SerializeField] float animalNoiseDistance4 = 30f;

    [Header("Required Components")]
    [SerializeField] AudioMixer audioMixer;

    [SerializeField] Contamination_System contaminationSystem;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        audioMixer.GetFloat("AnimalNoiseVolume", out currentAnimalNoiseVolume);
        Debug.Log("At start: " + currentAnimalNoiseVolume);
    }

    private void Update()
    {

        if (!playerHumanActive)
        {
            ActivatePlayerHuman();
        }
        else
        {
            PlayerHumanFadeIn();
        }

        if (!patientHumanActive)
        {
            ActivatePatientHuman();
        }
        else
        {
            PatientHumanFadeIn();
        }

        if (!animalNoiseActive)
        {
            ActivateAnimalNoise();
        }
        else
        {
            AnimalNoiseFadeIn();
        }

    }

    private void ActivatePlayerHuman()
    {
        switch (playerHumanTriggerLevel)
        {
            case 0: //Infected

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level0)
                {
                    playerHumanActive = true;
                }

                break;

            case 1: //Beat 1

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level1)
                {
                    playerHumanActive = true;
                }

                break;

            case 2: //Beat 2

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level2)
                {
                    playerHumanActive = true;
                }

                break;

            case 3: //Beat 3

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level3)
                {
                    playerHumanActive = true;
                }

                break;

            case 4: //Full Transitioned

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level4)
                {
                    playerHumanActive = true;
                }

                break;
        }
    }

    private void ActivatePatientHuman()
    {

        switch (patientHumanTriggerLevel)
        {
            case 0: //Infected

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level0)
                {
                    patientHumanActive = true;
                }

                break;

            case 1: //Beat 1

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level1)
                {
                    patientHumanActive = true;
                }

                break;

            case 2: //Beat 2

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level2)
                {
                    patientHumanActive = true;
                }

                break;

            case 3: //Beat 3

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level3)
                {
                    patientHumanActive = true;
                }

                break;

            case 4: //Full Transitioned

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level4)
                {
                    patientHumanActive = true;
                }

                break;
        }

    }

    private void ActivateAnimalNoise()
    {
        switch (animalNoiseTriggerLevel)
        {
            case 0: //Infected

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level0)
                {
                    animalNoiseActive = true;
                }

                break;

            case 1: //Beat 1

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level1)
                {
                    animalNoiseActive = true;
                }

                break;

            case 2: //Beat 2

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level2)
                {
                    animalNoiseActive = true;
                }

                break;

            case 3: //Beat 3

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level3)
                {
                    animalNoiseActive = true;
                }

                break;

            case 4: //Full Transitioned

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level4)
                {
                    animalNoiseActive = true;
                }

                break;
        }
    }

    private void AnimalNoiseFadeIn()
    {

        if (timerAnimalNoiseCurveDuration < animalNoiseCurveDuration)
        {
            timerAnimalNoiseCurveDuration += Time.deltaTime;

            currentAnimalNoiseVolume = animalNoiseVolume * animalNoiseCurve.Evaluate(timerAnimalNoiseCurveDuration / animalNoiseCurveDuration);
            audioMixer.SetFloat("AnimalNoiseVolume", currentAnimalNoiseVolume);
        }

    }

    private void PlayerHumanFadeIn()
    {

        if (timerPlayerHumanCurveDuration < playerHumanCurveDuration)
        {
            timerPlayerHumanCurveDuration += Time.deltaTime;

            currentPlayerHumanVolume = playerHumanVolume * playerHumanCurve.Evaluate(timerPlayerHumanCurveDuration / playerHumanCurveDuration);
            audioMixer.SetFloat("PlayerHumanVolume", currentPlayerHumanVolume);
        }

    }

    private void PatientHumanFadeIn()
    {

        if (timerPatientHumanCurveDuration < patientHumanCurveDuration)
        {
            if (timerPatientHumanCurveDuration < patientHumanCurveDuration)
            {
                timerPatientHumanCurveDuration += Time.deltaTime;
                currentPatientHumanVolume = patientHumanVolume * patientHumanCurve.Evaluate(timerPatientHumanCurveDuration / patientHumanCurveDuration);
                audioMixer.SetFloat("PatientHumanVolume", currentPatientHumanVolume);
            }
        } //CURRENTPATIENT MUST BE TO SOMETHING NOT 0

    }

    private void GetMaxDistance() ///MAKE SURE THE CONTAMINATION AUDIO CLIP SCRIPT CAN ACCESS AND SET ITS OWN MAX DISTANCE
    {
        Debug.Log("Testing");
    }
}
