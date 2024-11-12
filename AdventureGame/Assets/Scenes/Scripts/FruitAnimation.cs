using UnityEngine;

public class FruitAnimation : MonoBehaviour
{
    public Animator animator;  

    void Start()
    {
        // Automatically assigns the Animator if it's not set in the Inspector
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("Player")) 
        {
            //Trigger the collected animation
            animator.SetTrigger("CollectedTrigger");

            //Disable the fruit's collider so it can't be collected again
            GetComponent<Collider>().enabled = false;

            //Destroy the fruit after the animation has played
            Destroy(gameObject, 1f);  // Adjust the delay to match your animation length
        }
    }
}
