using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnaround : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<EnemyAI>())
        {
            other.GetComponent<EnemyAI>().speed *= 1;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, Vector3.one);
    }
}
