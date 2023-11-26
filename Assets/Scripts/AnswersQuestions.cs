using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class AnswersQuestions
{
    public enum QuestionType
    {
        Text,
        Image,
        TextAndImage
    }

    [SerializableEnum] 
    public QuestionType questionType;
    public string QuestionText;
    public Sprite ImageQuestion;
    public List<AnswerOption> Answers;
}

[System.Serializable]
public class AnswerOption
{
    public bool isTextAnswer;
    public string TextAnswer;
    public Sprite ImageAnswer;
    public bool isCorrect;
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(SerializableEnumAttribute))]
public class SerializableEnumDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType == SerializedPropertyType.Enum)
        {
            property.enumValueIndex = EditorGUI.Popup(position, label.text, property.enumValueIndex, property.enumDisplayNames);
        }
        else
        {
            EditorGUI.PropertyField(position, property, label);
        }
    }
}
#endif

#if UNITY_EDITOR
public class SerializableEnumAttribute : PropertyAttribute { }
#endif
/*[System.Serializable] 

public class AnswersQuestions

  /*public string Question;
  public string[] Answers; 
  public int CorrectAnswer;

{
    public bool isTextQuestion; // Flag indicating if the question is a text or image question
    public string Question; // Text question
    public Sprite ImageQuestion; // Image question

    public List<AnswerOption> Answers; // List of answer options
}

[System.Serializable]
public class AnswerOption
{
    public bool isTextAnswer; // Flag indicating if the answer is text or image
    public string TextAnswer; // Text answer
    public Sprite ImageAnswer; // Image answer
    public bool isCorrect; // Flag indicating if this answer is correct
}*/
