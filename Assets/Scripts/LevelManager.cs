using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject levelUp;

    // params
    [SerializeField] int breakableBlocks;  // for debugging purpose

    // cached components
    SceneLoader sceneLoader;


    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }


    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }


    public void BreakOneBlock()
    {
        breakableBlocks--;

        if (breakableBlocks <= 0)
        {
            StartCoroutine(WaitAndLoad());
        }
    }

    IEnumerator WaitAndLoad()
    {
        levelUp.SetActive(true);
        GameObject.Find("Play Area").SetActive(false);
        yield return new WaitForSeconds(0.8f);
        sceneLoader.LoadNextScene();
    }
}
