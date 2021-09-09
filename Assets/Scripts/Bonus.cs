using System.Collections;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public TypeBonus typeBonus;
    
    [SerializeField] private GameObject[] prefabsBonus;
    private const float _SpeedRotationBonus = 0.3f;
    private GameObject _createdBonus;
    private float _currentTime = 0;
    private const int _LifeTimeBonus = 10;

    private void RotateBonus()
    {
        if (_createdBonus != null)
        {
            _createdBonus.transform.Rotate(0, 0, 0.09f, Space.Self);
        }
    }
    
    public void CreatingBonus(Vector3 coord, int typeBonus)
    {
        if (typeBonus == 0)
        {
            _createdBonus = Instantiate(prefabsBonus[typeBonus], new Vector3(coord.x,0.07f,coord.z), Quaternion.identity);
        }
        else
        {
            _createdBonus = Instantiate(prefabsBonus[typeBonus], new Vector3(coord.x,0.224f,coord.z), Quaternion.identity);
        }
        //StartCoroutine(Timer());
    }

    private void Update()
    {
        RotateBonus();
        if (_currentTime >= _LifeTimeBonus)
        {
            StopCoroutine(Timer());
            _currentTime = 0;
        }
    }
    
    public IEnumerator Timer()
    {
        while (true)
        {
            _currentTime++;
                        
            yield return new WaitForSeconds(1);
        }
        // ReSharper disable once IteratorNeverReturns
    }
}

public enum TypeBonus
{
    ReductionRecharging,
    IncreasingRangeShot
}