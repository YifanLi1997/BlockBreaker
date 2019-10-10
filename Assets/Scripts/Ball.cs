using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;


    Vector3 ballToPaddleVector;
    bool hasStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        ballToPaddleVector = transform.position - paddle.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            LockBallToPaddle();
            ClickToLaunchTheBall();
        }
    }

    private void LockBallToPaddle()
    {
        transform.position = paddle.transform.position + ballToPaddleVector;
    }

    private void ClickToLaunchTheBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }
}
