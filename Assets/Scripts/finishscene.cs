using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finishscene : MonoBehaviour
{
    [SerializeField] private Text totalTimeText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalTimeText.text = "Totaltime: " + KevinGameManager.instance.totalTimeData.BestTimeValue.ToString("n2");
    }
}
