using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data
{
    [SerializeField]
    private string _id;

    [SerializeField]
    private Sprite _sprite;

    public string Id => _id;

    public Sprite Sprite => _sprite;
}
