using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormData : MonoBehaviour
{
    private static List<string> jeneng = new List<string>();

    private void Awake()
    {
        jeneng.Add("budi");
        jeneng.Add("badu");
        jeneng.Add("asep");
    }
    public static List<string> getjeneng()
    {
        return jeneng;
    }
}
