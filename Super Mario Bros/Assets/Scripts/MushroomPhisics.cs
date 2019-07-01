using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MushroomPhisics.cs
// 7/1/19
// Isaac Richards 

public class MushroomPhisics : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInParent<PlayerController>().getPowerUp();
            Destroy(gameObject);
        }
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
