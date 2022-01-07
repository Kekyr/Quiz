using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New MassOfPackOfData",menuName="Mass Of Pack Of Data",order=10)]
[Serializable]
public class MassOfPackOfData : ScriptableObject
{
    [SerializeField] 
    private PackOfData[] _packOfData;

    public PackOfData[] PackOfData => _packOfData;
}
