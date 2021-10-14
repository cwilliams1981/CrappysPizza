using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float turnSpeed = 1f;
    [SerializeField] float moveSpeed = 0.01f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, 0, turnSpeed);
        transform.Translate(0, moveSpeed, 0);
    }
}
