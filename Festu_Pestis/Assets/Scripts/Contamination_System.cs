using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contamination_System : MonoBehaviour
{
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
        if (isContaminated)
        {
            contaminationTimer += Time.deltaTime * contaminationLevel;
        }

        if (contaminationTimer >= 60)
        {
            isContaminated = false;
            Debug.Log("You died");
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        isContaminated = true;

    }

}
