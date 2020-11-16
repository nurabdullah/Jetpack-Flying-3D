using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{    
    List<Rigidbody> _rigidbodyBalls = new List<Rigidbody>();

    public AudioSource audioSource;
    public float forceFactor = 200f;

    private bool _magnetpointPlay = true;

    public Collider boxcol;
    public Collider sphCol;
    

    public float timerCounter;

    private void Update()
    {
        if (sphCol.enabled == true)
        {
            timerCounter -= Time.deltaTime;
            if (timerCounter <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        foreach(Rigidbody rgbBal in _rigidbodyBalls)
        {
            rgbBal.AddForce((transform.position - rgbBal.position) * forceFactor * Time.fixedDeltaTime);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            _rigidbodyBalls.Add(other.GetComponent<Rigidbody>());
        }
        
        if (other.gameObject.CompareTag("Player"))
        {
            boxcol.enabled = false;
            sphCol.enabled = true;
        }
    }
    
    void OnTriggerExit(Collider other)
     {
        if (other.gameObject.CompareTag("Coin"))
        {
            audioSource.Play();
            _rigidbodyBalls.Remove(other.GetComponent<Rigidbody>());
        }
     }
}
