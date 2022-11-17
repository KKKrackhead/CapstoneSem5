using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Inventory inventoryPlayer;
    private Inventory2 inventoryLemari;

    public void setInventory(Inventory inventory)
    {
        this.inventoryPlayer = inventory;
    }

    public void setInventory2(Inventory2 inventory)
    {
        this.inventoryLemari = inventory;
    }

    public void MoveToPlayer(int nomor)
    {
        inventoryPlayer.AddItem(inventoryLemari.getItem(nomor));
        inventoryLemari.RemoveItem(nomor);
    }

    public void MoveToLemari(int nomor)
    {
        inventoryLemari.AddItem(inventoryPlayer.getItem(nomor));
        inventoryPlayer.RemoveItem(nomor);
    }

    public void okButton()
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-4060f, 540f, 0f);
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
    }
}
