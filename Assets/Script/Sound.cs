using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static AudioClip coin, pembeli, brokie;
    static AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        coin = Resources.Load<AudioClip>("SFX - CoinDrop");
        pembeli = Resources.Load<AudioClip>("SFX - Death Bell");
        brokie = Resources.Load<AudioClip>("SFX - Buzzer");
    }

    public static void playSound(string clip)
    {
        if (clip.Equals("coin")) source.PlayOneShot(coin);
        else if (clip.Equals("pembeli")) source.PlayOneShot(pembeli);
        else if (clip.Equals("brokie")) source.PlayOneShot(brokie);
    }
}
