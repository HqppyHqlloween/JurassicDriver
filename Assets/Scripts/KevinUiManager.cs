using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KevinUiManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;
    public bool isPaused = false;
    [SerializeField ]Animator animation;
    [SerializeField] private GameObject UIpanel;
    public static KevinUiManager instance;
    [SerializeField] private Text countdownText;
    [SerializeField] private Text lapsText;
    [SerializeField] private Text lapsTimeText;
    [SerializeField] private Text totalTimeText;
    [SerializeField] private Text previousTimeText;
    [SerializeField] public Image spinImage;

    void Start()
    {       
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

    }

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        foreach (GameObject target in objects)
        {
            if(target.activeSelf == true)
            {
                target.GetComponent<Movement>();
            }
            
        if(isPaused == true)
        {
            Time.timeScale = 0;
        }
        else Time.timeScale = 1;

        if (KevinGameManager.instance.countdown >= 0)
        {
            countdownText.text = "" + KevinGameManager.instance.countdown.ToString("n0");
        }
        if (KevinGameManager.instance.countdown <= 0)
        {
            countdownText.enabled = false;
        }

        lapsText.text = "Laps: " + KevinGameManager.instance.laps.ToString("n0") + "/" + KevinGameManager.instance.lapsNeeded.ToString("n0");
        lapsTimeText.text = "Laptime: " + KevinGameManager.instance.laptime.ToString("n2");
        totalTimeText.text = "Totaltime: " + KevinGameManager.instance.totalTime.ToString("n2");
        previousTimeText.text = "previous lap: " + KevinGameManager.instance.previousLapTime.ToString("n2");

        GetPanel();

    }

    void GetPanel()
    {
        if(UIpanel != null)
        {
            bool pressedEscape = animation.GetBool("pressedEscape");

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                animation.SetBool("pressedEscape", !pressedEscape);
                isPaused = !isPaused;
            }
         }
     }
    }
}