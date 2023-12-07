using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPlayer : MonoBehaviour
{
    public static KeepPlayer Instance;
    public bool off = false;
    void Awake()
    {
        if (off){
            EnableInScene("all_objects");
            Cursor.lockState = CursorLockMode.Locked;
        }
        // Check if an instance already exists
        if (Instance == null)
        {
            // If not, set the instance to this
            Instance = this;
            // Don't destroy this GameObject when loading a new scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this GameObject
            Destroy(gameObject);
        }
        
    }

    void Update(){
        DisableInScene("Quiz Game");
        DisableInScene("Sign Language Scene");
    }

    void DisableInScene(string sceneName)
    {
        // Check if the current scene matches the specified scene name
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == sceneName)
        {
            // Disable the GameObject in the specified scene
            gameObject.SetActive(false);
            off = true;
        }
    }
    void EnableInScene(string sceneName)
    {
        // Check if the current scene matches the specified scene name
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == sceneName)
        {
            // Disable the GameObject in the specified scene
            gameObject.SetActive(true);
            off = false;
        }
    }
}
