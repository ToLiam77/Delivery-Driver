using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float timeForPackageDisappear = 0.1f;
    Color32 hasPackageColor = new Color32(107, 229, 114, 255);
    Color32 noPackageColor = new Color32(255, 255, 255, 255);

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked");
            hasPackage = true;
            Destroy(other.gameObject, timeForPackageDisappear);
            spriteRenderer.color = hasPackageColor;
        }

        if (other.tag == "DeliveryLocation" && hasPackage)
        {
            Debug.Log("Package delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
