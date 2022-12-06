using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnButtonClick : MonoBehaviour
{
   
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onStartClick()
    {
        SceneManager.LoadScene(1);
    }

    public void onCreditClick()
    {
        SceneManager.LoadScene(2);
    }
    public void onRecordClick()
    {
        SceneManager.LoadScene(5);
    }
    public void onStoreClick()
    {
        SceneManager.LoadScene(6);
    }
    public void onStartMenuStartClick()
    {
        SceneManager.LoadScene(6);
    }
    public void onOptionsClick()
    {
        SceneManager.LoadScene(3);
    }
    public void onMenuClick()
    {
        SceneManager.LoadScene(0);
    }
}
