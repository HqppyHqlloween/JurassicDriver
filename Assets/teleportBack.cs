using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleportBack : MonoBehaviour
{
     [SerializeField] private Transform _target;
    [SerializeField] private List<GameObject> Car;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
    }

    void OnTriggerEnter(Collider collision)
    {
         foreach (GameObject target in Car)
        {
            if(target.activeSelf == true)
            {
                target.transform.position = _target.position;
            }
        }
    }
}
