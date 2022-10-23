using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableInventory : MonoBehaviour
{
    private Item Display;
    private Inventory inventory;
    public RectTransform UI_InventoryActive;
    public GameObject UI_playerInventory;
    private GameObject[] clone;

    public void ChangeImage(string jeneng, int itemIndex)
    {

        inventory = GameObject.Find("Player").GetComponent<PlayerMovement>().getPlayerInventory();

        Display = inventory.getItem(itemIndex);

        Debug.Log(itemIndex + " table");

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
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
    }
}
