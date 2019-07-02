using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    public double lifeTime = .5;
    Vector3 dest;

    void Start()
    {
        dest = transform.position + Vector3.up;
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
        transform.position = Vector3.Lerp(transform.position, dest, 0.5f);
    }
}
