using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FadingScreen : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    
    void Start()
    {
        _meshRenderer=GetComponent<MeshRenderer>();
    }

    public void FadeOut()
    {
        _meshRenderer.material.DOFade(255f, 7);
    }
}
