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
    public GameObject Coin;
    public GameObject HitQBlock;

    void SpawnItem()
    {
            if (item == ItemType.Mushroom)
            {
                GameObject newMushroom = Instantiate(Mushroom);
                newMushroom.transform.position = transform.position + Vector3.up;
            }
            if (item == ItemType.Coin)
            {
            GameObject newCoin = Instantiate(Coin);
            newCoin.transform.position = transform.position;
            PlayerController.score += 100;
            }

            GameObject HitQuestionBlock = Instantiate(HitQBlock);
            HitQuestionBlock.transform.position = transform.position;
            Destroy(gameObject);
    }
}
