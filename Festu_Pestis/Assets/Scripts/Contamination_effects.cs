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

    [Header("Movement Speed Curve")] 
    
    [SerializeField] Contamination_System contaminationSystem;
    
    [SerializeField] [Range(0, 4)] int MovementTriggerLevel = 0;
    
    bool movementActive = false;
    
    [SerializeField] AnimationCurve movementCurve;
    [SerializeField] float movementDuration = 10;
    float timerMovement = 0;

    [SerializeField] float maxMovementSpeed = 8f;
    [SerializeField] float currentMovementSpeed = 0;

    [Header("Movement Values")]
    
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
        //Active Check Movement Curve
        if (!movementActive)
        {
            ActivateMovement();
        }
        else
        {
            MovementFadeIn();
        }


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
    
    //Movement Curve
    
    private void ActivateMovement()
    {
          switch (MovementTriggerLevel) 
          {
            case 0: //Infected

             if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level0)
             {
                 movementActive = true;
             }

             break;

             case 1: //Beat 1

            if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level1)
            {
                movementActive  = true;
            }

            break;

            case 2: //Beat 2

            if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level2)
            {
                movementActive  = true;
            }

            break;

             case 3: //Beat 3

            if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level3)
            {
                movementActive  = true;
            }

            break;

           case 4: //Full Transitioned

            if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level4)
            {
                movementActive  = true;
            }

            break;
         }
    }
    
    private void MovementFadeIn()
    {
        if(timerMovement  < movementDuration)
        {
            timerMovement += Time.deltaTime;

            currentMovementSpeed = maxMovementSpeed * movementCurve.Evaluate(timerMovement / movementDuration);
            FirstPersonController.MoveSpeed = currentMovementSpeed;
            
        }
        
    }
}
