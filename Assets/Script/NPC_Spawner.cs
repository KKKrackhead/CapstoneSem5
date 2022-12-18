using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Spawner : MonoBehaviour
{
    public GameObject[] NPCPrefabs;
    public Transform SpawnPoint;
    private int randomNPC_Type;
    private bool ea = false;
    private int jumlahNPC = 0;
    private GameObject baru;
    private int jalurNPC;

    private void Update()
    {
        if (!ea)
        {
            if (jumlahNPC < 5)
            {
                if(jumlahNPC == 0)
                {
                    StartCoroutine(Waiter());
                }
                else if(jalurNPC != 10)
                {
                    StartCoroutine(Waiter());
                }             
            }
        }
    }

    IEnumerator Waiter()
    {
        ea = true;

        randomNPC_Type = Random.Range(0, NPCPrefabs.Length);

        baru = Instantiate(NPCPrefabs[randomNPC_Type], SpawnPoint.position, transform.rotation);

        baru.SetActive(true);

        yield return new WaitForSeconds(10);

        jumlahNPC += 1;

        jalurNPC = baru.GetComponent<NPC_Movement>().getJalur();

        ea = false;
    }

    public void setJumlahNPC()
    {
        jumlahNPC -= 1;
    }
}
