using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    /// <summary>
    /// SCRIPT CURRENTLY NOT USED
    /// </summary>
    private DragnDropQuestion currentQuestion;
    public DragDrop dragDrop;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {

            dragDrop = eventData.pointerDrag.GetComponent<DragDrop>();
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = dragDrop.startPosition;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            if (eventData.pointerDrag.gameObject.tag == "Answer 1" && currentQuestion.answer1.isCorrect)
            {

                Debug.Log("Correct");
            }
            else
            {
                Debug.Log("False");
                //eventData.pointerDrag.transform.position = new Vector3(dragDrop.startPosition.x, dragDrop.startPosition.y);
                eventData.pointerDrag.GetComponent<RectTransform>().localPosition = dragDrop.startPosition;
            }
            if (eventData.pointerDrag.gameObject.tag == "Answer 2" && currentQuestion.answer2.isCorrect)
            {

                Debug.Log("Correct");
            }
            else
            {
                Debug.Log("False");
                //eventData.pointerDrag.transform.position = new Vector3(dragDrop.startPosition.x, dragDrop.startPosition.y);
                eventData.pointerDrag.GetComponent<RectTransform>().localPosition = dragDrop.startPosition;
            }
            if (eventData.pointerDrag.gameObject.tag == "Answer 3" && currentQuestion.answer3.isCorrect)
            {

                Debug.Log("Correct");
            }
            else
            {
                Debug.Log("False");
                //eventData.pointerDrag.transform.position = new Vector3(dragDrop.startPosition.x, dragDrop.startPosition.y);
                eventData.pointerDrag.GetComponent<RectTransform>().localPosition = dragDrop.startPosition;
            }
            if (eventData.pointerDrag.gameObject.tag == "Answer 4" && currentQuestion.answer4.isCorrect)
            {

                Debug.Log("Correct");
            }
            else
            {
                Debug.Log("False");
                //eventData.pointerDrag.transform.position = new Vector3(dragDrop.startPosition.x, dragDrop.startPosition.y);
                eventData.pointerDrag.GetComponent<RectTransform>().localPosition = dragDrop.startPosition;
            }
        }

    }
}
