using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChibiCanvas : MonoBehaviour
{

    private CharStats charStats;
    public Text hpText;

    private void Start()
    {
        //hpText = GameObject.Find("charStats");
    }
    private void Update()
    {
        if (hpText != null)
        {
            hpText.text = GameManager.instance.playerStats[0].currentHP.ToString();
        }

    }


    //private SpriteRenderer spriteRenderer;
    //public Text pressXText_Left;
    //public Text pressXText_Middle;
    //public Text pressXText_Right;

    //private void Start()
    //{
    //    spriteRenderer = GetComponent<SpriteRenderer>();
    //    pressXText_Left.enabled = false;
    //    pressXText_Middle.enabled = false;
    //    pressXText_Right.enabled = false;
    //}


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("LeftExit"))
    //    {
    //        pressXText_Left.enabled = true;
    //    }
    //    if (collision.gameObject.CompareTag("MiddleExit"))
    //    {
    //        pressXText_Middle.enabled = true;
    //    }
    //    if (collision.gameObject.CompareTag("RightExit"))
    //    {
    //        pressXText_Right.enabled = true;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("LeftExit"))
    //    {
    //        pressXText_Left.enabled = false;
    //    }
    //    if (collision.gameObject.CompareTag("MiddleExit"))
    //    {
    //        pressXText_Middle.enabled = false;
    //    }
    //    if (collision.gameObject.CompareTag("RightExit"))
    //    {
    //        pressXText_Right.enabled = false;
    //    }
    //}






    //public Text[] hpText;
    //public Text statusHP;
    //private CharStats[] charStats;
    //public GameObject[] charStatsHolder;

    //public void UpdateMainStats()
    //{
    //    charStats = GameManager.instance.playerStats;
    //    for (int i = 0; i < charStats.Length; i++)
    //    {
    //        if (charStats[i].gameObject.activeInHierarchy)
    //        {
    //            charStatsHolder[i].SetActive(true);
    //            hpText[i].text = charStats[i].currentHP + "/" + charStats[i].maxHP;
    //        }
    //        else
    //        {
    //            charStatsHolder[i].SetActive(false);
    //        }
    //    }
    //}


    //public Sprite[] waitingAnim, jumpingAnim, walkingAnim;
    ////public Sprite death;

    //private SpriteRenderer spriteRenderer;
    //private Rigidbody2D rigidbody2d;

    ////int walkingAnimCounter, jumpingAnimCounter, waitingAnimCounter = 0;
    ////float waitingAnimTime, walkingAnimTime, jumpingAnimTime = 0;

    //public Text hpText, deathText, lettuceText, needLettuceText;

    //private float lettuce, hpCount=1f ;
    //public Image CrimsonRedBG;

    //float CrimsonRedBGCounter = 0;
    //float gotoMainScreenTime = 0;

    //private bool transpassingIsActive; //tüm marulları toplayınca en son checkpoint'te yazının çıkması

    //private void Start()
    //{
    //    Time.timeScale = 1;
    //    hpText.text = "Canato: " + hpCount;                     //canvastaki yazılar
    //    lettuceText.text = "Marulato:" + lettuce + "/3";
    //    needLettuceText.enabled = false;
    //}

    //void FixedUpdate()
    //{
    //    if (hpCount <= 0)
    //    {

    //        Time.timeScale = 0.3f;      //ekran yavasca kararsın
    //        hpText.enabled = false;
    //        lettuceText.enabled = false;
    //        //spriteRenderer.sprite = death;
    //        rigidbody2d.AddForce(new Vector2(Random.Range(-100f, 100f), rigidbody2d.velocity.y));
    //        deathText.text = "HarcandIn!";
    //        CrimsonRedBGCounter += 0.03f;
    //        CrimsonRedBG.color = new Color(0, 0, 0, CrimsonRedBGCounter); //new color diyerek nesnesini olusturduk
    //        gotoMainScreenTime += Time.deltaTime;                         //rgba ;a transparanlık demek, 1'ken opak 
    //        //if (gotoMainScreenTime > 1)
    //        //{
    //        //    SceneManager.LoadScene("MainScreen");
    //        //}
    //    }

    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("bullet"))
    //    {
    //        hpCount -= 1;
    //        hpText.text = "Canato: " + hpCount;
    //    }
    //    if (collision.gameObject.CompareTag("enemy"))      //işe yaramıyo bu
    //    {                                               //artık yarıyo *coolface*
    //        hpCount -= 1;
    //        hpText.text = "Canato: " + hpCount;
    //    }
    //    if (collision.gameObject.CompareTag("saw"))
    //    {
    //        hpCount -= 1;
    //        hpText.text = "Canato: " + hpCount;
    //    }
    //    if (collision.gameObject.CompareTag("heart"))
    //    {

    //        if (hpCount < 100)
    //        {
    //            hpCount += 1;
    //            hpText.text = "Canato: " + hpCount;
    //            Destroy(collision.gameObject);
    //        }

    //    }
    //    if (collision.gameObject.CompareTag("marul"))
    //    {
    //        lettuce += 1;
    //        lettuceText.text = "Marulato:" + lettuce + "/3";
    //        Destroy(collision.gameObject);
    //    }
    //    //lettuce_text.enabled = false;
    //    if (collision.gameObject.CompareTag("checkpoint"))
    //    {
    //        if (lettuce == 3)
    //        {
    //            transpassingIsActive = true;
    //            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //        }
    //        else
    //        {
    //            needLettuceText.enabled = true;
    //            needLettuceText.text = "You Need " + (3 - lettuce) + " more MARUL!";
    //        }

    //    }

    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("checkpoint"))
    //    {
    //        transpassingIsActive = false;
    //        needLettuceText.enabled = false;
    //    }
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("ivy"))
    //    {
    //        hpCount -= 1;
    //        hpText.text = "Canato: " + hpCount;
    //        rigidbody2d.AddForce(new Vector2(Random.Range(-100f, 100f), 0));
    //    }
    //}

}
