using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewApple", menuName = "ScriptableObjects/AppleProbability", order = 1)]
public class AppleProbability : ScriptableObject
{
    public GameObject prefab;
    [Range(0, 1)] public float probability;
}
