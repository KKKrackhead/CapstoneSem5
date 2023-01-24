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
            case "Clurit": return ItemAssets.Instance.Clurit;
            case "Keris": return ItemAssets.Instance.Keris;

            case "Beras Kencur": return ItemAssets.Instance.BerasKencur;
            case "Kunyit Asem": return ItemAssets.Instance.KunyitAsem;
            case "Brotowali": return ItemAssets.Instance.Brotowali;

            case "Asem Jawa": return ItemAssets.Instance.AsemJawa;
            case "Jahe Merah": return ItemAssets.Instance.JaheMerah;
            case "Pandan": return ItemAssets.Instance.Pandan;
        }
    }
    public Sprite GetSprite2()
    {
        switch (jeneng)
        {
            default:

            case "Golok": return ItemAsset2.Instance.Golok;
            case "Clurit": return ItemAsset2.Instance.Clurit;
            case "Keris": return ItemAsset2.Instance.Keris;

            case "Beras Kencur": return ItemAsset2.Instance.BerasKencur;
            case "Kunyit Asem": return ItemAsset2.Instance.KunyitAsem;
            case "Brotowali": return ItemAsset2.Instance.Brotowali;

            case "Asem Jawa": return ItemAsset2.Instance.AsemJawa;
            case "Jahe Merah": return ItemAsset2.Instance.JaheMerah;
            case "Pandan": return ItemAsset2.Instance.Pandan;
        }
    }

    public Sprite GetSprite3()
    {
        switch (jeneng)
        {
            default:

            case "Golok": return ItemAsset3.Instance.Golok;
            case "Clurit": return ItemAsset3.Instance.Clurit;
            case "Keris": return ItemAsset3.Instance.Keris;

            case "Beras Kencur": return ItemAsset3.Instance.BerasKencur;
            case "Kunyit Asem": return ItemAsset3.Instance.KunyitAsem;
            case "Brotowali": return ItemAsset3.Instance.Brotowali;

            case "Asem Jawa": return ItemAsset3.Instance.AsemJawa;
            case "Jahe Merah": return ItemAsset3.Instance.JaheMerah;
            case "Pandan": return ItemAsset3.Instance.Pandan;
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
