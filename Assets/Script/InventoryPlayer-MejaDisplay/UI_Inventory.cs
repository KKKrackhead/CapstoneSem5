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
        Debug.Log("reset item");
        foreach (Transform child in itemSlotContainer)
        {
            if(child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        nomor = 0;

        //int x = 0;
        int y = 0;
        float itemSlotCellSize = -170f;

        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(0f,y * itemSlotCellSize);

            Image image = itemSlotRectTransform.Find("ItemImage").GetComponent<Image>();
            image.sprite = item.GetSprite();
            nomor++;
            y++;
        }

        if(GameObject.Find("Player").GetComponent<PlayerInteraction>().getMeja() == 1)
        {
            display = GameObject.Find("MejaAtasKiriDisplay").GetComponent<TableInventory>().getItemDisplay();

            if (display is not null)
            {
                if (display.getHarga() != 0)
                {
                    mejaDisplay.SetActive(true);

                    mejaDisplay.GetComponent<Image>().sprite = display.GetSprite();
                }
            }
            else
            {
                mejaDisplay.SetActive(false);
            }
        }
        else if(GameObject.Find("Player").GetComponent<PlayerInteraction>().getMeja() == 2)
        {
            display = GameObject.Find("MejaAtasKananDisplay").GetComponent<TableInventory>().getItemDisplay();

            if (display is not null)
            {
                if (display.getHarga() != 0)
                {
                    mejaDisplay.SetActive(true);

                    mejaDisplay.GetComponent<Image>().sprite = display.GetSprite();
                }
            }
            else
            {
                mejaDisplay.SetActive(false);
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
