using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmButtonMejaDisplay : MonoBehaviour
{
    private int nomorMeja;
    private int itemIndex;
    private GameObject tampil;
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
        }
        if (nomorMeja.Equals(2))
        {
            tampil = GameObject.Find("MejaAtasKiriDisplay");
        }

        tampil.GetComponent<TableInventory>().ChangeImage(jeneng, itemIndex);

        inventory.RemoveItem(itemIndex);
    }

    public void setitemIndex(int nomor)
    {
        itemIndex = nomor;
    }
}
