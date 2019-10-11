using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
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
            sceneLoader.LoadNextScene();
        }
    }
}
