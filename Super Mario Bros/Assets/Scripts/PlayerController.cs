// PlayerController.cs
// Created: 6/28/2019
// Owner: Julia Lundblad
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PowerUpState
    {
        small,
        big,
        fire,
    }
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode jump = KeyCode.W;
    public float speed = 1;
    public float jumpspeed = 9;
    Rigidbody rb;
    public Vector3 respawn;
    bool wasOnGround = false;
    PowerUpState powerUp;
    public GameObject smallMario;
    public GameObject bigMario;
    GameObject currentMario;
    Vector3 vel;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawn = transform.position;
        getPowerUp(PowerUpState.small);
    }
    public void Respawn()
    {
        transform.position = respawn;
        ResetCam();
    }
    
    public void ResetCam()
    {
        Camera.main.transform.position = new Vector3(transform.position.x + 11, 0, -10);
    }

    void CameraFollow()
    {
        if (Camera.main.transform.position.x < transform.position.x)
        {
            Vector3 destination = transform.position + Vector3.back * 10;
            destination.y = 0;
            Camera.main.transform.position = Vector3.Lerp(new Vector3(Camera.main.transform.position.x, 0, -10), destination, 0.5f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<EnemyAI>())
        {
            Rigidbody otherRB = collision.transform.GetComponent<Rigidbody>();
            Rigidbody myRB = GetComponent<Rigidbody>();
            if (myRB && vel.y >= 0)
            {
                Respawn();
            }
            else
            {
                collision.transform.GetComponent<EnemyAI>().Die();
            }
        }
        else if (collision.transform.GetComponent<Death>())
        {
            Respawn();
        }
        
    }

    bool OnGround(out RaycastHit hit)
    {
        if (powerUp == PowerUpState.small)
            return Physics.Raycast(transform.position, Vector3.down, out hit, transform.localScale.y / 2f + 0.1F)
                || Physics.Raycast(transform.position + Vector3.left * 0.5f * transform.localScale.x, Vector3.down, out hit, transform.localScale.y / 2f + 0.1f)
                || Physics.Raycast(transform.position + Vector3.right * 0.5f * transform.localScale.x, Vector3.down, out hit, transform.localScale.y / 2f + 0.1f);
        else
            return Physics.Raycast(transform.position, Vector3.down, out hit, (transform.localScale.y * 2) / 2f + 0.1F)
                || Physics.Raycast(transform.position + Vector3.left * 0.5f * transform.localScale.x, Vector3.down, out hit, (transform.localScale.y * 2) / 2f + 0.1F)
                || Physics.Raycast(transform.position + Vector3.right * 0.5f * transform.localScale.x, Vector3.down, out hit, (transform.localScale.y * 2) / 2f + 0.1F);
    }
    bool OnGround()
    {
        RaycastHit hit;
        return OnGround(out hit);
    }

    void Update()
    {
        RaycastHit hit;
        if (!wasOnGround && (wasOnGround = OnGround(out hit)))
        {
            if (powerUp == PowerUpState.small)
                transform.position += Vector3.down * (hit.distance - transform.localScale.y / 2f);
            else
                transform.position += Vector3.down * (hit.distance - transform.localScale.y);
            rb.useGravity = false;
        }
        else if (!OnGround())
        {
            wasOnGround = false;
            rb.useGravity = true;
        }
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
            newVel.x *= 0.5f;
        vel = rb.velocity = newVel;
        CameraFollow();
    }
    public void getPowerUp(PowerUpState newState)
    {
        powerUp = newState;
        if (currentMario)
            Destroy(currentMario);
        if (powerUp == PowerUpState.small)
            currentMario = Instantiate(smallMario);
        else if (powerUp == PowerUpState.big)
            currentMario = Instantiate(bigMario);
        currentMario.transform.parent = transform;
        currentMario.transform.localPosition = Vector3.zero;
    }

    public void getPowerUp()
    {
        if (powerUp == PowerUpState.small)
            getPowerUp(PowerUpState.big);
        else if (powerUp == PowerUpState.big)
            getPowerUp(PowerUpState.fire);

    }
    public void powerDown()
    {
        getPowerUp(PowerUpState.small);
    }
}



