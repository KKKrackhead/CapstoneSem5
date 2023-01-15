using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BuyMaster : MonoBehaviour
{
    private int FinalPrice;
    [SerializeField] private Text ReadFinalPrice;
    private string WrittenPrice;

    private void FixedUpdate()
    {
        WrittenPrice = ReadFinalPrice.text.ToString();
        FinalPrice = Convert.ToInt32(WrittenPrice);
    }

    public void DoBuy()
    {
        Debug.Log("Gold Sent = " +FinalPrice);
        GameObject.Find("Player").GetComponent<PlayerInteraction>().PlayerDoBuy(FinalPrice);
    }
}
