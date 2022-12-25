using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    public Transform itemSlotContainer;
    public Transform itemSlotTemplate;
    public GameObject mejaDisplay;
    private Item display = null;
    private int nomor;

    public void setInventory(Inventory inventory)   
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChange;

        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChange(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    public void RefreshInventoryItems()
    {
        Debug.Log("masuk");
        foreach (Transform child in itemSlotContainer)
        {
            if(child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        nomor = 0;

        int x = 0;
        float itemSlotCellSize = 170f;

        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize,0f);

            Image image = itemSlotRectTransform.Find("ItemImage").GetComponent<Image>();
            image.sprite = item.GetSprite();
            nomor++;
            x++;
        }

        if(GameObject.Find("Player").GetComponent<PlayerInteraction>().getMeja() == 1)
        {
            display = GameObject.Find("MejaAtasKiriDisplay").GetComponent<TableInventory>().getItemDisplay();

            if (display is not null)
            {
                if (display.getHarga() != 0)
                {
                    Debug.Log("masuk1");

                    mejaDisplay.SetActive(true);

                    mejaDisplay.GetComponent<Image>().sprite = display.GetSprite();
                }
            }
        }
        else if(GameObject.Find("Player").GetComponent<PlayerInteraction>().getMeja() == 2)
        {
            display = GameObject.Find("MejaAtasKananDisplay").GetComponent<TableInventory>().getItemDisplay();

            if (display is not null)
            {
                if (display.getHarga() != 0)
                {
                    Debug.Log("masuk2");
                    mejaDisplay.SetActive(true);

                    mejaDisplay.GetComponent<Image>().sprite = display.GetSprite();
                }
            }
        }
    }

    public int getNomor()
    {
        return nomor;
    }

    /*public Item getItem()
    {
        return inventory.getItem(nomor);
    }*/

    public string getJeneng(int nomor)
    {
        return inventory.getJeneng(nomor);
    }
}
