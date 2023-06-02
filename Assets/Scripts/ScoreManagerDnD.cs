using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManagerDnD : MonoBehaviour
{
    public static ScoreManagerDnD instance;
    [SerializeField]
    private int score;
    [SerializeField]
    private TMP_Text scoreText;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        scoreText.text = "Nilai Kamu : " + score.ToString() + " POIN ";
    }

    public void AddPoint()
    {
        score += 10;
        scoreText.text = "Nilai Kamu : " + score.ToString() + " POIN! ";
    }
}
