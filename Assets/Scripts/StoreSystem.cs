using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class StoreSystem : MonoBehaviour
{
    [SerializeField] MoveCars moveCars;
    [SerializeField] CoinSystem coins;
    [SerializeField] private int CoinAmout;
    [SerializeField] bool canBuy = false;

    void Start()
    {
        moveCars = GameObject.Find("Car Moving").GetComponent<MoveCars>();
    }

    // Update is called once per frame
    void Update()
    {
        readingTheAmount();
    }

    void readingTheAmount()
    {

        if(coins.FruitAmount >= CoinAmout)
        {
            canBuy = true;
        } else return; //cant buy
    }

    void settingAmount()
    {
        string settingAmount = Application.persistentDataPath + "/coins.txt";

        StreamWriter sw = new StreamWriter(settingAmount);
        coins.FruitAmount -= CoinAmout;
        sw.WriteLine(coins.FruitAmount);
        sw.Close();


    }

    void setShopAmount()
    {

    }

    public void onButtonClick()
    {
        if(canBuy == true)
        {
            settingAmount();
        }
    }
}
