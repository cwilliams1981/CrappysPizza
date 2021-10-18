using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float turnSpeed = 1f;
    [SerializeField] float normalSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    float moveSpeed;
    bool isSlow;
    bool isBoost;
    float slowTimer;
    float boostTimer;
    [SerializeField] float slowTime = 1f;
    [SerializeField] float boostTime = 1f;

    void Start()
    {
        moveSpeed = normalSpeed;
    }

    void Update()
    {
        float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -turnAmount);
        transform.Translate(0, moveAmount, 0);

        if (isSlow)
        {
            if (slowTimer > 0)
            {
                slowTimer -= Time.deltaTime;
            }
            else
            {
                moveSpeed = normalSpeed;
                isSlow = false;
            }
        }
        if (isBoost)
        {
            if (boostTimer > 0)
            {
                boostTimer -= Time.deltaTime;
            }
            else
            {
                moveSpeed = normalSpeed;
                isBoost = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
        slowTimer = slowTime;
        isSlow = true;
        isBoost = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
            boostTimer = boostTime;
            isBoost = true;
            isSlow = false;
        }
    }
}
