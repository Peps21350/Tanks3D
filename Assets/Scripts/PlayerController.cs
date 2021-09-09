using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private JoystickController joystickController;
    [SerializeField] private PlayerTank playerTank;
    [SerializeField] private GameObject screensaver;
    
    private void FixedUpdate()
    {
        playerTank.Move(joystickController.Horizontal,joystickController.Vertical);
        if (joystickController.Horizontal != 0  && joystickController.Vertical != 0)
        {
            playerTank.Rotate();
        }
        if (playerTank.opportunityToShoot == false)
        {
            screensaver.SetActive(true);
        }
        else
        {
            screensaver.SetActive(false);
        }
    }
}
