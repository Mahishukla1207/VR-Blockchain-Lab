using TMPro;
using UnityEngine;

public class ShowDefinition : MonoBehaviour
{
    [TextArea(3, 6)]
    public string definition;

    public TextMeshProUGUI infoText;

    public void ShowInfo()
    {
        infoText.text = definition;
    }
}
