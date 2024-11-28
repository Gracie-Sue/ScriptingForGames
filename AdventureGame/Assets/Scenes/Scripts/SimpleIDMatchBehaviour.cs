using UnityEngine;
using UnityEngine.Events;

public class SimpleIDMatchBehaviour : MonoBehaviour
{
    public Id id;                    // The unique ID for this object (fire)
    public UnityEvent matchEvent, noMatchEvent; // Events for when matching or no match
    public Animator fireAnimator;     // Reference to the fire's Animator

    private void OnTriggerEnter(Collider other)
    {
        var otherID = other.GetComponent<SimpleIDBehaviour>();

        if (otherID != null && otherID.id == id) // Check if the IDs match
        {
            matchEvent.Invoke(); // Trigger match event if IDs match
            Debug.Log("Matched ID: " + id);

            // Disable the fire animation (change it to an idle or deactivated state)
            if (fireAnimator != null)
            {
                fireAnimator.SetTrigger("Deactivate"); // Ensure you have a "Deactivate" trigger in the fire's Animator
            }

            // Disable the fire's damaging collider (or any damage component)
            var fireCollider = GetComponent<BoxCollider>(); // Assuming the fire uses a BoxCollider
            if (fireCollider != null)
            {
                fireCollider.enabled = false; // Disable the fire's collider to stop damage
            }

            // Destroy the key after it has been matched with the fire
            Destroy(other.gameObject); // This will destroy the key once it's used
        }
        else
        {
            noMatchEvent.Invoke(); // Trigger no match event if IDs do not match
            Debug.Log("No Match: " + id);
        }
    }
}