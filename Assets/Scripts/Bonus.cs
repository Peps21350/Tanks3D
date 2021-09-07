using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bonus : MonoBehaviour
{
    public TypeBonus TypeBonus;
    private const float speedRotationBonus = 0.3f;
    private static Map _map;
    [SerializeField] private GameObject[] prefabsBonus;

    private void Rotate()
    {
        transform.rotation = new Quaternion(0f, 0f, speedRotationBonus * Time.deltaTime, 0f);
    }


    public static void CreatingBonus(Vector3 coord, int typeBonus)
    {
        // int randPositionX = Random.Range(Map.AmountCellWhereDontSpawnObstacles, _map.heightMap - 10);
        // int randPositionZ = Random.Range(Map.AmountCellWhereDontSpawnObstacles, _map.widthMap - 10);
    }

    private void Update()
    {
        Rotate();
    }
}

public enum TypeBonus
{
    ReductionRecharging,
    IncreasingRangeShot
}