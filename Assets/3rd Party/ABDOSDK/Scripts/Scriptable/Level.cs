using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Data/Level", order = 2)]
public class Level : ScriptableObject
{
    public int index;
    public string description;
    public GameObject levelPrefab;
}