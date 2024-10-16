using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public Animator animator;  // Reference to the Animator component

    // Method to apply damage to the player
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player Health: " + health);

        // Trigger the hit animation
        animator.SetTrigger("HitTrigger");

        if (health <= 0)
        {
            Debug.Log("Player has died.");
            // Optionally, trigger death animation or handle player death
            // animator.SetTrigger("Die");
        }
    }
}