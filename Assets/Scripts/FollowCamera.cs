using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask maskObstacles;

    private Vector3 position;

    private void Start()
    {
        position = target.InverseTransformPoint(transform.position);
    }

    void Update()
    {
        Vector3 currentPositions = target.TransformPoint(position);
        transform.position = Vector3.Lerp(transform.position, currentPositions, speed * Time.deltaTime);
        var currentRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, currentRotation, speed * Time.deltaTime);
        
        RaycastHit hit;
        if (Physics.Raycast(target.position, transform.position - target.position, out hit, Vector3.Distance(transform.position, target.position), maskObstacles))
        {
            transform.position = hit.point;
            transform.LookAt(target);
        }
    }
}
