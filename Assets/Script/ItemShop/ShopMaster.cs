using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMaster : MonoBehaviour
{
    [SerializeField] GameObject shopcanvas;
    [SerializeField] GameObject shopui;
    bool NearShop;
    public bool ShopIsOpen;
    public Vector3 temp;

    void Start()
    {
        NearShop = false;
        ShopIsOpen = false;
        Debug.Log("Player is not near shop");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NearShop = true;
        Debug.Log("Player is near the shop");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        NearShop = false;
        Debug.Log("PLayer left the shop");
    }

    public void Update()
    {
        if (NearShop && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("haha yes");
            shopui.transform.position = new Vector3(4590, 8010, 0) * .2f;
            ShopIsOpen = true;
        }
    }
    public void exitshop()
    {
        shopui.transform.position = new Vector3(-4590, -8010, 0) * .2f;
        ShopIsOpen = false;
    }
}
