using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Laptime : MonoBehaviour
{
    private bool isActive;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            KevinGameManager.instance.startTime = true;

            if (KevinGameManager.instance.checkpoint == true && KevinGameManager.instance.cantCheat == false)
            {
                if (isActive == true)
                {
                    return;
                }

                StartCoroutine(enterTrigger());
                
            } 
            else if (KevinGameManager.instance.checkpoint == false && KevinGameManager.instance.cantCheat == true)
            {
               KevinGameManager.instance.SwitchSceneNoLaps(8);
            }

        }
    }

    private IEnumerator enterTrigger()
    {
        isActive = true;

        yield return new WaitForSeconds(0.2f);



        if (KevinGameManager.instance.laps == KevinGameManager.instance.lapsNeeded)
        {
            Debug.Log("create text");
            KevinGameManager.instance.CreateText();
            KevinGameManager.instance.totalTimeData.BestTimeValue = KevinGameManager.instance.totalTime;

            
            if (KevinGameManager.instance.bestTimeData1.BestTimeValue >= KevinGameManager.instance.totalTime || KevinGameManager.instance.bestTimeData1.BestTimeValue <= 0.5)
            {
                Debug.Log("new best time");
                KevinGameManager.instance.bestTimeData1.BestTimeValue = KevinGameManager.instance.totalTime;

            }

            if (KevinGameManager.instance.bestTimeData2.BestTimeValue <= 0.5f && KevinGameManager.instance.totalTime >= 1)
            {
                Debug.Log("time 1");
                KevinGameManager.instance.bestTimeData2.BestTimeValue = KevinGameManager.instance.totalTime;
                KevinGameManager.instance.totalTime = 0;
                
            }
            if (KevinGameManager.instance.bestTimeData3.BestTimeValue <= 0.5f && KevinGameManager.instance.totalTime >= 1)
            {
                KevinGameManager.instance.bestTimeData3.BestTimeValue = KevinGameManager.instance.totalTime;
                KevinGameManager.instance.totalTime = 0;
                
            }
            if (KevinGameManager.instance.bestTimeData4.BestTimeValue <= 0.5f && KevinGameManager.instance.totalTime >= 1)
            {
                KevinGameManager.instance.bestTimeData4.BestTimeValue = KevinGameManager.instance.totalTime;
                KevinGameManager.instance.totalTime = 0;
                
            }

        }
        KevinGameManager.instance.laps += 1;
        KevinGameManager.instance.checkpoint = false;
        KevinGameManager.instance.cantCheat = true;
        KevinGameManager.instance.previousLapTime = KevinGameManager.instance.laptime;
        KevinGameManager.instance.laptime = 0;

        yield return new WaitForSeconds(1f);
        KevinGameManager.instance.SwitchScene(4);

        isActive = false;
    }

}
