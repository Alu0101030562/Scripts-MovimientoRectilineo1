using UnityEngine;

public class Translate2 : MonoBehaviour
{
    public Vector3 goal;
    public float speed = 0.1f;

    void Update()
    {
      transform.Translate(goal.normalized *(speed * Time.deltaTime));
      goal = goal * 0.5f;
    }
}
