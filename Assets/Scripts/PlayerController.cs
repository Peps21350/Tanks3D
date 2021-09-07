using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private JoystickController _joystickController;
    [SerializeField] private Tank _tank;
    [SerializeField] private GameObject screensaver;
  


    private void FixedUpdate()
    {
        _tank.Move(_joystickController.Horizontal,_joystickController.Vertical);
        
        if (_joystickController.Horizontal != 0 || _joystickController.Vertical != 0)
        {
            _tank.Rotate();
        }

        if (_tank._opportunityToShoot == false && Map.isStart == true)
        {
            screensaver.SetActive(true);
        }
        else
        {
            screensaver.SetActive(false);
        }
    }

   
}
