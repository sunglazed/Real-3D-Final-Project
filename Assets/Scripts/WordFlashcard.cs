using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordFlashcard : MonoBehaviour
{
    public RectTransform r;
    public TMP_Text cardText;
    public Image sign;
    public TMP_Text cardTracker;
    
    public Question[] ques = new Question[29];
    private float flipTime = 0.5f;
    private int faceSide = 0;
    private int isShrinking = -1;
    private bool isFlipping = false;
    private int cardNum = 0;
    private float distancePerTime;
    private float timeCount = 0;
    void Start()
    {
        Sprite sprite1 = Resources.Load<Sprite>("who");
        Sprite sprite2 = Resources.Load<Sprite>("what");
        Sprite sprite3 = Resources.Load<Sprite>("when");
        Sprite sprite4 = Resources.Load<Sprite>("where");
        Sprite sprite5 = Resources.Load<Sprite>("why");
        Sprite sprite6 = Resources.Load<Sprite>("how");
        Sprite sprite7 = Resources.Load<Sprite>("which");
        Sprite sprite8 = Resources.Load<Sprite>("bathroom");
        Sprite sprite9 = Resources.Load<Sprite>("love");
        Sprite sprite10 = Resources.Load<Sprite>("deaf");
        Sprite sprite11 = Resources.Load<Sprite>("asl");
        Sprite sprite12 = Resources.Load<Sprite>("eat");
        Sprite sprite13 = Resources.Load<Sprite>("mother");
        Sprite sprite14 = Resources.Load<Sprite>("father");
        Sprite sprite15 = Resources.Load<Sprite>("friend");
        Sprite sprite16 = Resources.Load<Sprite>("iloveyou");
        Sprite sprite17 = Resources.Load<Sprite>("baby");
        Sprite sprite18 = Resources.Load<Sprite>("yes");
        Sprite sprite19 = Resources.Load<Sprite>("no");
        Sprite sprite20 = Resources.Load<Sprite>("school");
        Sprite sprite21 = Resources.Load<Sprite>("please");
        Sprite sprite22 = Resources.Load<Sprite>("thankyou");
        Sprite sprite23 = Resources.Load<Sprite>("play");
        Sprite sprite24 = Resources.Load<Sprite>("finished");
        Sprite sprite25 = Resources.Load<Sprite>("more");
        Sprite sprite26 = Resources.Load<Sprite>("help");
        Sprite sprite27 = Resources.Load<Sprite>("hello");
        Sprite sprite28 = Resources.Load<Sprite>("nicetomeetyou");
        Sprite sprite29 = Resources.Load<Sprite>("goodbye");

        ques[0] = new Question(sprite1, "Who");
        ques[1] = new Question(sprite2, "What");
        ques[2] = new Question(sprite3, "When");
        ques[3] = new Question(sprite4, "Where");
        ques[4] = new Question(sprite5, "Why");
        ques[5] = new Question(sprite6, "How");
        ques[6] = new Question(sprite7, "Which");
        ques[7] = new Question(sprite8, "Bathroom");
        ques[8] = new Question(sprite9, "Love");
        ques[9] = new Question(sprite10, "Deaf");
        ques[10] = new Question(sprite11, "ASL");
        ques[11] = new Question(sprite12, "Eat");
        ques[12] = new Question(sprite13, "Mother");
        ques[13] = new Question(sprite14, "Father");
        ques[14] = new Question(sprite15, "Friend");
        ques[15] = new Question(sprite16, "I love you");
        ques[16] = new Question(sprite17, "Baby");
        ques[17] = new Question(sprite18, "Yes");
        ques[18] = new Question(sprite19, "No");
        ques[19] = new Question(sprite20, "School");
        ques[20] = new Question(sprite21, "Please");
        ques[21] = new Question(sprite22, "Thank You");
        ques[22] = new Question(sprite23, "Play");
        ques[23] = new Question(sprite24, "Finished");
        ques[24] = new Question(sprite25, "More");
        ques[25] = new Question(sprite26, "Help");
        ques[26] = new Question(sprite27, "Hello");
        ques[27] = new Question(sprite28, "Nice To Meet You");
        ques[28] = new Question(sprite29, "Goodbye");

        distancePerTime = r.localScale.x / flipTime;
        cardNum = 0;
        sign.sprite = ques[cardNum].questionImage;
        cardText.text = ques[cardNum].correctAnswer;
        sign.enabled = true;
        cardText.enabled = false;
        cardTracker.text = (cardNum + 1) + "/29";
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
        cardTracker.text = (cardNum + 1) + "/29";
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
        cardTracker.text = (cardNum+1) + "/29";
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
        cardTracker.text = (cardNum + 1) + "/29";
    }
    
}
