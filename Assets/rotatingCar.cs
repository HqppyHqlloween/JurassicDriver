using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingCar : MonoBehaviour
{
    [SerializeField] Vector3 rotation;   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.Rotate(rotation * Time.deltaTime);
    }
}
