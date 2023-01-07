using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Weapon, Potion, Ingredient
    }

    private ItemType type;
    private string jeneng; // nama item
    private int harga;

    public Item(ItemType type, string jeneng, int harga)
    {
        this.type = type;
        this.jeneng = jeneng;
        this.harga = harga;
    }   
    
    public Item(Item buy)
    {
        this.type = buy.type;
        this.jeneng = buy.jeneng;
        this.harga = buy.harga;
    }

   public Sprite GetSprite()
    {
        switch (jeneng)
        {
            default:

            case "Golok": return ItemAssets.Instance.Golok;
            case "Asem Jawa": return ItemAssets.Instance.AsemJawa;
            case "Beras Kencur": return ItemAssets.Instance.BerasKencur;
        }
    }
    public Sprite GetSprite2()
    {
        switch (jeneng)
        {
            default:

            case "Golok": return ItemAsset2.Instance.Golok;
            case "Asem Jawa": return ItemAsset2.Instance.AsemJawa;
            case "Beras Kencur": return ItemAsset2.Instance.BerasKencur;
        }
    }

    public int getHarga()
    {
        return harga;
    }

    public string getJeneng()
    {
        return jeneng;
    }

    public void setHarga(int harga)
    {
       this.harga = harga;
    }
}
