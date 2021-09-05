using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
        public float _flightRange;
        public float _speed;
        public float _damage;
        private Vector3 _spawnPosition;

        public void init (float flightRange, float speed, float damage)
        {
                _flightRange = flightRange;
                _speed = speed;
                _damage = damage;
        }

        private void OnCollisionEnter(Collision other)
        {
                if (other.gameObject.CompareTag("Destructible"))
                {
                        Destroy(other.gameObject);
                }
        }

        private void FixedUpdate()
        {
                Vector3 currentPosition = transform.position;
                if (currentPosition - _spawnPosition + new Vector3(_flightRange, 0, _flightRange) ==
                    new Vector3(0, currentPosition.y, 0))
                {
                        Destroy(this);
                }
        }

        public void Move()
        {
                Rigidbody rbProjectile = this.GetComponent<Rigidbody>();
                rbProjectile.AddForce(this.transform.forward * _speed, ForceMode.Impulse);
        }
}