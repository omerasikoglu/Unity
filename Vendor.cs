using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendor : MonoBehaviour
{
    private bool isActive;

    public string[] ItemsForSale = new string[10];

    void Update()
    {
        if (isActive && Input.GetKeyDown(KeyCode.X)  && !Shop.instance.shopMenu.activeInHierarchy)
        {
            Shop.instance.itemsForSale = ItemsForSale;

            Shop.instance.OpenShop();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isActive = false;
        }
    }
}
