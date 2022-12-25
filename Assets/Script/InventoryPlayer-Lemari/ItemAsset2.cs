using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAsset2 : MonoBehaviour
{
    public static ItemAsset2 Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite Golok;
    public Sprite BerasKencur;
    public Sprite AsemJawa;
}
