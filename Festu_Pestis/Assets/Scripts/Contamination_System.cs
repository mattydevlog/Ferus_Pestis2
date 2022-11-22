using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contamination_System : MonoBehaviour
{
    public enum Contamination_Beats
    {
        Level0 = 0,
        Level1 = 1,
        Level2 = 2,
        Level3 = 3,
        Level4 = 4
    }

    public static Contamination_Beats currentBeat;


    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float contaminationLevel;

    [SerializeField]
    private float contaminationTimer;

    [SerializeField]
    private bool isContaminated;


    void Start()
    {
        contaminationLevel = 1;
        contaminationTimer = 0;
        isContaminated = false;

    }

    void Update()
    {
        Debug.Log(contaminationTimer);
        if (isContaminated && contaminationTimer < 60)
        {
            contaminationTimer += Time.deltaTime * contaminationLevel;

            switch (contaminationTimer)
            {
                case < 15f:
                    currentBeat = Contamination_Beats.Level0;
                    Debug.Log("You are coughing");
                    break;

                case < 30f:
                    currentBeat = Contamination_Beats.Level1;
                    Debug.Log("You hear Heartbeats");
                    break;

                case < 45f:
                    currentBeat = Contamination_Beats.Level2;
                    Debug.Log("You see a black Vignette");
                    break;

                case < 60f:
                    currentBeat = Contamination_Beats.Level3;
                    Debug.Log("You see a red Vignette");
                    break;

                case >= 60f:
                    currentBeat = Contamination_Beats.Level4;
                    Debug.Log("You are now a beast");
                    break;
            }
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        isContaminated = true;
    }

    public Contamination_Beats CurrentBeats()
    {
        return currentBeat;
    }
}


