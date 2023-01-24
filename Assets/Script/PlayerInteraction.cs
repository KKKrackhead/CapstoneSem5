using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{

    public RectTransform UI_InventoryActive;
    public RectTransform UI_Lemari;
    public Text uangPlayer;

    private int meja = 0;
    /*
    1 -> meja atas kiri
    2 -> meja atas kanan
    3 -> meja bawah kiri
    4 -> meja bawah kanan
    */
    private int lemari = 0;
    private int kasir = 0;

    public int playerGold;
    private int playerGoldAwal;

    private void Awake()
    {
        playerGoldAwal = playerGold;
        uangPlayer.text = "" + playerGold;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && meja != 0)
        {
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            UI_InventoryActive.anchoredPosition = new Vector3(960f, 540f, 0f);
            GameObject.Find("UI_PlayerInventory").GetComponent<UI_Inventory>().RefreshInventoryItems();
        }
        else if (Input.GetKeyDown(KeyCode.E) && lemari != 0)
        {
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            UI_Lemari.anchoredPosition = new Vector3(960f, 540f, 0f);
        }
        else if(Input.GetKeyDown(KeyCode.E) && kasir != 0)
        {
            int tanda = GameObject.Find("ShopCheck").GetComponent<ShopCheck>().getAntrianKasir();

            if (tanda != 0)
            {
                playerGold += GameObject.Find("ShopCheck").GetComponent<ShopCheck>().dapetDuit();
                GameObject.Find("ShopCheck").GetComponent<ShopCheck>().layaniPengunjung();
                uangPlayer.text = "" + playerGold;
                Debug.Log("player gold sekarang = " + playerGold);
            }
        }
    }

    public void PlayerDoBuy(int price)
    {
        Debug.Log("gold received = " +price);
        playerGold -= price;
        Debug.Log("Player's gold after buying = " +playerGold);
        Sound.playSound("coin");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("MejaAtasKiri"))
        {
            meja = 1;
        }
        else if (collision.tag.Equals("MejaAtasKanan"))
        {
            meja = 2;
        }
        else if (collision.tag.Equals("MejaBawahKiri"))
        {
            meja = 3;
        }
        else if (collision.tag.Equals("MejaBawahKanan"))
        {
            meja = 4;
        }
        else if (collision.tag.Equals("Lemari"))
        {
            lemari = 1;
        }
        else if (collision.tag.Equals("Kasir"))
        {
            kasir = 1;
        }
    }

    public int getKeuntungan()
    {
        return (playerGold - playerGoldAwal);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        meja = 0;
        lemari = 0;
        kasir = 0;
    }

    public int getMeja()
    {
        return meja;
    }
}
