using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReturn : MonoBehaviour
{
    public void GoBack()
    {
    //     int previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;

    //     if (previousSceneIndex >= 0)
    //     {
    //         SceneManager.LoadScene(previousSceneIndex);
    //     }
    //     else
    //     {
    //         Debug.LogWarning("No previous scene available.");
    //     }
        SceneManager.LoadScene("all_objects");
    }
}

