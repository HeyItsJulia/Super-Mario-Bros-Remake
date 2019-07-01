using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAnimation : MonoBehaviour
{
    public Sprite[] sprites;
    int currentSprite = 0;
    public float framesPerSecond;
    float secondsPerFrame;
    float timeUntilChange;

    void UpdateSecondsPerFrame()
    {
        if (framesPerSecond <= 0)
            framesPerSecond = 0.0001f;
        secondsPerFrame = 1f / framesPerSecond;
       
    }


    void Start()
    {
        UpdateSecondsPerFrame(); 
        timeUntilChange = secondsPerFrame;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[currentSprite];
        timeUntilChange -= Time.deltaTime;
        if (framesPerSecond > 0 && timeUntilChange < 0)
        {
            timeUntilChange = secondsPerFrame;
            currentSprite++;
            if (currentSprite >= sprites.Length)
                currentSprite = 0;


        }
        else if (framesPerSecond < 0 && timeUntilChange > 0)
        {
            timeUntilChange = secondsPerFrame;
            currentSprite--;
            if (currentSprite >= sprites.Length)
                currentSprite = 0;
            currentSprite = sprites.Length - 1;
        }
    }

}

