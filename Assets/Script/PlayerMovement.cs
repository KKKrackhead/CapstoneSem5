using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Vector2 moveDirection;
    private Inventory inventory;

    [SerializeField] private UI_Inventory uiInventory;
    [SerializeField] private UI_Inventory2 uiInventory2;
    [SerializeField] private ConfirmButtonMejaDisplay confirmButton;
    [SerializeField] private Mover move;
    [SerializeField] public GameObject ShopOpen;


    /*private void Awake()
    {
        inventory = new Inventory();
        uiInventory.setInventory(inventory);
        confirmButton.setInventory(inventory);
    }*/

    private void Start()
    {
        inventory = new Inventory();
        uiInventory.setInventory(inventory);
        uiInventory2.setInventory(inventory);
        confirmButton.setInventory(inventory);
        move.setInventory(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        if (ShopOpen.GetComponent<ShopMaster>().ShopIsOpen) return;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY);

        if (moveDirection.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveDirection.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (GetComponent<Animator>())
        {
            GetComponent<Animator>().SetFloat("Velx", Mathf.Abs(moveDirection.x));
        }
        if (GetComponent<Animator>())
        {
            GetComponent<Animator>().SetFloat("Vely", Mathf.Abs(moveDirection.y));
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    public Inventory getPlayerInventory()
    {
        return inventory;
    }
}