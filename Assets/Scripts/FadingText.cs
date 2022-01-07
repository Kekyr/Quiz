using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class FadingText : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;
    private Tween fadeTween;
    
    void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Fading());
    }

    public void FadeIn(float duration)
    {
        Fade(1f,duration);
    }

    public void FadeOut(float duration)
    {
        Fade(0f,duration);
    }

    private void Fade(float endValue, float duration)
    {
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }

        fadeTween = _textMeshPro.DOFade(endValue, duration);
        
    }

    public IEnumerator Fading()
    {
        FadeOut(0f);
        yield return new WaitForSeconds(2f);
        FadeIn(1f);
        
    }
    
}
