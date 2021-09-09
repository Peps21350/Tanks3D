using UnityEngine;
using Random = UnityEngine.Random;

public class MobsSpawn : MonoBehaviour
{
    [SerializeField] private Map _map;
    [SerializeField] private GameObject[] _tanksPrefabs;
    [SerializeField] private HunterTank _hunterTank;
    [SerializeField] private OrdinaryEnemyTank ordinaryEnemyTank;
    [SerializeField] private int countTanks = 8;
    public static int aliveTanks;

    float xOffset = 0.882f;
    float zOffset = 0.764f;
    
    private void Spawn()
    {
        for (int i = 0; i < countTanks; i++)
        {
            int randPositionX = Random.Range(Map.AmountCellWhereDontSpawnObstacles, _map.heightMap - 10);
            int randPositionZ = Random.Range(Map.AmountCellWhereDontSpawnObstacles, _map.widthMap - 10);

            if (_map.CheсkCoordWithList(randPositionX, randPositionZ))
            {
                float xRandPos = randPositionX * xOffset;
                if (randPositionZ % 2 == 1)
                {
                    xRandPos += xOffset / 2f;
                }
                Vector3 positionTank = new Vector3(xRandPos, 0.06f, randPositionZ * zOffset);
                if (i % 2 == 0)
                {
                    GameObject createdHunterTank = Instantiate(_tanksPrefabs[0], positionTank,Quaternion.identity);
                    ordinaryEnemyTank.init(1,5);
                }

                else
                {
                    GameObject createdOrdinaryEnemyTank= Instantiate(_tanksPrefabs[1], positionTank,Quaternion.identity);
                    _hunterTank.init(0.5f, 7);
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