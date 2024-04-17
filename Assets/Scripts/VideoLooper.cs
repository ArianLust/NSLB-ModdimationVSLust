using UnityEngine;
using UnityEngine.Video;

public class VideoLooper : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public float loopStart = 5f; // Time in seconds where the loop starts
    public float loopEnd = 10f; // Time in seconds where the loop ends
    private bool hasStarted = false;

    void Start()
    {
        // Ensure VideoPlayer component is assigned
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }
    }

    void Update()
    {
        // Check if the video player is playing
        if (videoPlayer.isPlaying)
        {
            // Check if the video has not started yet
            if (!hasStarted)
            {
                // Set video time to loop start
                videoPlayer.time = loopStart;
                hasStarted = true;
            }

            // Check if it's time to loop
            if (videoPlayer.time >= loopEnd)
            {
                // Set video time to loop start
                videoPlayer.time = loopStart;
            }
        }
        else
        {
            hasStarted = false; // Reset hasStarted flag if video is stopped
        }
    }
}
