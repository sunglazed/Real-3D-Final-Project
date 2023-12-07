using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class flashcardOptions : MonoBehaviour
{
    public GameObject introPanel;
    public GameObject alphabetPanel;
    public GameObject wordPanel;
    public GameObject numberPanel;
    
    public void openWord()
    {
        introPanel.SetActive(false);
        alphabetPanel.SetActive(false);
        numberPanel.SetActive(false);
        wordPanel.SetActive(true);

    }
    public void openNum()
    {
        introPanel.SetActive(false);
        alphabetPanel.SetActive(false);
        numberPanel.SetActive(true);
        wordPanel.SetActive(false);

    }
    public void openAlph()
    {
        introPanel.SetActive(false);
        alphabetPanel.SetActive(true);
        numberPanel.SetActive(false);
        wordPanel.SetActive(false);

    }

    public void Return(){
        introPanel.SetActive(true);
        alphabetPanel.SetActive(false);
        numberPanel.SetActive(false);
        wordPanel.SetActive(false);
    }
    
    public void BackToMain(){
        KeepPlayer.Instance.gameObject.SetActive(true);
        KeepCam.Instance.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("all_objects");
    }
}