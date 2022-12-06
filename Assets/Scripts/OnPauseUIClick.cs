using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnPauseUIClick : MonoBehaviour
{
     [SerializeField] KevinUiManager uiManager;
    [SerializeField] Animator animation;
    void Start()
    {
         uiManager = GameObject.Find("UiManager").GetComponent<KevinUiManager>();
        animation = GameObject.Find("Pause UI").GetComponent<Animator>();
    }

    
    public void onResumeClick()
    {
        bool pressedEscape = animation.GetBool("pressedEscape");
        animation.SetBool("pressedEscape", pressedEscape = false);
        uiManager.isPaused =  !uiManager.isPaused;
    }

    public void onMainMenuClick()
    {
        SceneManager.LoadScene(0);
    }

    public void onOptionsClick()
    {
    SceneManager.LoadScene(3);

    }
}
