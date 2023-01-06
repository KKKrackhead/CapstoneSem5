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


    /*public void Awake()
    {
        Display = new Item(Item.ItemType.Weapon, "Golok", 18);
        checkItem = 1;
        gameObject.GetComponent<SpriteRenderer>().sprite = Display.GetSprite2();
    }*/

    public void ChangeImage(string jeneng, int itemIndex)
    {

        inventory = GameObject.Find("Player").GetComponent<PlayerMovement>().getPlayerInventory();

        Display = inventory.getItem(itemIndex);

        if (jeneng.Equals("Golok"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Display.GetSprite();
        }
        else if(jeneng.Equals("Beras Kencur"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Display.GetSprite();
        }
        else if(jeneng.Equals("Gula Aren"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Display.GetSprite();
        }

        UI_InventoryActive.anchoredPosition = new Vector3(4060f, 540f, 0f);
        checkItem = 1;
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
}
