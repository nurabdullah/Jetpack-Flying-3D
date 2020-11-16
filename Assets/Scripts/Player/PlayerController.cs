using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float upSpeed; 
    public float forwardSpeed;

    private Rigidbody _rigidbody;
    public AudioSource audioSource;

    [HideInInspector] public bool isGround;
    [HideInInspector] public bool isFail;
    [HideInInspector] public bool isFinish;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        isFail = false;
        isFinish = false;

        ProgressBar.Instance.PlayerTransform = transform;
    }

    void FixedUpdate()
    {
        if (UIController.IsPlaying)
            Movement();
        else
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }

    }

    #region Controller

    private void Movement()
    {
        transform.Translate(0, 0, forwardSpeed * Time.deltaTime);

        _rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;
        _rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionZ;

        if (Input.GetMouseButton(0))
        {
            Vector3 maxUpLimit = new Vector3(0, upSpeed * Time.deltaTime, 0);
            _rigidbody.AddForce(maxUpLimit, ForceMode.Impulse);
        }

        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);


            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 maxUpLimit = new Vector3(0, upSpeed * Time.deltaTime, 0);
                _rigidbody.AddForce(maxUpLimit, ForceMode.Impulse);
            }

        }
        
    }

    public void Fail()
    {
        isFail = true;
        UIController.IsPlaying = false;
        StartCoroutine(FailCoroutine(1.5f));

    }

    public void Finish()
    {
        isFinish = true;
        UIController.IsPlaying = false;
        StartCoroutine(CompletedCoroutine(1.5f));

    }
    

    #endregion
    
    #region Collision Detection
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fail") && gameObject.CompareTag("Player"))
        {
            Fail();
        }
        if (other.CompareTag("Finish"))
        {
            Finish();
        }
        
        if (other.CompareTag("Coin"))
        {
            audioSource.Play();
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }

    #endregion
    
    IEnumerator CompletedCoroutine(float time)
    {
        var Counter = new WaitForSeconds(time);
        yield return Counter;
        LevelController.LevelCompleted();
    }
    
    IEnumerator FailCoroutine(float time)
    {
        var Counter = new WaitForSeconds(time);
        yield return Counter;
        LevelController.LevelFailed();
    }

}
