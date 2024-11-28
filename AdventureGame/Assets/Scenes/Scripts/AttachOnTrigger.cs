using UnityEngine;

public class AttachOnTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Only attach the key to the player
        {
            transform.parent = other.transform; // Attach the key to the player
            gameObject.SetActive(true); // Ensure the key is visible and active
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Only detach if it's the player
        {
            transform.parent = null; // Detach the key
        }
    }
}