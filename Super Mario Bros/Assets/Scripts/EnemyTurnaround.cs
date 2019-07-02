// EnemyTurnaround.cs
// Crated: 6/28/2019
// Owner: Lawrence Lundblad
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnaround : UnityEngine.MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<EnemyAI>())
        {
            other.GetComponent<EnemyAI>().speed *= -1;
        }

        if (other.GetComponent<MushroomPhisics>())
        {
            other.GetComponent<MushroomPhisics>().speed *= -1;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, Vector3.one);
    }
}
