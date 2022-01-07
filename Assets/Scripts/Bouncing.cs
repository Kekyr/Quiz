using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Bouncing : MonoBehaviour
{
    [SerializeField] private GameObject _particleSystem;
    private CellsController _cellsController;
    

    private void Start()
    {
        _cellsController = FindObjectOfType<CellsController>();
    }
    public void EasingInBounce(Vector2 position)
    {
        Sequence easeInBounce = DOTween.Sequence();
        easeInBounce.Append(transform.DOMoveX(1f, 0.5f).SetEase(Ease.InBounce));
        easeInBounce.Append(transform.DOMoveX(-1f, 0.5f));
        easeInBounce.Append(transform.DOMoveX(position.x, 2));
        easeInBounce.PrependInterval(1);
    }
    
    public void Bounce()
    {
        Sequence bounce = DOTween.Sequence();
        bounce.Append(transform.DOScale(0.1f, 0).SetEase(Ease.InBounce));
        bounce.Append(transform.DOScale(1, 2).SetEase(Ease.InBounce));
        
    }
    
    public IEnumerator BounceAndShowPackOfData()
    {
        Sequence bounceAndShowPackOfData = DOTween.Sequence();
        bounceAndShowPackOfData.Append(transform.DOScale(0.1f, 0).SetEase(Ease.InBounce));
        _particleSystem.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        bounceAndShowPackOfData.Append(transform.DOScale(1, 2).SetEase(Ease.InBounce));
        yield return new WaitForSeconds(2f);
        _particleSystem.SetActive(false);
        _cellsController.ShowPackOfData();
    }
}
