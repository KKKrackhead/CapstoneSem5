using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmButtonMejaDisplay : MonoBehaviour
{
    private int nomorMeja;
    private int itemIndex;
    private GameObject tampil;
    private GameObject tampil1;
    private Inventory inventory;

    public void setInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public void ConfirmButton()
    {
        string jeneng = GameObject.Find("UI_PlayerInventory").GetComponent<UI_Inventory>().getJeneng(itemIndex);

        nomorMeja = GameObject.Find("Player").GetComponent<PlayerInteraction>().getMeja();

        if (nomorMeja.Equals(1))
        {
            tampil = GameObject.Find("MejaAtasKiriDisplay");
            tampil1 = GameObject.FindGameObjectWithTag("MejaAtasKiri");
        }
        if (nomorMeja.Equals(2))
        {
            tampil = GameObject.Find("MejaAtasKananDisplay");
            tampil1 = GameObject.FindGameObjectWithTag("MejaAtasKanan");
        }

        tampil.GetComponent<TableInventory>().ChangeImage(jeneng, itemIndex);

        inventory.RemoveItem(itemIndex);

        tampil1.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void setitemIndex(int nomor)
    {
        itemIndex = nomor;
    }
}
