using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBurstTrigger : MonoBehaviour
{
    public ParticleSystem particleSystem;  // Reference to the ParticleSystem
    public float timeBetweenBursts = 0.5f; // Time between each burst
    public int burstsCount = 3;            // How many bursts to trigger

    void Start()
    {
        if (particleSystem == null)
        {
            particleSystem = GetComponentInChildren<ParticleSystem>(); // Ensure it's set
        }
    }

    // This method starts the burst sequence
    public void StartParticleBurst()
    {
        StartCoroutine(EmitParticleBurst());
    }

    // Coroutine to emit particle bursts
    private IEnumerator EmitParticleBurst()
    {
        for (int i = 0; i < burstsCount; i++)
        {
            particleSystem.Emit(20);  // Emit a burst of 20 particles
            yield return new WaitForSeconds(timeBetweenBursts); // Wait between bursts
        }
    }

    // Example Trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartParticleBurst();  // Start the particle bursts when the player touches
        }
    }
}
