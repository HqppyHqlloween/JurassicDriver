using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class KevinGameManager : MonoBehaviour
{
    [SerializeField] private AudioSource countdownAudio;
    public static KevinGameManager instance;
    [SerializeField] public float countdown = 3f;
    public bool checkpoint;
    [SerializeField] public float laptime;
    public float laps;
    public float totalTime;
    public float previousLapTime;
    public BestTimeData bestTimeData1;
    public BestTimeData bestTimeData2;
    public BestTimeData bestTimeData3;
    public BestTimeData bestTimeData4;
    public BestTimeData totalTimeData;
    public BestTimeData car;
    public BestTimeData coins;
    public BestTimeData mute;
    public int lapsNeeded;
    public bool startTime;
    public bool cantCheat;
    public bool muted;
    public bool godmodeOn;



    private void Awake()
    {
        instance = this;
        lapsNeeded = lapsNeeded + 1;
    }

    private void Start()
    {
        

        


        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;



        if (sceneName == "Main")
        {
            AudioManager.instance.Play("Countdown");
            AudioManager.instance.Play("theme");

        }
        else return;

        if (sceneName == "BonusMap")
        {
            countdown = 0;
        } else return;



    }

    void Update()
    {

         Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (countdown >= 0)
        {
            countdown -= Time.deltaTime;
        }
        if (countdown <= 0 && startTime)
        {
            KevinUiManager.instance.spinImage.gameObject.SetActive(false);
            laptime += Time.deltaTime;
            totalTime += Time.deltaTime;
        }

        if (countdown <= 0)
        {
            if(sceneName == "Main")
            {
            KevinUiManager.instance.spinImage.gameObject.SetActive(false);
            } else return;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            AudioManager.instance.Play("Honk");
        }

    }


    public void CreateText()
    {
        //path van de file
        string path = Application.dataPath + "/Highscore.txt";
        //maak een file als er geen is

        if (!File.Exists(path))
        {

            File.WriteAllText(path, "Your Current HighScore \n" + coins.BestTimeValue);
        }
        else
        {
            File.WriteAllText(path, "Your Current HighScore \n" + coins.BestTimeValue);
        }

    }

    public void SwitchScene(int sceneNumber)
    {
        if (laps == lapsNeeded +1)
        {
            SceneManager.LoadScene(sceneNumber);
            
        }
    }

    public void SwitchSceneNoLaps(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

}
