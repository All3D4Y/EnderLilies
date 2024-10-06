using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    [SerializeField] private float fadeTime;  // 페이드 되는 시간
    [SerializeField] private Image fadeImage; // 페이드 효과에 사용되는 Image UI

    private void Awake()
    {
        // 해당 게임 오브젝트에서 Image 컴포넌트를 가져옴
        fadeImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        // 페이드 효과를 In -> Out 무한 반복
        StartCoroutine("FadeInOut");
    }

    private void OnDisable()
    {
        // 페이드 효과 중지
        StopCoroutine("FadeInOut");
    }

    private IEnumerator FadeInOut()
    {
        // 무한 반복하여 FadeIn -> FadeOut 계속 실행
        while (true)
        {
            yield return StartCoroutine(Fade(1, 0));  // 페이드 인
            yield return StartCoroutine(Fade(0, 1));  // 페이드 아웃
        }
    }

    private IEnumerator Fade(float start, float end)
    {
        float current = 0f; // 현재 시간
        float percent = 0f; // 진행 비율

        // 페이드 시간 동안 페이드 처리
        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / fadeTime;  // 경과 시간 대비 비율 계산

            // Image 컴포넌트의 알파 값을 조절하여 페이드 효과 적용
            Color color = fadeImage.color;
            color.a = Mathf.Lerp(start, end, percent);
            fadeImage.color = color;

            yield return null;
        }
    }
}
