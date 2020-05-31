using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscMenu : MonoBehaviour
{
    public GameObject escMenu;
    public GameObject[] windows;

    private CharStats[] charStats;
    public Text[] nameText, hpText, manaText, levelText, xpText;
    public Slider[] xpSlider;
    public Image[] charImage;
    public GameObject[] charStatsHolder;

    public Text goldText;

    public GameObject[] statusButtons;
    public Text statusName, statusHP, statusMP, statusStr, statusDef, statusWpnEqpd, statusWpnPwr, statusArmrEqpd, statusArmrPwr, statusExp;
    public Image statusImage;

    public ItemButton[] itemButtons;
    public string selectedItem;
    public Item activeItem;
    public Text itemName;
    public Text itemDescription;
    public Text useButtonText;

    public static EscMenu instance;

    public GameObject itemCharChoiceMenu;
    public Text[] itemCharChoiceNames;

    public Text pressXText_Left;
    public Text pressXText_Middle;
    public Text pressXText_Right;

    
    private void Start()
    {
        pressXText_Left.enabled = false;
        pressXText_Middle.enabled = false;
        pressXText_Right.enabled = false;


        instance = this;

        escMenu.gameObject.SetActive(false);

       

    }
    private void Update()
    {
        
        

        if (Input.GetKeyDown(KeyCode.Escape))   //ESC yle aç kapa
        {
            
            if (escMenu.activeInHierarchy)
            {
                escMenu.SetActive(false);
                UpdateMainStats();
                GameManager.instance.escMenuOpen = false;
                CloseEscMenu();
            }
            else
            {
                escMenu.SetActive(true);
                GameManager.instance.escMenuOpen = true;
            }

            AudioManager.instance.PlaySFX(4);
        }
    }

    public void UpdateMainStats()
    {
        charStats = GameManager.instance.playerStats;

        for (int i = 0; i < charStats.Length; i++)
        {
            if (charStats[i].gameObject.activeInHierarchy)
            {
                charStatsHolder[i].SetActive(true);

                nameText[i].text = charStats[i].charName;
                hpText[i].text = charStats[i].currentHP + "/" + charStats[i].maxHP;
                manaText[i].text =charStats[i].currentMana + "/" + charStats[i].maxMana;
                levelText[i].text = "" + charStats[i].charLevel;
                xpSlider[i].maxValue = charStats[i].xpForNextLevel[charStats[i].charLevel];
                xpSlider[i].value = charStats[i].currentXP;
                charImage[i].sprite = charStats[i].charImage;
                goldText.text = GameManager.instance.currentGold.ToString();
            }
            else
            {
                charStatsHolder[i].SetActive(false);
            }
        }
        
    }


    public void ToggleWindow(int windowNumber)
    {
        UpdateMainStats();

        for (int i = 0; i < windows.Length; i++)
        {
            if (i==windowNumber)
            {
                windows[i].SetActive(!windows[i].activeInHierarchy);
            }
            else
            {
                windows[i].SetActive(false);
            }
        }
    }
    public void CloseEscMenu()
    {
        for (int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
        }
        escMenu.SetActive(false);
        GameManager.instance.escMenuOpen=false;
    }

    public void OpenStatus()
    {
        UpdateMainStats();
        StatusChar(0);

        for (int i = 0; i < statusButtons.Length; i++)
        {
            statusButtons[i].SetActive(charStats[i].gameObject.activeInHierarchy);
            statusButtons[i].GetComponentInChildren<Text>().text = charStats[i].charName;
        }
    }

    public void StatusChar(int selected)
    {
        statusName.text = charStats[selected].charName;
        statusHP.text = "" + charStats[selected].currentHP + "/" + charStats[selected].maxHP;
        statusMP.text = "" + charStats[selected].currentMana + "/" + charStats[selected].maxMana;
        statusStr.text = charStats[selected].STR.ToString();
        statusDef.text = charStats[selected].DEF.ToString();
        if (charStats[selected].equippedWeapon != "")
        {
            statusWpnEqpd.text = charStats[selected].equippedWeapon;
        }
        statusWpnPwr.text = charStats[selected].weaponPower.ToString();
        if (charStats[selected].equippedArmor != "")
        {
            statusArmrEqpd.text = charStats[selected].equippedArmor;
        }
        statusArmrPwr.text = charStats[selected].armorPower.ToString();
        statusExp.text = (charStats[selected].xpForNextLevel[charStats[selected].charLevel] - charStats[selected].currentXP).ToString();
        statusImage.sprite = charStats[selected].charImage;

    }

    public void ShowItems()
    {
        GameManager.instance.SortItems();

        for (int i = 0; i < itemButtons.Length; i++)
        {
            itemButtons[i].buttonValue = i;

            if (GameManager.instance.itemsHeld[i] != "")
            {
                itemButtons[i].buttonImage.gameObject.SetActive(true);
                itemButtons[i].buttonImage.sprite = GameManager.instance.GetItemDetails(GameManager.instance.itemsHeld[i]).itemSprite;
                itemButtons[i].amountText.text = GameManager.instance.numberOfItems[i].ToString();
            }
            else
            {
                itemButtons[i].buttonImage.gameObject.SetActive(false);
                itemButtons[i].amountText.text = "";
            }
        }
    }

    public void SelectItem(Item newItem)
    {
        activeItem = newItem;

        if (activeItem.isItem)
        {
            useButtonText.text = "Use";
            AudioManager.instance.PlaySFX(5);
        }

        if (activeItem.isWeapon || activeItem.isArmor)
        {
            useButtonText.text = "Equip";
            AudioManager.instance.PlaySFX(5);
        }

        itemName.text = activeItem.itemName;
        itemDescription.text = activeItem.description;
    }


    public void DropItem()
    {
        if (activeItem != null)
        {
            GameManager.instance.RemoveItem(activeItem.itemName);
            AudioManager.instance.PlaySFX(5);
        }
    }

    public void OpenItemCharChoice()
    {
        itemCharChoiceMenu.SetActive(true);
        AudioManager.instance.PlaySFX(5);

        for (int i = 0; i < itemCharChoiceNames.Length; i++)
        {
            itemCharChoiceNames[i].text = GameManager.instance.playerStats[i].charName;
            itemCharChoiceNames[i].transform.parent.gameObject.SetActive(GameManager.instance.playerStats[i].gameObject.activeInHierarchy);
        }
    }

    public void CloseItemCharChoice()
    {
        itemCharChoiceMenu.SetActive(false);
    }

    public void UseItem(int selectChar)
    {
        activeItem.Use(selectChar);
        CloseItemCharChoice();
        AudioManager.instance.PlaySFX(5);
    }

    public void ButtonSound()
    {
        AudioManager.instance.PlaySFX(3);
    }
}
