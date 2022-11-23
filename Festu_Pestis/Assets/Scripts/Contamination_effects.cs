using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Contamination_effects : MonoBehaviour
{
    [SerializeField]
    private float coughRate = 2f;
    [SerializeField]
    private float nextCough = 0.0f;
    [SerializeField]
    private float coughDuration = 1f;


    private float timerCoughDuration = 0f;

    private bool isCoughing;

    [SerializeField]
    private float normalSpeed = 4.0f;

    [SerializeField]
    private float coughMovementSpeed = 2.0f;

    [SerializeField]
    private float wolfSpeed = 100.0f;

    [SerializeField]
    private float preDelay = 3.0f;


    [SerializeField]
    private AudioSource cough;

    public static bool isWolf;

    void Start()
    {
        isCoughing = false;
        isWolf = false;

    }


    void Update()
    {
        if (Contamination_System.isContaminated && Contamination_System.contaminationTimer <= 15)
        {
            Cough();
        }

        if (isCoughing)
        {
            timerCoughDuration += Time.deltaTime;

            if (timerCoughDuration >= coughDuration)
            {
                StopCoughing();
            }
        }
        if (Contamination_System.isContaminated && Contamination_System.contaminationTimer >= 60)
        {
            WolfMode();
            isWolf = true;
        }

    }


    void Cough()
    {


        if (Time.time > nextCough && !isCoughing)
        {


            isCoughing = true;
            FirstPersonController.MoveSpeed = coughMovementSpeed;
            cough.Play();
            Debug.Log("You coughed");

        }
    }

    void StopCoughing()
    {
        nextCough = Time.time + coughRate;
        timerCoughDuration = 0;
        FirstPersonController.MoveSpeed = normalSpeed;
        cough.Stop();
        isCoughing = false;

    }

    void WolfMode()
    {
        FirstPersonController.MoveSpeed = wolfSpeed;
        Debug.Log("Fast!");
    }
}
