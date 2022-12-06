using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCars : MonoBehaviour
{
    [SerializeField] private Transform MoveTheCars;
    [SerializeField] public bool hasBought;
    [SerializeField] private BestTimeData car;

    void Start()
    {
   
        car.BestTimeValue = 0;
    }

    void Update()
    { 

    }

    public void onRightclick()
    {
        if(car.BestTimeValue <= 3)
        {
         Vector3 p = MoveTheCars.transform.position;
         p.x -= 27;
         MoveTheCars.transform.position = p;
        car.BestTimeValue += 1;
        }
    }

        public void onLeftClick()
    {
        if(car.BestTimeValue >= 1)
        {
         Vector3 p = MoveTheCars.transform.position;
         p.x += 27;
         MoveTheCars.transform.position = p;
        car.BestTimeValue -= 1;
        }
    }

}
