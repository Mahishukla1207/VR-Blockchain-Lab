using UnityEngine;
using TMPro;

[System.Serializable]
public class Question
{
    public string question;
    public string[] options;
    public int correctAnswer; // 0,1,2,3
}

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI[] optionTexts;
    public TextMeshProUGUI resultText;

    public Question[] questions;

    private int currentQuestionIndex = 0;

    void Start()
    {
        resultText.gameObject.SetActive(false);
        ShowQuestion();
    }

    void ShowQuestion()
    {
        if (currentQuestionIndex >= questions.Length)
            return;

        Question q = questions[currentQuestionIndex];

        questionText.text = q.question;

        for (int i = 0; i < optionTexts.Length; i++)
        {
            optionTexts[i].text = q.options[i];
        }
    }
}
