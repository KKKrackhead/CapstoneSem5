using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    

    public void DoJump()
    {
        if (DialogueManager.Getinstance().DialogueIsPlaying)
        {
            return;
        }

        if (GetComponent<Player>().health == 0)
        {
            return;
        }

        GetComponent<Rigidbody2D>().velocity = Vector2.up * 5;
        GetComponent<Animator>().SetBool("isjumping", true);
    }
}
