using UnityEngine;
using System;
using UnityStandardAssets.Utility;

public class Translate10 : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public float rotationSpeed = 1.0f;
    public float accuracy = .01f;

    private Transform goal;
    private Vector3 direction;
    private Quaternion goalRotation;
    void Start()
    {
        goal = GetComponent<WaypointProgressTracker>().target;
    }

    // Update is called once per frame
    void Update()
    {
        direction = goal.position - transform.position;
        goalRotation = Quaternion.LookRotation(direction);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, goalRotation, rotationSpeed * Time.deltaTime);
            
        if (!(direction.magnitude > accuracy)) 
            return;
        
        transform.Translate(direction.normalized * (movementSpeed * Time.deltaTime), Space.World);
    }
}
