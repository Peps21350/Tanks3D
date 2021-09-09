using UnityEngine;

public class PlayerTank : Tank
{
    public virtual void Move(float horizontal, float vertical)
    {
        if(_tankRB != null)
            _tankRB.velocity = new Vector3(horizontal * speed, _tankRB.velocity.y, vertical * speed);
        
    }
    public void Rotate()
    {
        _tankRB.rotation = Quaternion.LookRotation(_tankRB.velocity  * Time.fixedTime);
    }
}