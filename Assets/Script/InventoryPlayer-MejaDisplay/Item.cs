using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Weapon, Potion, Ingredient
    }

    public ItemType type;
    public string jeneng; // nama item
    public int amount;
    //private SpriteRenderer gambar;

    public Item(ItemType type, string jeneng, int amount /*,SpriteRenderer gambar*/)
    {
        this.type = type;
        this.jeneng = jeneng;
        this.amount = amount;
        //this.gambar = gambar;
    }   

   public Sprite GetSprite()
    {
        switch (jeneng)
        {
            default:

            case "Golok": return ItemAssets.Instance.Golok;
            case "Gula Aren": return ItemAssets.Instance.GulaAren;
            case "Beras Kencur": return ItemAssets.Instance.BerasKencur;

        }
    }
    public Sprite GetSprite2()
    {
        switch (jeneng)
        {
            default:

            case "Golok": return ItemAsset2.Instance.Golok;
            case "Gula Aren": return ItemAsset2.Instance.GulaAren;
            case "Beras Kencur": return ItemAsset2.Instance.BerasKencur;

        }
    }
}
