using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParticleEffects1 : MonoBehaviour
{

    [SerializeField]
    GameObject footsteps;



    private void Start()
    {
        footsteps.SetActive(false);

    }

    void Update()
    {
        if (Contamination_System.isContaminated && Contamination_System.contaminationTimer > 90)
        {
      
            footsteps.SetActive(true);
        }

    }
}
