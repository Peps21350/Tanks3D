using System.Collections;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using Random = UnityEngine.Random;


public class Tank : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected GameObject barrel;
    [SerializeField] protected Bonus bonus;
    [SerializeField] protected GameGUI gameGUI;
    [SerializeField] protected float speed;
    [SerializeField] protected float timeReload;
    [SerializeField] protected bool isEnemy = true;
    [SerializeField] protected float flightDistanceProjectile;
    
    [SerializeField] private float currentTime = 0;
    
    public bool opportunityToShoot = false;
    
    public void Init(float speed, float speedReload)
    {
        this.speed = speed;
        timeReload = speedReload;
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bonus"))
        {
            if (other.gameObject.GetComponent<Bonus>().typeBonus == TypeBonus.ReductionRecharging)
            {
                Destroy(other.gameObject);
                timeReload--;
            }
            else
            {
                Destroy(other.gameObject);
                flightDistanceProjectile += 0.4f;
            }
        }

        if (other.gameObject.CompareTag("Projectile"))
        {
            if (other.gameObject.GetComponent<Projectile>().isProjectileEnemi != isEnemy)
            {
                Destroy(gameObject);
                MobsSpawn.AliveTanks--;
                Destroy(other.gameObject);
                Vector3 position = gameObject.transform.position;
                int numberBonus = Random.Range(0, 2);
                bonus.CreatingBonus(position, numberBonus);
                if (MobsSpawn.AliveTanks == 0)
                {
                    GameMechanic.PlayerWin = true;
                    gameGUI.DisplayEndMenu();
                }
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }


    public void Fire(bool isEnemi)
    {
        if (opportunityToShoot && projectilePrefab != null)
        {
            Vector3 positionSpawnProjectile = barrel.transform.position;
            Quaternion rotationProjectile = barrel.transform.rotation;
            GameObject createdProjectile = Instantiate(projectilePrefab, positionSpawnProjectile, rotationProjectile);
            var componentProjectile = createdProjectile.GetComponent<Projectile>();
            createdProjectile.transform.rotation = transform.rotation;
            componentProjectile.Init(flightDistanceProjectile, 1, 1, gameObject, isEnemi);
            //componentProjectile.Move();
            currentTime = 0;
            opportunityToShoot = false;
        }
    }

    protected IEnumerator Reload()
    {
        while (true)
        {
            currentTime++;
            Debug.Log("_opportunityToShoot: " + (opportunityToShoot) + (currentTime));
            if (currentTime >= timeReload)
            {
                opportunityToShoot = true;
            }
            yield return new WaitForSeconds(1);
        }
        // ReSharper disable once IteratorNeverReturns
    }
    
}