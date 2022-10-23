using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public RectTransform UI_InventoryActive;

    private int meja = 0;
    /*
    1 -> meja atas kiri
    2 -> meja atas kanan
    3 -> meja bawah kiri
    4 -> meja bawah kanan
    */

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && meja != 0)
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
            UI_InventoryActive.anchoredPosition = new Vector3(960f, 540f, 0f);
        }
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
    }

    public int getMeja()
    {
        return meja;
    }
}
