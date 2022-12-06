using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManger : MonoBehaviour
{

    [SerializeField] CoinSystem coins;

    public int currentCarIndex;

    public GameObject[] carModels;

    public CarBlueprint[] cars;

    public Button buyBotton;
    [SerializeField] private Button playbutton;
    [SerializeField] private Button RightClick;
    [SerializeField] private Button LeftClick;



    void Start()
    {
        foreach(CarBlueprint car  in cars)
        {
            if (car.price == 0)
                car.isUnlocked = true;
            else
            car.isUnlocked = false;
         }

        currentCarIndex = 0;    

        foreach (GameObject car in carModels)
            car.SetActive(false);

        carModels[currentCarIndex].SetActive(true);
         
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void ChangeNext()
    {
        carModels[currentCarIndex].SetActive(false);

        currentCarIndex++;
        if (currentCarIndex == carModels.Length)
            currentCarIndex = 0;

        carModels[currentCarIndex].SetActive(true);
        CarBlueprint c = cars[currentCarIndex];
        PlayerPrefs.SetInt("SelectedCar", currentCarIndex);
        if (!c.isUnlocked) return;
    }



    public void ChangePrevios()
    {
        carModels[currentCarIndex].SetActive(false);

        currentCarIndex--;

        if (currentCarIndex == -1)
            currentCarIndex = carModels.Length - 1;

        carModels[currentCarIndex].SetActive(true);
        CarBlueprint c = cars[currentCarIndex];
        PlayerPrefs.SetInt("SelectedCar", currentCarIndex);
        if (!c.isUnlocked) return;
    }


    public void UnlockCar()
    {
        CarBlueprint c = cars[currentCarIndex];

        PlayerPrefs.SetInt(c.name, 1);
        c.isUnlocked = true;
        KevinGameManager.instance.coins.coinsValue -= c.price;
    }


    private void UpdateUI()
    {
        CarBlueprint c = cars[currentCarIndex];
        if (c.isUnlocked)
        {
            playbutton.gameObject.SetActive(true);
            buyBotton.gameObject.SetActive(false);
        }
        else
        {
            playbutton.gameObject.SetActive(false);
            buyBotton.gameObject.SetActive(true);

            buyBotton.GetComponentInChildren<TextMeshProUGUI>().text = "€" + c.price;
            if (c.price <= KevinGameManager.instance.coins.coinsValue)

            {
                buyBotton.interactable = true;

            }
            else
            {
                buyBotton.interactable = false;
            }
        }

        if(currentCarIndex >= 4)
        {
            RightClick.gameObject.SetActive(false);
        } else RightClick.gameObject.SetActive(true);

        if(currentCarIndex <= 0)
        {
            LeftClick.gameObject.SetActive(false);
        } else LeftClick.gameObject.SetActive(true);
    }


}
