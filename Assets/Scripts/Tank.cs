using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private GameObject Barrel;
    
    [SerializeField] private float speed;
    [SerializeField] private float _timeReload = 5;
    public bool _opportunityToShoot = true;
    private float _currentTime = 0;
    [SerializeField] private bool isEnemi = true;

    private Rigidbody _tankRB;

    public void init( float speed, float speedReload)
    {
        this.speed = speed;
        _timeReload = speedReload;
        _tankRB = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bonus"))
        {
            if (other.gameObject.GetComponent<Bonus>().TypeBonus == TypeBonus.ReductionRecharging)
            {
                _timeReload--;
            }
            else
            {
                _projectilePrefab.GetComponent<Projectile>()._flightRange++;
            }
        }

        if (other.gameObject.CompareTag("Projectile"))
        {
            if (other.gameObject.GetComponent<Projectile>().isProjectileEnemi != isEnemi)
            {
                Destroy(gameObject);
                MobsSpawn.aliveTanks--;
                Destroy(other.gameObject);
                if (MobsSpawn.aliveTanks == 0)
                {
                    GameMechanic.playerWin = true;
                    //GameGUI

                }
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
        
    }
    
    

    public void Fier(bool isEnemi)
    {
        if (_opportunityToShoot == true)
        {
            
            Vector3 positionSpawnProjectile = Barrel.transform.position;
            Quaternion rotationProjectile = Barrel.transform.rotation;
            GameObject createdProjectile = Instantiate(_projectilePrefab, positionSpawnProjectile, rotationProjectile);
            createdProjectile.GetComponent<Projectile>().init(2f,1,1,gameObject, isEnemi);

            createdProjectile.GetComponent<Projectile>().Move();
            _currentTime = 0;
            //Destroy(createdProjectile,2);
        }
    }

    public void Move(float horizontal, float vertical)
    {
        if(_tankRB != null)
            _tankRB.velocity = new Vector3(horizontal * speed, _tankRB.velocity.y, vertical * speed);
        
    }

    public void Rotate()
    {
        _tankRB.rotation = Quaternion.LookRotation(_tankRB.velocity  * Time.fixedTime) ;
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