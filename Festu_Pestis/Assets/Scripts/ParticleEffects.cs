using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParticleEffects : MonoBehaviour
{

    [SerializeField]
    GameObject patientHeart;

    [SerializeField]
    GameObject patient;

    public bool hasSpawned = false;


    private void Start()
    {
        // patientHeart.SetActive(false);

    }

    void Update()
    {
        if (Contamination_System.isContaminated && Contamination_System.contaminationTimer > 90 && !hasSpawned)
        {
            Debug.Log("has spawned");
            Instantiate(patientHeart, patient.transform.position, Quaternion.identity);
            hasSpawned = true;
        }

    }
}
