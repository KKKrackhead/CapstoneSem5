using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmButtonMejaDisplay : MonoBehaviour
{
    private int nomorMeja;
    private int itemIndex = -1;
    private GameObject tampil;
    private Inventory inventory;
    private Item display;

    public void setInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public void ConfirmButton()
    {
        if(itemIndex != -1)
        {
            string jeneng = GameObject.Find("UI_PlayerInventory").GetComponent<UI_Inventory>().getJeneng(itemIndex);

            nomorMeja = GameObject.Find("Player").GetComponent<PlayerInteraction>().getMeja();

            if (nomorMeja.Equals(1))
            {
                tampil = GameObject.Find("MejaAtasKiriDisplay");
            }
            if (nomorMeja.Equals(2))
            {
                tampil = GameObject.Find("MejaAtasKananDisplay");
            }
            if (nomorMeja.Equals(3))
            {
                tampil = GameObject.Find("MejaBawahKiriDisplay");
            }
            if (nomorMeja.Equals(4))
            {
                tampil = GameObject.Find("MejaBawahKananDisplay");
            }

            tampil.GetComponent<TableInventory>().ChangeImage(jeneng, itemIndex);

            display = inventory.getItem(itemIndex);

            inventory.RemoveItem(itemIndex);
            itemIndex = -1;
        }

        else // item ada harus cek harga berubah atau gk (belum)
        {
            tampil.GetComponent<TableInventory>().gantiHarga();
            RectTransform UI_InventoryActive =  GameObject.Find("Nyusun Barang1 Upgrade").GetComponent<RectTransform>();

            UI_InventoryActive.anchoredPosition = new Vector3(4060f, 540f, 0f);
        }

        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
    }

    public void closeBTN()
    {
        RectTransform UI_InventoryActive = GameObject.Find("Nyusun Barang1 Upgrade").GetComponent<RectTransform>();

        UI_InventoryActive.anchoredPosition = new Vector3(4060f, 540f, 0f);

        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
    }

    public void setitemIndex(int nomor)
    {
        itemIndex = nomor;
    }

    public Item getItemDisplay()
    {
        return display;
    }
}
