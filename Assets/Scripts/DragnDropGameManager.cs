using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragnDropGameManager : MonoBehaviour, IDropHandler
{
    public DragDrop dragDrop;

    public DragnDropQuestion[] questions;
    public ScoreManager scoreManager;
    private static List<DragnDropQuestion> unansweredQuestion;

    public GameObject correctAnswer;

    private DragnDropQuestion currentQuestion;
    //private Question.AnswerList userAnswer;
    [SerializeField]
    private TMP_Text questionText, answer1Text, answer2Text, answer3Text, answer4Text;
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
            unansweredQuestion = questions.ToList<DragnDropQuestion>();
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
        answer1Text.text = currentQuestion.answer1.answer1;
        answer2Text.text = currentQuestion.answer2.answer2;
        answer3Text.text = currentQuestion.answer3.answer3;
        answer4Text.text = currentQuestion.answer4.answer4;
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
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {

            dragDrop = eventData.pointerDrag.GetComponent<DragDrop>();
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            if (eventData.pointerDrag.gameObject.tag == "Answer 1" && currentQuestion.answer1.isCorrect)
            {

                Debug.Log("Correct");
            }
            else
            {
                Debug.Log("False");
                eventData.pointerDrag.GetComponent<RectTransform>().localPosition = dragDrop.startPosition;
            }
            if (eventData.pointerDrag.gameObject.tag == "Answer 2" && currentQuestion.answer2.isCorrect)
            {

                Debug.Log("Correct");
            }
            else
            {
                Debug.Log("False");
                eventData.pointerDrag.GetComponent<RectTransform>().localPosition = dragDrop.startPosition;
            }
            if (eventData.pointerDrag.gameObject.tag == "Answer 3" && currentQuestion.answer3.isCorrect)
            {

                Debug.Log("Correct");
            }
            else
            {
                Debug.Log("False");
                eventData.pointerDrag.GetComponent<RectTransform>().localPosition = dragDrop.startPosition;
            }
            if (eventData.pointerDrag.gameObject.tag == "Answer 4" && currentQuestion.answer4.isCorrect)
            {

                Debug.Log("Correct");
            }
            else
            {
                Debug.Log("False");
                eventData.pointerDrag.GetComponent<RectTransform>().localPosition = dragDrop.startPosition;
            }
        }

    }
}
