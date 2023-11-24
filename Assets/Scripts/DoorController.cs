using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator myDoor = null;
    public bool openTrigger = false;
    public bool closeTrigger = false;

    private void OnTriggerEnter(Collider other){
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
