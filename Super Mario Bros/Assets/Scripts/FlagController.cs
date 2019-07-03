using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    Rigidbody rb;
    public float delay = 2f;
    private void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "Player")
        {

            Vector3 newVel = rb.velocity;
            newVel.x = 1;
            delay -= Time.deltaTime;
            if (delay <= 0)
            {

            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
