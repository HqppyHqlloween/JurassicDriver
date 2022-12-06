    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Besttime : MonoBehaviour
{
    
    [SerializeField] private Text BestTimeText;

    private void Update()
    {
        BestTimeText.text = "Best Time: " + KevinGameManager.instance.bestTimeData1.BestTimeValue.ToString("n2");
    }
}
