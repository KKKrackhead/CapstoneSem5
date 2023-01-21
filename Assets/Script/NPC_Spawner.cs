using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Spawner : MonoBehaviour
{
    public GameObject[] NPCPrefabs;
    public Transform SpawnPoint;
    private int randomNPC_Type;
    private bool ea = false;
    //kurang boolean buat cek jualan udah beres ato gk
    private int jumlahNPC = 0;
    private GameObject baru;
    private int jalurNPC;

    private void Update()
    {
        if (!GameObject.Find("ShopCheck").GetComponent<ShopCheck>().getMinutesReal().Equals(7))
        {
            if (!ea)
            {
                if (jumlahNPC <= 5)
                {
                    if (jumlahNPC == 0)
                    {
                        StartCoroutine(Waiter());
                    }
                    else if (jalurNPC != 10)
                    {
                        StartCoroutine(Waiter());
                    }
                }
            }
        }
    }

    IEnumerator Waiter()
    {
        ea = true;

        Sound.playSound("pembeli");

        randomNPC_Type = Random.Range(0, NPCPrefabs.Length);

        baru = Instantiate(NPCPrefabs[randomNPC_Type], SpawnPoint.position, transform.rotation);

        baru.SetActive(true);

        jumlahNPC += 1;

        jalurNPC = baru.GetComponent<NPC_Movement>().getJalur();

        yield return new WaitForSeconds(10);

        ea = false;
    }

    public void setJumlahNPC()
    {
        jumlahNPC -= 1;
    }

    public int getJumlahNPC()
    {
        return jumlahNPC;
    }
}
