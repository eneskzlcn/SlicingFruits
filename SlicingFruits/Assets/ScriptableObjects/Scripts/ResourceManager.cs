using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName= "Resource Manager",menuName = "ScriptableObjects/ResourceManager")]
public class ResourceManager : ScriptableObject
{
    public ColorUtil innerColors;
    public ColorUtil outerColors;
    public MaterialUtil innerMaterials;
    public Material GetInnerMaterial(string fruitName)
    {
        if(innerMaterials == null)
        {
            Debug.Log("There is no inner material");
        }
        return innerMaterials.GetMaterialOfFruit(fruitName);
    }
   
}
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;

// [CreateAssetMenu(fileName= "Resource Manager",menuName = "ScriptableObjects/ResourceManager")]
// public class ResourceManager : ScriptableSingleton<ResourceManager>
// {
//     public ColorUtil innerColors;
//     public ColorUtil outerColors;
//     public MaterialUtil innerMaterials;
//     public Material GetInnerMaterial(string fruitName)
//     {
//         return innerMaterials.GetMaterialOfFruit(fruitName);
//     }
// }

