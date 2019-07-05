// PlayerController.cs
// Created: 6/28/2019
// Owner: Julia Lundblad
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : UnityEngine.MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    

    public enum PowerUpState
    {
        small,
        big,
        fire,
    }
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode jump = KeyCode.W;
    public KeyCode Down = KeyCode.S;
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
    public static int lives = -1;
    public Text livesDisplay;
    public static int score = 0;
    public Text scoreDisplay;
    public static bool fromPipe;
    public Transform pipeToComeFrom;
         

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawn = transform.position;
        getPowerUp(PowerUpState.small);
        if (lives < 0)
        {
            lives = 3;
            score = 0;
        }
         if (fromPipe && pipeToComeFrom)
        {
            transform.position = pipeToComeFrom.position + Vector3.up * 2;
            fromPipe = false;
        }
        ResetCam();
    }

    public void Respawn()
    {
        lives--;
        ResetCam();
        score = 0;
        FindObjectOfType<Timer>().ResetTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            if (powerUp == PowerUpState.small)
            {
                Rigidbody otherRB = collision.transform.GetComponent<Rigidbody>();
                Rigidbody myRB = GetComponent<Rigidbody>();
                if (myRB && vel.y >= 0)
                {
                    Respawn();
                    getPowerUp(PowerUpState.small);
                    
                }
                else
                {
                    collision.transform.GetComponent<EnemyAI>().Die();
                    score += 100;
                }
            }
            else if (powerUp == PowerUpState.big)
            {
                Rigidbody otherRB = collision.transform.GetComponent<Rigidbody>();
                Rigidbody myRB = GetComponent<Rigidbody>();
                if (myRB && vel.y >= 0)
                {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
=======

>>>>>>> Stashed changes
                    getPowerUp(PowerUpState.small);

                }
                else
                {
                    collision.transform.GetComponent<EnemyAI>().Die();
                    score += 100;
                }
            }
        }
                
        else if (collision.transform.GetComponent<Death>())
        {
            Respawn();
            getPowerUp(PowerUpState.small);
            
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
            newVel.x *= 0.8f;
        vel = rb.velocity = newVel;
        CameraFollow();
        if (scoreDisplay)
            scoreDisplay.text = "Score: " + score.ToString();
        if (livesDisplay)
            livesDisplay.text = "Lives: " + lives.ToString();
        if (lives == 0)
        {
            SceneManager.LoadScene("Game Over");
            lives = 3;
            score = 0;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButton ("Jump"))
        {
            rb.velocity += Vector3.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
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
        {
            score += 1000;
            getPowerUp(PowerUpState.big);
        }
           

    }
    public void powerDown()
    {
        getPowerUp(PowerUpState.small);
    }

}



