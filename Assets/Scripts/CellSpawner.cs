using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;
    private Cell _cell;


    public Cell SpawnCell(ref Vector2 position)
    {
        _cell = Instantiate(_cellPrefab, position, Quaternion.identity).GetComponent<Cell>();
        position.x += 3;
        return _cell;
    }
}
