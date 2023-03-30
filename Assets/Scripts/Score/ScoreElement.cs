using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ScoreElement : MonoBehaviour
{
    [SerializeField] private Sprite[] _numbers;
    private Image _image;
    private int _value;

    public int Value => _value;

    public Action<ScoreElement> WentOutOfArray;
    public void UpdateValue()
    {
        _value++;
        if (_value < _numbers.Length)
        {
          
            _image.sprite = _numbers[_value];
            return;
        }

        _value = 0;
        _image.sprite = _numbers[_value];
        WentOutOfArray?.Invoke(this);
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
    }
}
