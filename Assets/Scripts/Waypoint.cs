using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public GameObject circuit;
    public float speed = 3f;
    
    private List<Transform> waypoints;
    private int currentWaypointIndex = 0;
    private Vector3 initialPosition;
    private Renderer previousRenderer;
    
    void Start()
    {
        initialPosition = transform.position;
        
        waypoints = new List<Transform>();

        foreach (Transform waypoint in circuit.transform)
        {
            waypoints.Add(waypoint);
        }
        
        if (waypoints.Count > 0)
        {
            HighlightWaypoint(waypoints[currentWaypointIndex]);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Count == 0)
        {
            return;
        }
        
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            Debug.Log("Llegó a: " + targetWaypoint.name);
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
            HighlightWaypoint(waypoints[currentWaypointIndex]);
        }
    }
    
    private void HighlightWaypoint(Transform waypoint)
    {
        if (previousRenderer != null)
        {
            previousRenderer.material.color = Color.white; 
        }

        Renderer renderer = waypoint.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.red; 
            previousRenderer = renderer;
        }
    }
}
