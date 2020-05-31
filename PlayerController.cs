using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;    //static yaparız çünkü tek bir tane var
    public string areaName;

    public bool canMove = true;
    
    
  
    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this; //this script
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

 
    //private void Update()
    //{
    //    //hile modu
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        SceneManager.LoadScene("ova level");
    //        //instance.transform.gameObject.SetActive(false);
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {

    //        SceneManager.LoadScene("home");
    //        //instance.transform.gameObject.SetActive(true);
    //        instance.transform.position = new Vector3(-0.69f, -0.78f, 191f);
    //    }
    //}
}
