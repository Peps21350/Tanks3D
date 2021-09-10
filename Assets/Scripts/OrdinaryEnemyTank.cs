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
        private const int _RadiusWayPoint = 10;
        
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
                CreatingTargetPosition();
                _player = GameObject.FindWithTag("Player");
                StartCoroutine(Reload());
        }

        private void CreatingTargetPosition()
        {
                while (true)
                {
                        int randPositionX = Random.Range(1, map.heightMap - 1);
                        int randPositionZ = Random.Range(1, map.widthMap - 1);
                        if (map.CheсkCoordWithList(randPositionX, randPositionZ))
                        {
                                wayPoint = new Vector3(randPositionX, 0f, randPositionX);
                        }
                        else
                        {
                                continue;
                        }

                        break;
                }
        }
        
        private void Update()
        {
                if (gameObject != null && _player != null)
                {
                        if (navMeshAgent.isOnNavMesh)
                        {
                                Fire(isEnemy);
                                Vector3 playerPosition = _player.transform.position;
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
                                        navMeshAgent.destination = wayPoint;
                                        if (Vector3.Distance(transform.position, wayPoint) < _RadiusWayPoint)
                                        {
                                                CreatingTargetPosition();
                                        }
                                        Fire(isEnemy);
                                } 
                        }
                        else
                        {
                                gameObject.transform.position += new Vector3(0f, 0f, 0.5f);
                        }
                        
                }
        }
}

