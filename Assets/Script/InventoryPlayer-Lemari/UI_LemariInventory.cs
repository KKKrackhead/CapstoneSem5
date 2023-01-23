using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LemariInventory : MonoBehaviour
{
    public Inventory2 inventory;
    public Transform itemSlotContainer;
    public Transform itemSlotTemplate;
    private int nomor;

    [SerializeField] private Mover move;

    public void Awake()
    {
        inventory = new Inventory2();
        setInventory(inventory);
        move.setInventory2(inventory);
    }

    public void setInventory(Inventory2 inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged2 += Inventory_OnItemListChange2;

        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChange2(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        nomor = 0;
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 170f;

        foreach (Item item in inventory.GetItemList())
        {
            if (x != 4)
            {
                RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
                itemSlotRectTransform.gameObject.SetActive(true);
                itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);

                Image image = itemSlotRectTransform.Find("ItemImage").GetComponent<Image>();
                image.sprite = item.GetSprite2();
                nomor++;
                x++;

            }
            else
            {
                RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
                itemSlotRectTransform.gameObject.SetActive(true);
                itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);

                Image image = itemSlotRectTransform.Find("ItemImage").GetComponent<Image>();
                image.sprite = item.GetSprite2();
                nomor++;
                x=0;
                y--;
            }
        }
    }

    public int getNomor()
    {
        return nomor;
    }


    public Inventory2 getInventory()
    {
        return inventory;
    }
}
