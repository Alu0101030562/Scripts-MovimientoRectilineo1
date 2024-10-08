using UnityEngine;

public class Translate5 : MonoBehaviour
{
    public Transform goal;
    public float speed = 1.0f;
    public float speedIncreaser = 1.5f;
    
    private Vector3 direction;
    
    void Start()
    {
      transform.LookAt(goal);  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = speed + speedIncreaser;
            Debug.Log(($"Velocidad aumentada a {speed}"));
        }
        
        transform.LookAt(goal);
        direction = goal.position - transform.position;
        transform.Translate(direction.normalized * (speed * Time.deltaTime), Space.World);
        
        Debug.DrawRay(transform.position, direction, Color.red);
    }
}
