using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private JoystickController _joystickController;
    [SerializeField] private Tank _tank;
    [SerializeField] private GameObject screensaver;
  


    private void FixedUpdate()
    {
         _rigidbody.velocity = new Vector3(_joystickController.Horizontal * _tank.speed, _rigidbody.velocity.y,
             _joystickController.Vertical * _tank.speed);
        
        //_tank.Move(_joystickController.Horizontal,_joystickController.Vertical);
        if (_joystickController.Horizontal != 0 || _joystickController.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity  * Time.fixedTime) ;
        }

        if (_tank._opportunityToShoot == false)
        {
            screensaver.SetActive(true);
        }
        else
        {
            screensaver.SetActive(false);
        }
    }

   
}
