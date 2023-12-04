using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Question{
    public Sprite questionImage;
    public string correctAnswer;

    public Question(Sprite sprite, string ans){
        questionImage = sprite;
        correctAnswer = ans;
    }
}
public class FlashcardFlip : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform r;
    public TMP_Text cardText;
    public Image sign;
    public TMP_Text cardTracker;
    public Question[] ques = new Question[26];
    private float flipTime = 0.5f;
    private int faceSide = 0;
    private int isShrinking = -1;
    private bool isFlipping = false;
    private int cardNum = 0;
    private float distancePerTime;
    private float timeCount = 0;
    void Start()
    {
        Sprite sprite1 = Resources.Load<Sprite>("A");
        Sprite sprite2 = Resources.Load<Sprite>("B");
        Sprite sprite3 = Resources.Load<Sprite>("C");
        Sprite sprite4 = Resources.Load<Sprite>("D");
        Sprite sprite5 = Resources.Load<Sprite>("E");
        Sprite sprite6 = Resources.Load<Sprite>("F");
        Sprite sprite7 = Resources.Load<Sprite>("G");
        Sprite sprite8 = Resources.Load<Sprite>("H");
        Sprite sprite9 = Resources.Load<Sprite>("I");
        Sprite sprite10 = Resources.Load<Sprite>("J");
        Sprite sprite11 = Resources.Load<Sprite>("K");
        Sprite sprite12 = Resources.Load<Sprite>("L");
        Sprite sprite13 = Resources.Load<Sprite>("M");
        Sprite sprite14 = Resources.Load<Sprite>("N");
        Sprite sprite15 = Resources.Load<Sprite>("O");
        Sprite sprite16 = Resources.Load<Sprite>("P");
        Sprite sprite17 = Resources.Load<Sprite>("Q");
        Sprite sprite18 = Resources.Load<Sprite>("R");
        Sprite sprite19 = Resources.Load<Sprite>("S");
        Sprite sprite20 = Resources.Load<Sprite>("T");
        Sprite sprite21 = Resources.Load<Sprite>("U");
        Sprite sprite22 = Resources.Load<Sprite>("V");
        Sprite sprite23 = Resources.Load<Sprite>("W");
        Sprite sprite24 = Resources.Load<Sprite>("X");
        Sprite sprite25 = Resources.Load<Sprite>("Y");
        Sprite sprite26 = Resources.Load<Sprite>("Z");

        ques[0] = new Question(sprite1, "A");
        ques[1] = new Question(sprite2, "B");
        ques[2] = new Question(sprite3, "C");
        ques[3] = new Question(sprite4, "D");
        ques[4] = new Question(sprite5, "E");
        ques[5] = new Question(sprite6, "F");
        ques[6] = new Question(sprite7, "G");
        ques[7] = new Question(sprite8, "H");
        ques[8] = new Question(sprite9, "I");
        ques[9] = new Question(sprite10, "J");
        ques[10] = new Question(sprite11, "K");
        ques[11] = new Question(sprite12, "L");
        ques[12] = new Question(sprite13, "M");
        ques[13] = new Question(sprite14, "N");
        ques[14] = new Question(sprite15, "O");
        ques[15] = new Question(sprite16, "P");
        ques[16] = new Question(sprite17, "Q");
        ques[17] = new Question(sprite18, "R");
        ques[18] = new Question(sprite19, "S");
        ques[19] = new Question(sprite20, "T");
        ques[20] = new Question(sprite21, "U");
        ques[21] = new Question(sprite22, "V");
        ques[22] = new Question(sprite23, "W");
        ques[23] = new Question(sprite24, "X");
        ques[24] = new Question(sprite25, "Y");
        ques[25] = new Question(sprite26, "Z");

        distancePerTime = r.localScale.x / flipTime;
        cardNum = 0;
        sign.sprite = ques[cardNum].questionImage;
        cardText.text = ques[cardNum].correctAnswer;
        sign.enabled = true;
        cardText.enabled = false;
        cardTracker.text = (cardNum + 1) + "/26";
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
        cardTracker.text = (cardNum + 1) + "/26";
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
        cardTracker.text = (cardNum+1) + "/26";
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
        cardTracker.text = (cardNum + 1) + "/26";
    }
    
}
