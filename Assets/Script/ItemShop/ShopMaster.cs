using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMaster : MonoBehaviour
{
    [SerializeField] GameObject shopcanvas;
    [SerializeField] GameObject shopui;
    [SerializeField] GameObject gantiHari;
    bool NearShop;
    public bool ShopIsOpen;
    public Vector3 temp;

    void Start()
    {
        NearShop = false;
        ShopIsOpen = false;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NearShop = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        NearShop = false;

    }
    public void exitshop()
    {
        shopui.transform.position = new Vector3(-4590, -8010, 0) * .2f;
        ShopIsOpen = false;
        gantiHari.GetComponent<ShopCheck>().setTanda(1);
    }

    public void openShop()
    {
        shopui.transform.position = new Vector3(4590, 8010, 0) * .2f;
        ShopIsOpen = true;
    }
}
