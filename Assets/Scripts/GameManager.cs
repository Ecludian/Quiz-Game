using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Question[] questions;
    public ScoreManager scoreManager;
    private static List<Question> unansweredQuestion;

    public AudioManager audioManager;

    public Button correctButton;
    public Button wrongButton;

    private Question currentQuestion;
 
    [SerializeField]
    private TMP_Text questionText, textA, textB, textC, textD;
    [SerializeField]
    private Image questionPic;
    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private float timeBetweenQuestion = 1.5f;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private int score;
  

    private void Start()
    {
     
        
        if (unansweredQuestion == null || unansweredQuestion.Count == 0)
        {
            unansweredQuestion = questions.ToList<Question>();
        }

        SetCurrentQuestion();

    }

    void SetCurrentQuestion()
    {

        int randomQuestionIndex = Random.Range(0, unansweredQuestion.Count);
        if (randomQuestionIndex >= unansweredQuestion.Count)
        {
            FindObjectOfType<AudioManager>().Play("GameOverSound");
            panel.SetActive(true);
            return;
        }
        currentQuestion = unansweredQuestion[randomQuestionIndex];

        questionText.text = currentQuestion.question;
        questionPic.sprite = currentQuestion.image;
    
    }

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestion.Remove(currentQuestion);
       
        yield return new WaitForSeconds(1);
        animator.SetTrigger("Reset");
        yield return new WaitForSeconds(timeBetweenQuestion);
        SetCurrentQuestion();
        StartCoroutine(EnabledButton());

    }

    IEnumerator EnabledButton()
    {
        yield return new WaitForSeconds(0.2f);
        correctButton.enabled = true;
        wrongButton.enabled = true;
    }

 
    public void UserSelectCorrectAnswer()
    {
        correctButton.enabled = false;
        wrongButton.enabled = false;
        if (currentQuestion.isCorrect)
        {
            FindObjectOfType<AudioManager>().Play("CorrectSound");
            Debug.Log("Correct!");
            animator.SetTrigger("True");
            ScoreManager.instance.AddPoint();
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("WrongSound");
            Debug.Log("Wrong!");
            animator.SetTrigger("False");
        }

        StartCoroutine(TransitionToNextQuestion());
    }
    public void UserSelectWrongAnswer()
    {
        correctButton.enabled = false;
        wrongButton.enabled = false;
        if (!currentQuestion.isCorrect)
        {
            FindObjectOfType<AudioManager>().Play("CorrectSound");
            Debug.Log("Correct!");
            animator.SetTrigger("False");
            ScoreManager.instance.AddPoint();
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("WrongSound");
            Debug.Log("Wrong!");
            animator.SetTrigger("True");
        }

        StartCoroutine(TransitionToNextQuestion());
    }
}
