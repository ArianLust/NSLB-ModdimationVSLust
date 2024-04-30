using UnityEngine;
using System.Collections;

public class MinimizeSFX : MonoBehaviour
{
    public AudioClip minimizeSound;
    public AudioClip maximizeSound;

    private bool isGameMinimized = false;
    private bool isMuting = false;
    private float delay = 2f;

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus && !isGameMinimized && !isMuting)
        {
            isGameMinimized = true;
            isMuting = true;
            PlaySFX(minimizeSound);
            StartCoroutine(MuteAudioAfterDelay(delay));
        }
        else if (hasFocus && isGameMinimized && !isMuting)
        {
            isGameMinimized = false;
            isMuting = true;
            PlaySFX(maximizeSound);
            StartCoroutine(UnmuteAudioAfterDelay(delay));
        }
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus && !isGameMinimized && !isMuting)
        {
            isGameMinimized = true;
            isMuting = true;
            PlaySFX(minimizeSound);
            StartCoroutine(MuteAudioAfterDelay(delay));
        }
        else if (!pauseStatus && isGameMinimized && !isMuting)
        {
            isGameMinimized = false;
            isMuting = true;
            PlaySFX(maximizeSound);
            StartCoroutine(UnmuteAudioAfterDelay(delay));
        }
    }

    void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        }
    }

    IEnumerator MuteAudioAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        // Mute all audio sources
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in audioSources)
        {
            source.mute = true;
        }

        isMuting = false;
    }

    IEnumerator UnmuteAudioAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        // Unmute all audio sources
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in audioSources)
        {
            source.mute = false;
        }

        isMuting = false;
    }
}
