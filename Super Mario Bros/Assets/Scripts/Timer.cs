using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeStart = 60;
    public Text textBox;
    public Vector3 respawn;
    // Use this for initialization
    void Start()
    {
        textBox.text = timeStart.ToString();

    }
    public void Respawn()
    {
        transform.position = respawn;
        ResetCam();
    }
    public void ResetCam()
    {
        Camera.main.transform.position = new Vector3(transform.position.x + 11, 0, -10);
    }
    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        textBox.text = Mathf.Round(timeStart).ToString();

        if (timeStart == 0)
        {
            Respawn();
        }
    }
    
}
