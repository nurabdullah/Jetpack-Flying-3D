using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public LevelManager levelList;
    public static LevelManager LevelListStatic;
    
    private static GameObject _currentLevelStatic;
    
    public static int CurrentLevelIndexStatic;
    public static int LastLevelIndex;
    
    private void Awake()
    {
        LevelListStatic = levelList;
    }

    private void Start()
    {
        LevelStarted();
    }
    
    private void Update()
    {            
        PlayerPrefs.SetInt("CurrentLevel", CurrentLevelIndexStatic);
    }
    
    public static void LevelStarted()
    {
        CurrentLevel();
        //Debug.Log("Level Started");
    }

    public static void LevelCompleted()
    {
        UIController.OpenCompletedMenu();
        //Debug.Log("Level Completed");
    }
    
    public static void LevelFailed()
    {
        UIController.OpenFailedMenu();
        //Debug.Log("Level Failed");
    }
    

    #region Functions

    private static void CurrentLevel()
    {
        CurrentLevelIndexStatic = PlayerPrefs.GetInt("CurrentLevel");
        LastLevelIndex = LevelListStatic.levelList.Count;
        _currentLevelStatic = Instantiate(LevelListStatic.levelList[CurrentLevelIndexStatic].levelPrefab);
    }
    
    public static void NextLevel()
    {
        DeleteOldLevel();
                
        CurrentLevelIndexStatic += 1;
        if (CurrentLevelIndexStatic < (LastLevelIndex))
            _currentLevelStatic = Instantiate(LevelListStatic.levelList[CurrentLevelIndexStatic].levelPrefab);
            
        // Eğer son level gecilirse ilk levele atıyor
        else if (CurrentLevelIndexStatic == (LastLevelIndex) )
        {
            CurrentLevelIndexStatic = 0;
            _currentLevelStatic = Instantiate(LevelListStatic.levelList[CurrentLevelIndexStatic].levelPrefab);
        }
    }
        
    public static void PreviousLevel()
    {
        if (CurrentLevelIndexStatic > 0)
        {
            DeleteOldLevel();
            
            CurrentLevelIndexStatic -= 1;
            _currentLevelStatic = Instantiate(LevelListStatic.levelList[CurrentLevelIndexStatic].levelPrefab);
        }
    }
        
    public static void RetryLevel()
    {
        DeleteOldLevel();
            
        _currentLevelStatic = Instantiate(LevelListStatic.levelList[CurrentLevelIndexStatic].levelPrefab);
    }
        
    public static void ResetLevel()
    {
        DeleteOldLevel();
        CurrentLevelIndexStatic = 0;
        _currentLevelStatic = Instantiate(LevelListStatic.levelList[CurrentLevelIndexStatic].levelPrefab);
    }
    private static void DeleteOldLevel()
    {
        Destroy(_currentLevelStatic);
    }

    #endregion
    
  
}
