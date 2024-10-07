using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomSystem : MonoBehaviour
{
    public Camera mainCamera;
    public float zoomInSize = 2f;
    public float zoomOutSize = 5f;
    public float zoomDuration = 1f;

    public IEnumerator ZoomIn()
    {
        Debug.Log("¡‹¿Œ Ω√¿€");
        float elapsedTime = 0f;
        float startSize = mainCamera.orthographicSize;
        while (elapsedTime < zoomDuration)
        {
            mainCamera.orthographicSize = Mathf.Lerp(startSize, zoomInSize, elapsedTime / zoomDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        mainCamera.orthographicSize = zoomInSize;
    }
    public IEnumerator ZoomOut()
    {
        Debug.Log("¡‹æ∆øÙ Ω√¿€");
        float elapsedTime = 0f;
        float startSize = mainCamera.orthographicSize;
        while (elapsedTime < zoomDuration)
        {
            mainCamera.orthographicSize = Mathf.Lerp(startSize, zoomOutSize, elapsedTime / zoomDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        mainCamera.orthographicSize = zoomOutSize;
    }
}