using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bonus : MonoBehaviour
{
    public TypeBonus TypeBonus;
    private const float speedRotationBonus = 0.3f;
    private static Map _map;
    [SerializeField] private GameObject[] prefabsBonus;
    private GameObject createdBonus;

    private void RotateBonus()
    {
        if(createdBonus != null)
            createdBonus.transform.rotation = new Quaternion(0f, speedRotationBonus * Time.deltaTime, 0f, 0f);
    }
    
    public void CreatingBonus(Vector3 coord, int typeBonus)
    {
        if(typeBonus == 0)
            createdBonus = Instantiate(prefabsBonus[typeBonus], new Vector3(coord.x,0.07f,coord.z), Quaternion.identity);
        else
            createdBonus = Instantiate(prefabsBonus[typeBonus], new Vector3(coord.x,0.07f,coord.z), Quaternion.identity);
        RotateBonus();
    }

    private void Update()
    {
        RotateBonus();
    }
}

public enum TypeBonus
{
    ReductionRecharging,
    IncreasingRangeShot
}