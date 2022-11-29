using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contamination_System : MonoBehaviour
{
    public enum Contamination_Beats
    {

        NotContaminated,
        Level0 = 1,
        Level1 = 2,
        Level2 = 3,
        Level3 = 4,
        Level4 = 5
    }

    public static Contamination_Beats currentBeat;


    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float contaminationMultiplier;

    [SerializeField]
    public static float contaminationTimer;

    [SerializeField]
    public static bool isContaminated;

    [SerializeField]
    private const float contaminationCase0 = 30f;


    [SerializeField]
    private const float contaminationCase1 = 60f;


    [SerializeField]
    private const float contaminationCase2 = 90f;


    [SerializeField]
    private const float contaminationCase3 = 120f;

    [SerializeField]
    private const float contaminationCase4 = 120f;




    void Start()
    {
        contaminationMultiplier = 0.5f;
        contaminationTimer = 85;
        isContaminated = false;
        currentBeat = Contamination_Beats.NotContaminated;

    }

    void Update()
    {
        // contaminationCase = contaminationTimer;



       // Debug.Log(currentBeat);
        // Debug.Log(contaminationTimer);
        if (isContaminated && contaminationTimer < 120)
        {
            contaminationTimer += Time.deltaTime * contaminationMultiplier;

            switch (contaminationTimer)
            {
                case < contaminationCase0:
                    currentBeat = Contamination_Beats.Level0;
                    // Debug.Log("You are coughing");
                    break;

                case < contaminationCase1:
                    currentBeat = Contamination_Beats.Level1;
                    //   Debug.Log("You hear Heartbeats");
                    break;

                case < contaminationCase2:
                    currentBeat = Contamination_Beats.Level2;
                    //  Debug.Log("You see a black Vignette");
                    break;

                case < contaminationCase3:
                    currentBeat = Contamination_Beats.Level3;
                    // Debug.Log("You see a red Vignette");

                    break;

                case >= contaminationCase4:
                    currentBeat = Contamination_Beats.Level4;

                    //  Debug.Log("You are now a beast");
                    break;
            }
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        isContaminated = true;

        Contamination_effects.nextCough = Time.time + Contamination_effects.preDelay;


    }

    public Contamination_Beats CurrentBeats()
    {
        return currentBeat;

    }

    public float CurrentTime()
    {
        return contaminationTimer;
    }
}


