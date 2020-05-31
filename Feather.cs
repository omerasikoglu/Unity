using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feather : MonoBehaviour
{
    private float enableTimer;
    private bool isCollected;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        isCollected = false;
        spriteRenderer = transform.GetComponent<SpriteRenderer>();

    }
    private void Update()
    {
        if (isCollected)
        {
            enableTimer -= Time.deltaTime;
            if (enableTimer <= 0)
            {
                isCollected = false;
                spriteRenderer.color = new Color(1, 1, 1, 1f);
            }
        }
       
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        Jump player = collider.gameObject.GetComponent<Jump>();
        if (player != null && isCollected==false)
        {
            player.IsCollectFeather();
            isCollected = true;
            enableTimer = 5f;
            spriteRenderer.color = new Color(1, 1, 1, .5f);
        }
       
    }
}
