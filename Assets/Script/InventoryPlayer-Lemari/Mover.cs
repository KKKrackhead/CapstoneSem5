using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Inventory inventoryPlayer;
    private Inventory2 inventoryLemari;

    private int JmlhinventoryPlayer;
    private int JmlhinventoryLemari;

    public void setInventory(Inventory inventory)
    {
        this.inventoryPlayer = inventory;
        JmlhinventoryPlayer = inventoryPlayer.getJumlahItem();
    }

    public void setInventory2(Inventory2 inventory)
    {
        this.inventoryLemari = inventory;
        JmlhinventoryLemari = inventoryLemari.getJumlahItem();
    }

    public void MoveToPlayer(int nomor)
    {
        JmlhinventoryPlayer = inventoryPlayer.getJumlahItem();
        if (JmlhinventoryPlayer < 5)
        {
            inventoryPlayer.AddItem(inventoryLemari.getItem(nomor));
            inventoryLemari.RemoveItem(nomor);
            JmlhinventoryPlayer++;
            JmlhinventoryLemari--;
        }
    }

    public void MoveToLemari(int nomor)
    {
        JmlhinventoryLemari = inventoryLemari.getJumlahItem();
        if (JmlhinventoryLemari < 15)
        {
            inventoryLemari.AddItem(inventoryPlayer.getItem(nomor));
            inventoryPlayer.RemoveItem(nomor);
            JmlhinventoryPlayer--;
            JmlhinventoryLemari++;
        }
    }

    public void okButton()
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-4060f, 540f, 0f);
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
    }
}
