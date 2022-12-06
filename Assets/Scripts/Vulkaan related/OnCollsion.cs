using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollsion : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 15.7f, transform.position.z);
    }
    void Update()
    {
        StartCoroutine(removeObject());
    }
    IEnumerator removeObject()
    {
        yield return new WaitForSeconds(15f);
        Destroy(this.gameObject);
    }
}
