using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    public Text nama;
    private int random_nama;
    private List<string> jeneng = FormData.getjeneng();

    private void Start()
    {
        ngacak();
    }

    public void ngacak()
    {
        random_nama = Random.Range(0, 3);
    }

    private void Update()
    {
        nama.text = "Nama : " + jeneng[random_nama];
    }  
}
