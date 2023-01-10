using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public void Buy()
    {
        GetComponent<PlayerInteraction>().playerGold -= GetComponent<ItemPricing>().BuyPrice;
        Debug.Log("GetComponent<PlayerInteraction>().playerGold");
    }
}
