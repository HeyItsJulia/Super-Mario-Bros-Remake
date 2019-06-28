using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            if (item == ItemType.Coin)
            {

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
