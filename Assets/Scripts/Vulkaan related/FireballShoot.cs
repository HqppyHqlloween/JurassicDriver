using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballShoot : MonoBehaviour
{
    [SerializeField] private float Height = 10f;
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject lavaPitSpawnPoint;
    [SerializeField] private GameObject lavaPit;
    protected float Animation;

    // Update is called once per frame
    void Update()
    {
        Animation += Time.deltaTime;

        Animation = Animation % 5f;

        transform.position = MathParabola.Parabola(new Vector3(211.17f, 68.88f, 254.42f), _target.transform.position, Height, Animation / 5f);
    }

        void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Floor")
        {
            Instantiate(lavaPit, lavaPitSpawnPoint.transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
