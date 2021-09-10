using UnityEngine;

public class Bonus : MonoBehaviour
{
    public TypeBonus typeBonus;
    
    [SerializeField] private GameObject[] prefabsBonus;
    private float _timeRemaining = 10;
    private static bool _timerIsRunning = false;
    
    public void CreatingBonus(Vector3 coord, int typeBonus)
    {
        if (typeBonus == 0)
        {
            Instantiate(prefabsBonus[typeBonus], new Vector3(coord.x,0.07f,coord.z), Quaternion.identity);
        }
        else
        {
            Instantiate(prefabsBonus[typeBonus], new Vector3(coord.x,0.224f,coord.z), Quaternion.identity);
        }
        _timerIsRunning = true;
    }

    private void Update()
    {
        if (_timerIsRunning)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
                _timerIsRunning = false;
            }
        }
    }
}

public enum TypeBonus
{
    ReductionRecharging,
    IncreasingRangeShot
}