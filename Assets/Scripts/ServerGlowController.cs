using UnityEngine;

public class ServerGlowController : MonoBehaviour
{
    public Renderer serverRenderer;
    public Color glowColor = Color.cyan;
    public float glowIntensity = 2f;

    public void GlowOn()
    {
        serverRenderer.material.EnableKeyword("_EMISSION");
        serverRenderer.material.SetColor("_EmissionColor", glowColor * glowIntensity);
    }

    public void GlowOff()
    {
        serverRenderer.material.SetColor("_EmissionColor", Color.black);
    }
}
