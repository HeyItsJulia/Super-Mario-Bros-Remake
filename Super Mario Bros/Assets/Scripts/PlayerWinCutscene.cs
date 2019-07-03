using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWinCutscene : MonoBehaviour
{
    Rigidbody rb;
    public float delay = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 newVel = rb.velocity;
        newVel.x = 1;
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            SceneManager.LoadScene("High Scores");
        }
    }
}
