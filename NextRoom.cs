using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextRoom : MonoBehaviour
{
    public Text pressXText;
    private void Start()
    {
        pressXText.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Player")))
        {
            pressXText.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if ((other.gameObject.CompareTag("Player")))
        {
            pressXText.enabled = false;
        }

    }
}
