using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Movement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints1; //meja atas
    [SerializeField] private Transform[] waypoints2; //ke kasir
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private List<GameObject> displayTable;
    List<int> checkTableDisplay = new List<int>();

    private int waypointIndex = 0;
    private int waypointIndexMAX = 0;

    private Item buy;

    private int kasir;
    private int tandain;
    private int jalur;
    /*
     0 = atas kanan  
     1 = atas kiri
    */
    private void Start()
    {
        nentuinJalur();
    }

    private void Update()
    {
        if(jalur == 10)
        {
            nentuinJalur();
        }
        else
        {
            if (kasir == 1)
            {
                if (tandain == 0)
                {
                    waypointIndex = 0;
                    tandain = 1;
                    int antrian = GameObject.Find("ShopCheck").GetComponent<ShopCheck>().getAntrianKasir();
                    waypointIndexMAX = 7 - (5 - antrian);
                }

                MoveToCashierFromTop();
            }
            else if (jalur == 0 || jalur == 1)
            {
                Move1();
            }
        }
    }

    private void Move1()
    {
        if(waypointIndex <= waypoints1.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints1[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            if(gameObject.transform.position == waypoints1[waypointIndex].transform.position)
            {
                if (waypointIndex != waypointIndexMAX)
                {
                    waypointIndex++;
                }
                else
                {
                    waypointIndex += 10;
                }
            }
        }
        else
        {
            Item beli = displayTable[jalur].GetComponent<TableInventory>().getItemDisplay();
            buy = new Item(beli);
            displayTable[jalur].GetComponent<TableInventory>().removeItemDisplay();
            kasir = 1;
            GameObject.Find("ShopCheck").GetComponent<ShopCheck>().setAntrianKasir(gameObject);
            //Destroy(gameObject);
        }
    }

    private void MoveToCashierFromTop()
    {
        if (waypointIndex <= waypoints2.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints2[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            if (gameObject.transform.position == waypoints2[waypointIndex].transform.position)
            {
                if (waypointIndex != waypointIndexMAX)
                {
                    waypointIndex++;
                }
                else
                {
                    waypointIndex += 15;
                }
            }
        }
    }

    private void nentuinJalur() // cuma baru buat yg meja atas
    {
        checkTableDisplay.Clear();

        List<GameObject> displayTableTemp = new List<GameObject>();

        if (checkTableDisplay.Count.Equals(0))
        {
            for (int x = 0; x < displayTable.Count; x++)
            {
                checkTableDisplay.Add(displayTable[x].GetComponent<TableInventory>().getCheckItem());
                displayTableTemp.Add(displayTable[x]);
            }
        }

        int tanda = 0;

        while (tanda == 0){

                int y = Random.Range(1, checkTableDisplay.Count + 1);

                if (checkTableDisplay.Count.Equals(0))
                {
                    tanda = 1;
                    jalur = 10;
                }
                else if (checkTableDisplay[y - 1] == 1)
                {
                    tanda = 1;
                    if (displayTableTemp[y - 1].gameObject.name.Equals("MejaAtasKiriDisplay"))
                    {
                        jalur = 1;
                    }
                    else if (displayTableTemp[y - 1].gameObject.name.Equals("MejaAtasKananDisplay"))
                    {
                        jalur = 0;
                    }
                    checkTableDisplay.RemoveAt(y - 1);
                }
                else
                {
                    checkTableDisplay.RemoveAt(y - 1);
                    displayTableTemp.RemoveAt(y - 1);
                }
            }

            if (jalur == 0 || jalur == 1)
            {
                transform.position = waypoints1[waypointIndex].transform.position;
                waypointIndexMAX = 3 - jalur;
                displayTable[jalur].GetComponent<TableInventory>().removeItem();
            }
        }

        /*private void Move2()
        {
            if (waypointIndex <= waypoints2.Length - 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints2[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

                if (gameObject.transform.position == waypoints2[waypointIndex].transform.position)
                {
                    waypointIndex++;
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }*/

        public int getJalur()
    {
        return jalur;
    }
}
