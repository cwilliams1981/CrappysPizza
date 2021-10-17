using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay = 0f;

    bool hasPackage = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("I've Crashed!");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Package") && !(hasPackage))
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
        }
        else if ((other.tag == "Customer") && (hasPackage))
        {
            Debug.Log("Package delivered to customer!");
            hasPackage = false;
            Destroy(other.gameObject, destroyDelay);
        }
    }
}
