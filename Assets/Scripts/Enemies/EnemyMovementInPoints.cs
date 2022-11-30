using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementInPoints : MonoBehaviour
{
    [SerializeField]
    public Transform[] movementPoints;

    private int currentMoveIndex;

    private Vector3 targetPosition;

    private float moveSpeed = 8f;

    [SerializeField]
    private bool moveRandomly;

    [SerializeField] private float minSpeed, maxSpeed;



    private void Start()
    {
        SetTargetPosition();
    }
    private void Update()
    {
        Move();
    }
    void SetTargetPosition()
    {
        if (moveRandomly)
            MovementInRandom();
        else
            MovementInPoints();
    }

    void MovementInRandom()
    {
        while(movementPoints[currentMoveIndex].position==transform.position)
        {
            currentMoveIndex = Random.Range(0, movementPoints.Length);
            
        }
        targetPosition = movementPoints[currentMoveIndex].position;
        moveSpeed = Random.Range(minSpeed, maxSpeed);
    }

    void MovementInPoints()
    {
        if(currentMoveIndex>=movementPoints.Length)
        {
            currentMoveIndex = 0;
           
        }
        targetPosition = movementPoints[currentMoveIndex].position;
        currentMoveIndex++;        
        moveSpeed = Random.Range(minSpeed,maxSpeed);

    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < .1f)
        {
            SetTargetPosition();
        }

    }



}//class









































