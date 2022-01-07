using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;
    private Cell _cell;
    private int _intervalXPosition=3;


    public Cell SpawnCell(ref Vector2 position)
    {
        _cell = Instantiate(_cellPrefab, position, Quaternion.identity).GetComponent<Cell>();
        position.x += _intervalXPosition;
        return _cell;
    }
}
