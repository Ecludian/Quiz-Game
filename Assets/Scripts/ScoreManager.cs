using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField]
    private int score;
    [SerializeField]
    private TMP_Text scoreText;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        scoreText.text = score.ToString() + " POINTS ";
    }

    public void AddPoint()
    {
        score += 10;
        scoreText.text = score.ToString() + " POINTS! ";
    }
}
