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
    
    private int buyprice;

    public void ChangeIndex()
    {
        ItemPriceToText.text = ShopItemPrice.ToString();
    }

    public int changeprice()
    {
        buyprice = ShopItemPrice;
        return buyprice;
    }

    
}
