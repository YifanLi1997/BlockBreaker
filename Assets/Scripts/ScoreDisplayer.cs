using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplayer : MonoBehaviour
{
    GameSession gameSession;
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        text = GetComponent<TextMeshProUGUI>();
;    }

    // Update is called once per frame
    void Update()
    {
        text.text = gameSession.GetCurrentScore().ToString();
    }
}
