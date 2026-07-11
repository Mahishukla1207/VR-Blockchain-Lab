using UnityEngine;
using TMPro;

public class NetworkManager : MonoBehaviour
{
    [Header("Managers")]
    public AudioManager audioManager;

    [Header("Peers")]
    public GameObject[] peers;

    [Header("Connection Rods")]
    public GameObject[] rods;

    [Header("Materials")]
    public Material healthyMaterial;
    public Material failedMaterial;

    [Header("UI")]
    public TMP_Text networkStatus;
    public TMP_Text failedNodes;
    public TMP_Text observation;

    public GameObject failurePopup;
    public GameObject nextButton;

    bool alreadyFailed = false;

    void Start()
    {
        audioManager.PlayIntro();

        networkStatus.text = "Healthy";
        failedNodes.text = "0";

        observation.text =
        "Every node has equal responsibility.\n\nCommunication continues even if one node fails.";

        failurePopup.SetActive(false);
        nextButton.SetActive(false);
    }

    public void SimulateFailure()
    {
        if (alreadyFailed)
            return;

        alreadyFailed = true;

        audioManager.PlayFailure();

        // Fail Peer3
        peers[2].GetComponent<Renderer>().material = failedMaterial;

        // Fail Rod2 and Rod3
        rods[1].GetComponent<Renderer>().material = failedMaterial;
        rods[2].GetComponent<Renderer>().material = failedMaterial;

        networkStatus.text = "Operational";

        failedNodes.text = "1";

        observation.text =
        "One node has failed.\n\nThe remaining peers continue communicating through alternate paths.";

        failurePopup.SetActive(true);

        Invoke(nameof(ShowNextButton),4f);
    }

    void ShowNextButton()
    {
        nextButton.SetActive(true);
    }

    public void RestoreNetwork()
    {
        alreadyFailed = false;

        foreach(GameObject peer in peers)
        {
            peer.GetComponent<Renderer>().material = healthyMaterial;
        }

        foreach(GameObject rod in rods)
        {
            rod.GetComponent<Renderer>().material = healthyMaterial;
        }

        networkStatus.text = "Healthy";

        failedNodes.text = "0";

        observation.text =
        "Every node has equal responsibility.\n\nCommunication continues even if one node fails.";

        failurePopup.SetActive(false);
        nextButton.SetActive(false);

        audioManager.PlayIntro();
    }
}