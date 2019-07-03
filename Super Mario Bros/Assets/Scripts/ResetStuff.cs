using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStuff : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.fromPipe = false;
        }
    }
}
