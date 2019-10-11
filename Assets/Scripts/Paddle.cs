using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenWidthInUnit = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    float mouseXPosInUnit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveWithMouse();
    }

    private void MoveWithMouse()
    {
        mouseXPosInUnit = Input.mousePosition.x / Screen.width * screenWidthInUnit;
        transform.position = new Vector2(Mathf.Clamp(mouseXPosInUnit, minX, maxX), transform.position.y);
    }
}
