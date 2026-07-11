using UnityEngine;
using UnityEngine.Video;

public class CubeVideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip videoClip;

    public void PlayVideo()
    {
        videoPlayer.Stop();
        videoPlayer.clip = videoClip;
        videoPlayer.Play();
    }
}