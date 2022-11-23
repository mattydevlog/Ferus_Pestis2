using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Contamination_effects : MonoBehaviour
{
    [SerializeField]
    private float coughRate = 5f;
    [SerializeField]
    private float nextCough = 0.0f;
    [SerializeField]
    private float coughDuration = 1.5f;

    private float timerCoughDuration = 0;

    private bool isCoughing;

    [SerializeField]
    private AudioSource cough;

    void Start()
    {
        isCoughing = false;
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
    }


    void Cough()
    {
        if (Time.time > nextCough)
        {
            
            nextCough = Time.time + coughRate;
            Debug.Log("You coughed");
            isCoughing = true;
            FirstPersonController.MoveSpeed = 2.0f;
            cough.Play();

            //Set new movespeed here
            //Play Coughsound
        }

    }

    void StopCoughing()
    {
        timerCoughDuration = 0;
        FirstPersonController.MoveSpeed = 4.0f;
        cough.Pause();
        //Reset movespeed here
    }
}
