using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizScenerTransition : MonoBehaviour
{
    public void LoadScene(string sceneName){
        Debug.Log("Clicked");
        SceneManager.LoadScene(sceneName);
    }
}
