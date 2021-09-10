using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    
    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
