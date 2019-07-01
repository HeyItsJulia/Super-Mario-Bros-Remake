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
    public GameObject Mushroom;

    public GameObject HitQBlock;

    void OnCollisionEnter(Collision c)
    {
        Collider other = c.collider;
        Debug.Log("Collision!");
        if (other.GetComponent<PlayerController>() && other.GetComponent<Rigidbody>().velocity.y > 0)
        {
            Debug.Log("Player is rising!");
            if (item == ItemType.Mushroom)
            {
                GameObject newMushroom = Instantiate(Mushroom);
                newMushroom.transform.position = transform.position + Vector3.up;
            }

            GameObject HitQuestionBlock = Instantiate(HitQBlock);
            HitQuestionBlock.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
