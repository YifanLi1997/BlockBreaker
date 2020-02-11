using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject sparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    [Header("Bonus prefabs")]
    [SerializeField] GameObject ballPrefab;

    // state vars
    int hitTimes = 0;
    float secondBallRate;

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

            TriggerSecondBall();
            TriggerSparklesVFX();
            levelManager.BreakOneBlock();
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[hitTimes];
        }
    }

    private void TriggerSecondBall()
    {
        secondBallRate = UnityEngine.Random.Range(0f, 1f) ;
        if (secondBallRate <= 0.9)
        {
            InstantiateAndDestroyBall();
        }
    }

    private void InstantiateAndDestroyBall()
    {
        GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation) as GameObject;
        ball.GetComponent<Ball>().SetStart(true);
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -15f);
        // The disappearing logic is contradictory with lose logic. Gonna give it up for now
        //Destroy(ball, 0.5f);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(sparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
