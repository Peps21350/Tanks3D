using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    //[SerializeField] private float speed;
    //[SerializeField] private LayerMask maskObstacles;
    
    [SerializeField] private Vector3 offset;

    //private Vector3 position;

    private void Start()
    {
        //position = target.InverseTransformPoint(transform.position);
    }

    void Update()
    {
        transform.position = target.position + offset;
        //Vector3 currentPositions = target.TransformPoint(position) + new Vector3(0f,0f,1f);
        //transform.position = Vector3.Lerp(transform.position, currentPositions, speed * Time.deltaTime);
        //var currentRotation = Quaternion.LookRotation(target.position - transform.position);
        //transform.rotation = Quaternion.Lerp(transform.rotation, currentRotation, speed * Time.deltaTime);
        
        // RaycastHit hit;
        // if (Physics.Raycast(target.position, transform.position - target.position, out hit, Vector3.Distance(transform.position, target.position), maskObstacles))
        // {
        //     transform.position = hit.point;
        //     transform.LookAt(target);
        // }
    }
}
