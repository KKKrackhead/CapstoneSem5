using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    public float direction;

    Rigidbody2D rb;

    bool isGrounded;
    public Transform GroundCheck;
    public LayerMask Groundlayer;

    public GameObject SpawnEffect;
    public Vector3 SpawnPoint;

    public int health;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        Instantiate(SpawnEffect, transform.position , Quaternion.identity);
    }

    private void Start()
    {
        SpawnPoint = transform.position;
        health = 3;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, Groundlayer);
    }

    private void Update()
    {
        GetComponent<Move>().direction = Input.GetAxisRaw("Horizontal");
       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                GetComponent<Jump>().DoJump();
            }
        }

        GetComponent<Animator>().SetFloat("HeightVelocity", rb.velocity.y);

        if (isGrounded)
        {
            GetComponent<Animator>().SetBool("isjumping", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("isjumping", true);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<Player>().health--;
            Debug.Log("Damage Taken. Health = " + health);
            if (GetComponent<Player>().health <= 0)
            {
                GetComponent<Animator>().SetTrigger("death");
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = SpawnPoint;
            Instantiate(SpawnEffect, transform.position, Quaternion.identity);
            GetComponent<Animator>().SetTrigger("spawn");
            GetComponent<Player>().health = 3;
        }
    }


}
