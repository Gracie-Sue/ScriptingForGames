using UnityEngine;

public class DamageTriggerHandler : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage to deal

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger has the PlayerHealth script
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            // Apply damage to the player
            playerHealth.TakeDamage(damageAmount);
            Debug.Log("Player took damage!");
        }
    }
}
