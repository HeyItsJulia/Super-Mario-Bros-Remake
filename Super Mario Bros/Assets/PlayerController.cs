// PlayerController.cs
// Created: 6/28/2019
// Owner: Julia Lundblad
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode jump = KeyCode.W;
    public float speed = 1;
    public float jumpspeed = 9;
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
        Camera.main.transform.position = new Vector3(respawn.x + 5, 0, -10);
    }

    void CameraFollow()
    {
        if (Camera.main.transform.position.x < transform.position.x)
            Camera.main.transform.position = Vector3.Lerp(new Vector3(Camera.main.transform.position.x, 0, -10), transform.position + Vector3.back * 10, 0.5f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<EnemyAI>())
        {
            Rigidbody otherRB = collision.transform.GetComponent<Rigidbody>();
            Rigidbody myRB = GetComponent<Rigidbody>();
            if (otherRB && myRB && otherRB.velocity.y >= myRB.velocity.y)
            {
                Respawn();
            }
        }
        if (collision.transform.GetComponent<Death>())
        {
            Respawn();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerStop")
        {
            Vector3 v = rb.velocity;
            v.x = 0;
            rb.velocity = v;
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
        if (OnGround())
            newVel *= 0.5f;
        rb.velocity = newVel;
        CameraFollow();
    }
}
