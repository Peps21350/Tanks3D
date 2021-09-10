using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Projectile : MonoBehaviour
{
        public GameObject tank;
        public float flightRange;
        public float speed;
        public bool isProjectileEnemi = true;

        [SerializeField] private GameGUI gameGUI;
        [SerializeField] private Bonus _bonus;
        private static int s_destroyedObject;
        private Vector3 _spawnPosition;

        public void Init (float flightRange, float speed, float damage, GameObject tank, bool isProjectileEnemi)
        {
                this.flightRange = flightRange;
                this.speed = speed;
                this.tank = tank;
                this.isProjectileEnemi = isProjectileEnemi;
        }

        private void OnCollisionEnter(Collision other)
        {
                if (other.gameObject.CompareTag("Destructible"))
                {
                        Destroy(other.gameObject);
                        s_destroyedObject++;
                        if (s_destroyedObject % 2 == 0)
                        {
                                int numberBonus = Random.Range(0, 2);
                                Vector3 position = other.gameObject.transform.position;
                                _bonus.CreatingBonus(position,numberBonus);
                        }
                        Destroy(gameObject);
                }
                if (other.gameObject.CompareTag("Indestructible"))
                {
                        Destroy(gameObject);
                }
                if (other.gameObject.CompareTag("Projectile"))
                {
                        Destroy(other.gameObject);
                        Destroy(gameObject);
                }

                if (other.gameObject.CompareTag("Enemy"))
                {
                        GameMechanic.DestroyedEnemy++;
                }

                if (other.gameObject.CompareTag("Player"))
                {
                        gameGUI.DisplayEndGame();
                        PlayerTank.isAlive = false;
                        Destroy(gameObject);
                        Destroy(other.gameObject);
                }
        }

        private void FixedUpdate()
        {
                transform.Translate( Vector3.forward * speed * Time.fixedDeltaTime);
                Vector3 currentPosition = transform.position;
                if (gameObject != null && tank.gameObject != null)
                {
                        if( Vector3.Distance(currentPosition, tank.transform.position) >= flightRange)
                        {
                                Destroy(gameObject);
                        }
                }
        }
}
