using UnityEngine;

public class ObjectPulse : MonoBehaviour
{
    [Header("Materials to Pulse")]
    public Material[] pulseMaterials;

    [Header("Emission Colors")]
    public Color normalEmission = Color.purple;
    public Color pulseEmission = Color.white;

    [Header("Pulse Settings")]
    public float pulseSpeed = 2f;

    void Update()
    {
        float t = (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f;

        Color emission = Color.Lerp(normalEmission, pulseEmission, t);

        foreach (Material mat in pulseMaterials)
        {
            if (mat != null)
                mat.SetColor("_EmissionColor", emission);
        }
    }

    // --------- States ---------

    public void SetIdle()
    {
        pulseSpeed = 2f;
        normalEmission = Color.cyan;
        pulseEmission = Color.white;
    }

    public void SetWorking()
    {
        pulseSpeed = 5f;
        normalEmission = Color.yellow;
        pulseEmission = Color.white;
    }

    public void SetSuccess()
    {
        pulseSpeed = 2f;
        normalEmission = Color.green;
        pulseEmission = Color.white;
    }

    public void SetFailure()
    {
        pulseSpeed = 0f;

        foreach (Material mat in pulseMaterials)
        {
            if (mat != null)
                mat.SetColor("_EmissionColor", Color.red);
        }
    }
}