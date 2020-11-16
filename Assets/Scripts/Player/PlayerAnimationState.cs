using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationState : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _playerController;
    private PowerUps _powerUps;

    private bool _isGround;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
        _powerUps = GetComponent<PowerUps>();
    }
    
    void Update()
    {
        if (_playerController.isGround && UIController.IsPlaying)
        {
            _animator.SetBool("isRunning", true);
            _animator.SetBool("isFlying", false);
        }
        else
        {
            _animator.SetBool("isFlying", true);
            _animator.SetBool("isRunning", false);
        }
        
        if(_playerController.isFail)
            _animator.SetTrigger("isDeath");
        
        
        if(_playerController.isFinish)
            _animator.SetTrigger("isFinish");
        
        
        if (_powerUps.isSpeedUp)
        {
            _animator.SetBool("isSpeedUp", true);
        }
        else
        {
            _animator.SetBool("isSpeedUp", false);
        }
    }
}
