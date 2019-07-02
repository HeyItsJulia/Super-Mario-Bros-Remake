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
    bool canMove = false;

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
        Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
        if (!canMove && sp.x <= Screen.width + 32 && sp.x >= -32)
        {
            canMove = true;
            Debug.Log("In View! " + Mathf.Abs(transform.position.x - Camera.main.transform.position.x) + "<=" + Screen.width / 2f);
        }
        if (canMove)
            rb.velocity = new Vector3(speed, rb.velocity.y, 0);
        else
            rb.velocity = Vector3.zero;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (rb)
            Gizmos.DrawLine(transform.position, transform.position + rb.velocity);
    }
}

