using UnityEngine;
using UnityEngine.Video;

public class LoopVideoAtSpecificPoint : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public double loopStartPointInSeconds;
    public double loopEndPointInSeconds;

    bool isVideoPlaying = false;

    void Start()
    {
        videoPlayer.isLooping = false;
        videoPlayer.started += OnVideoStarted;
        videoPlayer.loopPointReached += OnLoopPointReached;
        videoPlayer.Play();
    }

    void Update()
    {
        if (isVideoPlaying && videoPlayer.time >= loopEndPointInSeconds)
        {
            videoPlayer.time = loopStartPointInSeconds;
        }
    }

    void OnVideoStarted(VideoPlayer vp)
    {
        isVideoPlaying = true;
    }

    void OnLoopPointReached(VideoPlayer vp)
    {
        isVideoPlaying = true;
        videoPlayer.Play();
    }
}
