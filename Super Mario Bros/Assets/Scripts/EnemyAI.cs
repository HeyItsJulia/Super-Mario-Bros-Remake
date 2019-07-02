// EnemyAI.cs
// Created: 6/28/2019
// Owner: Lawrence Lundblad
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 3;

    public void Die()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (rb)
            Gizmos.DrawLine(transform.position, transform.position + rb.velocity);
    }
}

