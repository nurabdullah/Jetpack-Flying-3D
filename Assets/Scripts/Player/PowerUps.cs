using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    private PlayerController _playerController;
    
    [HideInInspector]
    public bool isSpeedUp;
    private float timerCounter = 10f;

    public GameObject[] speedyParticle;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();

        isSpeedUp = false;
        speedyParticle[0].SetActive(false);
        speedyParticle[1].SetActive(false);
        speedyParticle[2].SetActive(false);
    }

    private void Update()
    {
        
        if (isSpeedUp)
        {
            _playerController.forwardSpeed = 40;
            timerCounter -= Time.deltaTime;
            
            speedyParticle[0].SetActive(true);
            speedyParticle[1].SetActive(true);
            speedyParticle[2].SetActive(true);

            if (timerCounter <= 0)
            {
                _playerController.forwardSpeed = 20;
                isSpeedUp = false;
                
                speedyParticle[0].SetActive(false);
                speedyParticle[1].SetActive(false);
                speedyParticle[2].SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Magnet"))
        {
            other.transform.SetParent(transform);
            other.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
        }
        
        if (other.gameObject.CompareTag("SpeedUp"))
        {
            isSpeedUp = true;
            Destroy(other.gameObject);
        }
    }
}
