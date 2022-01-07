using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CellsController : MonoBehaviour
{ 
    [SerializeField] private MassOfPackOfData[] _massOfPackOfData;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private FadingScreen _fadingScreen;
    private CellSpawner _spawner;
    private Cell _cell;
    private List<Cell> _activeCells=new List<Cell>();
    
    private Vector2 _position = new Vector2(-3, 3);
    private Vector2 _startPosition= new Vector2(-3, 3);
    private float _elementToFindIndex;
    private float _newLine;
    private int _currentMassOfPackOfData;
    private int _currentPackOfData;
    private int _startXPosition=-3;
    private int _intervalYPosition=3;
    private bool _interactable=true;


    private void Start()
    {
        _spawner = GetComponent<CellSpawner>();
        ShowPackOfData();
    }

    private void Update()
    {
        if (_interactable)
        {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.GetComponent<ElementToFind>() != null)
                    {
                        StartCoroutine(hit.collider.gameObject.GetComponent<Bouncing>().BounceAndShowPackOfData());
                    }
                    else
                    {
                        hit.collider.gameObject.GetComponent<Bouncing>().EasingInBounce(hit.collider.gameObject.transform.position);
                    }
                }
            }


            #if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.GetComponent<ElementToFind>() != null)
                    {
                        StartCoroutine(hit.collider.gameObject.GetComponent<Bouncing>().BounceAndShowPackOfData());
                    }
                    else
                    {
                        hit.collider.gameObject.GetComponent<Bouncing>().EasingInBounce(hit.collider.gameObject.transform.position);
                    }
                }
            }
            #endif
        }
    }

    public void ShowPackOfData()
    {
        if (_currentMassOfPackOfData < _massOfPackOfData.Length)
        {
            _currentPackOfData = Random.Range(0, _massOfPackOfData[_currentMassOfPackOfData].PackOfData.Length);
            if (_massOfPackOfData[_currentMassOfPackOfData].PackOfData[_currentPackOfData].Data.Length > 0)
            {
                System.Random rand = new System.Random(Guid.NewGuid().GetHashCode());
                _elementToFindIndex = rand.Next(0, _massOfPackOfData[_currentMassOfPackOfData].PackOfData[_currentPackOfData].Data.Length);
                for (int i = 0; i < _massOfPackOfData[_currentMassOfPackOfData].PackOfData[_currentPackOfData].Data.Length; i++)
                {
                    if (i<_activeCells.Count)
                    {
                        UseCreatedCell(i);
                    }
                    else
                    {
                        CreateNewCell(i);
                    }
                    _newLine++;
                    
                    if (i == _elementToFindIndex)
                    {
                        MarkElementToFind();
                    }
                    
                    if (_newLine % 3 == 0)
                    {
                        ChangePositionForNewLine();
                    }
                }
            }

            _position = _startPosition;

            _currentMassOfPackOfData++;
        }
        else
        {
            FadingOut();
        }
    }

    private void UseCreatedCell(int i)
    {
        _activeCells[i].ChangeData(_massOfPackOfData[_currentMassOfPackOfData].PackOfData[_currentPackOfData].Data[i].Id,
            _massOfPackOfData[_currentMassOfPackOfData].PackOfData[_currentPackOfData].Data[i].Sprite);
        _cell = _activeCells[i];
    }

    private void CreateNewCell(int i)
    {
        _cell=_spawner.SpawnCell(ref _position);
        _activeCells.Add(_cell);
        _cell.ChangeData(_massOfPackOfData[_currentMassOfPackOfData].PackOfData[_currentPackOfData].Data[i].Id,
            _massOfPackOfData[_currentMassOfPackOfData].PackOfData[_currentPackOfData].Data[i].Sprite);
    }

    private void MarkElementToFind()
    {
        _cell.gameObject.AddComponent<ElementToFind>();
        _textMeshPro.GetComponent<ChangingText>().ChangeText("Find "+_cell.Id);
    }

    private void ChangePositionForNewLine()
    {
        _position.y -= _intervalYPosition;
        _position.x = _startXPosition;
    }

    private void FadingOut()
    {
        _interactable = false;
        _restartButton.SetActive(true);
        _fadingScreen.FadeOut();
    }
    
}