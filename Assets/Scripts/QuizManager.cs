
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<AnswersQuestions> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TextMeshProUGUI QuestionText;
    public Image QuestionImg; // Image component for displaying image questions

    private void Start()
    {
        generateQuestion();
    }

    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
         for (int i = 0; i < options.Length; i++)
         {   
             options[i].GetComponent<AnswerScript>().isCorrect = false;

            if (QnA[currentQuestion].Answers[i].isTextAnswer)
            {
                options[i].transform.Find("answerText").GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i].TextAnswer;
            }
            else
            {
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
}
