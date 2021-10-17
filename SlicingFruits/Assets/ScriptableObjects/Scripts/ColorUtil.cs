using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public struct FruitColorMap
{
    public string name;
    public Color color;
}
[CreateAssetMenu(fileName= "Colors",menuName = "ScriptableObjects/ColorUtil")]
public class ColorUtil : ScriptableObject
{

    public FruitColorMap[] colors;

   
}
