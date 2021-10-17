using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct FruitMaterialMap
{
    public string name;
    public Material material;
}

[CreateAssetMenu(fileName= "Material",menuName = "ScriptableObjects/MaterialUtil")]
public class MaterialUtil : ScriptableObject
{

    public FruitMaterialMap[] materialsFruitPairs;

    public Material GetMaterialOfFruit(string fruitName)
    {
        for(int i = 0; i < materialsFruitPairs.Length;i++)
        {
            if(materialsFruitPairs[i].name == fruitName)
            {
                return materialsFruitPairs[i].material;
            }
        }
        return null;
    }
   
}
