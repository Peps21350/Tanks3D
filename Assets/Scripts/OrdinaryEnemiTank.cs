using UnityEngine;
using UnityEngine.AI;

public class OrdinaryEnemiTank : Tank
{
        private Vector3 targetPosition;
        [SerializeField] private PlayerTank _playerTank;
        [SerializeField] private Map _map;
        public float seeDistance = 5f;
        public float attackDistance = 2f;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        
        
        protected override void OnCollisionEnter(Collision other)
        {
                base.OnCollisionEnter(other);
                
                if (other.collider.CompareTag("Destructible"))
                {
                        Fier(isEnemi);
                }
        }
        
        void Start ()
        {
                _navMeshAgent.speed = speed;
        }

        private void CreatingTargetPosition()
        {
                int randPositionX = Random.Range(1, _map.heightMap - 1);
                int randPositionZ = Random.Range(1, _map.widthMap - 1);
                if (_map.CheсkCoordWithList(randPositionX, randPositionZ))
                {
                        targetPosition = new Vector3(randPositionX, 0.07f, randPositionX);
                }
        }


        private void Update()
        {
                Vector3 playerCoord = _playerTank.transform.position;
                if (Vector3.Distance (transform.position, playerCoord) < seeDistance) 
                {
                        if (Vector3.Distance (transform.position, playerCoord) > attackDistance) 
                        {
                                transform.LookAt (targetPosition);
                                _navMeshAgent.destination = targetPosition;
                        } 
                        else 
                        {
                                _navMeshAgent.speed = 0;
                                transform.LookAt (playerCoord);
                                if (_opportunityToShoot == true)
                                {
                                        Fier(isEnemi);
                                }
                        }
                }
                else
                {
                        _navMeshAgent.destination = targetPosition;
                }
        }
}

