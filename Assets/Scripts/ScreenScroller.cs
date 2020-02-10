using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScroller : MonoBehaviour
{
    [SerializeField] float verticalScrollingSpeed = 0.1f;
    [SerializeField] float horizontalScrollingSpeed = 0.03f;
    Material material;
    Vector2 offset;

    private void Awake()
    {
        int screenScrollerCount = FindObjectsOfType<ScreenScroller>().Length;

        if (screenScrollerCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = new Vector2(horizontalScrollingSpeed, verticalScrollingSpeed);
    }

    
    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
