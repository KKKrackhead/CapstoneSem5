using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float movementSpeed;
    public float direction;

    void Start()
    {
    
    }

    void Update()
    {
        if (GetComponent<Player>().health == 0)
        {
            return;
        }

        if (DialogueManager.Getinstance().DialogueIsPlaying)
        {
            return;
        }
        //GetComponent<Transform>().position = GetComponent<Transform>().position + new Vector3(0.01f, 0, 0);
        MoveAround();

        if (GetComponent<Animator>())
        {
            GetComponent<Animator>().SetFloat("velocity", Mathf.Abs(direction));
        }
    }

    private void MoveAround()
    {
        //float direction = Input.GetAxis("Horizontal"); //to get an axis???? from unity, this is simpler for movement bc of unity settings with WASD
        //float direction = Input.GetAxisRaw("Horizontal"); //doesn't slide like non-Raw, moved to InputHandler.cs

        if (direction > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        transform.position = transform.position + (new Vector3(1, 0, 0) * direction * Time.deltaTime * movementSpeed);


        // Input.GetKey(KeyCode.A); //return true value when button is pressed
        // Input.GetKeyDown(KeyCode.A); //to catch an input by pressing a button only once
        // Input.getKeyUp(KeyCode.A); //to catch an input when we release a button
    }

    public Vector3 OffsetPosition()
    {
        return Vector3.right * direction * Time.deltaTime * movementSpeed;
    }
}
