using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMove : MonoBehaviour
{
    [SerializeField]
    private float minSpeed = 4f, maxSpeed = 10f;

    private float speedX, speedY;

    private bool moveOnX, moveOnY = true;

    [SerializeField]
    private float minRotationalSpeed = 15f, maxRotationalSpeed = 50f;

    private float rotationalSpeed;

    private Vector3 tempMovement;

    private float z_Rotation;

    private void Awake()
    {
        rotationalSpeed = Random.Range(minRotationalSpeed, maxRotationalSpeed);

        speedX = Random.Range(minSpeed, maxSpeed);
        speedY = speedX;

        if (Random.Range(0, 2) > 0)
        {
            speedX *= -1f;
        }
        if (Random.Range(0, 2) > 0)
            rotationalSpeed *= -1f;

        if (Random.Range(0, 2) > 0)
        {
            moveOnX = true;
        }
    }

    private void Update()
    {
        HandleMovementX();
        HandleMovementY();
        RotateMeteor();
    }

    void HandleMovementX()
    {
        if (!moveOnX)
            return;

        tempMovement = transform.position;
        tempMovement.x += speedX * Time.deltaTime;
        transform.position = tempMovement;
    }

    void HandleMovementY()
    {
        if (!moveOnY)
            return;

        tempMovement = transform.position;
        tempMovement.y -= speedY * Time.deltaTime;
        transform.position = tempMovement;
    }

    void RotateMeteor()
    {


        /*z_Rotation += rotationalSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(z_Rotation, Vector3.forward);*/


        if (Random.Range(0, 2) > 0)
            gameObject.transform.Rotate(0f, 0f, rotationalSpeed * Time.deltaTime, Space.Self);
        else
            return;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(TagManager.UNTAGGED_TAG))
        {
            Destroy(gameObject);
        }
    }

}
