using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPricing : MonoBehaviour
{
    [Header("Item price & index")]
    [SerializeField] private int ShopItemPrice;
    [SerializeField] private int ShopSlotIndex;

    [Header ("TMP")]
    [SerializeField] private Text ItemPriceToText;

    public int BuyIndex;
    public int BuyPrice;

    
    public void ChangeIndex()
    {
        BuyIndex = ShopSlotIndex;
        BuyPrice = ShopItemPrice;
        Debug.Log("serialized index =" + ShopSlotIndex);
        Debug.Log("index = " +BuyIndex);
        Debug.Log("Current Item Price =" +BuyPrice);

        ItemPriceToText.text = BuyPrice.ToString();
    }
}
