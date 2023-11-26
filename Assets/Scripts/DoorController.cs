using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            if(openTrigger){
                myDoor.Play("door1Open", 0, 0.0f);
                gameObject.SetActive(false);
            }
            else if(closeTrigger){
                myDoor.Play("door1Close", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }

}



    /*public Animator myDoor = null;
    public bool openTrigger = false;
    public bool closeTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            if(openTrigger){
                myDoor.Play("dooropen", 0, 0.0f);
                gameObject.SetActive(false);
            }
            else if(closeTrigger){
                myDoor.Play("doorclose", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }

}*/
