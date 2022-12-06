using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_Godmode : MonoBehaviour
{
    [SerializeField] private GameObject buttonOn;
    [SerializeField] private GameObject buttonOff;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onGodmodeOn()
    {
        KevinGameManager.instance.car.hasGodmode = true;
        buttonOn.SetActive(true);
        buttonOff.SetActive(false);
    }

    public void onGodmodeOff()
    {
        KevinGameManager.instance.car.hasGodmode = false;
        buttonOn.SetActive(false);
        buttonOff.SetActive(true);
    }
}
