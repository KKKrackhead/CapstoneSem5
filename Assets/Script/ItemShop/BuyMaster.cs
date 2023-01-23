using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BuyMaster : MonoBehaviour
{
    private Inventory2 inv;
    public GameObject cariInv;
    public GameObject player;

     
    private int FinalPrice;
    [SerializeField] private Text ReadFinalPrice;
    private string WrittenPrice;

    private void Awake()
    {
        inv = cariInv.GetComponent<UI_LemariInventory>().getInventory();
    }

    private void FixedUpdate()
    {
        WrittenPrice = ReadFinalPrice.text.ToString();
        FinalPrice = Convert.ToInt32(WrittenPrice);
    }

    public void DoBuy()
    {
        if((player.GetComponent<PlayerInteraction>().playerGold - FinalPrice) <= 0 || cariInv.GetComponent<UI_LemariInventory>().inventory.itemList.Count >= 15)
        {
            return;
        }

        Debug.Log("Gold Sent = " +FinalPrice);
        GameObject.Find("Player").GetComponent<PlayerInteraction>().PlayerDoBuy(FinalPrice);

        switch (FinalPrice)
        {
            case 3:
                cariInv.GetComponent<UI_LemariInventory>().inventory.AddItem(new Item(Item.ItemType.Ingredient, "Asem Jawa", 3));
                break;
            case 8:
                cariInv.GetComponent<UI_LemariInventory>().inventory.AddItem(new Item(Item.ItemType.Potion, "Beras Kencur", 8));
                break;
            case 18:
                cariInv.GetComponent<UI_LemariInventory>().inventory.AddItem(new Item(Item.ItemType.Weapon, "Golok", 18));
                break;
            case 30:
                cariInv.GetComponent<UI_LemariInventory>().inventory.AddItem(new Item(Item.ItemType.Ingredient, "Pandan", 30));
                break;
            case 56:
                cariInv.GetComponent<UI_LemariInventory>().inventory.AddItem(new Item(Item.ItemType.Ingredient, "Kunyit Asem", 56));
                break;
            case 90:
                cariInv.GetComponent<UI_LemariInventory>().inventory.AddItem(new Item(Item.ItemType.Ingredient, "Clurit", 90));
                break;
            case 300:
                cariInv.GetComponent<UI_LemariInventory>().inventory.AddItem(new Item(Item.ItemType.Ingredient, "Jahe Merah", 300));
                break;
            case 392:
                cariInv.GetComponent<UI_LemariInventory>().inventory.AddItem(new Item(Item.ItemType.Ingredient, "Brotowali", 392));
                break;
            case 450:
                cariInv.GetComponent<UI_LemariInventory>().inventory.AddItem(new Item(Item.ItemType.Ingredient, "Keris", 450));
                break;

            default:
                break;
        }
    }
}
