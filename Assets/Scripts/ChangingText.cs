using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangingText : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;
    
    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }
    
    public void ChangeText(string text)
    {
        _textMeshPro.text = text;
    }
}
