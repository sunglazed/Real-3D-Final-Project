using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasSwitch : MonoBehaviour
{
    public Canvas canvasToDeactivate;

    public void OnButtonClick()
    {
       canvasToDeactivate.gameObject.SetActive(false);
       
    }
}

