using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulSystem : MonoBehaviour
{
    public SpriteRenderer soulImage;

    private void OnEnable()
    {
        StartCoroutine(AppearSoul());
    }
    private void OnDisable()
    {
        
    }
    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }
    IEnumerator AppearSoul()
    {
        float duration = 1f; 
        float elapsed = 0f;

        Color color = soulImage.color; 
        color.a = 0; 
        soulImage.color = color; 

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Lerp(0, 1, elapsed / duration); 
            soulImage.color = color;

            yield return null;
        }
        color.a = 1;
        soulImage.color = color;
    }
}
