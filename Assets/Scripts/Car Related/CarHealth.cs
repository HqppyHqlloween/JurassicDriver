using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarHealth : Explosion
{
    [SerializeField] Movement movement;
    //[SerializeField] private AudioSource carCrashedAudio;
    //[SerializeField] private AudioSource explodedcar;
    [SerializeField] SnelheidsMeter snelheid;
    [SerializeField] private ParticleSystem fireSparkles;
    [SerializeField] private ParticleSystem Explosion;
    [SerializeField] private bool isCrashed = false;
    [SerializeField] private bool isCrashed2 = false;
    [SerializeField] public bool isCrashed3 = false;   

    void Start()
    {
       // carCrashedAudio = GetComponent<AudioSource>();
        fireSparkles.GetComponent<ParticleSystem>();
    }
    
    void OnCollisionEnter(Collision collision)
    {

        if(KevinGameManager.instance.car.hasGodmode)
        {
            return;
        } else
        {

        

         if(collision.gameObject.CompareTag("Wall") && snelheid.speed >= 25 && isCrashed == false)
        {
         //   carCrashedAudio.Play();
            isCrashed = true;
            return;
        }
         if(collision.gameObject.CompareTag("Wall") && snelheid.speed >= 25 && isCrashed == true && isCrashed2 == false)
        {
          //  carCrashedAudio.Play();
            isCrashed2 = true;
            fireSparkles.Play();
            return;
        }
         if(collision.gameObject.CompareTag("Wall") && snelheid.speed >= 25 && isCrashed == true && isCrashed2 == true && isCrashed3 == false)
        {
           //explodedcar.Play();
           StartCoroutine(die());
            return;
        }

        if(collision.gameObject.CompareTag("Water"))
        {
            StartCoroutine(die());
            return;
        }
        }
}


    void OnTriggerEnter(Collider collider)
    {
          if(KevinGameManager.instance.car.hasGodmode)
        {
            return;
        } else
        {

         if(collider.gameObject.CompareTag("Lava"))
        {
            fireSparkles.Play();
        }
    }
    }

    private IEnumerator die()
    {
        isCrashed3 = true;
         Explosion.Play();
          movement.canMove = false;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);

    }
    
}
