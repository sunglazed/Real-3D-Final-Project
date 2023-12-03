using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScriptSwitch : MonoBehaviour

{
    public GameObject CanvasIntro; 
    // Start is called before the first frame update
    void Start()
    {
        CanvasIntro.SetActive(true);

        
    }

    // Update is called once per frame
    void Update()
    {
        CanvasIntro.SetActive(false);
        
    }
}
