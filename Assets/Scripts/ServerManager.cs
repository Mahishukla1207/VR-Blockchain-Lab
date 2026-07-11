using UnityEngine;
using TMPro;
using System.Collections;

public class ServerManager : MonoBehaviour
{
    [Header("Server Status")]
    public bool isOnline = true;
    
    public TextMeshPro statusLabel;
    public MeshRenderer serverRenderer;

public ServerPulse serverPulse;

    // Called when a request reaches the server
    public void ProcessRequest()
    {
        if (!isOnline)
            return;

        StartCoroutine(ProcessRoutine());
    }

    IEnumerator ProcessRoutine()
    {
        serverPulse.SetProcessing();

        statusLabel.color = Color.yellow;
        statusLabel.text = "STATUS: PROCESSING...";

        yield return new WaitForSeconds(2f);

        serverPulse.SetOnline();
        statusLabel.color = Color.green;
        statusLabel.text = "STATUS: ONLINE";
    }

    // Called when the player presses the Server Failure button
    public void SimulateFailure()
{
    isOnline = false;

    StopAllCoroutines();

    statusLabel.color = Color.red;
    statusLabel.text = "STATUS: OFFLINE";

    serverPulse.SetOffline();
}
    // Called when the player presses Restart
   public void RestartServer()
{
    StartCoroutine(RestartRoutine());
}

IEnumerator RestartRoutine()
{
    isOnline = false;

    statusLabel.color = Color.yellow;
    statusLabel.text = "STATUS: RESTARTING...";

    serverPulse.SetRestarting();

    yield return new WaitForSeconds(2f);

    isOnline = true;

    statusLabel.color = Color.green;
    statusLabel.text = "STATUS: ONLINE";

    serverPulse.SetOnline();
}
}