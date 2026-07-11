using UnityEngine;
using UnityEngine.Video;

public class PanelVideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private bool isPlaying = false;

    public void ToggleVideo()
    {
        if (videoPlayer == null) return;

        if (isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }

        isPlaying = !isPlaying;
    }
}
