using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// QuestionBlockController.cs
// 6/28/19
// Isaac Richards
public class QuestionBlockController : MonoBehaviour
{
   public enum ItemType
    {
        Nothing,
        Coin,
        Mushroom,
        Star
    }
    public ItemType item;
    Rigidbody PlayerUpSpeed;
    public GameObject Mushroom;

    void OnTriggerEnter(Collider other)
    {
        PlayerUpSpeed = GetComponent<Rigidbody>();
        if (other.GetComponent<PlayerController>() && PlayerUpSpeed.velocity.y > 0)
        {
            if (item == ItemType.Mushroom)
            {
                GameObject newMushroom = Instantiate(Mushroom);
                newMushroom.transform.position += Vector3.up;
            }


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
