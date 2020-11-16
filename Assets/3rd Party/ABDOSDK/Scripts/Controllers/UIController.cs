using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
[Space]
        [Header("MENUS")]
        public RectTransform mainMenu;
        public RectTransform gameMenu;
        public RectTransform completedMenu;
        public RectTransform failedMenu;
        
        public static RectTransform CompletedMenuStatic;
        public static RectTransform FailedMenuStatic;
        
        public static bool IsPlaying;

        public Text[] levelText;

        public GameObject tapTutorial;
        private void Awake()
        {
            CompletedMenuStatic = completedMenu;
            FailedMenuStatic = failedMenu;
            
            mainMenu.DOAnchorPos(Vector2.zero, 0.25f);
            
            IsPlaying = false;
            
            
        }

        private void Update()
        {
            for (int i = 0; i < levelText.Length; i++)
            {
                levelText[i].text = "Level " + (LevelController.CurrentLevelIndexStatic + 1);
            }

            if (Input.GetMouseButtonDown(0))
            {
                tapTutorial.SetActive(false);
            }
        }

        public void PlayButton()
        {
            IsPlaying = true;
            mainMenu.DOAnchorPos(new Vector2(-1100, 0), 0.25f);
            gameMenu.DOAnchorPos(Vector2.zero, 0.25f);
            tapTutorial.SetActive(true);
        }
    
        public void HomeButton()
        {
            IsPlaying = false;
            mainMenu.DOAnchorPos(Vector2.zero, 0.25f);
            gameMenu.DOAnchorPos(new Vector2(1100, 0), 0.25f);
        }

        public void PauseButton()
        {
            IsPlaying = false;
        }
        public void ResumeButton()
        {
            IsPlaying = true;
        }

        #region Completed Menu
        public static void OpenCompletedMenu()
        {
            CompletedMenuStatic.DOAnchorPos(Vector2.zero, 0.25f);
            IsPlaying = false;
        }
        public void CloseCompletedMenu()
        {
            CompletedMenuStatic.DOAnchorPos(new Vector2(0, 1920), 0.25f);
            IsPlaying = true;
        }
        #endregion

        #region Failed Menu
        public static void OpenFailedMenu()
        {
            FailedMenuStatic.DOAnchorPos(Vector2.zero, 0.25f);
            IsPlaying = false;
        }
        public void CloseFailedMenu()
        {
            FailedMenuStatic.DOAnchorPos(new Vector2(0, -1920), 0.25f);
            IsPlaying = true;
        }
        #endregion
        
        public void ToggleNextLevel()
        {
            LevelController.NextLevel();
            tapTutorial.SetActive(true);
        }
        public void ToggleRetryLevel()
        {
            LevelController.RetryLevel();
            tapTutorial.SetActive(true);
        }
        public void TogglePreviousLevel()
        {
            LevelController.PreviousLevel();
        }
        public void ToggleResetLevel()
        {
            LevelController.ResetLevel();
        }
}
