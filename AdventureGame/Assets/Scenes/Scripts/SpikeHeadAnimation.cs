using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHeadAnimation : MonoBehaviour
{
    public Animator spikeHeadAnimator; // The animator for the SpikeHead's animations

    void Start()
    {
        // Automatically assigns the Animator for SpikeHead if it's not set in the Inspector
        if (spikeHeadAnimator == null)
        {
            spikeHeadAnimator = GetComponent<Animator>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Trigger the hit animation for the SpikeHead
            spikeHeadAnimator.SetTrigger("SpikeHeadHit");

            // Disable the SpikeHead's collider so it can't be triggered again
            GetComponent<Collider>().enabled = false;

            // Destroy the SpikeHead after the animation has played
            Destroy(gameObject, 1f);  // Adjust the delay to match your SpikeHeadHit animation length
        }
    }
}
