using UnityEngine;

void OnCollisionEnter(Collision collision)
{
    Debug.Log("Collision detected with " + collision.gameObject.name);
}