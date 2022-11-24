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
    public static float nextCough = 0.0f;
    [SerializeField]
    private float coughDuration = 2f;


    private float timerCoughDuration = 0f;

    private bool isCoughing;

    [SerializeField]
    private float normalSpeed = 4.0f;

    [SerializeField]
    private float coughMovementSpeed = 2.0f;

    [SerializeField]
    private float wolfSpeed = 100.0f;

    [SerializeField]
    public static float preDelay = 3.0f;


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
     
       

        if (Contamination_System.isContaminated && Contamination_System.contaminationTimer <= 30)
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
        if (Contamination_System.isContaminated && Contamination_System.contaminationTimer >= 120)
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
