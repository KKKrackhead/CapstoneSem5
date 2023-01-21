using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCheck : MonoBehaviour
{

    private int maxPengunjung = 5;
    private int antrianKasir = 0;
    private int hargaBeli = 0;
    private List<GameObject> pembeli = new List<GameObject>();

    //timer
    private bool timerRunning = true;
    private float timePass = 0;
    private int minutesGame = 6;
    private float secondsGame;
    private float secondsReal;

    public Text timeText;

    //ganti hari
    public GameObject NPCSpawner;
    public GameObject keuntunganMuncul;
    public GameObject keuntunganUI;
    private int tandaUI;
    public Text keuntungan;

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
        Sound.playSound("coin");
        antrianKasir -= 1;
        NPCSpawner.GetComponent<NPC_Spawner>().setJumlahNPC();

        for (int a = 0; a < pembeli.Count; a++)
        {
            LeanTween.moveLocalY(pembeli[a], pembeli[a].GetComponent<Transform>().localPosition.y - (-1), 1);
        }
    }

    public int dapetDuit()
    {
        return pembeli[0].GetComponent<NPC_Movement>().getHarga();
    }

    public void SetTimerRunning(bool value)
    {
        timerRunning = value;
    }

    private void Update()
    {
        if (timerRunning)
        {
            timePass += Time.fixedDeltaTime;
            secondsReal = Mathf.FloorToInt(timePass % 60);
            if(secondsReal.Equals(1))
            {
                secondsReal = 0;
                timePass = 0;
                secondsGame += 30;
                if(secondsGame == 60)
                {
                    secondsGame = 0;
                    minutesGame += 1;
                }
                if(minutesGame == 7)
                {
                    timerRunning = false;
                }
            }
            timeText.text = string.Format("{0:00} {1:00}", minutesGame, secondsGame);
        }
        if(!timerRunning && NPCSpawner.GetComponent<NPC_Spawner>().getJumlahNPC().Equals(0) && tandaUI == 0)
        {
            keuntungan.text = "" + GameObject.Find("Player").GetComponent<PlayerInteraction>().getKeuntungan();
            Debug.Log("aa");
            tandaUI = 1;
            LeanTween.moveLocalY(keuntunganMuncul, 0f, 0.1f);
            LeanTween.scale(keuntunganUI, new Vector3(1f, 1f), 1.5f).setEaseInElastic();
            timeText.gameObject.SetActive(false);
        }
    }

    public int getMinutesReal()
    {
        return minutesGame;
    }
}
