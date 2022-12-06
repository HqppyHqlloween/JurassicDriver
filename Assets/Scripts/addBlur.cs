using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addBlur : MonoBehaviour
{
    KevinUiManager uiManager;
    [SerializeField] private GameObject Blur;

    void Start()
    {
        uiManager = GameObject.Find("UiManager").GetComponent<KevinUiManager>();
    }
    void Update()
    {
        if(uiManager.isPaused)
        {
            Blur.SetActive(true);
        }
        else Blur.SetActive(false);
    }
}
