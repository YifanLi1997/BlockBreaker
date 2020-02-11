using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseTrigger : MonoBehaviour
{
    [SerializeField] GameObject fail;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(WaitAndLoad());

    }

    IEnumerator WaitAndLoad()
    {
        fail.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("Game Over");
    }
}
