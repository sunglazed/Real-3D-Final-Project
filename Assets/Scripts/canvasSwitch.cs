using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasSwitch : MonoBehaviour
{
    public Canvas canvasToDeactivate;

    public void Switch()
    {
        Debug.Log("Pressed");
       canvasToDeactivate.gameObject.SetActive(false);
       
    }
}

