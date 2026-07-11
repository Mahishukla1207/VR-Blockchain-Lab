using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class QuizController : MonoBehaviour
{
    [Header("UI")]
    public GameObject questionArea;
    public TMP_Text questionText;
    public TMP_Text[] optionTexts;
    public TMP_Text feedbackText;

    [Header("Result UI")]
    public GameObject resultPanel;
    public TMP_Text resultTitleText;
    public TMP_Text scoreText;
    public TMP_Text resultMessageText;

    [Header("Quiz Data")]
    public List<QuizQuestion> questions;

    private int currentIndex = 0;
    private int score = 0;

    void Start()
    {
        questionArea.SetActive(false);
        resultPanel.SetActive(false);
        feedbackText.text = "";
    }

    public void StartQuiz()
    {
        currentIndex = 0;
        score = 0;

        resultPanel.SetActive(false);
        questionArea.SetActive(true);

        LoadQuestion();
    }

    void LoadQuestion()
    {
        QuizQuestion q = questions[currentIndex];

        questionText.text = q.question;
        optionTexts[0].text = q.optionA;
        optionTexts[1].text = q.optionB;
        optionTexts[2].text = q.optionC;
        optionTexts[3].text = q.optionD;

        feedbackText.text = "";
    }

    public void SelectAnswer(int selectedIndex)
    {
        if (selectedIndex == questions[currentIndex].correctAnswerIndex)
        {
            score++;
            feedbackText.text = "Correct!";
        }
        else
        {
            feedbackText.text = "Wrong!";
        }

        Invoke(nameof(NextQuestion), 1.2f);
    }

    void NextQuestion()
    {
        currentIndex++;

        if (currentIndex < questions.Count)
        {
            LoadQuestion();
        }
        else
        {
            ShowResult();
        }
    }

    void ShowResult()
    {
        questionArea.SetActive(false);
        resultPanel.SetActive(true);

        resultTitleText.text = "Quiz Completed!";
        scoreText.text = $"Your Score: {score} / {questions.Count}";

        if (score >= questions.Count * 0.7f)
            resultMessageText.text = "Great job! You understand the concepts well.";
        else
            resultMessageText.text = "Good attempt! You can review and try again.";
    }
}
