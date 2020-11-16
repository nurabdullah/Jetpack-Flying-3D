using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    public GameObject[] particle;
    public AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
       particle[0].SetActive(false); 
       particle[1].SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && UIController.IsPlaying)
        {
            audioSource.Play();
        }
        else if (Input.GetMouseButton(0) && UIController.IsPlaying)
        {
            particle[0].SetActive(true); 
            particle[1].SetActive(true); 
        }
        else if (Input.GetMouseButtonUp(0))
        {
            particle[0].SetActive(false); 
            particle[1].SetActive(false); 
            
            audioSource.Stop();
        }
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && UIController.IsPlaying)
            {
                audioSource.Play();
            }

            else if (touch.phase == TouchPhase.Moved && UIController.IsPlaying)
            {
                particle[0].SetActive(true); 
                particle[1].SetActive(true); 
            }
            
            else if (touch.phase == TouchPhase.Ended)
            {
                particle[0].SetActive(false); 
                particle[1].SetActive(false); 
            
                audioSource.Stop();
            }

        }
        
    }
}
