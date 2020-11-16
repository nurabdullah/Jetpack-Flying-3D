using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Manager", menuName = "Data/LevelManager", order = 1)]
public class LevelManager : ScriptableObject
{
    public List<Level> levelList;
}