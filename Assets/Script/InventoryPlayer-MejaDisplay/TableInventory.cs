using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableInventory : MonoBehaviour
{
    private Item Display;
    private Inventory inventory;
    public RectTransform UI_InventoryActive;
    public GameObject UI_playerInventory;
    private int checkItem = 0;

    public GameObject satuan;
    public GameObject puluhan;
    public GameObject ratusan;
    public GameObject ribuan;
    public GameObject puluhRibuan;

    private int satuanI;
    private int puluhanI;
    private int ratusanI;
    private int ribuanI;
    private int puluhRibuanI;

    private int hargaAkhir;

    /*public void Awake()
    {
        Display = new Item(Item.ItemType.Weapon, "Clurit", 90);
        checkItem = 1;
        if(gameObject.name.Equals("MejaAtasKananDisplay") || gameObject.name.Equals("MejaAtasKiriDisplay"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Display.GetSprite2();
        }
        else if (gameObject.name.Equals("MejaBawahKananDisplay") || gameObject.name.Equals("MejaBawahKiriDisplay"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Display.GetSprite3();
        }
    }*/

    public void ChangeImage(string jeneng, int itemIndex)
    {

        inventory = GameObject.Find("Player").GetComponent<PlayerMovement>().getPlayerInventory();

        Display = inventory.getItem(itemIndex);

        gantiHarga();

        gameObject.GetComponent<SpriteRenderer>().sprite = Display.GetSprite2();

        /*if (jeneng.Equals("Golok"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Display.GetSprite();
        }
        else if(jeneng.Equals("Beras Kencur"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Display.GetSprite();
        }
        else if(jeneng.Equals("Asem Jawa"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Display.GetSprite();
        }*/

        UI_InventoryActive.anchoredPosition = new Vector3(4060f, 540f, 0f);
        checkItem = 1;
    }

    public void gantiHarga()
    {
        setHarga();
        Display.setHarga(hargaAkhir);
    }

    public int getCheckItem()
    {
        return checkItem;
    }

    public Item getItemDisplay()
    {
        return Display;
    }

    public void removeItemDisplay()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
        Display = null;
    }

    public void removeItem()
    {
        checkItem = 0;
    }

    private void setHarga()
    {
        satuanI = satuan.GetComponent<PriceSet>().getHarga();
        puluhanI = puluhan.GetComponent<PriceSet>().getHarga();
        ratusanI = ratusan.GetComponent<PriceSet>().getHarga();
        ribuanI = ribuan.GetComponent<PriceSet>().getHarga();
        puluhRibuanI = puluhRibuan.GetComponent<PriceSet>().getHarga();

        hargaAkhir = satuanI + (puluhanI * 10) + (ratusanI * 100) + (ribuanI * 1000) + (puluhRibuanI * 10000);

        satuan.GetComponent<PriceSet>().resetHarga();
        puluhan.GetComponent<PriceSet>().resetHarga();
        ratusan.GetComponent<PriceSet>().resetHarga();
        ribuan.GetComponent<PriceSet>().resetHarga();
        puluhRibuan.GetComponent<PriceSet>().resetHarga();
    }
}
