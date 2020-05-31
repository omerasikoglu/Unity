using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharStats : MonoBehaviour
{
    //public Text hpText;

    public string charName;
    public int charLevel;
    public int currentXP;
    public int[] xpForNextLevel;
    public int maxLevel;
    public int baseXP ;

    public int currentHP;
    public int maxHP;
    public int maxMana;
    public int currentMana;
    public int[] manaLevelBonus;
    public int STR;
    public int DEF;
    public int weaponPower;
    public int armorPower;
    public string equippedWeapon;
    public string equippedArmor;

    public Sprite charImage;

    private void Start()
    {
        xpForNextLevel = new int[maxLevel];         //seviye başına gerekli XP miktarları
        xpForNextLevel[1] = baseXP;                 //kolay hesaplayabilmek için diziyi 1den başlattım ==> dizi[1]= seviye 1 oldu.
        for (int i = 1; i < xpForNextLevel.Length; i++)
        {
            xpForNextLevel[i] =3 /*xpForNextLevel[i-1]+1*/;
        }
        //currentMana = maxMana;        //hile modu
    }

     void Update()
    {
        //ConstantUI();
        //bitirme sunumu modu
        if (Input.GetKeyDown(KeyCode.K)) {

            AddXP(1);

        }
    }

    //private void ConstantUI()
    //{
    //    //hpText = GetComponent<Text>();
    //    if (hpText != null) {
    //        hpText.text = GameManager.instance.playerStats[0].currentHP.ToString();
    //        //hpText.text = currentHP.ToString();
    //    }
    //}

    public void AddXP(int xpForAdd)            //XP kazanma
    {
        currentXP += xpForAdd;
        if ( charLevel < maxLevel) 
        { 
        if (currentXP >= xpForNextLevel[charLevel] ) //Karakter level atlarsa
            {
            currentXP -= xpForNextLevel[charLevel];
            charLevel++;

            maxHP = Mathf.FloorToInt(maxHP + 1);    //en yakın tam sayıya indir --> 9.9'sa 9 olur -->elimin altında dursun diye yazdım
            currentHP = maxHP;

            maxMana += manaLevelBonus[charLevel-1];
            currentMana = maxMana;
            }
        }

        else          //karakter max leveldeyse (charLevel >= maxLevel) ise 
        {
            currentXP = 0;
            currentMana = maxMana;
        }
        

    }
}
