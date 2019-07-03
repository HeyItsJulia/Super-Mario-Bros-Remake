using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCoinScript : MonoBehaviour
{
    public GameObject Coin;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision!");
        if (other.tag == "Player")
        {
            Debug.Log("With Player!");
            GameObject newCoin = Instantiate(Coin);
            newCoin.transform.position = transform.position;
            PlayerController.score += 100;
            Destroy(gameObject);
        }
    }
}