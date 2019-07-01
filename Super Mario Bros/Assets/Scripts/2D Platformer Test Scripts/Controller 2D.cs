using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider2D))]
public class Controller2D : MonoBehaviour
{
    BoxCollider2D Collider;

    void Start() {
        Collider = GetComponent<BoxCollider2D>();
    }
    
}
