using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentsSystem : MonoBehaviour
{
    public int contentsBranch;
    public DialogSystem dialogSystem;  
    public ZoomSystem zoomSystem;
    public FadeSystem fadeSystem;
    private void OnEnable()
    {
        if (dialogSystem != null)
        {
            dialogSystem.gameObject.SetActive(true); 
        }
        StartCoroutine(RunContent());
    }
    private void OnDisable()
    {
        if (dialogSystem != null)
        {
            dialogSystem.gameObject.SetActive(false); 
        }
    }
    private IEnumerator RunContent()
    {
        if (zoomSystem != null)
        {
            yield return StartCoroutine(zoomSystem.ZoomIn());
        }
        if (fadeSystem != null)
        {
            yield return StartCoroutine(fadeSystem.FadeIn());
        }
        if (dialogSystem != null)
        {
            dialogSystem.SetBranch(contentsBranch);
            yield return new WaitUntil(() => dialogSystem.UpdateDialog());
        }
        if (zoomSystem != null)
        {
            yield return StartCoroutine(zoomSystem.ZoomOut());
        }
        if (fadeSystem != null)
        {
            yield return StartCoroutine(fadeSystem.FadeOut());
        }

        Debug.Log("ÄÁÅÙÃ÷ Á¾·á");
    }
}
