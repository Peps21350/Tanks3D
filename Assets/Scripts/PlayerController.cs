using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private JoystickController _joystickController;
    [SerializeField] private PlayerTank _playerTank;
    [SerializeField] private GameObject screensaver;
    
  


    private void FixedUpdate()
    {
        
        _playerTank.Move(_joystickController.Horizontal,_joystickController.Vertical);
        if (_joystickController.Horizontal != 0 || _joystickController.Vertical != 0)
        {
            //_playerTank.Rotate();
            //Debug.Log($"{_joystickController.Horizontal} + {_joystickController.Vertical }");
            // if ((_joystickController.Horizontal <= 1|| _joystickController.Horizontal >= -1) && (_joystickController.Vertical <= 0.4 || _joystickController.Vertical >= -0.4))
            // {
            //     int countRotate = 1;
            //     //_playerTank.Rotate();
            //     gameObject.transform.rotation = Quaternion.Euler(0f,45 * countRotate * Time.deltaTime,0f);
            //     countRotate++;
            //     
            // }
            // else
            // {
            //     _playerTank.Move(_joystickController.Horizontal,_joystickController.Vertical);
            // }
            _playerTank.Rotate();
        }
       

        if (_playerTank._opportunityToShoot == false)
        {
            screensaver.SetActive(true);
        }
        else
        {
            screensaver.SetActive(false);
        }
    }

   
}
