using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerAnimation : MonoBehaviour
{
    bool isPlayed = false;
    [SerializeField] private Animator werewolfAnimator = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPlayed)
        {
            werewolfAnimator.Play("WerewolfAggro", 0, 0f);
            isPlayed = true;
        }

    }
}
