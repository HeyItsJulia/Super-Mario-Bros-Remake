using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHitDetection : UnityEngine.MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision!");
        if (other.tag == "Player")
        {
            Debug.Log("With Player!");
            SendMessageUpwards("SpawnItem");
        }
    }
}
