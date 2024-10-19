using UnityEngine;
using UnityEngine.Events;

public class SimpleTriggerEventBehaviour : MonoBehaviour
{
    public UnityEvent triggerEvent;

    private Animator animator; // Reference to the Animator

    private void Start()
    {
        // Get the Animator component attached to the GameObject
        // If the Animator is on a different GameObject, adjust accordingly
        animator = GetComponent<Animator>();
        
        // If the Animator is on a different GameObject, you can use:
        // animator = transform.parent.GetComponent<Animator>(); // If on parent
        // animator = transform.GetChild(0).GetComponent<Animator>(); // If on first child
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Trigger the event and test with a debug message
            triggerEvent.Invoke();
            Debug.Log("Player interacted with the object!");

            // Call the Hit trigger on the Animator
            if (animator != null)
            {
                animator.SetTrigger("Hit");
            }
            else
            {
                Debug.LogWarning("Animator component not found!");
            }
        }
    }
}
