using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Move move;
    [SerializeField] private float WalkingDistance;
    [SerializeField] private float maxWalkingDistance;
    private float previousXPosition;


    // Start is called before the first frame update
    private void Awake()
    {
        move = GetComponent<Move>();
    }

    void start()
    {
        WalkingDistance = 0;
        move.direction = -1;
    }

    // Update is called once per frame
    void Update()
    {
        WalkingDistance += Mathf.Abs(move.OffsetPosition().x);

        if (WalkingDistance >= maxWalkingDistance)
        {
            move.direction *= -1;
            WalkingDistance = 0;
        }
    }
}
