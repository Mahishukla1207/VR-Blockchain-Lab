using UnityEngine;
using TMPro;
using System.Collections;


public class SmartContractManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject paymentTokenPrefab;
    public GameObject nftTokenPrefab;

    [Header("Spawn Points")]
    public Transform paymentSpawn;
    public Transform paymentTarget;

    public Transform nftSpawn;
    public Transform nftTarget;

    [Header("Status")]
public TextMeshPro statusLabel;          // Floating 3D text

public TextMeshProUGUI progressText;     // Terminal UI
public TextMeshProUGUI verificationText; // Terminal UI

    [Header("Glow")]
    public ObjectPulse contractPulse;

    public void ExecuteContract()
    {
        StartCoroutine(ContractRoutine());
    }

    IEnumerator ContractRoutine()
{
    // Prevent pressing the button multiple times
    statusLabel.text = "STATUS: EXECUTING...";
    statusLabel.color = Color.yellow;

    contractPulse.SetWorking();

    //--------------------------------------------------
    // PAYMENT TOKEN
    //--------------------------------------------------

    GameObject payment =
        Instantiate(paymentTokenPrefab,
                    paymentSpawn.position,
                    Quaternion.identity);

    TokenMover paymentMover =
        payment.GetComponent<TokenMover>();

    paymentMover.target = paymentTarget;

    // Wait until payment reaches contract
    // yield return new WaitForSeconds(2f);

    verificationText.text = "Verification: Receiving Payment...";

yield return new WaitForSeconds(2f);

verificationText.text = "Verification: Checking Conditions...";

yield return new WaitForSeconds(1.5f);

verificationText.text = "Conditions Met";
verificationText.color = Color.green;

yield return new WaitForSeconds(1f);

    //--------------------------------------------------
    // NFT TOKEN
    //--------------------------------------------------

    GameObject nft =
        Instantiate(nftTokenPrefab,
                    nftSpawn.position,
                    Quaternion.identity);

    TokenMover nftMover =
        nft.GetComponent<TokenMover>();

    nftMover.target = nftTarget;

    yield return new WaitForSeconds(2f);

    //--------------------------------------------------
    // FINISHED
    //--------------------------------------------------

    statusLabel.text = "STATUS: EXECUTED";
    statusLabel.color = Color.green;

    contractPulse.SetSuccess();

    yield return new WaitForSeconds(2f);

    statusLabel.text = "STATUS: READY";
    verificationText.text = "Verification: Waiting...";
verificationText.color = new Color(0.9f, 0.7f, 1f);

    statusLabel.color = new Color(0.95f,0.8f,1f);

    contractPulse.SetIdle();
}
}