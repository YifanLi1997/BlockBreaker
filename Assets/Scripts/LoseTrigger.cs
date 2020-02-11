using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseTrigger : MonoBehaviour
{
    [SerializeField] GameObject fail;

    [Header("For Visualization")]
    [SerializeField] int numberOfBalls = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyOneBall(collision);
        if (numberOfBalls <= 0)
        {
            StartCoroutine(WaitAndLoad());
        }
    }

    IEnumerator WaitAndLoad()
    {
        fail.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("Game Over");
    }

    public void AddOneBall()
    {
        numberOfBalls++;
    }

    public void DestroyOneBall(Collider2D ball)
    {
        Destroy(ball.gameObject);
        numberOfBalls--;
    }
}
