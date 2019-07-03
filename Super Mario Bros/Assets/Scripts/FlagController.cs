using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().enabled = false;
            other.gameObject.AddComponent<PlayerWinCutscene>();
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
