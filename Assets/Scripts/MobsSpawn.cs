using UnityEngine;
using Random = UnityEngine.Random;

public class MobsSpawn : MonoBehaviour
{
    [SerializeField] private Map map;
    [SerializeField] private GameObject[] tanksPrefabs;
    [SerializeField] private HunterTank hunterTank;
    [SerializeField] private OrdinaryEnemyTank ordinaryEnemyTank;
    private int _countTanks = 5;
    public static int AliveTanks;
    
    private void Spawn(int countTanksToSpawn )
    {
        for (int i = 0; i < countTanksToSpawn; i++)
        {
            int randPositionX = Random.Range(Map.AmountCellWhereDontSpawnObstacles, map.heightMap - 10);
            int randPositionZ = Random.Range(Map.AmountCellWhereDontSpawnObstacles, map.widthMap - 10);
            if (map.CheсkCoordWithList(randPositionX, randPositionZ))
            {
                // float xRandPos = randPositionX * map.xOffset;
                // if (randPositionZ % 2 == 1)
                // {
                //     xRandPos += map.xOffset / 2f;
                // }
                Vector3 positionTank = new Vector3(randPositionX, 0.06f, randPositionZ * map.zOffset);
                if (i % 2 == 0)
                {
                    Instantiate(tanksPrefabs[0], positionTank,Quaternion.identity);
                    ordinaryEnemyTank.Init(1,5);
                }
                else
                {
                    Instantiate(tanksPrefabs[1], positionTank,Quaternion.identity);
                    hunterTank.Init(0.5f, 7);
                }
                _countTanks--;
                AliveTanks++;
                Debug.Log($"{AliveTanks}");
            }
            else
            {
                Spawn(_countTanks);
            }
        }
    }

    private void Awake()
    {
        AliveTanks = 0;
        Spawn(_countTanks);
    }
}