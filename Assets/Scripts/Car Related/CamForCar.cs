using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamForCar : MonoBehaviour
{
    [SerializeField] private float smoothing;
    [SerializeField] private float Rotationsmoothing;
    [SerializeField] private List<GameObject> Car;
    // Update is called once per frame

    void Start()
    {
    }
    void Update()
    {
       
    }

    void FixedUpdate()
    {
         foreach (GameObject target in Car)
        {
            if(target.activeSelf == true)
            {
             transform.position = Vector3.Lerp(transform.position, target.transform.position, smoothing);
             transform.rotation = Quaternion.Slerp(transform.rotation, target.transform.rotation, Rotationsmoothing);
            }
            
        }
    }
}
