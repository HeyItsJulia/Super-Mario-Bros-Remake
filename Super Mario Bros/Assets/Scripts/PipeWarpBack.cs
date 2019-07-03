using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipeWarpBack : MonoBehaviour
{

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Trigger stay!");
            if (other.GetComponent<PlayerController>() && Input.GetKey(other.GetComponent<PlayerController>().right)
                || other.GetComponentInParent<PlayerController>() && Input.GetKey(other.GetComponentInParent<PlayerController>().right))
            {
                Debug.Log("Scene Change!");
                PlayerController.fromPipe = true;
                SceneManager.LoadScene("Level 1-1");
            }
        }
    }
}
