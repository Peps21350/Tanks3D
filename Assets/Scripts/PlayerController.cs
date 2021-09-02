using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private JoystickController _joystickController;
    [SerializeField] private float _moveSpeed;


    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystickController.Horizontal * _moveSpeed, _rigidbody.velocity.y,
            _joystickController.Vertical * _moveSpeed);
        if (_joystickController.Horizontal != 0 || _joystickController.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity  * Time.fixedTime) ;
        }
    }
    
}
