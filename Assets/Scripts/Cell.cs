using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.Serialization;

public class Cell : MonoBehaviour
{
    private string _id;
    
    private SpriteRenderer _spriteRenderer;
    private Bouncing _bouncing;
    
    private static int _counter;
    private int _numberOfBouncingCells = 4;
    
    private void Awake()
    {
        _bouncing = GetComponent<Bouncing>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void ChangeData(string id, Sprite sprite)
    {
        _id = id;
        _spriteRenderer.sprite = sprite;
        _counter++;

        if (_counter < _numberOfBouncingCells)
        {
            _bouncing.Bounce();
        }
    }

    public string Id => _id;





}
