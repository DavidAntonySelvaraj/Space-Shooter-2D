using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMovement : MonoBehaviour
{
    
    [SerializeField]private float min_X,max_X;

    [SerializeField]
    private float min_Y,max_Y;

    [SerializeField]
    private float moveSpeed = 4f;

    private Vector3 targetPosiion;


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
        targetPosiion = new Vector3(Random.Range(min_X,max_X),Random.Range(min_Y,max_Y),0f);
        Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosiion, moveSpeed*Time.deltaTime);

        if(Vector3.Distance(transform.position,targetPosiion)<0.1f)
        {
            SetTargetPosition();
        }
    }
}
