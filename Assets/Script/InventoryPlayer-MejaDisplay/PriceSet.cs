using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceSet : MonoBehaviour
{
    public Text teksHarga;
    private int harga;

    private void Start()
    {
        harga = 0;
    }

    public void upArrow()
    {
        updateHarga();
        if(harga != 9)
        {
            harga++;
            teksHarga.text = harga.ToString();
        }
    }

    public void downArrow()
    {
        updateHarga();
        if (harga != 0)
        {
            harga--;
            teksHarga.text = harga.ToString();
        }
    }

    private void updateHarga()
    {
        harga = int.Parse(teksHarga.text);
    }

    public int getHarga()
    {
        return harga;
    }
}
