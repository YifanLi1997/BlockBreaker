using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    //cached references
    LevelManager levelManager;


    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.CountBreakableBlocks();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyTheBlock();
    }

    private void DestroyTheBlock()
    {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

        Destroy(gameObject);

        levelManager.BreakOneBlock();
    }
}
