using System;
using UnityEngine;

public class Translate : MonoBehaviour
{
    public Vector3 goal;
    
    /*void Start()
    { 
      Debug.Log($"Posición del objeto antes de translate {transform.position}"); 
      this.transform.Translate(goal);
      Debug.Log($"Posición del objeto después de translate {transform.position}"); 
    }*/

    private void Update()
    { 
      transform.Translate(goal);
      goal = goal * 0.5f;
    }
}
