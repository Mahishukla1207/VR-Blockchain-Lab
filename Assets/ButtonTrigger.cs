using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public NetworkManager manager;

    public bool resetButton = false;

    public void ButtonPressed()
    {
        if(resetButton)
            manager.RestoreNetwork();
        else
            manager.SimulateFailure();
    }
}