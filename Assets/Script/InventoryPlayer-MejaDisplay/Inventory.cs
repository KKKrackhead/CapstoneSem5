using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    //inventory player
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;

    private int jumlahItem;

    public Inventory()
    {
        itemList = new List<Item>();

        if(itemList.Count < 5)
        {
            AddItem(new Item(Item.ItemType.Weapon, "Golok", 18));
            AddItem(new Item(Item.ItemType.Potion, "Beras Kencur", 8));
            AddItem(new Item(Item.ItemType.Ingredient, "Jahe Merah", 3));
            AddItem(new Item(Item.ItemType.Ingredient, "Jahe Merah", 3));
            AddItem(new Item(Item.ItemType.Ingredient, "Jahe Merah", 3));
        }
    }

    public void AddItem(Item item) 
    {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(int nomor)
    {
        itemList.RemoveAt(nomor);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

    public Item getItem(int nomor)
    {
        return itemList[nomor];
    }

    public void setItemList(List<Item> itemList)
    {
        this.itemList = itemList;
    }

    public string getJeneng(int nomor)
    {
        return itemList[nomor].getJeneng();
    }

    public int getJumlahItem()
    {
        jumlahItem = itemList.Count;

        return jumlahItem;
    }
}
