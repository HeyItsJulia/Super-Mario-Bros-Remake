// DeathbyMario.cs
// Created: 6/28/2019
// Owner: Lawrence Lundblad
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathbyMario : MonoBehaviour
{
    void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<PlayerController>())
        {
            Rigidbody otherRB = collision.transform.GetComponent<Rigidbody>();
            Rigidbody myRB = GetComponent<Rigidbody>();
            if (otherRB && myRB && otherRB.velocity.y > myRB.velocity.y)
            {
                Die();
            }
        }
    }
}
