using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Spawner : MonoBehaviour
{
    public GameObject[] NPCPrefabs;
    public Transform SpawnPoint;
    private int randomNPC_Type;
    private bool ea = false;

    private void Update()
    {
        if (!ea)
        {
            StartCoroutine(Waiter());
        }
    }

    IEnumerator Waiter()
    {
        ea = true;

        randomNPC_Type = Random.Range(0, NPCPrefabs.Length);

        GameObject baru = Instantiate(NPCPrefabs[randomNPC_Type], SpawnPoint.position, transform.rotation);

        baru.SetActive(true);

        yield return new WaitForSeconds(3);

        ea = false;
    }
}
