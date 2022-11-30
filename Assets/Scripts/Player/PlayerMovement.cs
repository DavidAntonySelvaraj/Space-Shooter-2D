using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float speed;

    private Rigidbody2D myBody;

    [SerializeField]
    private float minX,maxX, minY, maxY;    

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();   
    }


    private void Update()
    {
        Movement();
        HoldMovement();
    }

    void Movement()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            myBody.AddForce(transform.up * speed*Time.deltaTime,ForceMode2D.Force);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            myBody.AddForce(-transform.up * speed * Time.deltaTime, ForceMode2D.Force);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            myBody.AddForce(-transform.right * speed * Time.deltaTime, ForceMode2D.Force);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            myBody.AddForce(transform.right * speed*Time.deltaTime, ForceMode2D.Force);
        }
    }



    void HoldMovement()
    {
        if (transform.position.x < minX)
            transform.position = new Vector3(minX,transform.position.y,0f);

        if (transform.position.x > maxX)
            transform.position = new Vector3(maxX,transform.position.y,0f);

        if (transform.position.y < minY)
            transform.position = new Vector3(transform.position.x, minY, 0f);

        if (transform.position.y > maxY)
            transform.position = new Vector3(transform.position.x, maxY, 0f);
    }

}//class

























