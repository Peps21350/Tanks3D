using UnityEngine;
using Random = UnityEngine.Random;

public class MobsSpawn : MonoBehaviour
{
    [SerializeField] private Map _map;
    [SerializeField] private GameObject[] _tanksPrefabs;
    [SerializeField] private HunterTank _hunterTank;
    [SerializeField] private OrdinaryEnemiTank _ordinaryEnemiTank;
    [SerializeField] private int countTanks = 8;
    public static int aliveTanks;


    private void Spawn()
    {
        for (int i = 0; i < countTanks; i++)
        {
            int randPositionX = Random.Range(Map.AmountCellWhereDontSpawnObstacles, _map.heightMap - 10);
            int randPositionZ = Random.Range(Map.AmountCellWhereDontSpawnObstacles, _map.widthMap - 10);
            Vector3 positionTank = new Vector3(randPositionX, 0.07f, randPositionZ);
            if (_map.CheсkCoordWithList(randPositionX, randPositionZ) == true)
            {
                if (i % 2 == 0)
                {
                    GameObject createdHunterTank = Instantiate(_tanksPrefabs[0], positionTank,Quaternion.identity);
                    _ordinaryEnemiTank.init(1,5);
                    //createdHunterTank.transform.SetParent(_map.transform);
                    
                    
                }

                else
                {
                    GameObject createdOrdinaryEnemyTank= Instantiate(_tanksPrefabs[1], positionTank,Quaternion.identity);
                    _hunterTank.init(0.5f, 7);
                    //createdOrdinaryEnemyTank.transform.SetParent(_map.transform);
                }
            }
        }
        //Vector3 positionPlayerTank = new Vector3(2, 0.07f, 1);
       // GameObject playerTank = Instantiate(_tanksPrefabs[2], positionPlayerTank,Quaternion.identity);
        //playerTank.transform.parent = _map.transform;
    }

    private void Start()
    {
        Spawn();
        aliveTanks = countTanks;
    }
}