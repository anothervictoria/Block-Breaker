using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    Text scoreText;
    GameScore gameScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        gameScore = FindObjectOfType<GameScore>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gameScore.GetScore().ToString();
    }
}
