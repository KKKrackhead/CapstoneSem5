using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private Inventory inventory;

    [SerializeField] private UI_Inventory uiInventory;
    [SerializeField] private UI_Inventory2 uiInventory2;
    [SerializeField] private ConfirmButtonMejaDisplay confirmButton;
    [SerializeField] private Mover move;


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
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY);

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
