using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] SnelheidsMeter snelheid;
    [SerializeField] private float speed;
     private float maxSpeed = 260f;
     [SerializeField] private float turnSpeed;
    [SerializeField] public bool canMove = true;
    private bool isMoving;

  private float force = 1f;
  private int active = 0;

  private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        TurnCar();

        if(snelheid.speed >= 0.01f)
        {
            isMoving = true;
        }
        else isMoving = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Turn();
        
    }

    void Move ()
    {
      
        Vector3 Velocity = transform.InverseTransformDirection(rb.velocity);
        Velocity = new Vector3(0, Velocity.y, Velocity.z);
        rb.velocity = new Vector3(transform.TransformDirection(Velocity).x, rb.velocity.y, transform.TransformDirection(Velocity).z);
        
        if (Input.GetKey(KeyCode.W) && canMove && isgrounded() && KevinGameManager.instance.countdown <= 0)
        {
            Vector3 forceToAdd = transform.forward;
            forceToAdd.y = 0;
            if(snelheid.speed <= 180f)
            {
             rb.AddForce(forceToAdd * speed);
            }
        }
        else if (Input.GetKey(KeyCode.S) && canMove && isgrounded() && KevinGameManager.instance.countdown <= 0)
        {
            Vector3 forceToAdd = -transform.forward;
            forceToAdd.y = 0;
            rb.AddForce(forceToAdd * speed);
        }

    }

    void Turn ()
    {
        if (Input.GetKey(KeyCode.A) && canMove && isgrounded() && KevinGameManager.instance.countdown <= 0 && isMoving)
        {
            rb.AddTorque(-Vector3.up * turnSpeed);
            
        }
        else if (Input.GetKey(KeyCode.D) && canMove && isgrounded() && KevinGameManager.instance.countdown <= 0 && isMoving)
        {
            rb.AddTorque(Vector3.up * turnSpeed);
        }
    }
    bool isgrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1f);
    }

    void TurnCar()
    {
        Vector3 t = transform.rotation.eulerAngles;
        if(Input.GetKey(KeyCode.R))
        {
            t.x = 0.0f;
            t.z = 0.0f;
            transform.rotation = Quaternion.Euler(t);
        }
    }
}