using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScriptSwitch : MonoBehaviour

{
    public GameObject IntroCamera;
    public GameObject GameCamera;

    public GameObject IntroCanvas;
    public GameObject GameCanvas; 
    // Start is called before the first frame update
    void Start()
    {
        IntroCamera.SetActive(true);
        IntroCanvas.SetActive(true);
        GameCamera.SetActive(false);
        GameCanvas.SetActive(false);
    }

    public void SwitchCam(){
        IntroCamera.SetActive(false);
        IntroCanvas.SetActive(false);
        GameCamera.SetActive(true);
        GameCanvas.SetActive(true);
    }
}
