using UnityEngine;

public class PlayerTank : Tank
{
    [SerializeField] private Rigidbody _tankRB;
    public static bool isAlive = true;

    public virtual void Move(float horizontal, float vertical)
    {
        if (_tankRB != null)
            _tankRB.velocity = new Vector3(horizontal * speed, _tankRB.velocity.y, vertical * speed);

    }

    public void Rotate()
    {
        _tankRB.rotation = Quaternion.LookRotation(_tankRB.velocity * Time.fixedTime);
    }

    private void Start()
    {
        StartCoroutine(Reload());
        isAlive = true;
    }
}
    