using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private GameObject Barrel;

    private float _health;
    public float speed;
    private float _rangeofshots;
    private float _timeReload = 5;
    public bool _opportunityToShoot = true;
    private float _currentTime = 0;

    private Rigidbody _tankRB;

    public void init(float health, float speed, float damage, float rangeofshots, float speedReload)
    {
        _health = health;
        this.speed = speed;
        _rangeofshots = rangeofshots;
        _timeReload = speedReload;
        _tankRB = GetComponent<Rigidbody>();
    }

    public void Fier()
    {
        if (_opportunityToShoot == true)
        {
            
            Vector3 positionSpawnProjectile = Barrel.transform.position;
            Quaternion rotationProjectile = Barrel.transform.rotation;
            GameObject createdProjectile = Instantiate(_projectilePrefab, positionSpawnProjectile, rotationProjectile);
            createdProjectile.GetComponent<Projectile>().init(2,2,2);

            createdProjectile.GetComponent<Projectile>().Move();
            _currentTime = 0;
            //Destroy(createdProjectile,2);
        }
    }

    public void Move(float horizontal, float vertical)
    {
        _tankRB.velocity = new Vector3(horizontal * speed, _tankRB.velocity.y, vertical * speed);
    }


    IEnumerator Reload()
    {
        while(true) 
        {
                _currentTime++;
                Debug.Log("_opportunityToShoot: " + (_opportunityToShoot) + (_currentTime));
                if (_currentTime >= _timeReload)
                {
                    _opportunityToShoot = true;
                    
                }
                else
                {
                    _opportunityToShoot = false;
                }

                yield return new WaitForSeconds(1);
        }
        // ReSharper disable once IteratorNeverReturns
    }

    private void Start()
    {
        StartCoroutine(Reload());
        _tankRB = GetComponent<Rigidbody>();
    }
}