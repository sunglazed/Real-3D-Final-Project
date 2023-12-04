using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeButton : MonoBehaviour
{
    public Animator door;
    public string sceneName;
    private void OnMouseUpAsButton(){
        Debug.Log("Works");
        //door.Play("QuizDoor", 0, 0.0f);
        SceneManager.LoadScene(sceneName);
        Cursor.lockState = CursorLockMode.None;
    }
}
