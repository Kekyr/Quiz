using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New PackOfData",menuName="Pack Of Data",order=10)]
[Serializable]
public class PackOfData : ScriptableObject
{
    [SerializeField]
    private Data[] _data;
    
    public Data[] Data => _data;
    
    

    
    
}
