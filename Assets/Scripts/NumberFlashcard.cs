using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberFlashcard : MonoBehaviour
{
    public RectTransform r;
    public TMP_Text cardText;
    public Image sign;
    public TMP_Text cardTracker;
    
    public Question[] ques = new Question[10];
    private float flipTime = 0.5f;
    private int faceSide = 0;
    private int isShrinking = -1;
    private bool isFlipping = false;
    private int cardNum = 0;
    private float distancePerTime;
    private float timeCount = 0;
    void Start()
    {
        Sprite sprite1 = Resources.Load<Sprite>("one");
        Sprite sprite2 = Resources.Load<Sprite>("two");
        Sprite sprite3 = Resources.Load<Sprite>("three");
        Sprite sprite4 = Resources.Load<Sprite>("four");
        Sprite sprite5 = Resources.Load<Sprite>("five");
        Sprite sprite6 = Resources.Load<Sprite>("six");
        Sprite sprite7 = Resources.Load<Sprite>("seven");
        Sprite sprite8 = Resources.Load<Sprite>("eight");
        Sprite sprite9 = Resources.Load<Sprite>("nine");
        Sprite sprite10 = Resources.Load<Sprite>("ten");

        ques[0] = new Question(sprite1, "One");
        ques[1] = new Question(sprite2, "Two");
        ques[2] = new Question(sprite3, "Three");
        ques[3] = new Question(sprite4, "Four");
        ques[4] = new Question(sprite5, "Five");
        ques[5] = new Question(sprite6, "Six");
        ques[6] = new Question(sprite7, "Seven");
        ques[7] = new Question(sprite8, "Eight");
        ques[8] = new Question(sprite9, "Nine");
        ques[9] = new Question(sprite10, "Ten");

        distancePerTime = r.localScale.x / flipTime;
        cardNum = 0;
        sign.sprite = ques[cardNum].questionImage;
        cardText.text = ques[cardNum].correctAnswer;
        sign.enabled = true;
        cardText.enabled = false;
        cardTracker.text = (cardNum + 1) + "/10";
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
                    cardText.enabled = true;
                    sign.enabled = false;
                    //cardText.text = ques[cardNum].correctAnswer;

                }
                else{
                    faceSide = 0;
                    sign.enabled = true;
                    cardText.enabled = false;
                    //cardText.text = ques[cardNum].question;
                }
            }
            else if ((timeCount >= flipTime) && (isShrinking == 1)){
                isFlipping = false;
            }
        }
    }
    public void NextCard(){
        faceSide = 0;
        sign.enabled = true;
        cardText.enabled = false;
        cardNum++;
        if(cardNum >= ques.Length){
            cardNum = 0;
        }
        Debug.Log(cardNum);
        sign.sprite = ques[cardNum].questionImage;
        cardText.text = ques[cardNum].correctAnswer;
        cardTracker.text = (cardNum + 1) + "/10";
    }
    public void BackCard(){
        faceSide = 0;
        sign.enabled = true;
        cardText.enabled = false;
        cardNum--;
        if(cardNum <= 0){
            cardNum = 0;
        }
        Debug.Log(cardNum);
        sign.sprite = ques[cardNum].questionImage;
        cardText.text = ques[cardNum].correctAnswer;
        cardTracker.text = (cardNum+1) + "/10";
    }
    public void FlipCard(){
        timeCount = 0;
        isFlipping = true;
        isShrinking = -1;
    }
    static void Reshuffle(Question[] questions)
    {
        for (int t = 0; t < questions.Length; t++ )
        {
            Question tmp = questions[t];
            int r = Random.Range(t, questions.Length);
            questions[t] = questions[r];
            questions[r] = tmp;
        }
    }
    public void ShuffleCard(){
        faceSide = 0;
        sign.enabled = true;
        cardText.enabled = false;
        cardNum = 0;
        Reshuffle(ques);
        sign.sprite = ques[cardNum].questionImage;
        cardText.text = ques[cardNum].correctAnswer;
        cardTracker.text = (cardNum + 1) + "/10";
    }
}
