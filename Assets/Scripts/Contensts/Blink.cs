using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    [SerializeField] private float fadeTime;  // ���̵� �Ǵ� �ð�
    [SerializeField] private Image fadeImage; // ���̵� ȿ���� ���Ǵ� Image UI

    private void Awake()
    {
        // �ش� ���� ������Ʈ���� Image ������Ʈ�� ������
        fadeImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        // ���̵� ȿ���� In -> Out ���� �ݺ�
        StartCoroutine("FadeInOut");
    }

    private void OnDisable()
    {
        // ���̵� ȿ�� ����
        StopCoroutine("FadeInOut");
    }

    private IEnumerator FadeInOut()
    {
        // ���� �ݺ��Ͽ� FadeIn -> FadeOut ��� ����
        while (true)
        {
            yield return StartCoroutine(Fade(1, 0));  // ���̵� ��
            yield return StartCoroutine(Fade(0, 1));  // ���̵� �ƿ�
        }
    }

    private IEnumerator Fade(float start, float end)
    {
        float current = 0f; // ���� �ð�
        float percent = 0f; // ���� ����

        // ���̵� �ð� ���� ���̵� ó��
        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / fadeTime;  // ��� �ð� ��� ���� ���

            // Image ������Ʈ�� ���� ���� �����Ͽ� ���̵� ȿ�� ����
            Color color = fadeImage.color;
            color.a = Mathf.Lerp(start, end, percent);
            fadeImage.color = color;

            yield return null;
        }
    }
}
