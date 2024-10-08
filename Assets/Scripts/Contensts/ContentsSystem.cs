using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentsSystem : MonoBehaviour
{
    public Player player;
    public int contentsBranch;
    public DialogSystem dialogSystem;  
    public ZoomSystem zoomSystem;
    public FadeSystem fadeSystem;
    public SoulSystem soul;
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
        SoulSystem s = null;
        if (zoomSystem != null)
        {
            yield return StartCoroutine(zoomSystem.ZoomIn());
        }
        if (fadeSystem != null)
        {
            yield return StartCoroutine(fadeSystem.FadeIn());
        }
        if (soul != null)
        {
            s = Instantiate(soul, transform);
            s.SetPos(player.transform.position + new Vector3(3, 0, 0));
            yield return new WaitForSeconds(1.1f);
        }
        if (dialogSystem != null && contentsBranch != -1)
        {
            dialogSystem.SetBranch(contentsBranch);
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(s.transform.position + new Vector3(0, 1, 0));
            dialogSystem.GetComponent<RectTransform>().position = screenPosition;
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
        if(s != null)
        {
            s.gameObject.SetActive(false);
        }

        Debug.Log("ÄÁÅÙÃ÷ Á¾·á");
    }
}
