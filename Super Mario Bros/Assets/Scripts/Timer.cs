// Timer.cs
// Created: 7/2/2019
// Owner: Julia Lundblad

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public int startTime = 5;
    int timeLeft;
    public Text countdownText;
   
    // Use this for initialization
    void Start()
    {
        StartCoroutine("LoseTime");
        ResetTime();
    }

  
    
    // Update is called once per frame
    void Update()
    {
        countdownText.text = ("Time Left = " + timeLeft);

        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            FindObjectOfType<PlayerController>().Respawn();
        }
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }

    public void ResetTime()
    {
        timeLeft = startTime;
    }
}
