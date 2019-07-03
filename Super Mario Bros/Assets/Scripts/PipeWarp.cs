using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PipeWarp : MonoBehaviour
{
    Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.attachedRigidbody == true)
            {
                Debug.Log("true");
            }
            
            
        }
    }
}
