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

    public Button correctButton;
    public Button wrongButton;

    private Question currentQuestion;
    //private Question.AnswerList userAnswer;
    [SerializeField]
    private TMP_Text questionText, textA, textB, textC, textD;
    [SerializeField]
    private Image questionPic;
    [SerializeField]
    private GameObject panel;

    /*  [SerializeField]
      private TMP_Text correctAnswerText, wrongAnswerText;*/


    [SerializeField]
    private float timeBetweenQuestion = 1.5f;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private int score;
  

    private void Start()
    {
       /* Button corrButton = correctButton.GetComponent<Button>();
        Button wroButton = wrongButton.GetComponent<Button>();*/

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
            panel.SetActive(true);
        }
        currentQuestion = unansweredQuestion[randomQuestionIndex];

        questionText.text = currentQuestion.question;
        questionPic.sprite = currentQuestion.image;
     
       

        /*textA.text = currentQuestion.answerA;
        textB.text = currentQuestion.answerB;
        textC.text = currentQuestion.answerC;
        textD.text = currentQuestion.answerD;*/
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

    //use enum for mutliple choice
    /*  public void UserAnswer()
      {
         if(userAnswer == Question.AnswerList.A)
          {

          }
          if (userAnswer == Question.AnswerList.B)
          {

          }
          if (userAnswer == Question.AnswerList.C)
          {

          }
          if (userAnswer == Question.AnswerList.D)
          {

          }
      }
  */


    public void UserSelectCorrectAnswer()
    {
        correctButton.enabled = false;
        wrongButton.enabled = false;
        if (currentQuestion.isCorrect)
        {
            Debug.Log("Correct!");
            animator.SetTrigger("True");
            ScoreManager.instance.AddPoint();
        }
        else
        {
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
            Debug.Log("Correct!");
            animator.SetTrigger("False");
            ScoreManager.instance.AddPoint();
        }
        else
        {
            Debug.Log("Wrong!");
            animator.SetTrigger("True");
        }

        StartCoroutine(TransitionToNextQuestion());
    }
}
