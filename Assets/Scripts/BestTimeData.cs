using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BestTimeData", menuName = "ScriptableObjects/BestTime", order = 1)]


public class BestTimeData : ScriptableObject
{
    public float BestTimeValue;
    public int coinsValue;
    public bool hasGodmode;
}
