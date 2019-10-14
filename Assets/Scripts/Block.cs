using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject sparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    // state vars
    int hitTimes = 0;

    //cached references
    LevelManager levelManager;


    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        if (tag == "breakable")
        {
            levelManager.CountBreakableBlocks();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "breakable")
        {
            hitTimes++;
            HandleHits();
        }
    }

    private void HandleHits()
    {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

        if (hitTimes >= hitSprites.Length)
        {
            Destroy(gameObject);

            TriggerSparklesVFX();
            levelManager.BreakOneBlock();
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[hitTimes];
        }
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(sparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
