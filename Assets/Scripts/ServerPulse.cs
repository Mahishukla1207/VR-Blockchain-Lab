using UnityEngine;

public class ServerPulse : MonoBehaviour
{
    [Header("Materials")]
    public Material serverBody;
    public Material ring1;
    public Material ring2;

    [Header("Online Colors")]
    public Color onlineNormal = new Color(0.0f, 0.7f, 1.0f);
    public Color onlinePulse = Color.white;

    [Header("Restart Colors")]
    public Color restartingNormal = Color.yellow;
    public Color restartingPulse = Color.white;

    [Header("Offline Color")]
    public Color offlineColor = Color.red;

    [Header("Settings")]
    public float pulseSpeed = 2f;

    private bool canPulse = true;

    private Color currentNormal;
    private Color currentPulse;

    void Start()
    {
        currentNormal = onlineNormal;
        currentPulse = onlinePulse;
    }

    void Update()
    {
        if (!canPulse)
            return;

        float t = (Mathf.Sin(Time.time * pulseSpeed) + 1f) * 0.5f;

        Color emission = Color.Lerp(currentNormal, currentPulse, t);

        ApplyEmission(emission);
    }

    void ApplyEmission(Color color)
    {
        serverBody.SetColor("_EmissionColor", color);
        ring1.SetColor("_EmissionColor", color);
        ring2.SetColor("_EmissionColor", color);
    }

    // ==========================
    // ONLINE
    // ==========================
    public void SetOnline()
    {
        canPulse = true;
        pulseSpeed = 2f;

        currentNormal = onlineNormal;
        currentPulse = onlinePulse;
    }

    // ==========================
    // PROCESSING
    // ==========================
    public void SetProcessing()
    {
        canPulse = true;
        pulseSpeed = 5f;

        currentNormal = onlineNormal;
        currentPulse = Color.white;
    }

    // ==========================
    // RESTARTING
    // ==========================
    public void SetRestarting()
    {
        canPulse = true;
        pulseSpeed = 6f;

        currentNormal = restartingNormal;
        currentPulse = Color.white;
    }

    // ==========================
    // OFFLINE
    // ==========================
    public void SetOffline()
    {
        canPulse = false;

        ApplyEmission(offlineColor);
    }
}