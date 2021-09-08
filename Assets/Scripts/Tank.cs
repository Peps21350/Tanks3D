using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class Tank : MonoBehaviour
{
    [SerializeField] protected GameObject _projectilePrefab;
    [SerializeField] protected GameObject Barrel;
    [SerializeField] protected Bonus _bonus;
    [SerializeField] protected GameGUI _gameGUI;
    
    [SerializeField] protected float speed;
    [SerializeField] protected float _timeReload;
    public bool _opportunityToShoot = false;
    [SerializeField] private  float _currentTime = 0;
    [SerializeField] protected bool isEnemi = true;
    protected Rigidbody _tankRB;

    public void init( float speed, float speedReload)
    {
        this.speed = speed;
        _timeReload = speedReload;
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bonus"))
        {
            if (other.gameObject.GetComponent<Bonus>().TypeBonus == TypeBonus.ReductionRecharging)
            {
                Destroy(other.gameObject);
                _timeReload--;
            }
            else
            {
                Destroy(other.gameObject);
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
                Vector3 position = gameObject.transform.position;
                int numberBonus = Random.Range(0, 2);
                _bonus.CreatingBonus(position,numberBonus);
                if (MobsSpawn.aliveTanks == 0)
                {
                    GameMechanic.playerWin = true;
                    _gameGUI.DisplayENDMenu();
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
        if (_opportunityToShoot == true && _projectilePrefab != null)
        {
            Vector3 positionSpawnProjectile = Barrel.transform.position;
            Quaternion rotationProjectile = Barrel.transform.rotation;
            GameObject createdProjectile = Instantiate(_projectilePrefab, positionSpawnProjectile, rotationProjectile);
            createdProjectile.GetComponent<Projectile>().init(2f,1,1,gameObject, isEnemi);
            createdProjectile.GetComponent<Projectile>().Move();
            _currentTime = 0;
        }
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