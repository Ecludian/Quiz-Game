using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MateriMenu : MonoBehaviour
{
    public GameObject[] pages;
    public Button nextPageBtn;
    public Button prevPageBtn;

    int currentPage;

    private void Start()
    {
        prevPageBtn.interactable = false;
    }
    public void NextPage()
    {
        if(currentPage + 1 != pages.Length)
        {
            pages[currentPage].SetActive(false);

            currentPage++;
            pages[currentPage].SetActive(true);
          
            if (currentPage + 1 == pages.Length)
            {
                nextPageBtn.interactable = false;
            }
            else if(currentPage <= pages.GetLength(0))
            {
                prevPageBtn.interactable = true;
            }
        }
    }
    public void PreviousPage()
    {
        if (currentPage - 1 != pages.Length)
        {

            pages[currentPage].SetActive(false);

            currentPage--;
            pages[currentPage].SetActive(true);

            if (currentPage < 1)
            {
                prevPageBtn.interactable = false;
            }
            else if (currentPage < pages.Length)
            {
                nextPageBtn.interactable = true;
            }
        }
    }
}
