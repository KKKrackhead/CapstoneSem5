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
    public Text hari;
    public int harike = 0;

    //keuntungan
    public GameObject NPCSpawner;
    public GameObject keuntunganMuncul;
    public GameObject keuntunganUI;
    private int tandaUI;
    public Text keuntungan;
    public Text hariUntung;

    //ganti
    public Text gantiHari;
    public GameObject muncul;
    private int tanda = 1;

    private void Update()
    {
        if(tanda == 1)
        {
            tanda = 0;
            timerRunning = true;
            timePass = 0;
            minutesGame = 6;
            secondsGame = 0;
            secondsReal = 0;
            StartCoroutine(tunggubos());
        }
    }

    public void setTanda(int tanda)
    {
        this.tanda = tanda;
    }
    IEnumerator tunggubos()
    {
        LeanTween.moveLocalY(keuntunganMuncul, 1500f, 0.1f);
        LeanTween.scale(keuntunganUI, new Vector3(0f, 0f), 0.1f).setEaseInElastic();
        harike++;
        hari.text = "Hari " + harike;
        gantiHari.text = "Hari " + harike;

        LeanTween.scale(muncul, new Vector3(1, 1), 0.5f).setEaseInElastic();

        yield return new WaitForSeconds(2);

        LeanTween.scale(muncul, new Vector3(0, 0), 0.5f).setEaseInElastic();
        NPCSpawner.SetActive(true);
    }

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

    private void FixedUpdate()
    {
        if (timerRunning)
        {
            timePass += Time.fixedDeltaTime;
            secondsReal = Mathf.FloorToInt(timePass % 60);
            if(secondsReal.Equals(1))
            {
                secondsReal = 0;
                timePass = 0;
                secondsGame += 4;
                if(secondsGame == 60)
                {
                    secondsGame = 0;
                    minutesGame += 1;
                }
                if(minutesGame == 18)
                {
                    timerRunning = false;
                }
            }
            timeText.text = string.Format("{0:00} {1:00}", minutesGame, secondsGame);
        }

        if (!timerRunning)
        {
            timeText.text = string.Format("{0:00} {1:00}", minutesGame, secondsGame);
        }

        if(!timerRunning && NPCSpawner.GetComponent<NPC_Spawner>().getJumlahNPC().Equals(0) && tandaUI == 0 && minutesGame == 18)
        {
            timeText.text = string.Format("{0:00} {1:00}", minutesGame, secondsGame);
            hariUntung.text = "Hari " + harike;
            keuntungan.text = "" + GameObject.Find("Player").GetComponent<PlayerInteraction>().getKeuntungan();
            tandaUI = 1;
            LeanTween.moveLocalY(keuntunganMuncul, 0f, 0.1f);
            LeanTween.scale(keuntunganUI, new Vector3(1f, 1f), 0.5f).setEaseInElastic();
            NPCSpawner.SetActive(false);
        }
    }

    public int getMinutesReal()
    {
        return minutesGame;
    }
}
