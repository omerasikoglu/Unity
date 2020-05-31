using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    //public GameObject canvas; //ekran karartma sahne geçişlerinde kullanmıyom o yüzden çıkardım UIFade ile birlikte
    public GameObject player;
    public GameObject gameManager;
    public GameObject audioManager;

    private void Start()
    {
        void Start()
        {
            //if (UIFade.instance == null)  
            //{
            //    UIFade.instance = Instantiate(canvas).GetComponent<UIFade>();
            //}

            if (PlayerController.instance == null)
            {
                PlayerController clone = Instantiate(player).GetComponent<PlayerController>();
                PlayerController.instance = clone;
            }

            if (GameManager.instance == null)
            {
                GameManager.instance = Instantiate(gameManager).GetComponent<GameManager>();
            }

            if (AudioManager.instance == null)
            {
                AudioManager.instance = Instantiate(audioManager).GetComponent<AudioManager>();
            }


        }


    }
}
