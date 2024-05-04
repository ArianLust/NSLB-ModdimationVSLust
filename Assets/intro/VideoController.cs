using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName;

    private bool videoPlayed = false;

    void Start()
    {
        videoPlayer.loopPointReached += VideoFinished;
    }

    void VideoFinished(VideoPlayer vp)
    {
        videoPlayed = true;
    }

    void Update()
    {
        // Check if the video has been played completely
        if (videoPlayed && Mouse.current.leftButton.wasPressedThisFrame) // Using the Input System
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
