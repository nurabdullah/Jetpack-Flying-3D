using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{ 
    void Start()
    {
        ProgressBar.Instance.FinishTransform = transform;
    }
}
