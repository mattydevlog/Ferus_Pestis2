using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffects : MonoBehaviour
{

    [SerializeField]
    GameObject patientHeart;

    [SerializeField]
    GameObject patient;

    [SerializeField]
    GameObject bloodyFootsteps;

    [SerializeField]
    GameObject spawnPointFootsteps;

    // Update is called once per frame
    void Update()
    {
        if (Contamination_System.isContaminated && Contamination_System.contaminationTimer > 90)
        {
            Instantiate(patientHeart, patient.transform.position , Quaternion.identity);

        }

        if (Contamination_System.isContaminated && Contamination_System.contaminationTimer > 120)
        {
            Instantiate(bloodyFootsteps, spawnPointFootsteps.transform.position, Quaternion.identity);
        }

    }
}
