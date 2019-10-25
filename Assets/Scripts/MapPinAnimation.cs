using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPinAnimation : MonoBehaviour
{
    public float spinForce;
    public float temp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, temp * Time.deltaTime, 0);
    }

    public void StartSpinning()
    {
        temp = spinForce;
      
    }

    public void StopSpinning()
    {
       temp = 0;

    }
}
