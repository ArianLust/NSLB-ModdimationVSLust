using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeOutManager : MonoBehaviour {

    public float fadeTimer, fadeTime, blackTime, totalTime;
    public float fadeDelaySeconds = 0;
    public bool isText;

    private Image image;
    private TMP_Text text;
    private Coroutine fadeCoroutine;

    public void Start() {
        if(isText) 
            text = GetComponent<TMP_Text>(); 
        else 
            image = GetComponent<Image>();
    }

    private IEnumerator Fade() {
        if(fadeDelaySeconds != 0) yield return new WaitForSeconds(fadeDelaySeconds);
        if (!isText)
            while (fadeTimer > -totalTime) {
                fadeTimer -= Time.deltaTime;
                image.color = new(0, 0, 0, 1 - Mathf.Clamp01((Mathf.Abs(fadeTimer) - blackTime) / fadeTime));
                yield return null;
        } else
            while (fadeTimer > -totalTime) {
                fadeTimer -= Time.deltaTime;
                text.color = new(0, 0, 0, 1 - Mathf.Clamp01((Mathf.Abs(fadeTimer) - blackTime) / fadeTime));
                yield return null;
        }
        image.color = new(0, 0, 0, 0);
        fadeCoroutine = null;
    }

    public void FadeOutAndIn(float fadeTime, float blackTime) {
        this.fadeTime = fadeTime;
        this.blackTime = blackTime;
        totalTime = fadeTime + blackTime;
        fadeTimer = totalTime;

        if (fadeCoroutine == null)
            fadeCoroutine = StartCoroutine(Fade());
    }
}