using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Animator tansition;

    public float transitionTime = 1f;
    
    public void MainMenuButton()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        //tansition.SetTrigger("Start");
        StartCoroutine(transition(0));
        //SceneManager.LoadScene(0);
    }

   
    public void MateriButton()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        //tansition.SetTrigger("Start");
        StartCoroutine(transition((SceneManager.GetActiveScene().buildIndex + 1)));
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackButton()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        StartCoroutine(transition(SceneManager.GetActiveScene().buildIndex - 1));
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Quiz()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
       // StartCoroutine(transition());
        //tansition.SetTrigger("Start");
    }

    public void PilihanGanda()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        StartCoroutine(transition(2));
        //tansition.SetTrigger("Start");
        //SceneManager.LoadScene(2);
    }
    public void DragnDrop()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        StartCoroutine(transition(3));
       
    }
    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        Debug.Log("Quit");
        Application.Quit();
    }

    IEnumerator transition(int levelIndex)
    {
        tansition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
