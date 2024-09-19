using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // This is the correct signature for detecting collisions in Unity.
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.name);
    }
}