using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleNavMeshAgent : MonoBehaviour
{
    public Transform target; // Assign the target point in the inspector
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; // Disables automatic rotation for 2D
        SnapToNavMesh(); // Call the method to snap the character to the NavMesh at start
    }

    private void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    // Snaps the character to the nearest point on the NavMesh
    private void SnapToNavMesh()
    {
        NavMeshHit hit;
        // Use the character's position to find the closest valid position on the NavMesh
        if (NavMesh.SamplePosition(transform.position, out hit, 1.0f, NavMesh.AllAreas))
        {
            transform.position = hit.position; // Move the character to the valid position
        }
    }
}
