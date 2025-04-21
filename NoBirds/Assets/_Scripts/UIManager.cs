using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup[] screens;
    private int index = 0;

    public void Next() {
        if (index + 1 > screens.Length - 1) {  return; }

        CanvasGroup currScreen = screens[index];
        CanvasGroup nextScreen = screens[index + 1];

        StartCoroutine(FadeCanvasGroup(currScreen, 0.0f, 0.3f));
        StartCoroutine(FadeCanvasGroup(nextScreen, 1.0f, 1f));
        index++;
    }

    public void Back() {
        if (index - 1 < 0) { return; }

        CanvasGroup currScreen = screens[index];
        CanvasGroup prevScreen = screens[index - 1];
        currScreen.alpha = 0.0f;

        StartCoroutine(FadeCanvasGroup(currScreen, 0.0f, 0.3f));
        StartCoroutine(FadeCanvasGroup(prevScreen, 1.0f, 1));
        index--;
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup group, float targetAlpha, float duration) {
        float startAlpha = group.alpha;
        float timeElapsed = 0f;

        while (timeElapsed < duration) {
            group.alpha = Mathf.Lerp(startAlpha, targetAlpha, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        group.alpha = targetAlpha;
    }
}
