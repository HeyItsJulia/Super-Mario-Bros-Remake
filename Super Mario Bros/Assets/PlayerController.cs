﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode jump = KeyCode.W;
    public float speed = 1;
    public float jumpspeed = 5;
    Rigidbody rb;
    public Vector3 respawn;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawn = transform.position;
    }
    public void Respawn()
    {
        transform.position = respawn;
    }

    void CameraFollow()
    {
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, transform.position + Vector3.back * 10, 0.5f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<EnemyAI>())
        {
            Respawn();
        }
        if (collision.transform.GetComponent<Death>())
        {
            Respawn();
        }
    }
    bool OnGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, transform.localScale.y / 2f + 0.1F)
            || Physics.Raycast(transform.position + Vector3.left * 0.5f * transform.localScale.x, Vector3.down, transform.localScale.y / 2f + 0.1f)
            || Physics.Raycast(transform.position + Vector3.right * 0.5f * transform.localScale.x, Vector3.down, transform.localScale.y / 2f + 0.1f);
    }
    void Update()
    {
        Vector3 newVel = rb.velocity;
        if (Input.GetKey(left))
        {
            newVel.x = -speed;
        }
        if (Input.GetKey(right))
        {
            newVel.x = speed;
        }
        if (Input.GetKeyDown(jump) && OnGround())
        {
            newVel.y = jumpspeed; 
        }
        rb.velocity = newVel;
        CameraFollow();
    }
}
