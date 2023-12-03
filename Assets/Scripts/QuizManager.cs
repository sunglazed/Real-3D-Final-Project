
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<AnswersQuestions> QnA;
    public GameObject[] options; //array of buttons
    public int currentQuestion;

    public TextMeshProUGUI QuestionText;
    public Image QuestionImg; // Image component for displaying image questions

    public GameObject QuizPanel;
    public GameObject GoPanel;
    public TextMeshProUGUI ScoreText;

    int totalQuestion = 0;
    public int score;

    private void Start()
    {
        totalQuestion = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        

    }

    public void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreText.text = score + "/" + totalQuestion;



    }
    
    public void correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
        
    }
    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }
        
    

    void SetAnswers()
    {
        

         for (int i = 0; i < options.Length; i++)
         {   
            options[i].GetComponent<AnswerScript>().isCorrect = false;

            if (QnA[currentQuestion].Answers[i].isTextAnswer) //checking if the answer is text
            {
                options[i].transform.Find("answerText").gameObject.SetActive(true);
                options[i].transform.Find("answerImage").gameObject.SetActive(false);
                options[i].transform.Find("answerText").GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i].TextAnswer;
            }
            else
            {
                options[i].transform.Find("answerText").gameObject.SetActive(false);
                options[i].transform.Find("answerImage").gameObject.SetActive(true);
                options[i].transform.Find("answerImage").GetComponent<Image>().sprite = QnA[currentQuestion].Answers[i].ImageAnswer;
            }

            if (QnA[currentQuestion].Answers[i].isCorrect)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            switch (QnA[currentQuestion].questionType)
            {
                case AnswersQuestions.QuestionType.Text:
                    QuestionText.gameObject.SetActive(true);
                    QuestionImg.gameObject.SetActive(false);
                    QuestionText.text = QnA[currentQuestion].QuestionText;
                    break;

                case AnswersQuestions.QuestionType.Image:
                    QuestionText.gameObject.SetActive(false);
                    QuestionImg.gameObject.SetActive(true);
                    QuestionImg.sprite = QnA[currentQuestion].ImageQuestion;
                 break;

                case AnswersQuestions.QuestionType.TextAndImage:
                    QuestionImg.gameObject.SetActive(true);
                    QuestionText.gameObject.SetActive(true);
                    QuestionText.text = QnA[currentQuestion].QuestionText;
                    QuestionImg.sprite = QnA[currentQuestion].ImageQuestion;
                    break;
             }

             SetAnswers ();
        }
        else 
        {
            Debug.Log("Out of Questions");
            GameOver ();

        }
    }
}
