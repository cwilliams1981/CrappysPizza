using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField] float destroyDelay = 0f;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    bool hasPackage = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Package") && !(hasPackage))
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;
        }
        else if ((other.tag == "Customer") && (hasPackage))
        {
            Debug.Log("Package delivered to customer!");
            hasPackage = false;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = noPackageColor;
        }
    }
}
