using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballPoiint : MonoBehaviour
{
    [SerializeField] private GameObject fireball;
    bool one = false;
    [SerializeField] private GameObject fireball2;
    bool two = false;
    [SerializeField] private GameObject fireball3;
    bool three = false;

    [SerializeField] private float Timer = 0f;
    [SerializeField] private float waitTime = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
         if (other.tag == "Player" && one == false)
        {
            fireball.SetActive(true);
            Timer += Time.deltaTime;
            one = true;
        }
        if (other.tag == "Player" && Timer >= 0.1 &&  one == true && two == false)
        {
            fireball2.SetActive(true);
            two = true;
        }
        if (other.tag == "Player" && Timer >= 0.2 && three == false && two == true)
        {
         fireball3.SetActive(true);
         three = true;

        }
    }
    void OnTriggerExit(Collider collider)
    {
        Timer += Time.deltaTime;
    }
}
