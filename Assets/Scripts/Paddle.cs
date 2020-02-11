using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // config params
    [SerializeField] float screenWidthInUnit = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] Ball ball;

    // state vars
    float mouseXPosInUnit;
    bool hasStarted = false;

    // cached references
    GameSession myGameSession;

    // Start is called before the first frame update
    void Start()
    {
        myGameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            MovePaddle();
        }
        else
        {
            CheckMouseClick();
        }
        
    }

    private void MovePaddle()
    {
        if (myGameSession.IsAutoPlayEnabled())
        {
            if (!ball)
            {
                return;
            }
            mouseXPosInUnit = ball.transform.position.x;
        }
        else
        {
            mouseXPosInUnit = Input.mousePosition.x / Screen.width * screenWidthInUnit;
        }

        transform.position = new Vector2(Mathf.Clamp(mouseXPosInUnit, minX, maxX), transform.position.y);
    }

    private void CheckMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
        }
    }
}
