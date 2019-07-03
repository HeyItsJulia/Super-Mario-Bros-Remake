using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipeWarp : MonoBehaviour
{

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Trigger stay!");
            if (other.GetComponent<PlayerController>() && Input.GetKey(other.GetComponent<PlayerController>().Down)
                || other.GetComponentInParent<PlayerController>() && Input.GetKey(other.GetComponentInParent<PlayerController>().Down))
            {
                Debug.Log("Scene Change!");
                SceneManager.LoadScene("1-1 Underground");
            }
        }
    }
}
