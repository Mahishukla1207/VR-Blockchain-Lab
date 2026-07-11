using UnityEngine;
using TMPro;

public class InstructionPager : MonoBehaviour
{
    public TextMeshProUGUI instructionText;

    [TextArea(3, 6)]
    public string[] pages;

    private int currentPage = 0;

    void Start()
    {
        ShowPage();
    }

    public void NextPage()
    {
        currentPage++;

        if (currentPage >= pages.Length)
            currentPage = pages.Length - 1;

        ShowPage();
    }

    void ShowPage()
    {
        instructionText.text = pages[currentPage];
    }
}
