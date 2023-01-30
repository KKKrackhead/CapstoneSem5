using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Display : MonoBehaviour
{
    public GameObject pricetext;
    public GameObject nametext;
    int priceint;

    

    // Update is called once per frame
    void Update()
    {
        priceint = Convert.ToInt32(pricetext.GetComponent<Text>().text);

        switch (priceint)
        {
            case 3:
                GetComponent<Image>().sprite = GetComponent<ItemAsset2>().AsemJawa;
                nametext.GetComponent<Text>().text = ("Asem Jawa");
                break;
            case 8:
                GetComponent<Image>().sprite = GetComponent<ItemAsset2>().BerasKencur;
                nametext.GetComponent<Text>().text = ("Beras Kencur");
                break;
            case 18:
                GetComponent<Image>().sprite = GetComponent<ItemAsset2>().Golok;
                nametext.GetComponent<Text>().text = ("Golok");
                break;
            case 30:
                GetComponent<Image>().sprite = GetComponent<ItemAsset2>().Pandan;
                nametext.GetComponent<Text>().text = ("Pandan");
                break;
            case 56:
                GetComponent<Image>().sprite = GetComponent<ItemAsset2>().KunyitAsem;
                nametext.GetComponent<Text>().text = ("Kunyit Asem");
                break;
            case 90:
                GetComponent<Image>().sprite = GetComponent<ItemAsset2>().Clurit;
                nametext.GetComponent<Text>().text = ("Clurit");
                break;
            case 300:
                GetComponent<Image>().sprite = GetComponent<ItemAsset2>().JaheMerah;
                nametext.GetComponent<Text>().text = ("Jahe Merah");
                break;
            case 392:
                GetComponent<Image>().sprite = GetComponent<ItemAsset2>().Brotowali;
                nametext.GetComponent<Text>().text = ("Brotowali");
                break;
            case 450:
                GetComponent<Image>().sprite = GetComponent<ItemAsset2>().Keris;
                nametext.GetComponent<Text>().text = ("Keris");
                break;

            default:
                break;
        }

    }
}