using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Movement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints1;
    [SerializeField] private Transform[] waypoints2;
    [SerializeField] private float moveSpeed = 2f;

    private int waypointIndex = 0;

    private int jalur;

    private void Start()
    {
        jalur = Random.Range(0, 2);
        if(jalur == 0)
        {
            transform.position = waypoints1[waypointIndex].transform.position;
        }
        else
        {
            transform.position = waypoints2[waypointIndex].transform.position;
        }
    }

    private void Update()
    {
        if(jalur == 0)
        {
            Move1();
        }
        else
        {
            Move2();
        }
    }

    private void Move1()
    {
        if(waypointIndex <= waypoints1.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints1[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            if(gameObject.transform.position == waypoints1[waypointIndex].transform.position)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Move2()
    {
        if (waypointIndex <= waypoints2.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints2[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            if (gameObject.transform.position == waypoints2[waypointIndex].transform.position)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
