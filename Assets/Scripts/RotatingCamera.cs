using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCamera : MonoBehaviour
{
    [SerializeField]
    private float xrotate;
    [SerializeField]
    private float yrotate;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(xrotate, yrotate, 0.0f, Space.Self);
    }
}
