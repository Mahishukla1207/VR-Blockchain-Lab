using UnityEngine;

[System.Serializable]
public class QuizQuestion
{
    [TextArea]
    public string question;

    public string optionA;
    public string optionB;
    public string optionC;
    public string optionD;

    [Range(0, 3)]
    public int correctAnswerIndex;
}
