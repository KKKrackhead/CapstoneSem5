using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCheck : MonoBehaviour
{

    private int maxPengunjung = 5;
    private int antrianKasir = 0;
    private int hargaBeli = 0;
    private List<GameObject> pembeli = new List<GameObject>();

    public int getMaxPengunjung()
    {
        return maxPengunjung;
    }

    public int getAntrianKasir()
    {
        return antrianKasir;
    }

    public void setAntrianKasir(GameObject pembeli)
    {
        antrianKasir += 1;
        this.pembeli.Add(pembeli);
    }

    public void layaniPengunjung()
    {
        LeanTween.scale(pembeli[0], new Vector3(0, 0), 0.5f).setEaseInElastic();
        pembeli.RemoveAt(0);

        for(int a = 0; a < pembeli.Count; a++)
        {
            LeanTween.moveLocalY(pembeli[a], pembeli[a].GetComponent<Transform>().localPosition.y - (-1), 1);
        }
    }

    public int dapetDuit()
    {
        return pembeli[0].GetComponent<NPC_Movement>().getHarga();
    }
}
