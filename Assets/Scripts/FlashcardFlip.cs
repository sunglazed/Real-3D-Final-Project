using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question{
    public string question;
    public string correctAnswer;

    public Question(string i, string ans){
        question = i;
        correctAnswer = ans;
    }
}
public class FlashcardFlip : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform r;
    public Text cardText;
    public Question[] ques = new Question[3];
    private float flipTime = 0.5f;
    private int faceSide = 0;
    private int isShrinking = -1;
    private bool isFlipping = false;
    private int cardNum = 0;
    private float distancePerTime;
    private float timeCount = 0;
    void Start()
    {
        ques[0] = new Question("one", "1");
        ques[1] = new Question("two", "2");
        ques[2] = new Question("three", "3");

        distancePerTime = r.localScale.x / flipTime;
        cardNum = 0;
        cardText.text = ques[cardNum].question;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFlipping){
            Vector3 v = r.localScale;
            v.x += isShrinking * distancePerTime * Time.deltaTime;
            r.localScale = v;

            timeCount +=  Time.deltaTime;
            if((timeCount >= flipTime) && (isShrinking < 0)){
                isShrinking = 1;
                timeCount = 0;
                if(faceSide == 0){
                    faceSide = 1;
                    cardText.text = ques[cardNum].correctAnswer;
                }
                else{
                    faceSide = 0;
                    cardText.text = ques[cardNum].question;
                }
            }
            else if ((timeCount >= flipTime) && (isShrinking == 1)){
                isFlipping = false;
            }
        }
    }
    public void NextCard(){
        faceSide = 0;
        cardNum++;
        if(cardNum >= ques.Length){
            cardNum = 0;
        }
        cardText.text = ques[cardNum].question;
    }
    public void FlipCard(){
        timeCount = 0;
        isFlipping = true;
        isShrinking = -1;
    }
    
}
