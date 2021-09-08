using UnityEngine;
using UnityEngine.AI;

public class HunterTank : Tank
{
    [SerializeField] private GameObject target;
    private Transform targetPosition;
    public float seeDistance = 5f;
    public float attackDistance = 2f;
    [SerializeField] private NavMeshAgent _navMeshAgent;
   
    
    // public  void Move()
    // {
    //         _tankRB.transform.position += new Vector3(); 
    // }

    private void Awake()
    {
        _tankRB = gameObject.GetComponent<Rigidbody>();
    }

    // public void RotateHunterTank()
    // {
    //     _tankRB.transform.rotation =  Quaternion.Euler(0f,50f,0f);
    // }

    protected override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);

        // if (other.collider.CompareTag("Indestructible"))
        // {
        //     RotateHunterTank();
        // }

        if (other.collider.CompareTag("Destructible"))
        {
            Fier(isEnemi);
        }

    }

    


    void Start ()
    {      
        
        _navMeshAgent.speed = speed;
    }
   
    void Update ()
    {
        targetPosition = target.transform;
        var position = targetPosition.position;
        if (Vector3.Distance (transform.position, targetPosition.transform.position) < seeDistance) 
        {
            if (Vector3.Distance (transform.position, targetPosition.transform.position) > attackDistance) 
            {
                transform.LookAt (targetPosition.transform);
                
                //Vector3 direction = position - transform.position;
                //Quaternion rotation = Quaternion.LookRotation(direction);
                //transform.rotation = Quaternion.Lerp(transform.rotation,rotation,speed * Time.deltaTime);
                _navMeshAgent.destination = position;
            } 
            else 
            {
                _navMeshAgent.speed = 0;
                transform.LookAt (targetPosition.transform);
                if (_opportunityToShoot == true)
                {
                    Fier(isEnemi);
                }
            }
        }
        else
        {
            _navMeshAgent.destination = position;
        }
    }
}