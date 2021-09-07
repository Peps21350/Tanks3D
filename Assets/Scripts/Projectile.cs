using System;
using System.Collections.Generic;
using UnityEngine;
using static ExtendingVector3;
using Random = UnityEngine.Random;

public class Projectile : MonoBehaviour
{
        public float _flightRange;
        public float _speed;
        public float _damage;
        private Vector3 _spawnPosition;
        public GameObject _tank;
        public static int destroyedObject;
        public bool isProjectileEnemi = true;
        

        public void init (float flightRange, float speed, float damage, GameObject tank, bool isProjectileEnemi)
        {
                _flightRange = flightRange;
                _speed = speed;
                _damage = damage;
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
                                int randBonus = Random.Range(0, 2);
                                Bonus.CreatingBonus(other.gameObject.transform.position,randBonus);
                        }

                        Destroy(gameObject);
                }
                if (other.gameObject.CompareTag("Indestructible"))
                {
                        Destroy(gameObject);
                }
                if (other.gameObject.CompareTag("Enemi"))
                {
                        
                        Destroy(other.gameObject);
                        int randBonus = Random.Range(0, 2);
                        Bonus.CreatingBonus(other.gameObject.transform.position,randBonus);
                        destroyedObject++;
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