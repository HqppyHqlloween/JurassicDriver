using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimesManager : MonoBehaviour
{
    [SerializeField] private Text Time1;
    [SerializeField] private Text Time2;
    [SerializeField] private Text Time3;

    private void Update()
    {
        Time1.text = "first Time: " + KevinGameManager.instance.bestTimeData2.BestTimeValue.ToString("n2");
        Time2.text = "second Time: " + KevinGameManager.instance.bestTimeData3.BestTimeValue.ToString("n2");
        Time3.text = "third Time: " + KevinGameManager.instance.bestTimeData4.BestTimeValue.ToString("n2");
    }

}
