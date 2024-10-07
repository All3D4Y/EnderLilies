using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSystem : MonoBehaviour
{
    public CanvasGroup fadeCanvas;
    public float fadeDuration = 1f;

    public IEnumerator FadeIn()
    {
        Debug.Log("페이드인 시작");
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            fadeCanvas.alpha = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadeCanvas.alpha = 1;
    }

    public IEnumerator FadeOut()
    {
        Debug.Log("페이드아웃 시작");
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            fadeCanvas.alpha = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadeCanvas.alpha = 0;
    }
}