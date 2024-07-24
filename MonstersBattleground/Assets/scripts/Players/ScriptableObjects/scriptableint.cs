using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableInt", menuName = "MyGame/ScriptableInt")]
public class ScriptableInt : ScriptableObject
{
    [SerializeField] private int _value;

    public int Value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
        }
    }

}
