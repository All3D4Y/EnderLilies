using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour
{
    [SerializeField] private DialogSystem dialogSystem01;
    [SerializeField] private Text textCountdown; 
    [SerializeField] private DialogSystem dialogSystem02; 

    private IEnumerator Start()
    {
        // 첫 번째 대사 분기 시작
        textCountdown.gameObject.SetActive(false); 
        yield return new WaitUntil(() => dialogSystem01.UpdateDialog()); 

        textCountdown.gameObject.SetActive(true); 
        int count = 5; 
        while (count > 0)
        {
            textCountdown.text = count.ToString();  
            count--; 
            yield return new WaitForSeconds(1);
        }

        textCountdown.gameObject.SetActive(false);  
        yield return new WaitUntil(() => dialogSystem02.UpdateDialog()); 
        textCountdown.gameObject.SetActive(true);  
        textCountdown.text = "The End"; 
        yield return new WaitForSeconds(2);  

        UnityEditor.EditorApplication.ExitPlaymode();
    }
}

