using System;
using System.Collections.Generic;
using UnityEngine;
using static ExtendingVector3;
using Random = UnityEngine.Random;

public class Projectile : MonoBehaviour
{
        public float _flightRange;
        public float _speed;
        private Vector3 _spawnPosition;
        public GameObject _tank;
        [SerializeField] private Bonus _bonus;
        public static int destroyedObject;
        public bool isProjectileEnemi = true;
        

        public void init (float flightRange, float speed, float damage, GameObject tank, bool isProjectileEnemi)
        {
                _flightRange = flightRange;
                _speed = speed;
                _tank = tank;
                this.isProjectileEnemi = isProjectileEnemi;
        }

        private void OnCollisionEnter(Collision other)
        {
                if (other.gameObject.CompareTag("Destructible"))
                {
                        Destroy(other.gameObject);
                        destroyedObject++;
                        if (destroyedObject % 2 == 0)
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
        }

        private void FixedUpdate()
        {
                Vector3 currentPosition = transform.position;
                if ( IsGreaterOrEqual(currentPosition,  _tank.transform.position + new Vector3(_flightRange, 0, _flightRange)) == true)
                {
                        Destroy(gameObject);
                }
        }
        

        public void Move()
        {
                Rigidbody rbProjectile = this.GetComponent<Rigidbody>();
                rbProjectile.AddForce(this.transform.forward * _speed, ForceMode.Impulse);
        }
        
       
}

public static class ExtendingVector3
{
        public static bool IsGreaterOrEqual(Vector3 local, Vector3 other)
        {
                if(local.x >= other.x ||  local.z >= other.z)
                {
                        return true;
                }
                else
                {
                        return false;
                }
        }

        public static bool IsLesserOrEqual(Vector3 local, Vector3 other)
        {
                if(local.x <= other.x || local.z <= other.z)
                {
                        return true;
                }
                else
                {
                        return false;
                }
        }
}