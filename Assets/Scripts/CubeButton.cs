using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeButton : MonoBehaviour
{
    private void OnMouseUpAsButton(){
        Debug.Log("Works");
        SceneManager.LoadScene("Quiz Game");
    }
}
