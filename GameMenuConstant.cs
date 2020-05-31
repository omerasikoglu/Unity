using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuConstant : MonoBehaviour
{
    public GameObject ConstantMenu;
    public Text[] hpText, manaText, xpText;
    public Image deathImage;
    public Text deathText;
    


    private CharStats[] charStats;
    //public GameObject[] charStatsHolder;


    public Animator anim;

    private void Start()
    {
        deathImage.gameObject.SetActive(true);
        anim =  deathImage.GetComponent<Animator>();
        
    }

    private void Update()
    {
        UpdateMainStats();
    }



    public void UpdateMainStats()
    {
        charStats = GameManager.instance.playerStats;

        for (int i = 0; i < charStats.Length; i++)
        {
            
                
                hpText[i].text = charStats[i].currentHP + "/" + charStats[i].maxHP;
                manaText[i].text = charStats[i].currentMana + "/" + charStats[i].maxMana;
                xpText[i].text = charStats[i].currentXP + "/ 3";
            
           
        }
    }
    private void Death()
    {
        for (int i = 0; i < charStats.Length; i++)
        {

            if (charStats[i].currentHP <= 0)
            {
                anim.SetTrigger("Harcandin");
            }



        }
    }

}
