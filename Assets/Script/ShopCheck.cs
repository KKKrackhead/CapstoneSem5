using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCheck : MonoBehaviour
{

    private int maxPengunjung = 5;
    private int antrianKasir = 0;

    public int getMaxPengunjung()
    {
        return maxPengunjung;
    }

    public int getAntrianKasir()
    {
        return antrianKasir;
    }

    public void setAntrianKasir()
    {
        antrianKasir += 1;
    }
}
