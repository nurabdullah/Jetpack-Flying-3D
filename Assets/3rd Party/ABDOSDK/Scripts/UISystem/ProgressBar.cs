using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ProgressState
{
    OnProgressEnter,
    OnProgress,
    OnProgressExit
}

public class ProgressBar : MonoBehaviour
{
    public Slider progressbarSlider;
    public Text currentLevelText;
    public Text nextLevelText;

    public Transform PlayerTransform;
    public Transform FinishTransform;

    private float _distance;

    public ProgressState progressState;

    #region Signleton

    public static ProgressBar Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    void Start()
    {
        progressState = ProgressState.OnProgressEnter;

    }

    void Update()
    {
        switch (progressState)
        {
            case ProgressState.OnProgressEnter:
                SetValues();
                progressState = ProgressState.OnProgress;
                break;
            case ProgressState.OnProgress:
                if (PlayerTransform.position.z <= _distance && PlayerTransform.position.z <= FinishTransform.position.z)
                {
                    float distance = 1 - (getDistance() / _distance);
                    progressbarSlider.value = distance;
                }

                break;
            case ProgressState.OnProgressExit:
                break;
        }

        currentLevelText.text = Convert.ToString(LevelController.CurrentLevelIndexStatic + 1);
        nextLevelText.text = Convert.ToString(LevelController.CurrentLevelIndexStatic + 2);
    }

    public void SetValues()
    {
        _distance = getDistance();
    }

    float getDistance()
    {
        return Vector3.Distance(FinishTransform.position, PlayerTransform.position);
    }

    public void ResetProgress()
    {
        progressbarSlider.value = 0;
    }
}    

