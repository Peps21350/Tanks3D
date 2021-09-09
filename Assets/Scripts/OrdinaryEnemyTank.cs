using UnityEngine;
using UnityEngine.AI;

public class OrdinaryEnemyTank : Tank
{
        public float seeDistance = 5f;
        public float attackDistance = 2f;
        
        [SerializeField] private Map map;
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private Vector3 wayPoint;
        private GameObject _player; 
        
        protected override void OnCollisionEnter(Collision other)
        {
                base.OnCollisionEnter(other);
                
                if (other.collider.CompareTag("Destructible"))
                {
                        Fire(isEnemy);
                }
        }
        
        void Start ()
        {
                navMeshAgent.speed = speed;
                CreatingTargetPosition();
                _player = GameObject.FindWithTag("Player");
        }

        private void CreatingTargetPosition()
        {
                int randPositionX = Random.Range(1, map.heightMap - 1);
                int randPositionZ = Random.Range(1, map.widthMap - 1);
                if (map.CheсkCoordWithList(randPositionX, randPositionZ))
                {
                        wayPoint = new Vector3(randPositionX, 0f, randPositionX);
                }
                else
                {
                        CreatingTargetPosition();
                }
        }


        private void Update()
        {
                Fire(isEnemy);
                Vector3 playerPosition = _player.transform.position;
                Debug.Log($"{playerPosition} + OrdinaryEnemyTank");
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
                                if (opportunityToShoot)
                                {
                                        Fire(isEnemy);
                                }
                        }
                }
                else
                {
                        navMeshAgent.destination = wayPoint;
                        if (Vector3.Distance(transform.position, wayPoint) < 10)
                        {
                                CreatingTargetPosition();
                        }
                        Fire(isEnemy);
                }
        }
}

