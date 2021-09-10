using UnityEngine;
using UnityEngine.AI;

public class HunterTank : Tank
{
    public float seeDistance = 5f;
    public float attackDistance = 2f;
    
    [SerializeField] private NavMeshAgent navMeshAgent;
    private Transform _targetPosition;
    private GameObject _player;
    
    protected override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
        if (other.collider.CompareTag("Destructible"))
        {
            Fire(isEnemy);
        }
    }
    
    private void Start ()
    {
        navMeshAgent.speed = speed;
        _player = GameObject.FindWithTag("Player");
        StartCoroutine(Reload());
    }
   
    private void Update ()
    {
        if (gameObject != null && _player != null)
        {
            Vector3 playerPosition = _player.transform.position;
            Fire(isEnemy);
            if (Vector3.Distance (transform.position, playerPosition) < seeDistance) 
            {
                if (Vector3.Distance (transform.position, playerPosition) > attackDistance) 
                {
                    transform.LookAt (playerPosition);
                    navMeshAgent.destination = playerPosition;
                } 
                else 
                {
                    navMeshAgent.speed = 0;
                    transform.LookAt (playerPosition);
                    Fire(isEnemy);
                }
            }
            else
            {
                navMeshAgent.destination = playerPosition;
                Fire(isEnemy);
            }
        }

    }
}