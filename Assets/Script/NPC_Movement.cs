using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Movement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints1; //meja atas
    [SerializeField] private Transform[] waypoints2; //ke kasir
    [SerializeField] private Transform[] waypoints3; //meja bawah
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private List<GameObject> displayTable;
    [SerializeField] private GameObject emote;
    List<int> checkTableDisplay = new List<int>();

    private int waypointIndex = 0;
    private int waypointIndexMAX = 0;

    private Item buy;

    private int kasir;
    private int tandain;
    public int jalur = 10;

    public Vector2 moveDirection;
  
    /*
     0 = atas kanan  
     1 = atas kiri
    */
    private void Awake()
    {
        jalur = 10;
        nentuinJalur();
        GetComponent<Animator>().SetBool("isWalking", false);
    }


    private void FixedUpdate()
    {
        GetComponent<Animator>().SetBool("isWalking", false);
        if (jalur == 10)
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
            else if(jalur == 2 || jalur == 3)
            {
                Move2();
            }
            
        }
    }

    private void Move1()
    {
        GetComponent<Transform>().transform.rotation = Quaternion.Euler(0, 0, 0);
        if (waypointIndex <= waypoints1.Length - 1)
        {
            GetComponent<Animator>().SetBool("isWalking", false);
            transform.position = Vector2.MoveTowards(transform.position, waypoints1[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
            GetComponent<Animator>().SetBool("isWalking", true);


            if (gameObject.transform.position == waypoints1[waypointIndex].transform.position)
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
            GetComponent<Animator>().SetBool("isWalking", false);
            Item beli = displayTable[jalur].GetComponent<TableInventory>().getItemDisplay();
            buy = new Item(beli);
            displayTable[jalur].GetComponent<TableInventory>().removeItemDisplay();
            kasir = 1;
            GameObject.Find("ShopCheck").GetComponent<ShopCheck>().setAntrianKasir(gameObject);
            //Destroy(gameObject);
        }
    }

    private void Move2()
    {
        GetComponent<Transform>().transform.rotation = Quaternion.Euler(0, 0, 0);
        if (waypointIndex <= waypoints3.Length - 1)
        {
            GetComponent<Animator>().SetBool("isWalking", false);
            transform.position = Vector2.MoveTowards(transform.position, waypoints3[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
            GetComponent<Animator>().SetBool("isWalking", true);

            if(gameObject.transform.position == waypoints3[waypointIndex].transform.position)
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
            GetComponent<Animator>().SetBool("isWalking", false);
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
        GetComponent<Transform>().transform.rotation = Quaternion.Euler(0, 180, 0);
        if (waypointIndex <= waypoints2.Length - 1)
        {
            GetComponent<Animator>().SetBool("isWalking", false);
            transform.position = Vector2.MoveTowards(transform.position, waypoints2[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
            GetComponent<Animator>().SetBool("isWalking", true);

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

    private void nentuinJalur()
    {
        emote.SetActive(false);
        GetComponent<Animator>().SetBool("isWalking", false);

        checkTableDisplay.Clear();

        int tanda = 0;
        int tanda2 = 0;
        int tanda3 = 0;

        List<GameObject> displayTableTemp = new List<GameObject>();

        if (checkTableDisplay.Count.Equals(0))
        {
            for (int x = 0; x < displayTable.Count; x++)
            {
                checkTableDisplay.Add(displayTable[x].GetComponent<TableInventory>().getCheckItem());
                displayTableTemp.Add(displayTable[x]);
            }

            for (int x = 0; x < checkTableDisplay.Count; x++)
            {
                if (checkTableDisplay.Count.Equals(0))
                {
                    tanda = 2;
                    jalur = 10;
                    break;
                }
                else if (checkTableDisplay[x] == 1)
                {
                    Item barang = displayTableTemp[x].gameObject.GetComponent<TableInventory>().getItemDisplay();

                    string namaBarang = barang.getJeneng();
                    int hargaBarang = barang.getHarga();

                    if (namaBarang.Equals("Golok"))
                    {
                        if(hargaBarang > 25)
                        {
                            checkTableDisplay[x] = 2;
                            tanda2++;
                            tanda3++;
                        }
                    }
                    else if (namaBarang.Equals("Clurit"))
                    {
                        if (hargaBarang > 109)
                        {
                            checkTableDisplay[x] = 2;
                            tanda2++;
                            tanda3++;
                        }
                    }
                    else if (namaBarang.Equals("Keris"))
                    {
                        if (hargaBarang > 476)
                        {
                            checkTableDisplay[x] = 2;
                            tanda2++;
                            tanda3++;
                        }
                    }

                    else if (namaBarang.Equals("Beras Kencur"))
                    {
                        if (hargaBarang > 15)
                        {
                            checkTableDisplay[x] = 2;
                            tanda2++;
                            tanda3++;
                        }
                    }
                    else if (namaBarang.Equals("Kunyit Asem"))
                    {
                        if (hargaBarang > 75)
                        {
                            checkTableDisplay[x] = 2;
                            tanda2++;
                            tanda3++;
                        }
                    }
                    else if (namaBarang.Equals("Brotowali"))
                    {
                        if (hargaBarang > 418)
                        {
                            checkTableDisplay[x] = 2;
                            tanda2++;
                            tanda3++;
                        }
                    }

                    else if (namaBarang.Equals("Jahe Merah"))
                    {
                        if (hargaBarang > 10)
                        {
                            checkTableDisplay[x] = 2;
                            tanda2++;
                            tanda3++;
                        }
                    }
                    else if (namaBarang.Equals("Pandan"))
                    {
                        if (hargaBarang > 49)
                        {
                            checkTableDisplay[x] = 2;
                            tanda2++;
                            tanda3++;
                        }
                    }
                    else if (namaBarang.Equals("Asem Jawa"))
                    {
                        if (hargaBarang > 326)
                        {
                            checkTableDisplay[x] = 2;
                            tanda2++;
                            tanda3++;
                        }
                    }
                }
                else
                {
                    tanda2++;
                }
            }
        }
        
        if(tanda2 == checkTableDisplay.Count && tanda3 != 0)
        {
            jalur = 10;
            tanda = 2;
        }

        while (tanda == 0){

                int y = Random.Range(1, checkTableDisplay.Count + 1);

                if (checkTableDisplay.Count.Equals(0))
                {
                   // Debug.Log("masuk 1");
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
                    else if (displayTableTemp[y - 1].gameObject.name.Equals("MejaBawahKiriDisplay"))
                    {
                        jalur = 3;
                    }
                    else if (displayTableTemp[y - 1].gameObject.name.Equals("MejaBawahKananDisplay"))
                    {
                        jalur = 2;
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
                displayTable[jalur].GetComponent<TableInventory>().getItemDisplay();
                displayTable[jalur].GetComponent<TableInventory>().removeItem();
            }
            else if(jalur == 2 || jalur == 3)
            {
                transform.position = waypoints3[waypointIndex].transform.position;
                waypointIndexMAX = 3 - (jalur-2);
                displayTable[jalur].GetComponent<TableInventory>().getItemDisplay();
                displayTable[jalur].GetComponent<TableInventory>().removeItem();
            }

            if(tanda == 2)
            {
                emote.SetActive(true);
            }
        }

    public int getJalur()
    {
        return jalur;
    }

    public int getHarga()
    {
        return buy.getHarga();
    }
}
